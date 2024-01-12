<?php

namespace Database\Factories;

use Faker\Provider\Text;
use Illuminate\Database\Eloquent\Factories\Factory;
use Illuminate\Support\Number;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Products>
 */
class ProductsFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */

    public function definition(): array
    {
        return [
            'productName' => fake()->name(),
            'description' => Text::randomLetter(),
            'price' => Number::random(5),
            'stock' => Number::random(1)
        ];
    }
}
