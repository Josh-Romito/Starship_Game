/**********
 * 
 * Josh Romito
 * CP_220
 * Assignment 1
 * Starship Battle
 * March 2, 2017
 * 
 * 
 ************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Microsoft.VisualBasic;
using System.Reflection;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Starship_Visual
{
    public partial class Starship_Battle : Form
    {
        public Starship_Battle()
        {
            InitializeComponent();
            //calling method to load my custom font
            CustomFont();      
        }

        //variable of starship type to store player starship object
        private Starship GlobalPlayer;

        //variable of ordinance type to store player ordinance object
        private Ordinance GlobalPlayerAmmo;

        //variable  of Starship type to store enemy starship object
        private Starship GlobalEnemy;

        //variable of ordinace type to store enemy ordinance object
        private Ordinance GlobalEnemyAmmo;

        //button to create player ship
        private void createMyShip_Click(object sender, EventArgs e)
        {
            //checking which radio button is checked and creating the a starship based on only the string name input
            //then creating cruiser/destroyer ship, passing it the name from the starship and applying a default health
            //responsible for calling other methods that hide/display the corresponding controls and labels
            if (pCruiserRadio.Checked == true)
            {
                Lbl1.Visible = false;
                //taking in the name
                string p1Name = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of your ship: ", "Your ship name");
                createMyShip.Visible = false;
                grpBoxPlayer.Visible = false;
                //creating starship with only the name
                //Starship player_cruiser = new Starship(p1Name);   
                //creating cruiser object, passing in the starship name, and the default cruiser health
                Starship PlayerCruiser = new Cruiser(p1Name, Cruiser.cruiserHealth);
                playerStatsShow(PlayerCruiser);
                updatePlayerStats(PlayerCruiser);
                GlobalPlayer = PlayerCruiser;
                cruiserImg.Visible = true;
                resetBtn.Visible = true;
                extBtn.Visible = true;
            }
            else if (pDestroyerRadio.Checked == true)
            {
                Lbl1.Visible = false;
                //taking in the name
                string p1Name = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of your ship: ", "Your ship name");
                createMyShip.Visible = false;
                grpBoxPlayer.Visible = false;
                //creating starship with only the name
                //Starship player_destroyer = new Starship(p1Name);
                destroyerImg.Visible = true;
                //creating destroyer object, passing in the starship name, and the default destroyer health
                Destroyer PlayerDestroyer = new Destroyer(p1Name, Destroyer.destroyerHealth);
                playerStatsShow(PlayerDestroyer);
                updatePlayerStats(PlayerDestroyer);
                //assigning the created player ship, to the global player variable - so it can be used else where
                GlobalPlayer = PlayerDestroyer;
                resetBtn.Visible = true;
                extBtn.Visible = true;
            }
            else
            {
                MessageBox.Show("You are required to select a ship type! Try again.");
            }
        }
        
        //button to create enemy ship
        private void createEnemy_Click(object sender, EventArgs e)
        {
            // checking which radio button is checked and creating the a starship based on only the string name input
            //then creating cruiser/destroyer ship, passing it the name from the starship and applying a default health
            //responsible for calling other methods that hide/display the corresponding controls and labels
            if (enemyCruiserRadio.Checked == true)
            {
                Lbl2.Visible = false;
                //taking in the name
                string enemyName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the enemy ship: ", "Enemy ship name");
                createEnemy.Visible = false;
                grpBoxEnemy.Visible = false;
                //creating starship with only the name
                //Starship enemy_cruiser = new Starship(enemyName);
                e_CruiserImg.Visible = true;
                //creating cruiser object, passing in the starship name, and the default cruiser health
                Cruiser EnemyCruiser = new Cruiser(enemyName, Cruiser.cruiserHealth);
                enemyStatsShow(EnemyCruiser);
                updateEnemyStats(EnemyCruiser);
                //assigning the created enemy ship, to the global enemy variable - so it can be used else where
                GlobalEnemy = EnemyCruiser;
                resetBtn.Visible = true;
                extBtn.Visible = true;
            }
            else if (enemyDestroyerRadio.Checked == true)
            {
                Lbl2.Visible = false;
                //taking in the name
                string enemyName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the enemy ship: ", "Enemy ship name");
                createEnemy.Visible = false;
                grpBoxEnemy.Visible = false;
                //creating starship with only the name
                //Starship enemy_destroyer = new Starship(enemyName);
                e_DestroyerImg.Visible = true;
                //creating destroyer object, passing in the starship name, and the default destroyer health
                Starship EnemyDestroyer = new Destroyer(enemyName, Destroyer.destroyerHealth);
                enemyStatsShow(EnemyDestroyer);
                updateEnemyStats(EnemyDestroyer);
                //assigning the created enemy ship, to the global enemy variable - so it can be used else where
                GlobalEnemy = EnemyDestroyer;
                resetBtn.Visible = true;
                extBtn.Visible = true;
            }
            else
            {
                MessageBox.Show("You are required to select a ship type! Try again.");
            }               
        }

        //method to show all labels for enemy
        private void enemyStatsShow(Starship enemy)
        {
            //setting all the labels for the enemy stats to visible
            e_shipTypeLbl.Visible = true;
            EnemyLbl.Visible = true;
            e_NameLbl.Visible = true;
            e_NameResultLbl.Visible = true;
            e_HealthLbl.Visible = true;
            e_HealthLblResult.Visible = true;
            e_ShieldLbl.Visible = true;
            e_ShieldResultLbl.Visible = true;
            e_Ammo.Visible = true;
            e_AmmoResultLbl.Visible = true;
            enemyLoadBox.Visible = true;
            e_AmmoTypeLbl.Visible = true;
            e_AmmoTypeResultLbl.Visible = true;
            e_ConditionLbl.Visible = true;
            e_ConditionResultLbl.Visible = true;
            e_DmgModLbl.Visible = true;
            e_DmgModResultLbl.Visible = true;
            e_InitialHealthLbl.Visible = true;
            e_InitialHealthResultLbl.Visible = true;
            e_InitialShieldLbl.Visible = true;
            e_InitialShieldResultLbl.Visible = true;
            e_FireBtn.Visible = true;
        }

        //method to show all labels for player
        private void playerStatsShow(Starship player)
        {
            //setting all the labels for the enmy stats to visible
            p_shipTypeLbl.Visible = true;
            playerLbl.Visible = true;
            playerNameLbl.Visible = true;
            playerNameResultLbl.Visible = true;
            playerCurrentHealthLbl.Visible = true;
            playerHealthResultLbl.Visible = true;
            playerCurrentShieldLbl.Visible = true;
            playerCurrentShieldResultLbl.Visible = true;
            playerAmmoLbl.Visible = true;
            playerAmmoResultLbl.Visible = true;
            playerAmmoType.Visible = true;
            playerAmmoTypeResultLbl.Visible = true;
            playerAmmoTypeLbl.Visible = true;
            playerAmmoTypeResultLbl.Visible = true;
            playerConditionLbl.Visible = true;
            playerConditionResultLbl.Visible = true;
            playerDmgModLbl.Visible = true;
            playerDmgModResultLbl.Visible = true;
            playerInitialHealthLbl.Visible = true;
            playerInitalHealthResultLbl.Visible = true;
            playerInitalShieldLbl.Visible = true;
            playerLoadBox.Visible = true;
            playerInitialShieldResultLbl.Visible = true;
            playerFireButton.Visible = true;
        }

        //method to update player stats with ship data
        private void updatePlayerStats(Starship player)
        {
            //updating all the player stat labels with the corresponding attribute
            p_shipTypeLbl.Text = ("(" + player.shipType.ToString() + ")");
            playerNameResultLbl.Text = player.shipName.ToString();
            playerHealthResultLbl.Text = player.health.ToString();
            playerCurrentShieldResultLbl.Text = player.shieldLevel.ToString();
            playerInitalHealthResultLbl.Text = player.maxHealth.ToString();
            playerInitialShieldResultLbl.Text = player.maxShieldHealth.ToString();
            playerConditionResultLbl.Text = player.condition.ToString();
            playerAmmoResultLbl.Text = player.ordinance.ToString();
        }

        //method to update enemy stats with ship data
        private void updateEnemyStats(Starship enemy)
        {
            //updating all the enemy player stat labels with the corresponding attribute
            e_shipTypeLbl.Text = ("(" + enemy.shipType.ToString() + ")");
            e_NameResultLbl.Text = enemy.shipName.ToString();
            e_HealthLblResult.Text = enemy.health.ToString();
            e_ShieldResultLbl.Text = enemy.shieldLevel.ToString();
            e_InitialHealthResultLbl.Text = enemy.maxHealth.ToString();
            e_InitialShieldResultLbl.Text = enemy.maxShieldHealth.ToString();
            e_ConditionResultLbl.Text = enemy.condition.ToString();
            e_AmmoResultLbl.Text = enemy.ordinance.ToString();
        }

        //separate update function to handle only the player ammo stats updating
        //takes in the Ordinance type, and Starship type
        private void playerAmmoUpdate(Ordinance ammo, Starship player)
        {
            //updates the labels with the corresponding attribute
            playerAmmoTypeResultLbl.Text = ammo.ordName.ToString();
            playerDmgModResultLbl.Text = ammo.dmg.ToString();
            playerAmmoResultLbl.Text = player.ordinance.ToString();
        }

        //separate update function to handle only the enemy ammo stats updating
        //takes in the Ordinance type, and Starship type
        private void enemyAmmoUpdate(Ordinance ammo, Starship enemy)
        {
            //updates the labels with the corresponding attribute
            e_AmmoTypeResultLbl.Text = ammo.ordName.ToString();
            e_DmgModResultLbl.Text = ammo.dmg.ToString();
            e_AmmoResultLbl.Text = enemy.ordinance.ToString();
        }

        //player load ammo button
        private void playerLoad_Click(object sender, EventArgs e)
        {
            //creates ordinance type based on which radio button is checked
            //calls the player ship's load function, passing it the selected ordinance
            //updates players ammo labels
            //prevents users from loading cannon without selecting type of ammo
            if (playerLaserRadio.Checked == true)
            {
                Laser laser = new Laser("Laser");
                GlobalPlayerAmmo = laser;
                GlobalPlayer.Load(laser);
                playerAmmoUpdate(laser, GlobalPlayer);
            }
            else if (playerIonRadio.Checked == true)
            {
                IonBomb ion = new IonBomb("Ion Bomb");
                GlobalPlayerAmmo = ion;
                GlobalPlayer.Load(ion);
                playerAmmoUpdate(ion, GlobalPlayer);
            }
            else if (playerTorpedoRadio.Checked == true)
            {
                Torpedo Torpedo = new Torpedo("Torpedo");
                GlobalPlayerAmmo = Torpedo;
                GlobalPlayer.Load(Torpedo);
                playerAmmoUpdate(Torpedo, GlobalPlayer);
            }
            else
            {
                MessageBox.Show("You must select an ammo type before loading the cannon!");
            }
        }

        //enemy load ammo button
        private void e_LoadBtn_Click(object sender, EventArgs e)
        {
            //creates ordinance type based on which radio button is checked
            //calls the enemy ship's load function, passing it the selected ordinance
            //updates enemy ammo labels
            //prevents users from loading cannon without selecting type of ammo
            if (e_LaserRadio.Checked == true)
            {
                Laser laser = new Laser("Laser");
                GlobalEnemy.Load(laser);
                enemyAmmoUpdate(laser, GlobalEnemy);
                GlobalEnemyAmmo = laser;
            }
            else if (e_IonRadio.Checked == true)
            {
                IonBomb ion = new IonBomb("Ion Bomb");
                GlobalEnemy.Load(ion);
                enemyAmmoUpdate(ion, GlobalEnemy);
                GlobalEnemyAmmo = ion;
            }
            else if (e_TorpedoRadio.Checked == true)
            {
                Torpedo torpedo = new Torpedo("Torpedo");
                GlobalEnemy.Load(torpedo);
                enemyAmmoUpdate(torpedo, GlobalEnemy);
                GlobalEnemyAmmo = torpedo;
            }
            else
            {
                MessageBox.Show("You must select an ammo type before loading the cannon!");
            }
        }     

        //enemy fire button
        private void e_FireBtn_Click(object sender, EventArgs e)
        {
            //declaring the properties of the timer and disabling the fire button for that time
            //preventing users from shooting too many ordinance
            timer.Interval = travelTime; 
            timer.Tick += enemy_limiter;
            timer.Start();
            e_FireBtn.Enabled = false;
            //nested if's and try/catch
            //preventing DISASTER!!!
            //before firing we check to make sure: there is another ship created to battle,
            //the opposition is not destroyed, the current ship is not destroyed, and if there is ammo loaded
            //if all is true FIRE AWAY!
            try
            {
                if (GlobalPlayer.health != 0)
                {
                    if (GlobalEnemy.health != 0)
                    {
                        try
                        {
                            if (GlobalEnemy.ordinance != 0)
                            {
                                //calling enemy shoot method, passing in enemy ammo
                                enemyRenderFire(GlobalEnemyAmmo);
                                //calling update player stats after firing, passing in player ship
                                updatePlayerStats(GlobalPlayer);
                                //calling enemy fire method, passing in player ship
                                GlobalEnemy.Fire(GlobalPlayer);
                                //calling update player stats after firing, passing in player ship
                                updatePlayerStats(GlobalPlayer);
                                //calling ammo update, passing in player ammo, and player ship
                                enemyAmmoUpdate(GlobalEnemyAmmo, GlobalEnemy);
                                MessageBox.Show("The ship was attacked with " + (GlobalEnemy.FiringDamage) + " damage!");
                            }
                            else
                            {
                                MessageBox.Show("You need to load some ammo before you fire!");
                            }                              
                        }
                        catch
                        {
                            MessageBox.Show("You need to load some ammo before you fire!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(GlobalEnemy.shipName.ToString() + " cannot fire! It is DESTROYED!!!!");
                    }                      
                }
                else
                {
                    MessageBox.Show("You cannot fire upon " + GlobalPlayer.shipName.ToString() + "! It is destroyed...");
                }                   
            }
            catch
            {
                MessageBox.Show("There is no player ship to fire upon... Maybe you should try creating one??");
            }         
        }

        //player fire button
        private void playerFireButton_Click(object sender, EventArgs e)
        {
            //declaring the properties of the timer and disabling the fire button for that time
            //preventing users from shooting too many ordinance
            timer.Interval = travelTime; 
            timer.Tick += player_limiter;
            timer.Start();
            playerFireButton.Enabled = false;
            //nested if's and try/catch
            //preventing DISASTER!!!
            //before firing we check to make sure: there is another ship created to battle,
            //the opposition is not destroyed, the current ship is not destroyed, and if there is ammo loaded
            //if all is true FIRE AWAY!
            try
            {
                if (GlobalEnemy.health != 0)
                {
                    if (GlobalPlayer.health != 0)
                    {
                        try
                        {
                            if (GlobalPlayer.ordinance != 0 && GlobalPlayer.health > 0)
                            {
                                //calling player shoot method, passing in player ammo
                                playerRenderFire(GlobalPlayerAmmo);
                                //calling update enemy stats before firing, passing in enemy ship
                                updateEnemyStats(GlobalEnemy);
                                //calling player fire method, passing in enemy ship
                                GlobalPlayer.Fire(GlobalEnemy);
                                //calling update enemy stats after firing, passing in enemy ship
                                updateEnemyStats(GlobalEnemy);
                                //calling ammo update, passing in player ammo, and player ship
                                playerAmmoUpdate(GlobalPlayerAmmo, GlobalPlayer);
                                MessageBox.Show("The ship was attacked with " + (GlobalPlayer.FiringDamage) + " damage!");
                            }
                            else
                                MessageBox.Show("You need to load some ammo before you fire!");
                        }
                        catch
                        {
                            MessageBox.Show("You need to load some ammo before you fire!");
                        }
                    }
                    else
                        MessageBox.Show(GlobalPlayer.shipName.ToString() + " cannot fire! It is DESTROYED!!!!");
                }
                else
                    MessageBox.Show("You can not fire upon " + GlobalEnemy.shipName.ToString() + "! It is destroyed...");
            }
            catch
            {
                MessageBox.Show("There is no enemy to fire upon... Maybe you should try creating one??");
            }
        }

        // MAKE IT MOVE :)
        //method to visualize the ordinance - taking in an ordinance type
        //the steps are repeated for each ordinance type - only the value definitions are changed.
        private void playerRenderFire(Ordinance ammo)
        {
            //checking what type of ordinance the player has loaded, and creating the corresponding sprite 
            if (ammo.ordName == "Laser")
            {
                //getting the image from resources
                Image sprite = Starship_Visual.Properties.Resources.Green_laser;
                //creating picture box
                PictureBox pb = new PictureBox();
                //defining size of picture box
                pb.Size = new Size(100, 19);
                //setting the back ground image of the picture box to the sprite
                pb.BackgroundImage = sprite;
                //setting the back ground transparent
                pb.BackColor = Color.Transparent;
                //setting the the size  mode to stretch
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                //defining the location
                pb.Location = new Point(210, 350);
                //setting it to visible
                pb.Visible = true;
                //adding it to the controls
                this.Controls.Add(pb);
                //a loop to move the sprite to its desired location
                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left + 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                //removing the picture box once move is complete
                this.Controls.Remove(pb);
            }
            else if (ammo.ordName == "Torpedo")
            {
                Image sprite = Starship_Visual.Properties.Resources.playerTorpedo;
                PictureBox pb = new PictureBox();
                pb.Size = new Size(100, 53);
                pb.BackgroundImage = sprite;
                pb.BackColor = Color.Transparent;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(210, 340);
                pb.Visible = true;
                this.Controls.Add(pb);

                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left + 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                this.Controls.Remove(pb);
            }
            else if (ammo.ordName == "Ion Bomb")
            {
                Image sprite = Starship_Visual.Properties.Resources.ufodark;
                PictureBox pb = new PictureBox();
                pb.Size = new Size(39, 39);
                pb.BackgroundImage = sprite;
                pb.BackColor = Color.Transparent;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(210, 345);
                pb.Visible = true;
                this.Controls.Add(pb);

                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left + 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                this.Controls.Remove(pb);
            }           
        }

        // MAKE IT MOVE :)
        //method to visualize the ordinance - taking in an ordinance type
        //the steps are repeated for each ordinance type - only the value definitions are changed.
        private void enemyRenderFire(Ordinance ammo)
        {
            if(ammo.ordName == "Laser")
            {
                //getting the image from resources
                Image sprite = Starship_Visual.Properties.Resources.Green_laser;
                //creating picture box
                PictureBox pb = new PictureBox();
                //defining size of picture box
                pb.Size = new Size(100, 19);
                //setting the back ground image of the picture box to the sprite
                pb.BackgroundImage = sprite;
                //setting the back ground transparent
                pb.BackColor = Color.Transparent;
                //setting the the size  mode to stretch
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                //defining the location
                pb.Location = new Point(850, 350);
                //setting it to visible
                pb.Visible = true;
                //adding it to the controls
                this.Controls.Add(pb);
                //a loop to reposition the sprite to its desired location
                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left - 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                this.Controls.Remove(pb);
            }
            else if(ammo.ordName == "Torpedo")
            {
                Image sprite = Starship_Visual.Properties.Resources.enemyTorpedo;
                PictureBox pb = new PictureBox();
                pb.Size = new Size(100, 53);
                pb.BackgroundImage = sprite;
                pb.BackColor = Color.Transparent;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(850, 340);
                pb.Visible = true;
                this.Controls.Add(pb);

                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left - 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                this.Controls.Remove(pb);
            }
            else if (ammo.ordName == "Ion Bomb")
            {
                Image sprite = Starship_Visual.Properties.Resources.ufodark;
                PictureBox pb = new PictureBox();
                pb.Size = new Size(39, 39);
                pb.BackgroundImage = sprite;
                pb.BackColor = Color.Transparent;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(870, 345);
                pb.Visible = true;
                this.Controls.Add(pb);

                for (int i = 0; i < 50; i++)
                {
                    pb.Location = new Point(pb.Left - 15, pb.Top);
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(1);
                }

                this.Controls.Remove(pb);
            }           
        }

        //re-enabling the enemy fire button after specified time       
        private void enemy_limiter(object sender, System.EventArgs e)
        {
            e_FireBtn.Enabled = true;
            timer.Stop();
        }

        //re-enabling the player fire button after specified time       
        private void player_limiter(object sender, System.EventArgs e)
        {
            playerFireButton.Enabled = true;
            timer.Stop();
        }

        //variable to store the time it takes for the ordinance to travel across the screen
        //prevents fire button being pressed too many times and launching multiple ordinance
        int travelTime = 3000;

        //creating a timer to disable fire button for specified time
        //this prevents user from clicking the fire button multiple times and sending out too many ordinance
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //method to add my custom font
        private void CustomFont()
        {
            //Create private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select ont from the resources.
            int fontLength = Properties.Resources.Nero.Length;

            //create a buffer to read in to
            byte[] fontdata = Properties.Resources.Nero;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            //pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            //free up the unsafe memory
            Marshal.FreeCoTaskMem(data);

            //set the label specs
            label1.Font = new Font(pfc.Families[0], label1.Font.Size);
            label1.Text = "Starship Battle";
        }
        //reset button to restart the game/reload application
        private void resetBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        //exit button - to   ...   exit.
        private void extBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Starship_Battle_Load(object sender, EventArgs e)
        {
            
        }

    }
}
