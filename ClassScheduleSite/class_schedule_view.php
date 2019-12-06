<?php

require_once('DB.php');
session_start();

if (isset($_POST['className']) && isset($_POST['startTime']) && isset($_POST['endTime']) && isset($_POST['day'])) {
    $className = $_POST['className'];

    $start = $_POST['startTime'];
    $end = $_POST['endTime'];

    // parse hour and minute from time strings
    $split = explode(':', $start);
    $startHour = $split[0];
    $secondHalf = explode('  ', $split[1]);
    $startMinute = $secondHalf[0];
    if ($secondHalf[1] == 'PM') {
        $startHour = $startHour % 12 + 12;
    }
    $split = explode(':', $end);
    $endHour = $split[0];
    $secondHalf = explode('  ', $split[1]);
    $endMinute = $secondHalf[0];
    if ($secondHalf[1] == 'PM') {
        $endHour = $endHour % 12 + 12;
    }

    $days = $_POST['day'];

    // check if start time is before end time
    if ($startHour < $endHour || ($startHour == $endHour && $startMinute < $endMinute)) {
        // save class event to database for each weekday
        foreach ($days as $day) {
            try {
                $addClass = DB::get()->prepare("INSERT INTO scheduleevent (studentID, eventType, startHour, startMinute, endHour, endMinute, `day`, eventName, ScheduleID)
                                                      VALUES ({$_SESSION["id"]}, 0, $startHour, $startMinute, $endHour, $endMinute, $day, :className, (SELECT ScheduleID FROM CurrentSchedule))");
                $addClass->bindParam("className", $className);
                $addClass->execute();
            }
            catch (Exception $e) {
                echo "Insert new class failed: " . $e->getMessage();
            }
        }
    }

    unset($_POST['className']);
}

?>

<head>
    <title><?php echo $_SESSION['name'] . " - "?>Class Schedule</title>

    <link rel="stylesheet" href="styles.css"/>

    <!--  Flatpicker Styles  -->
    <link rel="stylesheet" href="node_modules/flatpickr/dist/flatpickr.css"/>
</head>

<body>
<div class="nameRegion">
    <h3><?php echo $_SESSION['name']?></h3>
</div>
<div class="classRegion">
    <h1>Add a Class</h1>
    <div>
        <form method="post" action="class_schedule_view.php">
            <table>
                <tr>
                    <td id="firstColumn">
                        <label for="className" class="classInfoElement">Class Name: </label>
                    </td>
                    <td colspan="3">
                        <input name="className" type="text" id="className" class="classInfoElement"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="startTime" class="classInfoElement">Start: </label>
                    </td>
                    <td>
                        <input name="startTime" id="startTime" class="classInfoElement" value="12:00  PM"/>
                    </td>

                    <td>
                        <label for="endTime" class="classInfoElement">End: </label>
                    </td>
                    <td>
                        <input name="endTime" id="endTime" class="classInfoElement" value="12:00  PM"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="days" class="classInfoElement">Days: </label>
                    </td>
                    <td colspan="3">
                        <fieldset id="group1" class="classInfoElement">
                            <input type="checkbox" id="check1" value="0" name="day[]" class="checkBox"><label for="check1" class="checkLabel">Monday</label>
                            <input type="checkbox" id="check2" value="1" name="day[]" class="checkBox"><label for="check2" class="checkLabel">Tuesday</label>
                            <input type="checkbox" id="check3" value="2" name="day[]" class="checkBox"><label for="check3" class="checkLabel">Wednesday</label>
                            <input type="checkbox" id="check4" value="3" name="day[]" class="checkBox"><label for="check4" class="checkLabel">Thursday</label>
                            <input type="checkbox" id="check5" value="4" name="day[]" class="checkBox"><label for="check5" class="checkLabel">Friday</label>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <input type="submit" value="Add Class" id="addClassButton" class="submitButton"/>
        </form>
    </div>
</div>

<!--  Flatpickr  -->
<script src="node_modules/flatpickr/dist/flatpickr.js"></script>

<script>
    flatpickr("#startTime", {
        enableTime: true,
        noCalendar: true,
        dateFormat: "h:i  K",
        minDate: "7:00",
        maxDate: "22:00",
        time_24hr: false
    });

    flatpickr("#endTime", {
        enableTime: true,
        noCalendar: true,
        dateFormat: "h:i  K",
        minDate: "7:00",
        maxDate: "22:00",
        time_24hr: false
    })
</script>

<br/>
<hr/>
<br/>

<h1>Your Class Schedule</h1> <br/>

<div class="classRegion">
    <table>
        <tr>
            <th>Name</th>
            <th>Start Time</th>
            <th>End Time</th>
            <th>Day</th>
        </tr>

        <?php
        // load class schedule into the table
        try {
            $getClass = DB::get()->prepare("SELECT startHour, startMinute, endHour, endMinute, `day`, eventName FROM ScheduleEvent WHERE studentID = {$_SESSION["id"]}");
            $getClass->execute();

            foreach ($getClass->fetchAll() as $result) {
                // build time strings
                $startHour = $result['startHour'];
                $startMinute = $result['startMinute'];
                $startString = ($startHour > 12 ? $startHour - 12 : $startHour) . ":" . ($startMinute < 10 ? "0$startMinute" : $startMinute) . "  " . ($startHour >= 12 ? "PM" : "AM");
                $endHour = $result['endHour'];
                $endMinute = $result['endMinute'];
                $endString = ($endHour > 12 ? $endHour - 12 : $endHour) . ":" . ($endMinute < 10 ? "0$endMinute" : $endMinute) . "  " . ($endHour >= 12 ? "PM" : "AM");

                // get other information
                $className = $result['eventName'];
                $day = $result['day'];

                $dayLabels = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];

                echo "
                    <tr>
                        <td id=\"classListName\"><p class=\"classInfoElement\">$className</p></td>
                        <td><p class=\"classInfoElement\">$startString</p></td>
                        <td><p class=\"classInfoElement\">$endString</p></td>
                        <td><p class=\"classInfoElement\">$dayLabels[$day]</p></td>
                    </tr>
                ";
            }
        }
        catch (Exception $e) {
            echo "Retrieve class schedule failed: " . $e->getMessage();
        }

        ?>
    </table>
</div>
</body>



