<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class WebpageController extends Controller
{
    public function index()
    {
        $data = [
            'title' => 'My Webpage',
            'content' => 'Welcome to my webpage!'
        ];

        return view('webpage.index', $data);
    }
}
