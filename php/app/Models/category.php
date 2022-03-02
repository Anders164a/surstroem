<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model as Eloquent;
class category extends Eloquent
{
    protected $fillable = [
        'category', 'parent_category_id'
    ];
}
