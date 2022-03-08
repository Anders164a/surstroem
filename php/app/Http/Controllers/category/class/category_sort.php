<?php

namespace App\Http\Controllers\category\class;

use Collator;

class category_sort
{
    public function __construct(?Collator $collator = null) {
        $this->collator = $collator ?? new Collator('da_dk');
    }

    public function sort(array $array, string $direction = 'asc', string $field = 'id'): array {
        if(strtolower($direction) === 'desc'){
            return $this->usort_desc($array, $field);
        } else {
            return $this->usort_asc($array, $field);
        }
    }

    /**
     * @param string $field
     */
    private function usort_desc(array $array, string $field): array {
        usort($array, function($a, $b) use ($field){
            return $this->collator->compare($b[$field], $a[$field]);
        });

        return $array;
    }

    /**
     * @param string $field
     */
    private function usort_asc(array $array, string $field): array {
        usort($array, function($a, $b) use ($field){
            return $this->collator->compare($a[$field], $b[$field]);
        });

        return $array;
    }
}
