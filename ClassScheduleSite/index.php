<?php

require_once("DB.php");

// verify student id if it is set
if (isset($_POST['id'])) {
    $getStudentID = DB::get()->prepare("SELECT studentName FROM studentworker WHERE studentID = :studentID");
    $studentID = $_POST["id"];
    $getStudentID->bindParam("studentID", $studentID);
    $getStudentID->execute();

    $result = $getStudentID->fetchAll(PDO::FETCH_ASSOC);
    if (count($result) == 1) {
        session_start();
        $_SESSION['id'] = $studentID;
        $_SESSION['name'] = $result[0]["studentName"];
        header("Location: class_schedule_view.php");
    } else {
        unset($_POST["id"]);
    }
}
?>


<head>
    <title>EKU Gurus - Update your class schedule</title>

    <link rel="stylesheet" href="styles.css"/>
</head>

<body>
<div id="studentIDSection">
    <div id="studentIDInput">
        <form action="index.php" method="post">
            <label for="studentID" class="inputElement">Student ID: </label>
            <input autofocus name="id" id="studentID" type="text" class="inputElement" maxlength="9"/>
            <input type="submit" class="submitButton"/>
        </form>
    </div>
</div>
</body>
