<?php

namespace App\Http\Controllers;

use App\Exceptions\could_not_delete_exception;
use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\category\class\category_sort;
use App\Http\Controllers\category\repository\category_repository;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Http\Request;

class CategoryController extends Controller
{
    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:users.edit')->only('edit');
    }

    public function get_all()
    {
        $category_repo = new category_repository();
        $all_categories = $category_repo->get_categories()->toArray();

        $sort = new category_sort();
        $sorted_categories = $sort->sort($all_categories, 'asc', 'category');

        return json_encode($sorted_categories);
    }

    public function get_category(int $id): object {
        if (empty($id)) {
            throw integer_not_allowed_null::integer_not_null();
        }

        $category_repo = new category_repository();
        return $category_repo->get_category($id);
    }

    public function get_categories_by_parent_id(Request $request): Collection {
        if (empty($request->parent_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $category_repo = new category_repository();
        return $category_repo->get_categories_by_parent_id($request->parent_id);
    }

    public function store(Request $request) {
        if (empty($request->category)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $parent_id = $request->parent_category_id ?? null;
        $category_repo = new category_repository();
        $new_category = $category_repo->store_category($request->category, $parent_id);

        return json_encode($this->get_category($new_category->get_id()));
    }

    /**
     * @return false|string
     * @throws form_not_filled_correctly
     * @throws integer_not_allowed_null
     */
    public function update() {
        parse_str(file_get_contents('php://input'), $_PUT);

        if (empty($_PUT['id'])) {
            throw integer_not_allowed_null::integer_not_null();
        }

        if (empty($_PUT['category'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $category_repo = new category_repository();
        $category = $category_repo->update_category($_PUT);

        return json_encode($category);
    }

    public function destroy(Request $request): void
    {
        try {
            if (empty($request->id)) {
                throw integer_not_allowed_null::integer_not_null();
            }

            $category_repo = new category_repository();

            $category_repo->delete_category($request->id);
        } catch (could_not_delete_exception $e) {
            throw $e;
        }
    }
}
