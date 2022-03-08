<?php

namespace App\Http\Controllers;

use App\Exceptions\could_not_delete_exception;
use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\product\repository\product_repository;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:products.edit')->only('edit');
    }

    public function get_all()
    {
        $product_repo = new product_repository();
        $all_products = $product_repo->get_products();

        return json_encode($all_products);
    }

    public function get_product($id): object {
        if (empty($id)) {
            throw integer_not_allowed_null::integer_not_null();
        }

        $product_repo = new product_repository();
        return $product_repo->get_product($id);
    }

    public function get_products_from_brand_id(Request $request) {
        if (empty($request->brand_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_repo = new product_repository();
        return $product_repo->get_products_from_column($request->brand_id, 'brand_id');
    }

    public function get_products_from_color_id(Request $request) {
        if (empty($request->color_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $product_repo = new product_repository();
        return $product_repo->get_products_from_column($request->color_id, 'color_id');
    }

    public function store(Request $request) {
        if (empty($request->title) || empty($request->price) || empty($request->brand_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $price = floatval($request->price);

        $product_repo = new product_repository();
        $new_product = $product_repo->store_product($request->title, $request->short_description, $request->description, $price, $request->weight, $request->width, $request->length, $request->height, $request->warranty_period_id, $request->color_id, $request->brand_id);

        return json_encode(['id' => $new_product->get_id(), 'title' => $new_product->get_title(), 'price' => $new_product->get_price()]);
    }

    /**
     * @throws form_not_filled_correctly
     * @throws \classes\category\repository\exception\category_not_found_exception
     * @throws integer_not_allowed_null
     */
    public function update() {
        parse_str(file_get_contents('php://input'), $_PUT);

        if (empty($_PUT['id'])) {
            throw integer_not_allowed_null::integer_not_null();
        }

        if (empty($_PUT['title']) || empty($_PUT['price']) || empty($_PUT['brand_id'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $price = floatval($_PUT['price']);

        $product_repo = new product_repository();
        $product = $product_repo->get_product($_PUT['id']);

        $product->product_title = $_PUT['title'];
        $product->short_description = $_PUT['short_description'] ?? null;
        $product->description = $_PUT['description'] ?? null;
        $product->price = $price;
        $product->weight = $_PUT['weight'] ?? null;
        $product->width = $_PUT['width'] ?? null;
        $product->length = $_PUT['length'] ?? null;
        $product->height = $_PUT['height'] ?? null;
        $product->warranty_period_id = $_PUT['warranty_period_id'] ?? null;
        $product->color_id = $_PUT['color_id'] ?? null;
        $product->brand_id = $_PUT['brand_id'];
        $product->update();

        return json_encode($product);
    }

    public function destroy(Request $request) {
        try {
            if (empty($request->id)) {
                throw integer_not_allowed_null::integer_not_null();
            }

            $product_repo = new product_repository();

            $product_repo->delete_product($request->id);
        } catch (could_not_delete_exception $e) {
            throw $e;
        }
    }
}
