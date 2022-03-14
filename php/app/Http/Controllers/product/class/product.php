<?php
namespace App\Http\Controllers\product\class;

class product
{
    private int $id;
    private string $product_title;
    private ?string $short_description;
    private ?string $description;
    private float $price;
    private int $product_specification_id;
    private ?int $warranty_period_id;
    private ?int $color_id;
    private int $brand_id;

    public function __construct(int $id, string $product_title, ?string $short_description, ?string $description, float $price, int $product_specification_id, ?int $warranty_period_id, ?int $color_id, int $brand_id) {
        $this->id = $id;
        $this->product_title = $product_title;
        $this->short_description = $short_description;
        $this->description = $description;
        $this->price = $price;
        $this->product_specification_id = $product_specification_id;
        $this->warranty_period_id = $warranty_period_id;
        $this->color_id = $color_id;
        $this->brand_id = $brand_id;
    }

    public function get_id(): int {
        return $this->id;
    }

    public function get_title(): string {
        return $this->product_title;
    }

    public function get_short_description(): ?string {
        return $this->short_description;
    }

    public function get_description(): ?string {
        return $this->description;
    }

    public function get_price(): float {
        return $this->price;
    }

    public function get_product_specification_id(): ?float {
        return $this->product_specification_id;
    }

    public function get_warranty_period_id(): ?int {
        return $this->warranty_period_id;
    }

    public function get_color_id(): ?int {
        return $this->color_id;
    }

    public function get_brand_id(): int {
        return $this->brand_id;
    }
}
