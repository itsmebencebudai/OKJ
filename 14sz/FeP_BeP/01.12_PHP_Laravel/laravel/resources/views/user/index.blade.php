<!-- resources/views/products/index.blade.php -->

@extends('layouts.app')

@section('content')
    <h1>Product List</h1>

    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Description</th>
                <th>Price</th>
                <th>Stock</th>
            </tr>
        </thead>
        <tbody>
            @foreach($User as $user)
                <tr>
                    <td>{{ $user->id }}</td>
                    <td>{{ $user->name }}</td>
                    <td>{{ $user->email }}</td>
                    <td>{{ $user->password }}</td>
                    <td>{{ $user->accountNumber }}</td>
                    <td>{{ $user->token }}</td>
                </tr>
            @endforeach
        </tbody>
    </table>
@endsection
