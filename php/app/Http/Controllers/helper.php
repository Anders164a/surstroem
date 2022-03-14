<?php

namespace App\Http\Controllers;


use Illuminate\Database\Eloquent\Collection;

class helper
{
    public static function remove_collections_null_values(Collection $collection): Collection {
        foreach ($collection as $object) {
            self::remove_null_values_in_object($object);
        }

        return $collection;
    }

    public static function remove_null_values_in_object(object $object): object {
        $array = $object->toArray();

        foreach ($array as $key => $value) {
            if ($value == null) {
                unset($object[$key]);
            } else if (is_array($value)) {
                self::remove_null_values_in_object($object[$key]);
            }
        }

        return $object;
    }

    public static function remove_array_null_values(array $array): array {
        foreach ($array as $key => $array_index) {
            $array[$key] = self::remove_null_values_in_array($array_index);
        }

        return $array;
    }

    public static function remove_null_values_in_array(array $array): array {
        foreach ($array as $key => $value) {
            if ($value == null) {
                unset($array[$key]);
            } else if (is_array($value)) {
                self::remove_null_values_in_array($array[$key]);
            }
        }

        return $array;
    }
}
