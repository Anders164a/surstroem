<?php

namespace surstroem_connection;

include $_SERVER['DOCUMENT_ROOT']."\php\\eloquent\\vendor\autoload.php";

use Illuminate\Database\Capsule\Manager as Capsule;

$capsule = new Capsule();


$capsule->addConnection([
    "driver" => "mysql",
    "host" => getenv('DB_HOST'),
    "database" => "case",
    "port" => "3306",
    "username" => "root",
    "password" => ""
]);

$capsule->setAsGlobal();

$capsule->bootEloquent();