<?php
namespace classes\category\factory;

use classes\category\class\category;

class category_factory
{
    public static function make(object $category_data): category {
        return new category($category_data->id, $category_data->category, $category_data->parent_category_id);
    }
}