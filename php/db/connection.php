<?php

namespace surstroem_connection;

include $_SERVER['DOCUMENT_ROOT']."\php\\eloquent\\vendor\autoload.php";

use Illuminate\Database\Capsule\Manager as Capsule;

$capsule = new Capsule();


$capsule->addConnection([
    "driver" => "mysql",
    "host" => "127.0.0.1",
    "database" => "surstroem",
    "port" => "3306",
    "username" => "root",
    "password" => ""
]);

$capsule->setAsGlobal();

$capsule->bootEloquent();