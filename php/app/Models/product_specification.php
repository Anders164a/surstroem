<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model as Eloquent;

class product_specification extends Eloquent
{
    protected $fillable = [
        'short_description', 'description','weight', 'width', 'length', 'height'
    ];
}
