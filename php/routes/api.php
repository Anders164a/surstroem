<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::get('/categories', [App\Http\Controllers\category_controller::class, 'get_all']);

Route::get('/category/{id}', [App\Http\Controllers\category_controller::class, 'get_category']);

Route::get('/category', [App\Http\Controllers\category_controller::class, 'get_categories_by_parent_id']);

Route::post('/category', [App\Http\Controllers\category_controller::class, 'store']);

Route::put('/category', [App\Http\Controllers\category_controller::class, 'update']);

Route::delete('/category', [App\Http\Controllers\category_controller::class, 'destroy']);

Route::get('/products', [App\Http\Controllers\product_controller::class, 'get_all']);

Route::get('/product/{id}', [App\Http\Controllers\product_controller::class, 'get_product']);

Route::get('/product_brand_id', [App\Http\Controllers\product_controller::class, 'get_products_from_brand_id']);

Route::get('/product_color_id', [App\Http\Controllers\product_controller::class, 'get_products_from_color_id']);

Route::post('/product', [App\Http\Controllers\product_controller::class, 'store']);

Route::put('/product', [App\Http\Controllers\product_controller::class, 'update']);

Route::delete('/product', [App\Http\Controllers\product_controller::class, 'destroy']);

Route::get('/product_category', [App\Http\Controllers\product_category_controller::class, 'get_all']);

Route::get('/product_category/{id}', [App\Http\Controllers\product_category_controller::class, 'get_product_category']);

Route::post('/product_category', [App\Http\Controllers\product_category_controller::class, 'store']);

Route::put('/product_category', [App\Http\Controllers\product_category_controller::class, 'update']);

Route::delete('/product_category', [App\Http\Controllers\product_category_controller::class, 'destroy']);

Route::get('/product_category_from_product_id', [App\Http\Controllers\product_category_controller::class, 'get_categories_from_product_id']);

Route::get('/product_category_from_category_id', [App\Http\Controllers\product_category_controller::class, 'get_products_from_category_id']);

Route::get('/products_from_a_parent_category', [App\Http\Controllers\product_category_controller::class, 'get_products_from_a_parent_category']);
