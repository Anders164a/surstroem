<?php
include "route.php";

use classes\category\class\category;
use classes\category\repository\category_repository;

header("Access-Control-Allow-Origin", "*");
header("Access-Control-Allow-Methods", "PUT, DELETE, POST, GET, OPTIONS");
header("Access-Control-Allow-Headers", "Content-Type, Authorization, X-Requested-With");

Route::add('/api/categories',function(){
    $category_repo = new category_repository();
    $all_categories = $category_repo->get_categories();

    echo json_encode($all_categories, JSON_FORCE_OBJECT);
});

?>

<button onclick="test()">Knap</button>
<?php
Route::add('/api/category',function(){
    /*$validate = \Illuminate\Support\Facades\Validator::make($_POST, [
        'name' => 'required'
    ]);*/

    $parent_id = $_POST['parent_category_id'] ?? null;
    $category_repo = new category_repository();
    $new_category = $category_repo->store_category($_POST['category'], $parent_id);

    return json_encode(['category' => $new_category->get_name(), 'parent_category_id' => $new_category->get_parent_category_id()]);
}, 'post');

Route::add('/api/category',function(){
    //parse_str(file_get_contents('php://input'), $_PUT);

    echo "test";
    /*$parent_id = is_string($_PUT['parent_category_id']) ? NULL : $_PUT['parent_category_id'];

    $category_repo = new category_repository();
    $category = $category_repo->get_category($_PUT['id']);

    $category['category'] = $_PUT['category'];
    $category->parent_category_id = $parent_id;
    $category->update();*/
}, 'put');

Route::run();
?>


<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script>
    function test() {
        $.ajax({
            type: 'PUT',
            url: 'http://127.0.0.1/api/category',
            dataType: 'JSON',
            contentType: 'application/json',
            data: {
                category: null,
                parent_category_id: null
            },
            success:function (data) {
                console.log(data);
            }
        })
    }
</script>
