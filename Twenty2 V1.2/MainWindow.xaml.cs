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
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

namespace Twenty2_V1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        playMusic playMusic = new playMusic();

        private void Openfile_click(object sender, RoutedEventArgs e)
        {
            string strfile = playMusic.fileFind();

            Filedisplay.Text = $"Currently playing {strfile}";
        }

        #region Second Button Clicked

        private void SecondButton_click(object sender, EventArgs e)
        {

            if (playMusic.BreakButtonState == 0)
            {
                SecondButtonTypeSwitch.Content = "Minutes";
                playMusic.BreakButtonState = 1;
                playMusic.breakButtonSwitchMinutes();
            }

            else
            {

                if (playMusic.BreakButtonState == 2)
                {
                    SecondButtonTypeSwitch.Content = "Seconds";
                    playMusic.BreakButtonState = 0;
                    playMusic.breakButtonSwitchSeconds();
                }
                else
                {


                    if (playMusic.BreakButtonState == 1)
                    {
                        SecondButtonTypeSwitch.Content = "Hours";
                        playMusic.BreakButtonState = 2;
                        playMusic.breakButtonSwitchHours();
                    }
                }
            }
        }

        #endregion

        #region First Button Clicked

        private void Button_click(object sender, EventArgs e)
        {

            if (playMusic.ButtonState == 1)
            {
                ButtonTypeSwitch.Content = "Hours";
                playMusic.ButtonState = 2;
                playMusic.buttonSwitchHours();
            }

            else
            {

                if (playMusic.ButtonState == 2)
                {
                    ButtonTypeSwitch.Content = "Seconds";
                    playMusic.ButtonState = 0;
                    playMusic.buttonSwitchSeconds();
                }
                else
                {
                    if (playMusic.ButtonState == 0)
                    {
                        ButtonTypeSwitch.Content = "Minutes";
                        playMusic.ButtonState = 1;
                        playMusic.buttonSwitchMinutes();
                    }
                }
            }
        }

        #endregion


        #region On/Off Button

        private void On_click(object sender, EventArgs e)
        {
            if (playMusic.on == true)
            {
                this.OnButton.Content = "On";
                playMusic.on = false;
                playMusic.onTimer();

            }
            else
            {
                this.OnButton.Content = "Off";
                playMusic.on = true;
                playMusic.onTimer();
            }
        }

        #endregion

        private void ApplyButton_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AllowedTime.Text))
            {
                return;
            }
            else if(string.IsNullOrEmpty(AllowedBreakTime.Text))
            {
                return;
            }
            else
            {
                /*
                playMusic.TimeAllowed = int.Parse(AllowedTime.Text);
                playMusic.MultiplyFactor = int.Parse(AllowedBreakTime.Text);
                playMusic.setTimer(playMusic.TimeAllowed, playMusic.MultiplyFactor);
                */
                playMusic.setTimer(int.Parse(AllowedTime.Text));
            }
            /*
            if (string.IsNullOrEmpty(AllowedBreakTime.Text))
            {
                return;
            }
            else
            {

                playMusic.setTimer();
            }
            */
        }

        public MainWindow()
        {
            InitializeComponent();

            #region Defaults

            playMusic playMusic = new playMusic();

            //playMusic.BreakMultiplyFactor = 1000;
            //playMusic.MultiplyFactor = 60000;
            playMusic.breakButtonSwitchSeconds();
            playMusic.buttonSwitchSeconds();

            playMusic.ButtonState = 1;
            playMusic.BreakButtonState = 0;

            playMusic.TimeAllowed = 20;
            playMusic.BreakTime = 20;

            playMusic.file = new Uri(@"C:\Users\seabe\Music\Tobu - Candyland.mp3");

            playMusic.on = true;

            #endregion

            playMusic.setTimer(playMusic.TimeAllowed);

            #region Un-Minimize

            myIcon = new NotifyIcon();
            //myIcon.Icon = new System.Drawing.Icon(@"C:\Seabert's Visual Studio\TwentyTwo v1.1\Icon test.ico");

            myIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(doubleclick);

            #endregion

        }

        #region Minimize

        private NotifyIcon myIcon;

        void doubleclick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void statechange(object sender, EventArgs e)
        {
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

        private void checkElapsed()
        {
            while (true)
            {
                if (playMusic.elapsedBool == true)
                {
                    playMusic.media.Open(playMusic.file);
                }
            }
        }

    }
}
