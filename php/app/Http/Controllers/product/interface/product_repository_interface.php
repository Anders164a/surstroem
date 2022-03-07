<?php

namespace App\Http\Controllers\product\interface;


use App\Http\Controllers\product\class\product;
use Illuminate\Database\Eloquent\Collection;

interface product_repository_interface
{
    public function get_products(): Collection;

    public function store_product(string $product_title, string $short_description, string $description, float $price, float $weight, float $width, float $length, float $height, int $warranty_period_id, int $color_id, int $brand_id): product;

    public function get_product(int $product_id): object;

    public function get_products_from_column(int $param, string $column = 'id'): Collection;

    public function delete_product(int $product_id): void;
}
