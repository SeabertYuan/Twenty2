using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Forms;

namespace Twenty2_V1._2
{
    class playMusic
    {
        public int timeAllowed { get; set; }
        public int breakTime { get; set; }
        //tells whether it should wait seconds, hours, or minutes before playing music
        public int multiplyFactor { get; set; }
        public int buttonState { get; set; }
        public int breakButtonState { get; set; }
        public static bool on { get; set; }
        public MediaPlayer media = new MediaPlayer();

        //creates new dispatcher timer
        public DispatcherTimer twentyDispatcherTimer = new DispatcherTimer();

        #region Timer
        //Dispatcher Timer
        public void setTwentyTimer()
        {
            //Hour Minute or Second
            if(multiplyFactor == 1)
            {
                twentyDispatcherTimer.Interval = new TimeSpan(0, timeAllowed, 0);
            }
            else if(multiplyFactor == 2)
            {
                twentyDispatcherTimer.Interval = new TimeSpan(timeAllowed, 0, 0);
            }
            else if(multiplyFactor == 0)
            {
                twentyDispatcherTimer.Interval = new TimeSpan(0,0,timeAllowed);
            }
            twentyDispatcherTimer.Tick += new EventHandler(twentyTimer_Tick);
        }
        //Triggered when event happens
        public void twentyTimer_Tick(object sender, EventArgs e)
        {
            if (on)
            {
                breakTimer();
                media.Open(interfaceClass.file);
                media.Play();
            }
            else
            {
                Console.WriteLine("Feature is currently paused");
            }
        }
        //Asycn break
        public async void breakTimer()
        {
            if(on)
            {
                twentyDispatcherTimer.Stop();
                await Task.Delay(breakTime * interfaceClass.breakMultiplyFactor);
                media.Stop();
                twentyDispatcherTimer.Start();
            }

        }
        #endregion

    }
    class interfaceClass
    {
        //tells whether the break time should be seconds, minutes, or hours
        public static int breakMultiplyFactor { get; set; }
        public static Uri file { get; set; }
        OpenFileDialog dialog = new OpenFileDialog();
        public string disFile { get; set; }

        #region fileGet

        public string fileFind()
        {
            int disFileCount = 0;

            dialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            dialog.ShowDialog();
            if(dialog.FileName != null)
                file = new Uri(dialog.FileName);

            string disFile = file.ToString();

            for(int i = disFile.Length - 1; i >= 0; i--)
            {
                disFileCount++;

                if (disFile[i].Equals('/'))
                {
                    break;
                }
            }
            return disFile.Substring(disFile.Length - disFileCount + 1);
        }

        #endregion

        #region Hour Minute Buttons

        public void breakButtonSwitchSeconds()
        {
            breakMultiplyFactor = 1000;
        }
        public void breakButtonSwitchMinutes()
        {
            breakMultiplyFactor = 60000;
        }
        public void breakButtonSwitchHours()
        {
            breakMultiplyFactor = 3600000;
        }

        #endregion
    }
}
