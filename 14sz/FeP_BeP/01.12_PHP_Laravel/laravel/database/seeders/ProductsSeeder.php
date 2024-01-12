<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Products;

class ProductsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $faker = \Faker\Factory::create();

        for ($i = 0; $i < 10; $i++) {
            Products::create([
                'productName' => $faker->sentence(2),
                'description' => $faker->paragraph,
                'price' => $faker->randomFloat(2, 10, 100),
                'stock' => $faker->numberBetween(1, 100),
                // 'path' => $faker->imageUrl(),
                'path' => null,
            ]);
        }
    }
}
