<?php

namespace App\Exceptions;

class integer_not_allowed_null extends \Exception
{
    public static function integer_not_null(): self
    {
        return new self("The integer is not allowed to be null");
    }
}
