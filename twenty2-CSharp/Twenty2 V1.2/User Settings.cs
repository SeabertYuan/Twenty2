using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

namespace Twenty2_V1._2
{
    class playMusic
    {
        public int timeAllowed { get; set; }
        public int breakTime { get; set; }
        public int multiplyFactor { get; set; }
        public int buttonState { get; set; }
        public int breakButtonState { get; set; }
        //public int BreakInterval { get; set; }
        private bool elapse = false;
        public static bool on { get; set; }
        //public bool elapsedBool;

        /* trying dispatcher timer
        public System.Timers.Timer aTimer;
        */
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
                elapse = true;
                breakTimer();
                media.Open(interfaceClass.file);
                media.Play();
            }
            else
            {
                Console.WriteLine("Feature is currently paused");
            }
        }

        public async void breakTimer()
        {
            if(on)
            {
                twentyDispatcherTimer.Stop();
                await Task.Delay(breakTime * interfaceClass.BreakMultiplyFactor);
                media.Stop();
                twentyDispatcherTimer.Start();
            }

        }
        /* trying dispatcher timer
        public void elapsed(MediaPlayer media)
        {
            this.media = media;

            aTimer.Stop();

            int BreakInterval = BreakTime * BreakMultiplyFactor;

            elapsedBool = true;

            //issue spot
            this.media.Play();

            Task.Delay(BreakInterval).Wait();

            media.Stop();
            media.Close();

            aTimer.Start();
        }

        public void setTimer(int TimeAllowed)
        {
            int Interval = TimeAllowed * MultiplyFactor;

            if (aTimer != null)
                aTimer.Interval = Interval;
            else
                aTimer = new System.Timers.Timer(Interval);

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        public void onTimer()
        {
            if (on == true)
            {
                //aTimer.Elapsed += OnTimedEvent;
                aTimer.Enabled = true;
            }
            else
            {
                aTimer.Enabled = false;
            }
        }

        //what happens when timer is done
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (on == true)
            {
                elapsed(media);
            }
            else
            {
                return;
            }
        }
        */
        #endregion

    }
    class interfaceClass
    {
        public static int BreakMultiplyFactor { get; set; }
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
            BreakMultiplyFactor = 1000;
        }
        public void breakButtonSwitchMinutes()
        {
            BreakMultiplyFactor = 60000;
        }
        public void breakButtonSwitchHours()
        {
            BreakMultiplyFactor = 3600000;
        }

        #endregion
        /*
        public void buttonSwitchSeconds()
        {
            MultiplyFactor = 1000;
        }
        public void breakButtonSwitchMinutes()
        {
            MultiplyFactor = 60000;
        }

        public void breakButtonSwitchHours()
        {
            MultiplyFactor = 3600000;
        }
        */
    }
}
