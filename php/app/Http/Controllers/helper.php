<?php

namespace App\Http\Controllers;


class helper
{
    public static function remove_null_values(object $object): object {
        $array = $object->toArray();

        foreach ($array as $key => $value) {
            if ($value == null) {
                unset($object[$key]);
            } else if (is_array($value)) {
                self::remove_null_values($object[$key]);
            }
        }

        return $object;
    }
}
