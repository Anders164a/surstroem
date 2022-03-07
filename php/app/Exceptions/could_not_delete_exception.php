<?php

namespace App\Exceptions;

use Exception;

class could_not_delete_exception extends Exception
{
    public static function could_not_delete(): self
    {
        return new self("There was a problem trying to delete, try again later or contact your supervisor");
    }
}
