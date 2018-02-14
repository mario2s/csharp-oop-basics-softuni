﻿using System;
using System.Linq;

class DateModifier
{
    private int daysDiff;

    public int DaysDiff
    {
        get { return daysDiff; }
        set { daysDiff = value; }
    }

    public int CalculateDiff(string firstInput, string secondInput)
    {
        var firstArgs = firstInput.Split().Select(int.Parse).ToArray();
        var firstDate = new DateTime(firstArgs[0], firstArgs[1], firstArgs[2]);

        var secondArgs = secondInput.Split().Select(int.Parse).ToArray();
        var secondDate = new DateTime(secondArgs[0], secondArgs[1], secondArgs[2]);

        this.DaysDiff = Math.Abs((int)(firstDate.Date - secondDate.Date).TotalDays);

        return this.DaysDiff;
    }
}
