<?php

namespace App\Http\Controllers\product\repository\exception;

class product_not_found_exception extends \Exception
{
    public static function product_id_not_found(int $product_id): self
    {
        return new self("Could not find product - Product id: " . $product_id);
    }

    public static function product_not_found(): self {
        return new self("Could not find product");
    }
}
