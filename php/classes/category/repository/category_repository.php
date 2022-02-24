<?php
namespace classes\category\repository;

use classes\category\factory\category_factory;
use classes\category\interface\category_repository_interface;
use Illuminate\Database\Eloquent\Collection;
use model\category;

class category_repository implements category_repository_interface
{
    public function get_categories(): Collection {
        return category::query()->leftJoin('categories as parent_category', 'parent_category.id', '=', 'categories.parent_category_id')->select('categories.category', 'parent_category.category as parent_category')->get();
    }

    public function store_category(string $category, ?int $parent_category_id): \classes\category\class\category {
        $new_category = new category();
        $new_category->category = $category;
        $new_category->parent_category_id = $parent_category_id;
        $new_category->save();

        return category_factory::make($new_category);
    }

    public function get_category(int $category_id): object {
        return category::query()->where('id', '=', $category_id)->first();
    }
}