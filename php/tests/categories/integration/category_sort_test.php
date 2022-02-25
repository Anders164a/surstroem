<?php

namespace Tests\categories\integration;

use App\Http\Controllers\category\class\category_sort;
use App\Models\category;
use Illuminate\Foundation\Testing\TestCase;
use Illuminate\Support\Facades\DB;

class category_sort_test extends TestCase
{
    public function createApplication()
    {
        $app = require __DIR__.'/../../../bootstrap/app.php';

        //Load .env.testing environment
        $app->loadEnvironmentFrom('.env.testing');

        $app->make('Illuminate\Contracts\Console\Kernel')->bootstrap();

        return $app;
    }

    public function setUp(): void
    {
        parent::setUp();
        $this->db = DB::connection();
        $this->db->beginTransaction();

        category::create(['category' => "Let's go"]);
        category::create(['category' => "Open Sesame"]);
        category::create(['category' => "Ålen Egon"]);
        category::create(['category' => "Lets go"]);
        category::create(['category' => "!Special Chars First"]);
        category::create(['category' => "Æggesalat"]);
        category::create(['category' => "Øllebølle"]);
        category::create(['category' => "I should go fourth!"]);
        category::create(['category' => "Let's go2"]);
        category::create(['category' => "I am the third"]);
        category::create(['category' => "123"]);
    }

    public function tearDown(): void
    {
        parent::tearDown();
        $this->db->rollBack();
    }

    public function test_sort_by_name(): void {
        $categories = category::query()->select('category')->orderBy('category', 'asc')->get()->toArray();

        $sort = new category_sort();

        $sorted_categories = $sort->sort($categories, 'asc', 'category');

        self::assertSame("!Special Chars First", $sorted_categories[0]['category']);
        self::assertSame("123", $sorted_categories[1]['category']);
        self::assertSame("I am the third", $sorted_categories[2]['category']);
        self::assertSame("I should go fourth!", $sorted_categories[3]['category']);
        self::assertSame("Let's go", $sorted_categories[4]['category']);
        self::assertSame("Let's go2", $sorted_categories[5]['category']);
        self::assertSame("Lets go", $sorted_categories[6]['category']);
        self::assertSame("Open Sesame", $sorted_categories[7]['category']);
        self::assertSame("Æggesalat", $sorted_categories[8]['category']);
        self::assertSame("Øllebølle", $sorted_categories[9]['category']);
        self::assertSame("Ålen Egon", $sorted_categories[10]['category']);
    }

    public function test_sort_by_id(): void {
        $categories = category::query()->select('id', 'category')->orderBy('category', 'asc')->get()->toArray();

        $sort = new category_sort();

        $sorted_categories = $sort->sort($categories);

        self::assertSame("Let's go", $sorted_categories[0]['category']);
        self::assertSame("Open Sesame", $sorted_categories[1]['category']);
        self::assertSame("Ålen Egon", $sorted_categories[2]['category']);
        self::assertSame("Lets go", $sorted_categories[3]['category']);
        self::assertSame("!Special Chars First", $sorted_categories[4]['category']);
        self::assertSame("Æggesalat", $sorted_categories[5]['category']);
        self::assertSame("Øllebølle", $sorted_categories[6]['category']);
        self::assertSame("I should go fourth!", $sorted_categories[7]['category']);
        self::assertSame("Let's go2", $sorted_categories[8]['category']);
        self::assertSame("I am the third", $sorted_categories[9]['category']);
        self::assertSame("123", $sorted_categories[10]['category']);
    }
}
