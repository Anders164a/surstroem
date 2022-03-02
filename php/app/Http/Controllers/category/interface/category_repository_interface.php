<?php

namespace App\Http\Controllers\category\interface;


use App\Http\Controllers\category\class\category;
use Illuminate\Database\Eloquent\Collection;

interface category_repository_interface
{
    public function get_categories(): Collection;

    public function store_category(string $category, ?int $parent_category_id): category;
}
