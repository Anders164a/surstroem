<?php
namespace App\Http\Controllers\product\factory;

use App\Http\Controllers\product\class\product;

class product_factory
{
    public static function make(object $product_data): product {
        return new product(
            $product_data->id,
            $product_data->product_title,
            $product_data->short_description,
            $product_data->description,
            $product_data->price,
            $product_data->product_specification_id,
            $product_data->warranty_period_id,
            $product_data->color_id,
            $product_data->brand_id
        );
    }
}
