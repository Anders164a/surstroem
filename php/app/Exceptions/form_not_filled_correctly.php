<?php

namespace App\Exceptions;

class form_not_filled_correctly extends \Exception
{
    public static function form_does_not_fulfill_requirements(): self
    {
        return new self("The form was not filled correctly, please fulfill the requirements");
    }
}
