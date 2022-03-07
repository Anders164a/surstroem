<?php
namespace App\Http\Controllers\product\repository;

use App\Http\Controllers\product\factory\product_factory;
use App\Http\Controllers\product\class\product;
use App\Http\Controllers\product\interface\product_repository_interface;
use App\Http\Controllers\product\repository\exception\product_not_found_exception;
use Illuminate\Database\Eloquent\Collection;

class product_repository implements product_repository_interface
{
    public function get_products(): Collection {
        return \App\Models\product::query()->leftJoin('colors', 'colors.id', '=', 'products.color_id')
            ->join('brands', 'brands.id', '=', 'products.brand_id')
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
            ->get();
    }

    public function store_product(string $product_title, ?string $short_description, ?string $description, float $price, ?float $weight, ?float $width, ?float $length, ?float $height, ?int $warranty_period_id, ?int $color_id, int $brand_id): product {
        $new_product = new \App\Models\product();
        $new_product->product_title = $product_title;
        $new_product->short_description = $short_description;
        $new_product->description = $description;
        $new_product->price = $price;
        $new_product->weight = $weight;
        $new_product->width = $width;
        $new_product->length = $length;
        $new_product->height = $height;
        $new_product->warranty_period_id = $warranty_period_id;
        $new_product->color_id = $color_id;
        $new_product->brand_id = $brand_id;

        $new_product->save();

        return product_factory::make($new_product);
    }

    public function get_product(int $product_id): object {
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
            ->where('id', '=', $product_id)
            ->first();

        if ($product === null) {
            throw product_not_found_exception::product_not_found();
        }

        return $product;
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
