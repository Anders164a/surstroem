<?php

namespace model;

use Illuminate\Database\Eloquent\Model as Eloquent;
class category extends Eloquent
{
    protected $fillable = [
        'category', 'parent_category_id'
    ];
}