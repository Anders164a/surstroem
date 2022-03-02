<?php

namespace classes\category\repository\exception;

class category_not_found_exception extends \Exception
{
    public static function category_id_not_found(int $category_id): self
    {
        return new self("Could not find category id - Category id: " . $category_id);
    }
}