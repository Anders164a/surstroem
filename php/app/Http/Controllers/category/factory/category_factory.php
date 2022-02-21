<?php
namespace App\Http\Controllers\category\factory;

use App\Http\Controllers\category\class\category;

class category_factory
{
    public static function make(object $category_data): category {
        return new category($category_data->id, $category_data->category, $category_data->parent_category_id);
    }
}
