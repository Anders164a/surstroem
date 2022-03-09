<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model as Eloquent;

class product extends Eloquent
{
    protected $fillable = [
        'product_tile', 'short_description', 'description', 'price', 'weight', 'width', 'length', 'height', 'warranty_period_id', 'color_id', 'brand_id'
    ];

    public function brand() {
        return $this->hasOne(brand::class, 'id', 'brand_id');
    }

    public function color() {
        return $this->hasOne(color::class, 'id', 'color_id');
    }

    public function warranty_period() {
        return $this->hasOne(warranty_period::class, 'id', 'warranty_period_id');
    }

    public function product_specification() {
        return $this->hasOne(product_specification::class, 'id', 'product_specification_id');
    }
}
