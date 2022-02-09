<?php
include "route.php";

// Get user from ID
Route::add('/user/([1-9]+)',function($user_id){
    $user_repo = new user_repository();
    $user = $user_repo->get_user_from_user_id($user_id);

    if ($user === null) {
        throw new Exception('No User with this ID');
    }

    echo $user->get_fullname();
});

// Get user from ID
Route::add('/user/([1-9]+)',function($user_id){
    $user_repo = new user_repository();
    $user = $user_repo->get_user_from_user_id($user_id);

    if ($user === null) {
        throw new Exception('No User with this ID');
    }

    echo $user->get_fullname();
}, 'post');

Route::run();