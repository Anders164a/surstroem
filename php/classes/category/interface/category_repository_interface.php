<?php

namespace classes\category\interface;


use classes\category\class\category;
use Illuminate\Database\Eloquent\Collection;

interface category_repository_interface
{
    public function get_categories(): Collection;

    public function store_category(string $category, ?int $parent_category_id): category;
}