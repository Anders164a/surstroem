<?php


namespace App\Http\Controllers;


use Illuminate\Database\Eloquent\Collection;
use Illuminate\Http\Request;

interface controller_interface
{
    public function get_all(): Collection;
    public function store(Request $request): object;
    public function update(): object;
    public function destroy(Request $request): void;
}
