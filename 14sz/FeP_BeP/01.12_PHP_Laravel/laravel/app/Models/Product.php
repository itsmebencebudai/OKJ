<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    use HasFactory;
    protected $table = "Products";
    protected $fillable = ['productName','description','price','stock','path'];
    public $timestamps = false;
}