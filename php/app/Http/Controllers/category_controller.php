<?php

namespace App\Http\Controllers;

use App\Exceptions\could_not_delete_exception;
use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\category\class\category_sort;
use App\Http\Controllers\category\repository\category_repository;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Http\Request;

class category_controller extends Controller implements controller_interface
{
    private category_repository $category_repo;

    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:users.edit')->only('edit');

        $this->category_repo = new category_repository();
    }

    public function get_all(): Collection
    {
        return $this->category_repo->get_categories();
    }

    public function get_sorted_categories(Request $request): array {
        if (empty($request->direction) || empty($request->field)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $all_categories = $this->get_all()->toArray();

        $sort = new category_sort();

        return $sort->sort($all_categories, $request->direction, $request->field);
    }

    public function get_category(int $id): object {
        if (empty($id)) {
            throw integer_not_allowed_null::integer_not_null();
        }

        return $this->category_repo->get_category($id);
    }

    public function get_categories_by_parent_id(Request $request): Collection {
        if (empty($request->parent_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        return $this->category_repo->get_categories_by_parent_id($request->parent_id);
    }

    public function store(Request $request): object {
        if (empty($request->category)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $parent_id = $request->parent_category_id ?? null;

        $new_category = $this->category_repo->store_category($request->category, $parent_id);

        return $this->get_category($new_category->get_id());
    }

    /**
     * @return false|string
     * @throws form_not_filled_correctly
     * @throws integer_not_allowed_null
     */
    public function update(): object {
        parse_str(file_get_contents('php://input'), $_PUT);

        if (empty($_PUT['id'])) {
            throw integer_not_allowed_null::integer_not_null();
        }

        if (empty($_PUT['category'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        return $this->category_repo->update_category($_PUT);
    }

    public function destroy(Request $request): void
    {
        try {
            if (empty($request->id)) {
                throw integer_not_allowed_null::integer_not_null();
            }

            $this->category_repo->delete_category($request->id);
        } catch (could_not_delete_exception $e) {
            throw $e;
        }
    }
}
