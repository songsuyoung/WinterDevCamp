
<?php

$servername="서버이름";
$username="mysql이름";
$password="비밀번호";
$dbname="데이터베이스 이름";

$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error) {
    die("Connection failed: ". $conn->connect_error);
} 


if(isset($_POST['HashUrl'])&&isset($_POST['urlid'])){
    echo "1";
    $url=$_POST['HashUrl'];
    $urlid=(int)$_POST['urlid'];

    $insertSql = "UPDATE UrlInfo SET hashURL='$url' where id ='$urlid'";
    echo $insertSql;

    if($conn->query($insertSql)===TRUE){
        echo "삽입 성공!";
    }else{
        echo "ERROR: ".$insertSql;
    }
}

$conn->close();

?>
