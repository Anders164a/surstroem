<?php

namespace App\Http\Controllers;

use App\Exceptions\could_not_delete_exception;
use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\product_category\repository\product_category_repository;
use Illuminate\Http\Request;

class product_category_controller extends Controller
{
    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:products.edit')->only('edit');
    }

    public function get_all()
    {
        $product_category_repo = new product_category_repository();
        $all_product_categories = $product_category_repo->get_all();

        return json_encode($all_product_categories);
    }

    public function get_product_category($id): object {
        if (empty($id)) {
            throw integer_not_allowed_null::integer_not_null();
        }

        $product_category_repo = new product_category_repository();
        return $product_category_repo->get_product_category($id);
    }

    public function get_categories_from_product_id(Request $request) {
        if (empty($request->product_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_id = strval($request->product_id);

        $product_category_repo = new product_category_repository();
        return $product_category_repo->get_categories_from_product_id($product_id);
    }

    public function get_products_from_category_id(Request $request) {
        if (empty($request->category_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $category_id = strval($request->category_id);

        $product_category_repo = new product_category_repository();
        return $product_category_repo->get_products_from_category_id($category_id);
    }

    public function get_products_from_a_parent_category(Request $request) {
        if (empty($request->category_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_category_repo = new product_category_repository();

        return $product_category_repo->get_products_from_a_parent_category($request->category_id);
    }

    public function store(Request $request) {
        if (empty($request->product_id) || empty($request->category_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_category_repo = new product_category_repository();
        $new_product_category = $product_category_repo->store_product_category($request->product_id, $request->category_id);

        return json_encode($this->get_product_category($new_product_category->get_id()));
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

        if (empty($_PUT['product_id']) || empty($_PUT['category_id'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_repo = new product_category_repository();
        $product = $product_repo->update_product_category($_PUT);

        return json_encode($product);
    }

    public function destroy(Request $request) {
        try {
            if (empty($request->id)) {
                throw integer_not_allowed_null::integer_not_null();
            }

            $product_repo = new product_category_repository();

            $product_repo->delete_product_category($request->id);
        } catch (could_not_delete_exception $e) {
            throw $e;
        }
    }
}
