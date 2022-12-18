<?php

$servername="서버이름";
$username="mysql이름";
$password="비밀번호";
$dbname="데이터베이스 이름";

$conn = new mysqli($servername,$username,$password,$dbname);
# 입력들어온 url에 대한 id를 전달 -> url 저장 후 id전달...
if($conn->connect_error) {
    die("Connection failed: ". $conn->connect_error);
} 

if(isset($_POST['HashUrl'])){
    $url=$_POST['HashUrl'];
    $selectSql = "SELECT originalURL FROM UrlInfo where hashURL ='$url'";
    $result =$conn->query($selectSql);

    if($result->num_rows>0){//있으면 id값 반환
        while($row = mysqli_fetch_array($result)){
            echo $row["originalURL"];
        }
    }
}
if(isset($_POST['OriginalUrl'])){

    $url=$_POST['OriginalUrl'];
    $selectSql = "SELECT id FROM UrlInfo where originalURL ='$url'";
    $result =$conn->query($selectSql);

    if($result->num_rows>0){//있으면 id값 반환
        while($row = mysqli_fetch_array($result)){
            echo $row["hashURL"];
        }
    }else{
        //없으면 삽입 후 새로운 id값 가져오기!
        $insertSql = "INSERT INTO UrlInfo(originalURL) VALUES ('$url')";
        $result =$conn->query($insertSql);
        
        echo $url;
        // 데이터 삽입 진행 후 그에 대한 num값 반환!
        $selectSql = "SELECT id FROM UrlInfo where originalURL ='$url'";
        $result1 =$conn->query($selectSql);
    
        if($result1->num_rows>0){
            while($row = mysqli_fetch_array($result1)){
                echo $row["id"];
            }
        }
    }
}


$conn->close();

?>


