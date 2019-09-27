<head>
    <title>EKU Gurus - Update your class schedule</title>

    <link rel="stylesheet" href="styles.css"/>

    <!--  Flatpicker Styles  -->
    <link rel="stylesheet" href="node_modules/flatpickr/dist/flatpickr.css"/>
</head>

<?php
if (isset($_POST["id"])) {
    // get id from db
    // show class schedule page
    ?>
    <body>
        <div class="classRegion">
            <h1>Add a Class</h1>
            <div>
                <form method="post" action="index.php">
                    <table>
                        <tr>
                            <td id="firstColumn">
                                <label for="className" class="classInfoElement">Class Name: </label>
                            </td>
                            <td colspan="3">
                                <input type="text" id="className" class="classInfoElement"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="startTime" class="classInfoElement">Start: </label>
                            </td>
                            <td>
                                <input id="startTime" class="classInfoElement" value="12:00  PM"/>
                            </td>

                            <td>
                                <label for="endTime" class="classInfoElement">End: </label>
                            </td>
                            <td>
                                <input id="endTime" class="classInfoElement" value="12:00  PM"/>
                            </td>
                        </tr>
                    </table>
                    <input type="submit" value="Add Class" id="addClassButton" class="submitButton"/>
                </form>
            </div>
        </div>

        <br/><hr/><br/>

        <h1>Your Class Schedule</h1> <br/>

        <div class="classRegion">
            <table>
                <tr>
                    <th>Name</th>
                    <th>Start Time</th>
                    <th>End Time</th>
                </tr>
                <tr>
                    <td id="classListName"><p class="classInfoElement">MyClass1</p></td>
                    <td><p class="classInfoElement">10:10 am</p></td>
                    <td><p class="classInfoElement">11:00 am</p></td>
                </tr>
            </table>
        </div>
    </body>

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

    <?php
}
else {
    ?>

    <body>
        <div id="studentIDSection">
            <div id="studentIDInput">
                <form action="index.php" method="post">
                    <label for="studentID" class="inputElement">Student ID: </label>
                    <input name="id" id="studentID" type="text" class="inputElement" maxlength="9"/>
                    <input type="submit" class="submitButton"/>
                </form>
            </div>
        </div>
    </body>

    <?php
}
