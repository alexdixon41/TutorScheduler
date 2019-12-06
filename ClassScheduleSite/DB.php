<?php

require_once('_config.php');

class DB
{
    private static $instance = null;

    public static function get()
    {
        global $DBhost, $DBdatabase, $DBuser, $DBpassword;

        if(self::$instance == null)
        {
            try
            {
                self::$instance = new PDO('mysql:host=' . $DBhost . ';dbname=' . $DBdatabase, $DBuser, $DBpassword);
            }
            catch(PDOException $e)
            {
                echo "Connection failed: " . $e->getMessage();
            }
        }
        return self::$instance;
    }
}