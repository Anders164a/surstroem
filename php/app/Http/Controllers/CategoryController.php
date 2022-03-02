<?php

namespace App\Http\Controllers;

use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\category\class\category_sort;
use App\Http\Controllers\category\repository\category_repository;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;

class CategoryController extends Controller
{
    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:users.edit')->only('edit');
    }

    public function get_all_categories()
    {
        $category_repo = new category_repository();
        $all_categories = $category_repo->get_categories()->toArray();

        $sort = new category_sort();
        $sorted_categories = $sort->sort($all_categories, 'asc', 'category');

        return json_encode($sorted_categories, JSON_FORCE_OBJECT);
    }

    public function store_category(Request $request) {
        if (empty($request->category)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $parent_id = $request->parent_category_id ?? null;
        $category_repo = new category_repository();
        $new_category = $category_repo->store_category($request->category, $parent_id);

        return json_encode(['category' => $new_category->get_name(), 'parent_category_id' => $new_category->get_parent_category_id()]);
    }

    /**
     * @throws form_not_filled_correctly
     * @throws \classes\category\repository\exception\category_not_found_exception
     * @throws integer_not_allowed_null
     */
    public function update_category() {
        parse_str(file_get_contents('php://input'), $_PUT);

        if (empty($_PUT['id'])) {
            throw integer_not_allowed_null::integer_not_null();
        }

        if (empty($_PUT['category'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $parent_id = empty($_PUT['parent_category_id']) ? NULL : $_PUT['parent_category_id'];

        $category_repo = new category_repository();
        $category = $category_repo->get_category($_PUT['id']);

        $category['category'] = $_PUT['category'];
        $category->parent_category_id = $parent_id;
        $category->update();

        return json_encode($category);
    }
}
