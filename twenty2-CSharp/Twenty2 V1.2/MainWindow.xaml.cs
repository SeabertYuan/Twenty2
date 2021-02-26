using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading;

namespace Twenty2_V1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static playMusic playMusic = new playMusic();
        static interfaceClass interfaceClass = new interfaceClass();

        //Makes the label readable on the UI
        private void Openfile_click(object sender, RoutedEventArgs e)
        {
            string strfile = interfaceClass.fileFind();

            Filedisplay.Text = $"Currently playing {strfile}";
        }

        #region Button Text Updates
        //updates the text on the break button
        public void updateBreakButton()
        {
            if (secondButtonTypeSwitch != null)
            {
                //if currently on seconds
                if (playMusic.breakButtonState == 0)
                    secondButtonTypeSwitch.Content = "Seconds";
                else
                {
                    //if currently on hours
                    if (playMusic.breakButtonState == 2)
                        secondButtonTypeSwitch.Content = "Hours";
                    else
                    {
                        //if currently on minutes
                        if (playMusic.breakButtonState == 1)
                            secondButtonTypeSwitch.Content = "Minutes";
                    }
                }
            }
        }
        //updates the text on the time button
        public void updateButton()
        {
            if (buttonTypeSwitch != null)
            {
                //if currently on seconds
                if (playMusic.buttonState == 0)
                     buttonTypeSwitch.Content = "Seconds";
                else
                {
                    //if currently on hours
                    if (playMusic.buttonState == 2)
                        buttonTypeSwitch.Content = "Hours";
                    else
                    {
                        //if currently on minutes
                        if (playMusic.buttonState == 1)
                            buttonTypeSwitch.Content = "Minutes";
                    }
                }
            }
        }
        #endregion

        #region Second Button Clicked

        private void SecondButton_click(object sender, EventArgs e)
        {
            //if currently on seconds
            if (playMusic.breakButtonState == 0)
            {
                playMusic.breakButtonState = 1;
                interfaceClass.breakButtonSwitchMinutes();
            }
            else
            {
                //if currently on hours
                if (playMusic.breakButtonState == 2)
                {
                    playMusic.breakButtonState = 0;
                    interfaceClass.breakButtonSwitchSeconds();
                }
                else
                {
                    //if currently on minutes
                    if (playMusic.breakButtonState == 1)
                    {
                        playMusic.breakButtonState = 2;
                        interfaceClass.breakButtonSwitchHours();
                    }
                }
            }
            updateBreakButton();
        }
        #endregion

        #region First Button Clicked

        private void Button_click(object sender, EventArgs e)
        {
            //if currently on minutes
            if (playMusic.buttonState == 1)
            {
                playMusic.buttonState = 2;
                playMusic.multiplyFactor = 2;
            }

            else
            {
                //if currently on hours
                if (playMusic.buttonState == 2)
                {
                    playMusic.buttonState = 0;
                    playMusic.multiplyFactor = 0;
                }
                else
                {
                    //if currently on seconds
                    if (playMusic.buttonState == 0)
                    {
                        playMusic.buttonState = 1;
                        playMusic.multiplyFactor = 1;
                    }
                }
            }
            updateButton();
        }
        #endregion


        #region On/Off Button

        private void On_click(object sender, EventArgs e)
        {
            if(playMusic.on)
            {
                this.OnButton.Content = "On";
                playMusic.on = false;
                try
                {
                    timeThread.Abort();
                }
                catch(ThreadAbortException)
                {
                    Console.WriteLine("Error aborting thread...");
                }
                playMusic.twentyDispatcherTimer.Stop();
            }
            else if(!playMusic.on)
            {
                this.OnButton.Content = "Off";
                playMusic.on = true;
                timeThread = new Thread(threadSettings);
                timeThread.Start();
            }
        }
        #endregion

        private void ApplyButton_click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(AllowedTime.Text))
                playMusic.timeAllowed = int.Parse(AllowedTime.Text);
            if(!string.IsNullOrEmpty(AllowedBreakTime.Text))
                playMusic.breakTime = int.Parse(AllowedBreakTime.Text);
            if (!string.IsNullOrEmpty(AllowedTime.Text) || !string.IsNullOrEmpty(AllowedBreakTime.Text))
            {
                timeThread.Abort();
                timeThread = new Thread(threadSettings);
                updateBreakButton();
                updateButton();
                timeThread.Start();
            }
        }

        Thread timeThread;
        static Thread gui;
        public MainWindow()
        {
            gui = new Thread(InitializeComponent);

            //object
            playMusic playMusic = new playMusic();

            timeThread = new Thread(threadStartAction);
            timeThread.Start();

            #region Un-Minimize

            myIcon = new NotifyIcon();
            //temporarily disabled | Gets icon to display when minimized
            //myIcon.Icon = new System.Drawing.Icon(@"C:\Seabert's Visual Studio\TwentyTwo v1.1\Icon test.ico");
            myIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(click);
            #endregion
        }

        public void threadStartAction()
        {
            playMusic.on = true;
            //set file to Tobu-Candyland
            interfaceClass.file = new Uri(@"C:\Users\seabe\Music\Tobu - Candyland.mp3");
            interfaceClass.breakButtonSwitchSeconds();
            playMusic.multiplyFactor = 1; //seconds = 0, minutes = 1, hours = 2

            //for displaying button info
            playMusic.buttonState = 1;
            playMusic.breakButtonState = 0;

            //update text (doesn't work yet)
            updateButton();
            updateBreakButton();

            playMusic.timeAllowed = 20;
            playMusic.breakTime = 20;
            playMusic.setTwentyTimer();
            playMusic.twentyDispatcherTimer.Start();
        }
        public void threadSettings()
        {
            playMusic.twentyDispatcherTimer.Stop();
            playMusic.setTwentyTimer();
            playMusic.twentyDispatcherTimer.Start();
        }

        #region Minimize
        
        //initialize a notify icon
        private NotifyIcon myIcon;
        void click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void statechange(object sender, EventArgs e)
        {
            //if window is minimized
            if (this.WindowState == WindowState.Minimized)
            {
                myIcon.Visible = true;
                this.ShowInTaskbar = false;

                myIcon.BalloonTipTitle = "TwentyTwo Minimized";
                myIcon.BalloonTipText = "TwentyTwo is now minimized, click the icon to maximize.";
                myIcon.ShowBalloonTip(500);

            }

            else if (this.WindowState == WindowState.Normal)
            {
                myIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        #endregion

        #region Number Filter

        //Forces the text box to only allow numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion
    }
}
