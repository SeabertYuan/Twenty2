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
        public int TimeAllowed { get; set; }
        public int BreakTime { get; set; }

        public int BreakMultiplyFactor { get; set; }
        public int MultiplyFactor { get; set; }
        public int ButtonState { get; set; }
        public int BreakButtonState { get; set; }
        //public int BreakInterval { get; set; }

        public bool on { get; set; }
        //public bool elapsedBool;
        public Uri file { get; set; }
        public string disFile { get; set; }

        /* trying dispatcher timer
        public System.Timers.Timer aTimer;
        */
        public MediaPlayer media = new MediaPlayer();
        
        OpenFileDialog dialog = new OpenFileDialog();

        public DispatcherTimer twentyDispatcherTimer = new DispatcherTimer();
        #region Methods and Functions

        #region Timer

        //Dispatcher Timer
        public void setTwentyTimer()
        {
            //Hour Minute or Second
            if(MultiplyFactor == 1)
            {
                twentyDispatcherTimer.Interval += new TimeSpan(0, TimeAllowed, 0);
            }
            else if(MultiplyFactor == 2)
            {
                twentyDispatcherTimer.Interval += new TimeSpan(TimeAllowed, 0, 0);
            }
            else if(MultiplyFactor == 0)
            {
                twentyDispatcherTimer.Interval = new TimeSpan(0,0,TimeAllowed);
            }
            twentyDispatcherTimer.Tick += new EventHandler(twentyTimer_Tick);
        }

        //Triggered when event happens
        public async void twentyTimer_Tick(object sender, EventArgs e)
        {
            media.Open(file);
            twentyDispatcherTimer.Stop();
            media.Play();
            await Task.Delay(BreakTime * BreakMultiplyFactor);
            media.Stop();
            media.Close();
            twentyDispatcherTimer.Start();
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

        #region fileGet

        public string fileFind()
        {
            int disFileCount = 0;

            dialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            dialog.ShowDialog();

            file = new Uri(dialog.FileName);

            string disFile = file.ToString();

            for (int i = disFile.Length - 1; i >= 0; i--)
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

        #endregion
    }
}
