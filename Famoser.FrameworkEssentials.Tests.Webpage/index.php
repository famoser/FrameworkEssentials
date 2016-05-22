<?php
/**
 * Created by PhpStorm.
 * User: famoser
 * Date: 22/05/2016
 * Time: 16:21
 */
echo "start\n";
if (count($_POST) != 0)
    echo json_encode($_POST);
if (count($_FILES) != 0)
    echo json_encode($_FILES);
$fullRequest = file_get_contents('php://input');
if (strlen($fullRequest) > 0)
    echo json_encode(json_decode($fullRequest));
echo "\nend";
