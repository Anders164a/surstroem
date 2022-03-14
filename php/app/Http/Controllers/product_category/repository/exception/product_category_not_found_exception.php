<?php

namespace App\Http\Controllers\product_category\repository\exception;

use Exception;

class product_category_not_found_exception extends Exception
{
    public static function product_category_id_not_found(int $id): self
    {
        return new self("Could not find product category - Product category id: " . $id);
    }

    public static function product_category_not_found(): self {
        return new self("Could not find product category");
    }
}
