<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Address;

class AddressSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run()
    {
        $faker = \Faker\Factory::create();

        for ($i = 0; $i < 10; $i++) {
            Address::create([
                'zipCode' => str_replace('-', '', $faker->postcode),
                'city' => $faker->city,
                'street' => $faker->streetAddress,
                'delevery' => $faker->numberBetween(1, 100),
            ]);
        }
    }
}
