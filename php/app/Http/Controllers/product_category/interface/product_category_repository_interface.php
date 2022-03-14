<?php

namespace App\Http\Controllers\product_category\interface;

use App\Http\Controllers\product_category\class\product_category;
use Illuminate\Database\Eloquent\Collection;

interface product_category_repository_interface
{
    public function get_all(): Collection;

    public function get_products_from_category_id(int $category_id): Collection;

    public function get_categories_from_product_id(int $product_id): Collection;

    public function get_products_from_a_parent_category(int $category_id): ?Collection;

    public function store_product_category(int $product_id, int $category_id): product_category;

    public function update_product_category(array $_PUT): object;

    public function get_product_category(int $product_id): object;

    public function delete_product_category(int $product_category_id): void;
}
