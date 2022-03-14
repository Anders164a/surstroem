<?php

namespace App\Http\Controllers;

use App\Exceptions\could_not_delete_exception;
use App\Exceptions\form_not_filled_correctly;
use App\Exceptions\integer_not_allowed_null;
use App\Http\Controllers\product\repository\product_repository;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Http\Request;

class product_controller extends Controller implements controller_interface
{
    private product_repository $product_repo;

    public function __construct()
    {
        //$this->middleware('auth');
        //$this->middleware('check.auth:products.edit')->only('edit');

        $this->product_repo = new product_repository();
    }

    public function get_all(): Collection
    {
        return $this->product_repo->get_products();
    }

    public function get_product($id): object {
        if (empty($id)) {
            throw integer_not_allowed_null::integer_not_null();
        }

        return $this->product_repo->get_product($id);
    }

    public function get_products_from_brand_id(Request $request): Collection {
        if (empty($request->brand_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        return $this->product_repo->get_products_from_column($request->brand_id, 'brand_id');
    }

    public function get_products_from_color_id(Request $request): Collection {
        if (empty($request->color_id)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        return $this->product_repo->get_products_from_column($request->color_id, 'color_id');
    }

    public function store(Request $request): object {
        if (empty($request->title) || empty($request->price) || empty($request->brand_id) || empty($requestshort_description) || empty($requestdescription)) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        $price = floatval($request->price);

        $new_product = $this->product_repo->store_product($request->title, $request->short_description, $request->description, $price, $request->weight, $request->width, $request->length, $request->height, $request->warranty_period_id, $request->color_id, $request->brand_id);

        return $this->get_product($new_product->get_id());
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

        if (empty($_PUT['title']) || empty($_PUT['price']) || empty($_PUT['brand_id']) || empty($_PUT['short_description']) || empty($_PUT['description'])) {
            throw form_not_filled_correctly::form_does_not_fulfill_requirements();
        }

        return $this->product_repo->update_product($_PUT);
    }

    public function destroy(Request $request): void {
        try {
            if (empty($request->id)) {
                throw integer_not_allowed_null::integer_not_null();
            }

            $this->product_repo->delete_product($request->id);
        } catch (could_not_delete_exception $e) {
            throw $e;
        }
    }
}
