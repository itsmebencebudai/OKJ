<?php

use App\Http\Controllers\ProductsController;
use App\Http\Controllers\UserController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::get("/user", [UserController::class, 'index']);
Route::get("/user/{id}", [UserController::class, 'show']);
Route::post("/user", [UserController::class, 'store']);
Route::put("/user/{id}", [UserController::class, 'update']);
Route::delete("/user/{id}", [UserController::class, 'destroy']);

Route::get("/products", [ProductsController::class, 'index']);
Route::get("/products/{id}", [ProductsController::class, 'show']);
Route::post("/products", [ProductsController::class, 'store']);
Route::put("/products/{id}", [ProductsController::class, 'update']);
Route::delete("/products/{id}", [ProductsController::class, 'destroy']);


