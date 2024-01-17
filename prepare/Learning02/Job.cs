using System;
public class Job //Job is the box that holds the variables down below.//
{                //Custom Data Types, When you create classes, you are really creating a new custom data type.//
    public string _company; //When you declare a variable of these types, it is like making a box that can hold that type of data, putting a label on the outside of the box with varibale name.//
    public string _jobTitle;
    public int _startYear;  //using double instead of int = float from Python//
    public int _endYear;
    public void Display()
    {
        Console.WriteLine($"{_jobTitle}, ({_company}), {_startYear}--{_endYear}");
    }
}