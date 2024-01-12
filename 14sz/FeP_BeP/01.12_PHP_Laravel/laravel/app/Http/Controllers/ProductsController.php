<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Products;

class ProductsController extends Controller
{
    public function index()
    {
        $Products = Products::all();
        return view('products.index', compact('Products'));
    }

    public function store(Request $request)
    {
        request()->validate([
            'files' => 'require|image|mimes:jpg,png',
        ]);

        if ($request->hasFile('file')) {
            $name = $request->file->getClientOriginalName();
            $path = $request->file->store('images', 'public');
        }

        try {
            $Products = new Products;
            $Products->productName = $request->productName;
            $Products->description = $request->description;
            $Products->price = $request->price;
            $Products->stock = $request->stock;
            $Products->path = $request->path;
            $Products->save();
        } catch (\Exception $e) {
            return response(500)->json(['message' => 'Could not save', 'error' => $e->getMessage()], 404);
        }

        return response()->json([
            'message' => 'Product saved successfully',
            'products' => $Products
        ], 201);
    }

    public function show($id)
    {
        $Products = Products::find($id);
        if (empty($Products)) {
            return response()->json([
                'message' => 'There is no Product to this ID'
            ], 404);
        }
        return response()->json($Products);
    }

    public function update(Request $request, int $id)
    {
        if (Products::where('productID', $id)->exists()) {
            try {
                $Products = Products::find($id);
                $Products->productName = is_null($request->productName) ? $Products->productName : $request->productName;
                $Products->description = is_null($request->description) ? $Products->description : $request->description;
                $Products->price = is_null($request->price) ? $Products->price : $request->price;
                $Products->stock = is_null($request->stock) ? $Products->stock : $request->stock;
                $Products->path = is_null($request->path) ? $Products->path : $request->path;
                $Products->save();
                return response()->json($Products);
            } catch (\Exception $e) {
                return response()->json([
                    'message' => 'Product not found',
                ], 404);
            }
        }
    }

    public function destroy(int $id)
    {
        if (Products::where('productID', $id)->exists()) {
            $Products = Products::find($id);
            $Products->delete();
            return response()->json([
                'message' => 'Product deleted'
            ], 202);
        }
    }

}
