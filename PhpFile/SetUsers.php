
<?php

$servername="서버이름";
$username="mysql이름";
$password="비밀번호";
$dbname="데이터베이스 이름";

$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error) {
    die("Connection failed: ". $conn->connect_error);
} 


if(isset($_POST['id'])&&isset($_POST['password'])&&isset($_POST['email'])){


    $id=$_POST['id'];
    $password=$_POST['password'];
    $email=$_POST['email'];

    $selectSql = "SELECT id FROM UserInfo where name ='$id'";

    $result =$conn->query($selectSql);

    if($result->num_rows>0){//있으면 id값 반환
        while($row = mysqli_fetch_array($result)){
            echo $row["id"];
        }
    }else{
        echo "없음";
        $insertSql = "INSERT INTO UserInfo(name,password,email) VALUES ('$id','$password','$email')";

        if($conn->query($insertSql)===TRUE){
            echo "삽입 성공!";
        }else{
            echo "ERROR: ".$insertSql;
        }
    }
}

$conn->close();

?>
