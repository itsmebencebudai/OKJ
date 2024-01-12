<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Cart;
use App\Models\Product;
use App\Models\User;

class CartController extends Controller
{
    public function index()
    {
        $valami = Product:: query("select * from product");
        
        $data = Cart::join('cart_item','cart.id','=','cart_item.id')
                    ->join('user','user.id','=','cart.userID')
                    ->join('product','product.id','=','cart_item.productID')
                    ->get();

        return view('join_multiple_table', compact('data'));
    }
}
