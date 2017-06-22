<?php
	////check GET
	//foreach($_GET as $key => $val){ 
	//	print_r("[_GET]".$key); 
	//	echo "=";
	//	print_r($val); 
	//	echo "\n";
	//}
	//echo "\n";
	////check POST
	//foreach($_POST as $key => $val){ 
	//	print_r("[_POST]".$key); 
	//	echo "=";
	//	print_r($val); 
	//	echo "\n";
	//}
	//echo "\n";
	////check SERVER
	//foreach($_SERVER as $key => $val){ 
	//	print_r("[_SERVER]".$key); 
	//	echo "=";
	//	print_r($val); 
	//	echo "\n";
	//}
	//echo "\n";
	//check GET/POST
	if ($_SERVER["REQUEST_METHOD"] == "POST") {
		if(isset($_POST['id'])) $id = $_POST["id"];
	} else {
		if(isset($_GET['id'])) $id = $_GET["id"];
	}

    // 1. 데이타베이스 서버 연결(MySQL 서버 연결)
    $connect = mysqli_connect(
        "localhost", // mysql 서버 주소
        "root", // 관리자 아이디
        "autoset", // 관리자 패스워드
        "game_db" // 데이타베이스 이름
    ) or die("Error".mysqli_error($connect));
  
    // 2. 데이타 조회 sql 쿼리 작성
    $sql = "SELECT * FROM user_tb WHERE id='".$id."';";
  
    //echo "sql -> ".$sql;
    //exit();
  
    // 3. 쿼리 실행
    // mysqli_query(connect변수, 쿼리문자열);
    $result = mysqli_query($connect, $sql);
  
    // 5. 응답 데이타 객체 생성
    $response_data = array(
        "result_code" => "SELECT_SUCCESS", // 결과 코드
        "result_data" => array() // 결과 데이타
    );
  
	// echo "\n[SQL][ERROR][CHECK]".mysqli_errno($connect) . ": " . mysqli_error($connect). "\n\n";
	$response_data["error_code"] = mysqli_errno($connect);
	$response_data["error_messge"] = mysqli_error($connect);

    // 쿼리실행후 리턴받은 결과객체->num_rows : 조회결과 갯수
    if ($result->num_rows > 0) {
          
        //$i = 0;
        //// mysqli_fetch_assoc(쿼리실행후 리턴받은 결과객체)
        //while($row = mysqli_fetch_assoc($result)) {
        //    // 추출한 행 데이타를 결과 데이타 배열에 추가함
        //    $response_data["result_data"][$i++] = $row;
        //}
		$row = mysqli_fetch_assoc($result);
		$response_data["result_data"] = $row;
  
    }
    else
    {
        $response_data["result_code"] = "SELECT_FAIL";
    }

    // 6. 클라이언트에 응답데이타를 전송함
    echo json_encode($response_data);
	//echo "\n";
	//foreach($response_data as $key => $val){ 
	//	print_r("[result_data]".$key); 
	//	echo "=";
	//	print_r($val); 
	//	echo "\n";
	//}
	//echo "\n";
  
    // 7. 데이타베이스 연결해제
    mysqli_close($connect);
?>