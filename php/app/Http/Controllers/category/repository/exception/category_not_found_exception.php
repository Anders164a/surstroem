<?php

namespace App\Http\Controllers\category\repository\exception;

use Exception;

class category_not_found_exception extends Exception
{
    public static function category_id_not_found(int $category_id): self
    {
        return new self("Could not find category id - Category id: " . $category_id);
    }

    public static function categories_with_parent_id_not_found(int $parent_id): self {
        return new self("Could not find any categories with this parent id - Parent id: " . $parent_id);
    }
}
