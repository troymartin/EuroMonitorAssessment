using System;

//Credit: https://www.c-sharpcorner.com/uploadfile/cbragg/console-application-waitbusy-spin-animation/

namespace Turfsport.Automation.LoadTest
{
    public static class SpinAnimation
    {
        //spinner background thread
        private static System.ComponentModel.BackgroundWorker Spinner = null;

        //starting position of spinner changes to current position on start
        private static int _spinnerPosition = 25;

        //pause time in milliseconds between each character in the spin animation
        private static int _spinWait = 25;

        //field and property to inform client if spinner is currently running
        private static bool _isRunning;

        public static bool IsRunning => _isRunning;

        /// <summary>
        /// Worker thread factory
        /// </summary>
        /// <returns>background worker thread</returns>
        private static System.ComponentModel.BackgroundWorker InitialiseBackgroundWorker()
        {
            System.ComponentModel.BackgroundWorker obj = new System.ComponentModel.BackgroundWorker();
            //allow cancellation to be able to stop the spinner
            obj.WorkerSupportsCancellation = true;
            //anonymous method for background thread"s DoWork event
            obj.DoWork += delegate
            {
                //set the spinner position to the current console position
                _spinnerPosition = Console.CursorLeft;
                //run animation unless a cancellation is pending
                while (!obj.CancellationPending)
                {
                    //characters to iterate through during animation
                    var spinChars = new string[] { "|", "/", "-", "\\" };
                    //iterate through animation character array
                    foreach (var spinChar in spinChars)
                    {
                        //reset the cursor position to the spinner position
                        Console.CursorLeft = _spinnerPosition;
                        //write the current character to the console
                        Console.Write(spinChar);
                        //pause for smooth animation - set by the start method
                        System.Threading.Thread.Sleep(_spinWait);
                    }
                }
            };
            return obj;
        }

        /// <summary>
        /// Start the animation
        /// </summary>
        /// <param name="spinWait">wait time between spin steps in milliseconds</param>
        public static void Start(int spinWait)
        {
            if (Spinner == null)
            {
                Spinner = InitialiseBackgroundWorker();
                //Set the running flag
                _isRunning = true;
                //process spinwait value
                SpinAnimation._spinWait = spinWait;
                //start the animation unless already started
                if (!Spinner.IsBusy)
                    Spinner.RunWorkerAsync();
                else throw new InvalidOperationException("Cannot start spinner whilst spinner is already running");
            }
        }

        /// <summary>
        /// Overloaded Start method with default wait value
        /// </summary>
        public static void Start() { Start(25); }
        /// <summary>
        /// Stop the spin animation
        /// </summary>

        public static void Stop()
        {
            //Stop the animation
            Spinner.CancelAsync();
            //wait for cancellation to complete
            while (Spinner.IsBusy) System.Threading.Thread.Sleep(100);
            //reset the cursor position
            
            //set the running flag
            _isRunning = false;
        }
    }
}
