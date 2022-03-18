<?php
namespace App\Http\Controllers\category\repository;

use App\Http\Controllers\category\class\category;
use App\Http\Controllers\category\factory\category_factory;
use App\Http\Controllers\category\interface\category_repository_interface;
use App\Http\Controllers\category\repository\exception\category_not_found_exception;
use App\Http\Controllers\helper;
use Illuminate\Database\Eloquent\Collection;

class category_repository implements category_repository_interface
{
    public function get_categories(): Collection {
        $categories = \App\Models\category::query()
            ->with(['parent_category'])
            ->get()
            ->makeHidden('parent_category_id');

        return helper::remove_collections_null_values($categories);
    }

    public function store_category(string $category, ?int $parent_category_id): category {
        $new_category = new \App\Models\category();
        $new_category->category = $category;
        $new_category->parent_category_id = $parent_category_id;
        $new_category->save();

        return category_factory::make($new_category);
    }

    public function update_category(array $_PUT): object {
        $category = $this->get_category($_PUT['id']);

        $parent_id = empty($_PUT['parent_category_id']) ? NULL : $_PUT['parent_category_id'];

        $category['category'] = $_PUT['category'];
        $category->parent_category_id = $parent_id;
        $category->update();

        return $this->get_category($category->id);
    }

    public function get_category(int $category_id): object {
        $category = \App\Models\category::query()
            ->with(['parent_category'])
            ->where('id', '=', $category_id)
            ->first();

        if ($category === null) {
            throw category_not_found_exception::category_id_not_found($category_id);
        }

        $category->makeHidden('parent_category_id');

        helper::remove_null_values_in_object($category);

        return $category;
    }

    public function get_categories_by_parent_id(int $parent_id): Collection {
        $categories = \App\Models\category::query()->where('parent_category_id', '=', $parent_id)->get();

        if (count($categories) < 1) {
            throw category_not_found_exception::categories_with_parent_id_not_found($parent_id);
        }

        return $categories;
    }

    public function delete_category(int $category_id): void
    {
        $category = \App\Models\category::query()->where('id', '=', $category_id)->first();

        if ($category == null) {
            throw category_not_found_exception::category_id_not_found($category);
        }

        $category->delete();
    }
}
