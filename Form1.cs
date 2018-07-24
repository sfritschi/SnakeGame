using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace Snake
{
    public partial class Snake : Form
    {
        private List<Circle> PlayerSnake = new List<Circle>();
        private Circle Target = new Circle();
        private string Directory = System.IO.Directory.GetCurrentDirectory();
        private const int MaximumSpeed = 18;
        private const int MaximumHighscores = 5;
        private static SpeechSynthesizer Synth = new SpeechSynthesizer();
        private Random rnd = new Random();

        #region TTSMessages
        private List<string> TTSMessages = new List<string>()
        {
            "feels bad man",
            "not pretending, feels weird man",
            "omega lul",
            "lidl player omega lul",
            "pepe hands",
            "baby rage never lucky baby rage",
            "captial d colon",
            "just don't die 4head"
        };
        #endregion

        public Snake()
        {
            InitializeComponent();

            // Set settings to default
            new Settings();
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            // Start the game
            StartGame();
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;
            
            // Set settings to default
            new Settings();

            // Reset timer
            ResetTimer();

            //Create new player object
            PlayerSnake.Clear();
            Circle Head = new Circle()
            {
                X = 10,
                Y = 5
            };
            PlayerSnake.Add(Head);

            // Update UI
            lblScore.Text = Settings.Score.ToString();
            string[] Scores = ReadScores();
            string HighScoreText = "";
            for (int i = 0; i < Scores.Length; i++)
                if (i < MaximumHighscores)
                    HighScoreText += $"{i+1}. {Scores[i]}\n";
                else
                    break;
            lblHighScore.Text = HighScoreText;

            GenerateTarget();
        }

        // Place target randomly in PlayArea
        private void GenerateTarget()
        {
            int MaxXPos = PlayArea.Size.Width / Settings.Width;
            int MaxYPos = PlayArea.Size.Height / Settings.Height;
            Target.X = rnd.Next(0, MaxXPos);
            Target.Y = rnd.Next(0, MaxYPos);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // Check for GameOver
            if (Settings.GameOver)
            {
                // Check if 'Enter' is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.Direction != Directions.LEFT)
                    Settings.Direction = Directions.RIGHT;
                if (Input.KeyPressed(Keys.Left) && Settings.Direction != Directions.RIGHT)
                    Settings.Direction = Directions.LEFT;
                if (Input.KeyPressed(Keys.Up) && Settings.Direction != Directions.DOWN)
                    Settings.Direction = Directions.UP;
                if (Input.KeyPressed(Keys.Down) && Settings.Direction != Directions.UP)
                    Settings.Direction = Directions.DOWN;

                MovePlayer();
            }
            // Close the game if 'Escape' is pressed
            if (Input.KeyPressed(Keys.Escape))
                this.Close();

            PlayArea.Invalidate();
        }

        private void MovePlayer()
        {
            for (int i = PlayerSnake.Count - 1; i >= 0; i--)
            {
                // Move head
                if (i == 0)
                {
                    switch (Settings.Direction)
                    {
                        case Directions.RIGHT:
                            PlayerSnake[i].X++;
                            break;
                        case Directions.LEFT:
                            PlayerSnake[i].X--;
                            break;
                        case Directions.UP:
                            PlayerSnake[i].Y--;
                            break;
                        default:
                            PlayerSnake[i].Y++;
                            break;

                    }

                    // Get maximum XPos and YPos
                    int MaxXPos = PlayArea.Size.Width / Settings.Width;
                    int MaxYPos = PlayArea.Size.Height / Settings.Height;

                    // Check for collision with game borders
                    if (PlayerSnake[i].X < 0 || PlayerSnake[i].Y < 0 ||
                        PlayerSnake[i].X >= MaxXPos || PlayerSnake[i].Y >= MaxYPos)
                    {
                        Die();
                    }

                    // Check for collision with body
                    for (int j = 1; j < PlayerSnake.Count; j++)
                    {
                        if (PlayerSnake[i].X == PlayerSnake[j].X &&
                            PlayerSnake[i].Y == PlayerSnake[j].Y)
                        {
                            Die();
                        }
                    }

                    // Check for collision with body
                    if (PlayerSnake[0].X == Target.X &&
                        PlayerSnake[0].Y == Target.Y)
                    {
                        Eat();
                    }
                } else
                {
                    // Move body
                    PlayerSnake[i].X = PlayerSnake[i - 1].X;
                    PlayerSnake[i].Y = PlayerSnake[i - 1].Y;
                }

            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            
        }

        // End game
        private void Die()
        {
            Settings.GameOver = true;
            // Write high score to File
            string[] Scores = ReadScores();
            int ParsedScore = 0;
            bool IsNumber = true;
            try
            {
                ParsedScore = int.Parse(Scores[0]);
            }
            catch (Exception)
            {
                IsNumber = false;
            };
            // File is Empty
            if (Scores.Length == 0)
            {
                string[] CurrentScore = { Settings.Score.ToString() }; 
                WriteScores(CurrentScore);
              
            }
            else if (IsNumber)
            {
                if (ParsedScore < Settings.Score)
                {
                    string[] HighScore = { Settings.Score.ToString() };
                    var NewScores = new string[Scores.Length + HighScore.Length];

                    HighScore.CopyTo(NewScores, 0);
                    Scores.CopyTo(NewScores, HighScore.Length);

                    WriteScores(NewScores);
                } else
                {
                    // Mock player
                    Synth.SpeakAsync(TTSMessages[rnd.Next(0, TTSMessages.Count)]);
                }
            }
        }

        // Destroy Target
        private void Eat()
        {
            // Add circle to body
            Circle Target = new Circle()
            {
                X = PlayerSnake[PlayerSnake.Count - 1].X,
                Y = PlayerSnake[PlayerSnake.Count - 1].Y
            };
            PlayerSnake.Add(Target);

            // Update score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            // Increment game speed every 50 points
            if (Settings.Score % 50 == 0 && Settings.Speed < MaximumSpeed)
            {
                Settings.Speed += 1;
                ResetTimer();
            }
            GenerateTarget();
        }

        private void ResetTimer()
        {
            gameTimer.Stop();
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Start();
        }

        private void PlayArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                // Set color of snake
                Brush SnakeColor;

                // Draw snake
                for (int i = 0; i < PlayerSnake.Count; i++)
                {
                    if (i == 0)
                        SnakeColor = Brushes.Black;  // Draw head
                    else
                        SnakeColor = Brushes.Green;  // Draw rest

                    Canvas.FillEllipse(SnakeColor,
                        new Rectangle(PlayerSnake[i].X * Settings.Width, PlayerSnake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));
                }
                // Draw target
                Canvas.FillEllipse(Brushes.Red,
                    new Rectangle(Target.X * Settings.Width, Target.Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            } else
            {
                string gameOverMsg = $"Game Over \n Your final score is: {Settings.Score} \n Press 'Enter' to try again";
                lblGameOver.Text = gameOverMsg;
                lblGameOver.Visible = true;
            }
        }

        // Read scores from highscore file
        private string[] ReadScores()
        {
            try
            {
                return System.IO.File.ReadAllLines(Directory);
            } catch(IOException)
            {
                MessageBox.Show("Couldn't read from file");
                return new string[0];
            }
        }

        // Write Scores to highscore file
        private void WriteScores(string[] Scores)
        {
            try
            {
                System.IO.File.WriteAllLines(Directory, Scores);
            }
            catch (IOException)
            {
                MessageBox.Show("Couldn't write to file");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
