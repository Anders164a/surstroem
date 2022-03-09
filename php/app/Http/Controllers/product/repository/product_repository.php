<?php
namespace App\Http\Controllers\product\repository;

use App\Http\Controllers\helper;
use App\Http\Controllers\product\factory\product_factory;
use App\Http\Controllers\product\class\product;
use App\Http\Controllers\product\interface\product_repository_interface;
use App\Http\Controllers\product\repository\exception\product_not_found_exception;
use App\Models\product_specification;
use Illuminate\Database\Eloquent\Collection;

class product_repository implements product_repository_interface
{
    public function get_products(): Collection {
        $products = \App\Models\product::query()
            ->with([
                'brand',
                'color',
                'warranty_period',
                'product_specification'
            ])
            ->get()
            ->makeHidden(["color_id", "brand_id", "warranty_period_id", "product_specification_id"]);

        foreach ($products as $product) {
            helper::remove_null_values($product);
        }

        return $products;
    }

    public function store_product(string $product_title, ?string $short_description, ?string $description, float $price, ?float $weight, ?float $width, ?float $length, ?float $height, ?int $warranty_period_id, ?int $color_id, int $brand_id): product {
        $new_specification = new product_specification();
        $new_specification->short_description = $short_description;
        $new_specification->description = $description;
        $new_specification->weight = $weight;
        $new_specification->width = $width;
        $new_specification->length = $length;
        $new_specification->height = $height;
        $new_specification->save();

        $new_product = new \App\Models\product();
        $new_product->product_title = $product_title;
        $new_product->price = $price;
        $new_product->product_specification_id = $new_specification->id;
        $new_product->warranty_period_id = $warranty_period_id;
        $new_product->color_id = $color_id;
        $new_product->brand_id = $brand_id;
        $new_product->save();

        return product_factory::make($new_product);
    }

    public function update_product(array $_PUT): object
    {
        $product = $this->get_product($_PUT['id']);
        $product_specification = $this->get_product_specification($_PUT['product_specification_id']);

        $product_specification->short_description = $_PUT['short_description'] ?? null;
        $product_specification->description = $_PUT['description'] ?? null;
        $product_specification->weight = $_PUT['weight'] ?? null;
        $product_specification->width = $_PUT['width'] ?? null;
        $product_specification->length = $_PUT['length'] ?? null;
        $product_specification->height = $_PUT['height'] ?? null;
        $product_specification->update();

        $price = floatval($_PUT['price']);

        $product->product_title = $_PUT['title'];
        $product->price = $price;
        $product->warranty_period_id = $_PUT['warranty_period_id'] ?? null;
        $product->color_id = $_PUT['color_id'] ?? null;
        $product->brand_id = $_PUT['brand_id'];
        $product->update();

        return $this->get_product($product->id);
    }

    public function get_product(int $product_id): object {
            $product = \App\Models\product::query()
                ->with([
                    'brand',
                    'color',
                    'warranty_period',
                    'product_specification'
                ])
                ->where('id', '=', $product_id)
                ->first();

            if ($product === null) {
                throw product_not_found_exception::product_id_not_found($product_id);
            }

            $product->makeHidden(["color_id", "brand_id", "warranty_period_id", "product_specification_id"]);

            helper::remove_null_values($product);

            return $product;
    }

    public function get_product_specification(int $product_specification_id) {
        return product_specification::query()
            ->where('id', '=', $product_specification_id)
            ->first();
    }

    public function get_products_from_column(int $param, string $column = 'id'): Collection {
        $product = \App\Models\product::query()
            ->with([
                'brand' => function($query) {
                    $query->select('id','name');
                },
                'color' => function($query) {
                    $query->select('id','name');
                },
                'warranty_period' => function($query) {
                    $query->select('id', 'warranty_type', 'warranty_period');
                }])
            ->where($column, '=', $param)
            ->get();

        if ($product === null && $column === 'id') {
            throw product_not_found_exception::product_id_not_found($param);
        }

        if ($product === null) {
            throw product_not_found_exception::product_not_found();
        }

        return $product;
    }

    public function delete_product(int $product_id): void {
        $product = \App\Models\product::query()->where('id', '=', $product_id)->first();

        if ($product == null) {
            throw product_not_found_exception::product_id_not_found($product_id);
        }

        $product->delete();
    }
}
