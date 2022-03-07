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

Route::get('/categories', [App\Http\Controllers\CategoryController::class, 'get_all_categories']);

Route::post('/category', [App\Http\Controllers\CategoryController::class, 'store_category']);

Route::put('/category', [App\Http\Controllers\CategoryController::class, 'update_category']);

Route::get('/products', [App\Http\Controllers\ProductController::class, 'get_all']);

Route::get('/product/{id}', [App\Http\Controllers\ProductController::class, 'get_product']);

Route::get('/product_brand_id', [App\Http\Controllers\ProductController::class, 'get_products_from_brand_id']);

Route::get('/product_color_id', [App\Http\Controllers\ProductController::class, 'get_products_from_color_id']);

Route::post('/product', [App\Http\Controllers\ProductController::class, 'store']);

Route::put('/product', [App\Http\Controllers\ProductController::class, 'update']);

Route::delete('/product', [App\Http\Controllers\ProductController   ::class, 'destroy']);

