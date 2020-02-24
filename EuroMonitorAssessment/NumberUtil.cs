using System;
using System.Collections.Generic;
using System.Text;
using Turfsport.Automation.LoadTest;

namespace EuroMonitorAssessment
{
    public static class NumberUtil
    {

        public static void Init()
        {

        }

        public static bool ProcessInput(string number, out string message,out int difference)
        {
            SpinAnimation.Start(spinWait: 250);
            var validNumber = int.TryParse(number, out var parseResult);
            difference = 0;
            if (!validNumber)
            {
                message = "Input is not a number";
                return false;
            }

            validNumber = parseResult < 5 && parseResult > 0;
            if (!validNumber)
            {
                message = "Input is greater than, equal to or less than 5";
                return false;
            }
            difference = 5 - parseResult;
            message = $"The difference between {number} and 5 is {(5 - parseResult).ToString()}";
            SpinAnimation.Stop();
            return true;
        }


    }
}
