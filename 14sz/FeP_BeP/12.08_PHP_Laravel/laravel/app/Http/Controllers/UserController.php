<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Validation\Rules\Exists;

class UserController extends Controller
{
    public function index()
    {
        $User = User::all();
        return response()->json($User);
    }

    public function store(Request $request)
    {
        $User = new User;
        $User->name = $request->name;
        $User->email = $request->email;
        $User->password = bcrypt($request->password);
        $User->password = password_hash($request->password, PASSWORD_DEFAULT);
        $User->accountNumber = $request->accountNumber;
        try {
            $User->save();
        } catch (\Exception $e) {
            return response(500)->json(['messega' => 'Could not save', 'error' => $e->getMessage()], 404);
        }

        return response()->json([
            'message' => 'User saved successfully',
            'user' => $User
        ], 201);
    }

    public function show($id)
    {
        $User = User::find($id);
        if (empty($User)) {
            return response()->json([
                'message' => 'There is no User to this  ID'
            ], 404);
        }
        return response()->json($User);
    }

    public function update(Request $request, int $id)
    {
        if (User::where('id', $id)->exists()) {
            try {
                $User = User::find($id);
                $User->name = is_null($request->name) ? $User->name : $request->name;
                $User->email = is_null($request->email) ? $User->email : $request->email;
                $User->password = is_null($request->password) ? $User->password : bcrypt($request->password, [PASSWORD_BCRYPT]);
                $User->accountNumber = is_null($request->accountNumber) ? $User->accountNumber : $request->accountNumber;
                // $User->token = jwt token mit generálok
                $User->save();
                return response()->json($User);
            } catch (\Exception $e) {
                return response()->json([
                    'message' => 'User not found',
                ], 404);
            }
        }
    }

    public function destroy(int $id)
    {
        if (User::where('id', $id)->exists()) {
            $User = User::find($id);
            $User->delete();
            return response()->json([
                'message' => 'User deleted'
            ], 202);
        }
    }

}