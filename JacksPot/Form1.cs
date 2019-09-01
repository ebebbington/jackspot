using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace JacksPot
{
    public partial class Form1 : Form
    {
        /* Contents: PLEASE READ - Organised in terms of first to last actions
         * 0:
         * 1: Setting Global Data (Sound, Variables, Array) >>>>>>>>>>>>>>  [Line 30]
         * 2: When the form loads (Picture, Array and Sound Content)  >>>>  [Line 60]
         * 3: When Exit button is clicked  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 142]
         * 4: Timer for Exit  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 128]
         * 5: When Raise Bet is clicked  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 159]
         * 6: When Lower Bet is clicked  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 181]
         * 7: When Mute is clicked  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 198]
         * 8: When Gamble is clicked  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  [Line 217]
         * 9: When Spin is clicked (Checking Scenarios)  >>>>>>>>>>>>>>>>>  [Line 234]
         * 10: Timer for Spin (picture box content, picturebox rewards)  >  [Line 260]
         */

        //1.0 - Setting the sound
        SoundPlayer cantinasong;

        //1.1 - setting the variables for how much credits the user has, how much they have betted and for later use - the rng
        int bet = 1;
        int credits = 10;
        bool soundon = true;
        int timer = 2;
        int winnings = 0;
        bool gamblecredits = false;
        int creditsgamble = 0;
        int spinamount = 0;
        bool spinclick = false;

        //1.2 - Setting the array
        Bitmap Car = Properties.Resources.Car;
        Bitmap Cat = Properties.Resources.Cat;
        Bitmap Painting = Properties.Resources.Painting;
        Bitmap Table = Properties.Resources.Table;
        Bitmap TV = Properties.Resources.TV;
        Bitmap Xbox = Properties.Resources.Xbox;
        Bitmap Pot = Properties.Resources.Pot;
        Bitmap[] pics = new Bitmap[16];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //2.0 - I am setting the picture boxes to show these pictures as soon as the user loads the form
            pictureBox1.BackgroundImage = Properties.Resources.Cat;
            pictureBox2.BackgroundImage = Properties.Resources.Cat;
            pictureBox3.BackgroundImage = Properties.Resources.Cat;
            pictureBox4.BackgroundImage = Properties.Resources.Car;
            pictureBox5.BackgroundImage = Properties.Resources.Car;
            pictureBox6.BackgroundImage = Properties.Resources.Car;
            pictureBox7.BackgroundImage = Properties.Resources.Painting;
            pictureBox8.BackgroundImage = Properties.Resources.Painting;
            pictureBox9.BackgroundImage = Properties.Resources.Painting;
            pictureBox10.BackgroundImage = Properties.Resources.Table;
            pictureBox11.BackgroundImage = Properties.Resources.Table;
            pictureBox12.BackgroundImage = Properties.Resources.Table;
            pictureBox13.BackgroundImage = Properties.Resources.TV;
            pictureBox14.BackgroundImage = Properties.Resources.TV;
            pictureBox15.BackgroundImage = Properties.Resources.TV;
            pictureBox16.BackgroundImage = Properties.Resources.Xbox;
            pictureBox17.BackgroundImage = Properties.Resources.Xbox;
            pictureBox18.BackgroundImage = Properties.Resources.Xbox;
            pictureBox19.BackgroundImage = Properties.Resources.Pot;
            pictureBox20.BackgroundImage = Properties.Resources.Pot;
            pictureBox21.BackgroundImage = Properties.Resources.Pot;
            sound.BackgroundImage = Properties.Resources.SoundIcon;
            arrow.BackgroundImage = Properties.Resources.arrownew;
            leftbox.BackgroundImage = Properties.Resources.Car;
            middlebox.BackgroundImage = Properties.Resources.Painting;
            rightbox.BackgroundImage = Properties.Resources.Pot;
            //2.1 - I now edit these to make it stretch which means the picture will fit the picture box perfectly
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox13.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox14.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox15.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox16.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox17.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox18.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox19.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox20.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox21.BackgroundImageLayout = ImageLayout.Stretch;
            sound.BackgroundImageLayout = ImageLayout.Stretch;
            arrow.BackgroundImageLayout = ImageLayout.Stretch;
            leftbox.BackgroundImageLayout = ImageLayout.Stretch;
            middlebox.BackgroundImageLayout = ImageLayout.Stretch;
            rightbox.BackgroundImageLayout = ImageLayout.Stretch;
            middlebox.BorderStyle = BorderStyle.Fixed3D;
            leftbox.BorderStyle = BorderStyle.Fixed3D;
            rightbox.BorderStyle = BorderStyle.Fixed3D;

            //2.2 - Numbering the contents of the array
            pics[0] = new Bitmap(Properties.Resources.Car);
            pics[1] = new Bitmap(Properties.Resources.Car);
            pics[2] = new Bitmap(Properties.Resources.Car);
            pics[3] = new Bitmap(Properties.Resources.Cat);
            pics[4] = new Bitmap(Properties.Resources.Cat);
            pics[5] = new Bitmap(Properties.Resources.Cat);
            pics[6] = new Bitmap(Properties.Resources.Painting);
            pics[7] = new Bitmap(Properties.Resources.Painting);
            pics[8] = new Bitmap(Properties.Resources.Painting);
            pics[9] = new Bitmap(Properties.Resources.Table);
            pics[10] = new Bitmap(Properties.Resources.Table);
            pics[11] = new Bitmap(Properties.Resources.TV);
            pics[12] = new Bitmap(Properties.Resources.TV);
            pics[13] = new Bitmap(Properties.Resources.Xbox);
            pics[14] = new Bitmap(Properties.Resources.Xbox);
            pics[15] = new Bitmap(Properties.Resources.Pot);

            //2.3 - Setting the sound and playing it
            cantinasong = new SoundPlayer(Properties.Resources.StarWarsCantinaSong);
            cantinasong.Play();

            //2.4 - setting gifs
            pictureBox22.Enabled = true;
            pictureBox22.Visible = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //3.0 - this is what happens when the user clicks the "Exit" button
            Application.Exit();
        }

        private void exittimer_Tick(object sender, EventArgs e)
        {
            //4.0 - Setting the timer when it ticks to reduce var timer and when it reaches 0 game will close
            lowerbet.Enabled = false;
            raisebet.Enabled = false;
            spin.Enabled = false;
            gamble.Enabled = false;
            timer--;

            if (timer == 0)
            {
                Application.Exit();
            }
        }

        private void raisebet_Click(object sender, EventArgs e)
        {
            //5.0 - this will increase the "Bet" by 1 and reduce credits by 1 then display this
            if (credits > 0)
            {
                bet++;
                label14.Text = Convert.ToString(bet);
            }
            else
            {
                credits = 0;
                MessageBox.Show("Out of credits.");
            }

            if (bet > credits)
            {
                MessageBox.Show("You are betting more than you currently have. Your bet is now the same as your credits.");
                bet = credits;
                label14.Text = Convert.ToString(bet);
            }
        }

        private void lowerbet_Click(object sender, EventArgs e)
        {
            //6.0 - This will decrease the bet and display only if bet will always => 1
            if (bet > 0)
            {
                bet--;
                label14.Text = Convert.ToString(bet);
            }
            else //6.1 - This happens if someone tried to lower bet below 1. No one will ever be able to bet less than 1
            {
                MessageBox.Show("Cannot bet a negative number of bets.");
                bet = bet + 1;
                label14.Text = Convert.ToString(bet);
            }
        }

        private void sound_Click(object sender, EventArgs e)
        {
            //7.0 - If the sound icon is shown, then change icon to mute sound icon and mute sound when mute button is pressed
            if (soundon == true)
            {
                sound.BackgroundImage = Properties.Resources.MuteSoundIcon;
                sound.BackgroundImageLayout = ImageLayout.Stretch;
                soundon = false;
                cantinasong.Stop();
            }
            else//7.1 - If the mute sound icon is shown, then change icon to sound icon and play sound
            {
                sound.BackgroundImage = Properties.Resources.SoundIcon;
                sound.BackgroundImageLayout = ImageLayout.Stretch;
                soundon = true;
                cantinasong.Play();
            }
        }

        private void gamble_Click(object sender, EventArgs e)
        {
            //8.0 - If the gamble button is clicked, it activates or deactivates booleon 'gamblecredits'
            if (gamblecredits == false)
            {
                gamblecredits = true;
                bet = credits;
                label14.Text = Convert.ToString(bet);
                gamble.ForeColor = Color.Red;
            }
            else
            {
                gamblecredits = false;
                gamble.ForeColor = Color.Black;
            }
        }

        private void spin_Click(object sender, EventArgs e)
        {
            spinclick = true;
            //9.2 - This is when the user can actually spin and the bet is not a number that cant be used
            if (bet >= 1)
            {
                //9.3 - activates the timer
                spintimer.Enabled = true;

                //9.4 credits the user based on if gamble is active or not
                if (gamblecredits == true)
                {
                    creditsgamble = credits;
                    credits = credits - credits;
                    label13.Text = Convert.ToString(credits);
                    bet = 0;
                    label14.Text = Convert.ToString(bet);
                }

                if (gamblecredits == false)
                {
                    credits = credits - bet;
                    label13.Text = Convert.ToString(credits);
                }

                if (spinclick == true)
                {
                    lowerbet.Enabled = false;
                    raisebet.Enabled = false;
                    spin.Enabled = false;
                    gamble.Enabled = false;
                }
            }
        }

        private void spintimer_Tick(object sender, EventArgs e)
        {
            //10.1 - Only runs if timer is enabled which happens when the spin buton is rightfully clicked
            if (spintimer.Enabled == true)
            {
                //10.2 - When the timer starts, it fills the picture boxes
                Random rng = new Random(Environment.TickCount);
                spinamount = rng.Next(0, 16);
                leftbox.BackgroundImage = pics[spinamount];
                leftbox.BackgroundImageLayout = ImageLayout.Stretch;

                spinamount = rng.Next(0, 16);
                middlebox.BackgroundImage = pics[spinamount];
                middlebox.BackgroundImageLayout = ImageLayout.Stretch;

                spinamount = rng.Next(0, 16);
                rightbox.BackgroundImage = pics[spinamount];
                rightbox.BackgroundImageLayout = ImageLayout.Stretch;

                //10.3 - adds 1 each time a picture displays after 1 the interval will increase by 10 to make the timer slow down each second
                spintimer.Interval += 10;
            }

            //10.4 - and to turn it off but also the rewards section
            if (spintimer.Interval >= 280)
            {
                spintimer.Enabled = false;
                spintimer.Interval = 10;
                spinclick = false;
                if (spinclick == false)
                {
                    spin.Enabled = true;
                    lowerbet.Enabled = true;
                    raisebet.Enabled = true;
                    gamble.Enabled = true;
                }

                if (gamblecredits == false)
                {
                    //10.4.1 - This will close the game if the user reaches 0 credits and doesnt win
                    if (leftbox.BackgroundImage != middlebox.BackgroundImage)
                    {
                        Thread.Sleep(2000);
                        if (credits <= 0)
                        {

                            MessageBox.Show("Out of credits, game is closing in 2 seconds");
                            exittimer.Enabled = true;
                            exittimer.Start();
                        }
                    }
                    // 10.5 - Depending on what icons show, the user will have credits deposited into their own credits
                    if (leftbox.BackgroundImage == middlebox.BackgroundImage)
                    {
                        if (middlebox.BackgroundImage == rightbox.BackgroundImage)
                        {
                            if (leftbox.BackgroundImage == Cat)
                            {
                                winnings = bet * 2;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Car)
                            {
                                winnings = bet * 1;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Painting)
                            {
                                winnings = bet * 5;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Table)
                            {
                                winnings = bet * 10;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == TV)
                            {
                                winnings = bet * 25;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Xbox)
                            {
                                winnings = bet * 50;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Pot)
                            {
                                winnings = bet * 100;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }
                        }
                    }
                }

                if (gamblecredits == true)
                {
                    //10.5.1 - This section will close the game if the user reaches 0 credits and doesnt win
                    if (leftbox.BackgroundImage != middlebox.BackgroundImage)
                    {
                        Thread.Sleep(1000);
                        if (credits == 0)
                        {
                            MessageBox.Show("Out of credits, game is closing in 2 seconds");
                            exittimer.Enabled = true;
                            exittimer.Start();
                        }
                    }
                    // 10.6 - Depending on what icons show, the user will have credits deposited into their own credits
                    if (leftbox.BackgroundImage == middlebox.BackgroundImage)
                    {
                        if (middlebox.BackgroundImage == rightbox.BackgroundImage)
                        {
                            if (leftbox.BackgroundImage == Cat)
                            {
                                winnings = creditsgamble * 2;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Car)
                            {
                                winnings = creditsgamble * 1;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Painting)
                            {
                                winnings = creditsgamble * 5;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Table)
                            {
                                winnings = creditsgamble * 10;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == TV)
                            {
                                winnings = creditsgamble * 25;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Xbox)
                            {
                                winnings = creditsgamble * 50;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }

                            if (leftbox.BackgroundImage == Pot)
                            {
                                winnings = creditsgamble * 10000;
                                credits = credits + winnings;
                                label13.Text = Convert.ToString(credits);
                                MessageBox.Show("You won!" + " " + winnings + " Credits have been deposited.");
                            }
                        }
                    }
                }
            }
        }
    }
}