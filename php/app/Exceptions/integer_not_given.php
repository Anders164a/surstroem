<?php

namespace App\Exceptions;

use Exception;

class integer_not_given extends Exception
{
    public static function integer_not_null(): self
    {
        return new self("The input has to be an integer");
    }
}
