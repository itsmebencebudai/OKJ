<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Address;

class AddressController extends Controller
{
    public function index()
    {
        $Address = Address::all();
        return view('address.index', compact('Address'));
    }

    public function store(Request $request)
    {
        try {
            $address = new Address;
            $address->zipCode = $request->zipCode;
            $address->city = $request->city;
            $address->street = $request->street;
            $address->delevery = $request->delevery;
            $address->save();
        } catch (\Exception $e) {
            return response()->json(['message' => 'Could not save', 'error' => $e->getMessage()], 500);
        }

        return response()->json([
            'message' => 'Address saved successfully',
            'address' => $address
        ], 201);
    }

    public function show($id)
    {
        $address = Address::find($id);
        if (empty($address)) {
            return response()->json([
                'message' => 'There is no address with this ID'
            ], 404);
        }
        return response()->json($address);
    }

    public function update(Request $request, int $id)
    {
        if (Address::where('id', $id)->exists()) {
            try {
                $address = Address::find($id);
                $address->zipCode = $request->zipCode ?? $address->zipCode;
                $address->city = $request->city ?? $address->city;
                $address->street = $request->street ?? $address->street;
                $address->delevery = $request->delevery ?? $address->delevery;
                $address->save();
                return response()->json($address);
            } catch (\Exception $e) {
                return response()->json([
                    'message' => 'Address not found',
                ], 404);
            }
        }
    }

    public function destroy(int $id)
    {
        if (Address::where('id', $id)->exists()) {
            $address = Address::find($id);
            $address->delete();
            return response()->json([
                'message' => 'Address deleted'
            ], 202);
        }
    }
}
