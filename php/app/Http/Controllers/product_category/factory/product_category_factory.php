<?php
namespace App\Http\Controllers\product_category\factory;

use App\Http\Controllers\product_category\class\product_category;

class product_category_factory
{
    public static function make(object $product_category_data): product_category {
        return new product_category(
            $product_category_data->id,
            $product_category_data->product_id,
            $product_category_data->category_id
        );
    }
}
