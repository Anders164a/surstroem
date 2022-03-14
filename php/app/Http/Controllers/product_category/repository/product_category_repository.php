<?php
namespace App\Http\Controllers\product_category\repository;

use App\Http\Controllers\category\repository\exception\category_not_found_exception;
use App\Http\Controllers\helper;
use App\Http\Controllers\product_category\factory\product_category_factory;
use App\Http\Controllers\product_category\class\product_category;
use App\Http\Controllers\product_category\interface\product_category_repository_interface;
use App\Http\Controllers\product_category\repository\exception\product_category_not_found_exception;
use App\Models\category;
use App\Models\product;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Support\Facades\Http;

class product_category_repository implements product_category_repository_interface
{
    public function get_all(): Collection
    {
        $product_categories = \App\Models\product_category::query()
            ->with([
                'product' => function ($product) {
                    $product->with([
                        'brand',
                        'color',
                        'warranty_period',
                        'product_specification'
                    ]);
                },
                'category' => function ($category) {
                    $category->with(['parent_category']);
                }
            ])
            ->get()->makeHidden(['category_id', 'product_id']);

        foreach ($product_categories as $product_category) {
            $this->remove_double_values_from_product($product_category);
            $this->remove_double_values_from_category($product_category);

            helper::remove_null_values_in_object($product_category);
        }

        return $product_categories;
    }

    public function get_products_from_category_id(int $category_id): Collection {
        $product_categories = \App\Models\product_category::query()
            ->where('category_id', '=', $category_id)
            ->get();

        $products_in_product_categories = [];
        foreach ($product_categories as $product_category) {
            array_push($products_in_product_categories, $product_category->product_id);
        }

        return $this->get_products_from_product_categories($products_in_product_categories);
    }

    private function get_products_from_product_categories(array $product_category_ids) {
        return helper::remove_collections_null_values(product::query()
            ->whereIn('id', $product_category_ids)
            ->with([
                'brand',
                'color',
                'warranty_period',
                'product_specification'
            ])
            ->get()
            ->makeHidden(["color_id", "brand_id", "warranty_period_id", "product_specification_id"]));
    }

    public function get_categories_from_product_id(int $product_id): Collection {
        $product_categories = \App\Models\product_category::query()
            ->where('product_id', '=', $product_id)
            ->get();

        $categories_in_product_categories = [];
        foreach ($product_categories as $product_category) {
            array_push($categories_in_product_categories, $product_category->category_id);
        }

        return helper::remove_collections_null_values(category::query()
            ->with(['parent_category'])
            ->orderBy('categories.category')
            ->whereIn('id', $categories_in_product_categories)
            ->get()
            ->makeHidden('parent_category_id'));
    }

    public function get_products_from_a_parent_category(int $category_id): ?Collection {
        $categories = category::query()
            ->where('id', '=', $category_id)
            ->orWhere('parent_category_id', '=', $category_id)
            ->get();

        if (count($categories) >= 1) {
            $categories = $this->get_categories($categories->toArray(), $category_id);
        } else {
            throw category_not_found_exception::category_id_not_found($category_id);
        }

        $categories = helper::remove_array_null_values($categories);

        $category_ids = [];
        foreach ($categories as $category) {
            $category_ids[] = $category["id"];
        }

        $product_ids = [];
        foreach ($this->get_product_categories_from_categories($category_ids) as $product_category) {
            $product_ids[] = $product_category->product_id;
        }

        return $this->get_products_from_product_categories($product_ids);
    }

    public function store_product_category(int $product_id, int $category_id): product_category {
        $new_product_category = new \App\Models\product_category();
        $new_product_category->product_id = $product_id;
        $new_product_category->category_id = $category_id;
        $new_product_category->save();

        return product_category_factory::make($new_product_category);
    }

    public function update_product_category(array $_PUT): object
    {
        $product_category = $this->get_product_category($_PUT['id']);

        $product_category->product_id = $_PUT['product_id'];
        $product_category->category_id = $_PUT['category_id'];
        $product_category->update();

        return $this->get_product_category($product_category->id);
    }

    public function get_product_category(int $product_category_id): object {
        $product_category = \App\Models\product_category::query()
            ->with([
                'product' => function ($product) {
                    $product->with([
                        'brand',
                        'color',
                        'warranty_period',
                        'product_specification'
                    ]);
                },
                'category' => function ($category) {
                    $category->with([
                        'parent_category'
                    ]);
                }
            ])
            ->where('id', '=', $product_category_id)
            ->first();

        if ($product_category === null) {
            throw product_category_not_found_exception::product_category_id_not_found($product_category_id);
        }

        $product_category->makeHidden(["product_id", "category_id"]);
        $this->remove_double_values_from_product($product_category);
        $this->remove_double_values_from_category($product_category);

        helper::remove_null_values_in_object($product_category);

        return $product_category;
    }

    public function delete_product_category(int $id): void {
        $product_category = \App\Models\product_category::query()->where('id', '=', $id)->first();

        if ($product_category == null) {
            throw product_category_not_found_exception::product_category_id_not_found($id);
        }

        $product_category->delete();
    }

    private function remove_double_values_from_product(object $object): void {
        $object->product->makeHidden(["color_id", "brand_id", "warranty_period_id", "product_specification_id"]);
    }

    private function remove_double_values_from_category(object $object): void {
        $object->category->makeHidden(["parent_category_id"]);
    }

    private function get_product_categories_from_categories(array $category_ids) {
        return \App\Models\product_category::query()
            ->whereIn('category_id', $category_ids)
            ->get();
    }

    private function get_categories(array $categories, int $parent_id, array $child_category_from_categories = []) {
        if (empty($child_category_from_categories)) {
            foreach ($categories as $category) {
                if ($category["parent_category_id"] == $parent_id) {
                    $child_categories = $this->get_child_categories($category["id"]);
                    if ($child_categories != null) {
                        foreach ($child_categories as $child_category) {
                            $categories[] = $child_category;
                            $categories = $this->get_categories($categories, $category["id"], $child_category);
                        }
                    }
                }
            }
        } else {
            if ($child_category_from_categories["parent_category_id"] == $parent_id) {
                $child_categories = $this->get_child_categories($child_category_from_categories["id"]);
                if ($child_categories != null) {
                    foreach ($child_categories as $child_category) {
                        $categories[] = $child_category;
                        $categories = $this->get_categories($categories, $child_category["id"], $child_category);
                    }
                }
            }
        }

        return $categories;
    }

    private function get_child_categories(int $parent_id) {
        return json_decode(Http::get("http://127.0.0.1/api/category/", [
            "parent_id" => $parent_id
        ])->body(), JSON_OBJECT_AS_ARRAY);
    }
}
