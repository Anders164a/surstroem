<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model as Eloquent;
class product_category extends Eloquent
{
    protected $fillable = [
        'product_id', 'category_id'
    ];

    public function product() {
        return $this->hasOne(product::class, 'id', 'product_id');
    }

    public function category() {
        return $this->hasOne(category::class, 'id', 'category_id');
    }
}
