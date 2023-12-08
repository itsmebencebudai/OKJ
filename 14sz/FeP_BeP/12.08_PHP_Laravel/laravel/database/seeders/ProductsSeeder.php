<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use App\Models\Products;

class ProductsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $faker = \Faker\Factory::create();
        for ($i=0; $i < 10; $i++) { 
            Products::create([
                'productName' => $faker->name,
                'description' => $faker->text,
                'price' => $faker->randomNumber,
                'stock' => $faker->randomNumber
            ]);
        }
    }
}
