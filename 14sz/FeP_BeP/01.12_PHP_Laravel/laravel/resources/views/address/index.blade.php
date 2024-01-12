<!-- resources/views/addresses/index.blade.php -->

@extends('layouts.app')

@section('content')
    <h1>Address List</h1>

    <table border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Zip Code</th>
                <th>City</th>
                <th>Street</th>
                <th>Delivery</th>
            </tr>
        </thead>
        <tbody>
            @foreach($Address as $address)
                <tr>
                    <td>{{ $address->id }}</td>
                    <td>{{ $address->zipCode }}</td>
                    <td>{{ $address->city }}</td>
                    <td>{{ $address->street }}</td>
                    <td>{{ $address->delevery }}</td>
                </tr>
            @endforeach
        </tbody>
    </table>
@endsection
