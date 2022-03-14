<?php
namespace App\Http\Controllers\product_category\class;

class product_category
{
    private int $id;
    private int $product_id;
    private int $category_id;

    public function __construct(int $id, int $product_id, int $category_id) {
        $this->id = $id;
        $this->product_id = $product_id;
        $this->category_id = $category_id;
    }

    public function get_id(): int {
        return $this->id;
    }

    public function get_product_id(): int {
        return $this->product_id;
    }

    public function get_category_id(): int {
        return $this->category_id;
    }
}
