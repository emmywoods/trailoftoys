using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace game.toyGame
{
    public partial class GameBoard : Form
    {
        private PictureBox[] trail;
        private Random rnd = new Random();
        private List<IPlayer> Players = new List<IPlayer>();
        private int _whoseTurn;
        private bool inPlay = false; // true if the game has been started
        private bool cardWasDrawn = false; // true if the player whose turn it is has drawn a card already
        private List<string> toysAlreadyDrawn = new List<string>();

        public GameBoard()
        {
            InitializeComponent();
            trail = new PictureBox[] { T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16,
            T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36,
            T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56,
            T57, T58, T59, T60,  T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78,
            T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100,
            T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, 
            T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136,
            T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155,
            T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174,
            T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193,
            T194, T195, T196, T197, T198, T199, T200, T201};
        }

        public ICollection<PictureBox> Trail
        {
            get { return trail; }
        }

        private int[] path1 = new int[] { 0, 1, 4, 5, 8, 9, 12, 13, 16, 17, 20, 21, 24, 25, 28, 29, 32, 33, 36, 37, 40, 41,
        44, 45, 48, 49, 52, 53, 56, 57,  60, 61, 64, 65, 68, 69, 72, 73, 75, 78, 76, 77, 80, 81,  84, 85, 88, 89, 92, 93, 96,
        97, 100, 101, 104, 105, 108, 109, 112, 113,   116, 117, 120, 121, 124, 125, 128, 129, 132, 133, 136, 137, 140, 141,
        144, 145, 148, 149, 152, 153, 155,  158, 156, 157, 160, 161, 164, 165, 168, 169, 172, 173, 176, 177, 180, 181, 184,
        185, 188, 189, 192, 193, 196, 197,  200};

        private int[] path2 = new int[] { 2, 3, 6, 7, 10, 11, 14, 15, 18, 19, 22, 23, 26, 27, 30, 31, 34, 35, 33, 36, 38, 39, 42,
        43, 46, 47, 50, 51, 54, 55, 58, 59,  62, 63, 66, 67, 70, 71, 74, 75, 78, 79, 82, 83,  86, 87, 90, 91, 94, 95, 98, 99,
        102, 103, 106, 107, 110, 111, 114, 115, 113, 116,  118, 119, 122, 123, 126, 127, 130, 131, 134, 135, 138, 139, 142, 143,
        146, 147, 150, 151, 154, 155,  158, 159, 162, 163, 166, 167, 170, 171, 174, 175, 178, 179, 182, 183, 186, 187, 190, 191,
        194, 195, 198, 199, 200};

        SpeechSynthesizer synth = new SpeechSynthesizer();
        //synth.SetOutputToDefaultAudioDevice();

        private void Button0_Click(object sender, EventArgs e)
        {
            // this is the start button

            // if the game is already in play, ignore the start button
            if (this.inPlay == true) return;

            // If there are no players yet, don't start the game...
            if (Players.Count == 0) return;

            // If there's only one player, add a computer player
            ComputerPlayer compPlayer = new ComputerPlayer(Properties.Resources.faceRobot, "Computer", Player0Status, Player0Border);
            if (Players.Count == 1)
            {
                //Players.Add(compPlayer);
                if (Player0Status.Visible == false)
                {
                    Player0.BackgroundImage = Properties.Resources.faceRobot;
                    this.Player0Status.BackgroundImage = Properties.Resources.robot;
                    this.Player0Status.Visible = true;
                    Player0.Text = "";
                    Player0.Tag = "0";
                    this.Player0Name.Text = "Computer";
                }
                else
                {
                    // if Player0 isn't available, Player1 must be, because there's only one player
                    Player1.BackgroundImage = Properties.Resources.faceRobot;
                    this.Player1Status.BackgroundImage = Properties.Resources.robot;
                    this.Player1Status.Visible = true;
                    compPlayer.FullAvatar = Player1Status;
                    compPlayer.Border = Player1Border;
                    Player1.Text = "";
                    Player1.Tag = "1";
                    this.Player1Name.Text = "Computer";
                    this.Player1Name.Visible = true;
                }
                Players.Add(compPlayer);
            }
            Card.Visible = true;
            this.inPlay = true;
            // get rid of the word start from the start button
            this.Button0.Text = "";
            // also get rid of any "add player" buttons
            if (this.Player0.Text != "") this.Player0.Visible = false;
            if (this.Player1.Text != "") this.Player1.Visible = false;
            if (this.Player2.Text != "") this.Player2.Visible = false;
            if (this.Player3.Text != "") this.Player3.Visible = false;
            this.StartTurn();
        }

        void StartTurn()
        {
            IPlayer thisPlayer = Players[_whoseTurn];
            // highlight the player whose turn it is
            thisPlayer.Border.BackColor = Color.Red;
            thisPlayer.FullAvatar.BorderStyle = BorderStyle.FixedSingle;
            // display their name
            label1.Text = thisPlayer.Name + "'s turn";
            label1.Visible = true;   

            // if this player is the computer, have it take it's turn
            if (thisPlayer is ComputerPlayer)
            {
                // state whose turn it is...
                synth.SpeakAsync("It's the Computer's turn");

                // pause briefly...
                this.Refresh();
                System.Threading.Thread.Sleep(500);

                // draw a card
                this.DrawCard();

                // pause briefly
                this.Refresh();
                System.Threading.Thread.Sleep(500);

                // move the face
                int? oldPosition = thisPlayer.Position;
                this.MoveFace(thisPlayer.NextPosition, oldPosition);
            }
            else
            {
                synth.SpeakAsync("It's " + thisPlayer.Name + "'s turn. Draw a card.");
            }
        }

        void EndTurn()
        {
            // make the Draw a card visible, and the card contents invisible again
            Card.Text = "???   Draw a card   ???";
            CardColor1.Visible = false;
            CardColor2.Visible = false;
            CardColor3.Visible = false;
            CardColor3.BackgroundImage = null;
            Card.Visible = true;
            // make the border invisible
            IPlayer thisPlayer = Players[_whoseTurn];
            thisPlayer.Border.BackColor = Color.Empty;
            thisPlayer.FullAvatar.BorderStyle = BorderStyle.None;
            // change whose turn it is
            this._whoseTurn += 1;
            if (this._whoseTurn >= Players.Count) this._whoseTurn = 0;
            // this guy hasn't drawn a card yet
            this.cardWasDrawn = false;
            this.StartTurn();
        }

        void MoveFace(int desiredPosition, int? oldPosition)
        {
            IPlayer thisPlayer = Players[_whoseTurn];
            // ok so I don't really want them to go where they clicked exactly. I want them to go to their 
            // correct offset from the start of the square...
            thisPlayer.Position = thisPlayer.NextPosition;

            // tell the player they're right
            if (thisPlayer is HumanPlayer)
                synth.SpeakAsync("That's right");

            // move the player's face to the new position
            if (oldPosition == null || oldPosition == -1)
            {
                oldPosition = 0;
                if (this.trail[(int)oldPosition].BackgroundImage == null)
                {
                    this.trail[(int)oldPosition].BackgroundImage = thisPlayer.Avatar;
                    this.trail[(int)oldPosition].Tag = _whoseTurn.ToString();
                }
                // remove this player's face from the start button
                if (_whoseTurn.ToString() == (string)this.Player0.Tag) this.Player0.Visible = false;
                if (_whoseTurn.ToString() == (string)this.Player1.Tag) this.Player1.Visible = false;
                if (_whoseTurn.ToString() == (string)this.Player2.Tag) this.Player2.Visible = false;
                if (_whoseTurn.ToString() == (string)this.Player3.Tag) this.Player3.Visible = false;

                // to do: use _whoseTurn number for Tag in Player0-3 buttons AND in T picture boxes to prevent 
                // players from eating each other when they walk over someone with the same name or picture

                // refresh and wait briefly
                this.Refresh();
                System.Threading.Thread.Sleep(100);
            }
            int pathIndex = 0;
            int[] thisPath = path1;
            double result = (int)oldPosition / 2;
            pathIndex = (int)Math.Ceiling(result);
            if (_whoseTurn == 2 || _whoseTurn == 3)
            {
                //pathIndex -= 1;
                thisPath = path2;
            }
            while (thisPath[pathIndex] < oldPosition)
            {
                pathIndex += 1;
            }
            bool moveForward = (oldPosition < thisPlayer.Position);

            while (oldPosition != thisPlayer.Position)
            {
                // get rid of the image that's on the board
                //if (this.trail[(int)oldPosition].BackgroundImage == thisPlayer.Avatar)
                if ((string)this.trail[(int)oldPosition].Tag == _whoseTurn.ToString())
                    this.trail[(int)oldPosition].BackgroundImage = null;
                // incriment so that the image is walking along the board
                oldPosition = thisPath[pathIndex];
                if (moveForward)
                    pathIndex++;
                else
                    pathIndex--;
                // place the image in the next spot
                if (this.trail[(int)oldPosition].BackgroundImage == null)
                {
                    this.trail[(int)oldPosition].BackgroundImage = thisPlayer.Avatar;
                    this.trail[(int)oldPosition].Tag = _whoseTurn.ToString();
                }
                this.debug.Text = oldPosition.ToString();
                // show changes and sleep briefly
                this.Refresh();
                System.Threading.Thread.Sleep(200);
            }

            if (thisPlayer.Position == 200)
            {
                // game over
                this.label1.Text = thisPlayer.Name + " wins!";
                synth.SpeakAsync(thisPlayer.Name + " wins!");
                this.T201.Visible = true;
                return;
            }

            this.EndTurn();
        }

        void TrailClick(object sender, EventArgs e)
        {
            // this should be called whenever the player clicks on the trail
            if (this.cardWasDrawn == false) return; // can't move on the trail until they've drawn a card
            PictureBox box = sender as PictureBox;
            IPlayer tPlayer = Players[_whoseTurn];
            if (tPlayer is ComputerPlayer) return; // clicking during the computer's turn is ignored
            var thisPlayer = (HumanPlayer)tPlayer;

            int? oldPosition = thisPlayer.Position;

            // attempt to move the player to the location they clicked
            int positionInt = 0;

            for (int i = 0; i < trail.Length; i++)
            {
                if (trail[i] == box)
                {
                    positionInt = i;
                    //this.debug.Text = "positionInt: " + positionInt.ToString();
                    break;
                }
            }
            thisPlayer.Position = positionInt;

            // check if their position moved
            if (thisPlayer.CorrectChoice)
                this.MoveFace(thisPlayer.NextPosition, oldPosition);
        }

        // get rid of this
        void BoardButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            //here you can check which button was clicked by the sender
        }

        private void Player_Setup_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;

            PictureBox currentBox = this.Player0Status;
            Label currentLabel = this.Player0Name;
            PictureBox border = this.Player0Border;
            currentButton.Tag = "0"; // making the tag on the button their player number

            if (currentButton == this.Player1)
            {
                currentBox = this.Player1Status;
                currentLabel = this.Player1Name;
                border = this.Player1Border;
                currentButton.Tag = "1";
            }
            else if (currentButton == this.Player2)
            {
                currentBox = this.Player2Status;
                currentLabel = this.Player2Name;
                border = this.Player2Border;
                currentButton.Tag = "2";
            }
            else if (currentButton == this.Player3)
            {
                currentBox = this.Player3Status;
                currentLabel = this.Player3Name;
                border = this.Player3Border;
                currentButton.Tag = "3";
            }

            AvatarDialog aForm = new AvatarDialog();
            aForm.ShowDialog();
            if (aForm.DialogResult == DialogResult.Cancel) return;

            HumanPlayer thisPlayer;
            if (aForm.AvatarNumber == 1)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face1, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face1;
                currentBox.BackgroundImage = Properties.Resources._1;
            }
            else if (aForm.AvatarNumber == 2)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face2, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face2;
                currentBox.BackgroundImage = Properties.Resources._2;
            }
            else if (aForm.AvatarNumber == 3)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face3, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face3;
                currentBox.BackgroundImage = Properties.Resources._3;
            }
            else if (aForm.AvatarNumber == 4)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face4, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face4;
                currentBox.BackgroundImage = Properties.Resources._4;
            }
            else if (aForm.AvatarNumber == 5)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face5, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face5;
                currentBox.BackgroundImage = Properties.Resources._5;
            }
            else if (aForm.AvatarNumber == 6)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face6, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face6;
                currentBox.BackgroundImage = Properties.Resources._6;
            }
            else if (aForm.AvatarNumber == 7)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face7, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face7;
                currentBox.BackgroundImage = Properties.Resources._7;
            }
            else if (aForm.AvatarNumber == 8)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face8, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face8;
                currentBox.BackgroundImage = Properties.Resources._8;
            }
            else if (aForm.AvatarNumber == 9)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face9, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face9;
                currentBox.BackgroundImage = Properties.Resources._9;
            }
            else if (aForm.AvatarNumber == 10)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face10, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face10;
                currentBox.BackgroundImage = Properties.Resources._10;
            }
            else if (aForm.AvatarNumber == 11)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face11, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face11;
                currentBox.BackgroundImage = Properties.Resources._11;
            }
            else if (aForm.AvatarNumber == 12)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face12, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face12;
                currentBox.BackgroundImage = Properties.Resources._12;
            }
            else if (aForm.AvatarNumber == 13)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face13, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face13;
                currentBox.BackgroundImage = Properties.Resources._13;
            }
            else if (aForm.AvatarNumber == 14)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face14, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face14;
                currentBox.BackgroundImage = Properties.Resources._14;
            }
            else if (aForm.AvatarNumber == 15)
            {
                thisPlayer = new HumanPlayer(Properties.Resources.face15, currentLabel.Text, currentBox, border);
                currentButton.BackgroundImage = Properties.Resources.face15;
                currentBox.BackgroundImage = Properties.Resources._15;
            }
            else
            {
                // just in case... but this should never be called
                thisPlayer = new HumanPlayer(Properties.Resources.face15, currentLabel.Text, currentBox, border);
            }
            currentLabel.Text = aForm.AvatarName;
            if (currentLabel.Text == "") currentLabel.Text = "Player " + (Players.Count + 1).ToString();
            currentButton.Text = "";
            currentBox.Visible = true;
            currentLabel.Visible = true;
            thisPlayer.Name = currentLabel.Text;
            this.Players.Add(thisPlayer);
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }

        private string ColorNameOnly(Color c)
        {
            // the speech synth says "color orange" instead of just "orange"...
            if (c == Color.Red) return "red";
            else if (c == Color.Orange) return "orange";
            else if (c == Color.Yellow) return "yellow";
            else if (c == Color.Green) return "green";
            else if (c == Color.Blue) return "blue";
            else return "purple";
        }

        private void DrawCard()
        {
            if (Card.Text != "")
            {
                // they've clicked to draw a card!
                // figure out who the player is
                IPlayer thisPlayer = Players[_whoseTurn];

                // should it be a toy card or a color card?
                int colorOrToy = rnd.Next(0, 10);
                if (colorOrToy == 0) //  should be (colorOrToy == 0) 
                {
                    // toy card!
                    Bitmap[] toys = {Properties.Resources.basketball, Properties.Resources.car, Properties.Resources.keyboard,
                    Properties.Resources.dinosaur, Properties.Resources.teddybear, Properties.Resources.tricycle,
                    Properties.Resources.blocks };
                    string[] imageNames = { "basketball", "car", "keyboard", "dinosaur", "teddybear", "tricycle", "blocks"};

                    // there are 7 toys on the board?
                    int imgNum = rnd.Next(0, 7); // to do: should be 0, 7
                    Bitmap chosenImage = toys[imgNum];
                    // make sure this card is still available to be drawn, because toys can only be drawns once eacyh per game
                    /* to do: uncomment this?
                    if (toysAlreadyDrawn.Contains(imageNames[imgNum]))
                    {
                        // draw a different card
                        this.Card_Click(sender, e);
                        return;
                    }*/

                    toysAlreadyDrawn.Add(imageNames[imgNum]);
                    ToyCard drawnCard = new ToyCard(chosenImage, imageNames[imgNum]);
                    synth.SpeakAsync("Go to the " + imageNames[imgNum]);
                    CardColor3.BackgroundImage = drawnCard.Image;
                    CardColor3.BackColor = Color.Empty;
                    CardColor3.Visible = true;

                    // the player needs to know where the target is on the trail
                    thisPlayer.DetermineNextPosition(drawnCard, this.Players);
                    this.debug.Text = "next: " + thisPlayer.NextPosition.ToString();
                }
                else
                {
                    // color card!
                    ColorCard drawnCard = new ColorCard(rnd);
                    if (drawnCard.NumSquares == 1)
                    {
                        CardColor3.BackColor = drawnCard.Color;
                        CardColor3.Visible = true;
                        synth.SpeakAsync("Move one " + this.ColorNameOnly(drawnCard.Color) + " square");
                    }
                    else
                    {
                        CardColor1.BackColor = drawnCard.Color;
                        CardColor2.BackColor = drawnCard.Color;
                        CardColor1.Visible = true;
                        CardColor2.Visible = true;
                        synth.SpeakAsync("Move two " + this.ColorNameOnly(drawnCard.Color) + " squares");
                    }
                    // the player needs to know where the target is on the trail
                    thisPlayer.DetermineNextPosition(drawnCard, this.Players);
                    //this.debug.Text = thisPlayer.NextPosition.ToString();
                }
                Card.Text = "";
                Card.Visible = false;
                this.cardWasDrawn = true;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            this.DrawCard();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            IPlayer thisPlayer = Players[_whoseTurn];
            int? oldPosition = thisPlayer.Position;
            if (thisPlayer.NextPosition == 200)
            {
                this.Finish.Text = "";
                this.MoveFace(thisPlayer.NextPosition, oldPosition);
            }
        }
    }
}
