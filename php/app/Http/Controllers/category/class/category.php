<?php
namespace App\Http\Controllers\category\class;

use App\Http\Controllers\category\repository\category_repository;
use Illuminate\Database\Eloquent\Collection;

class category
{
    private int $id;
    private string $name;
    private ?int $parent_category_id;

    public function __construct(int $id, string $name, ?int $parent_category_id) {
        $this->id = $id;
        $this->name = $name;
        $this->parent_category_id = $parent_category_id;
    }

    public function get_name(): string {
        return $this->name;
    }

    public function get_parent_category_id(): ?int {
        return $this->parent_category_id;
    }
}
