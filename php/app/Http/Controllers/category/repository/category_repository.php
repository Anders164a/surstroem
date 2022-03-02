<?php
namespace App\Http\Controllers\category\repository;

use App\Http\Controllers\category\class\category;
use App\Http\Controllers\category\factory\category_factory;
use App\Http\Controllers\category\interface\category_repository_interface;
use classes\category\repository\exception\category_not_found_exception;
use Illuminate\Database\Eloquent\Collection;

class category_repository implements category_repository_interface
{
    public function get_categories(): Collection {
        return \App\Models\category::query()->leftJoin('categories as parent_category', 'parent_category.id', '=', 'categories.parent_category_id')
            ->select('categories.category', 'parent_category.category as parent_category')
            ->orderBy('categories.category')
            ->get();
    }

    public function store_category(string $category, ?int $parent_category_id): category {
        $new_category = new \App\Models\category();
        $new_category->category = $category;
        $new_category->parent_category_id = $parent_category_id;
        $new_category->save();

        return category_factory::make($new_category);
    }

    public function get_category(int $category_id): object {
        $category = \App\Models\category::query()->where('id', '=', $category_id)->first();

        if ($category === null) {
            throw category_not_found_exception::category_id_not_found($category_id);
        }

        return $category;
    }
}
