<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model as Eloquent;
class warranty_period extends Eloquent
{
    protected $fillable = [
        'warranty_type', 'warranty_period'
    ];
}
