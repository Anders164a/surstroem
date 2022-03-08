<?php

namespace App\Http\Controllers\category\interface;

use App\Http\Controllers\category\class\category;
use Illuminate\Database\Eloquent\Collection;

interface category_repository_interface
{
    public function get_categories(): Collection;

    public function store_category(string $category, ?int $parent_category_id): category;

    public function update_category(array $_PUT): object;

    public function get_category(int $category_id): object;

    public function get_categories_by_parent_id(int $parent_id): Collection;

    public function delete_category(int $category_id): void;
}
