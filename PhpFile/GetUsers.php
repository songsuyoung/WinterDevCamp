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

if(isset($_POST['id'])&&isset($_POST['passwd'])){
    $id=$_POST['id'];
    $password=$_POST['passwd'];
    $selectSql = "SELECT * FROM UserInfo where name ='$id'";
    $result =$conn->query($selectSql);

    if($result->num_rows>0){//있으면 id값 반환
        while($row = mysqli_fetch_array($result)){

            if($row["password"]===$password){
                echo $row["id"];
            }else{
                echo "비밀번호 오류";
            }
        }
    }else{
        echo "없음";
    }
}

$conn->close();

?>


