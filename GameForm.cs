using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WWTBAM_Control_Panel
{
    public class GameForm : Form
    {
        // Játék állapot
        private Game _game;
        
        // UI elemek
        private Label _questionLabel;
        private Button[] _answerButtons;
        private ListBox _prizeList;
        private Label _currentPrizeLabel;
        private Button _fiftyFiftyButton;
        private Button _audienceButton;
        private Button _phoneButton;

        public GameForm()
        {
            InitializeGame();
            InitializeUI();
            UpdateGameUI();
        }

        private void InitializeGame()
        {
            try
            {
                // Kérdések és nyeremények betöltése
                var questions = LoadQuestions("questions.json");
                var prizeSettings = LoadPrizeSettings("prizes.json");
                _game = new Game(questions, prizeSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a játék inicializálásakor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void InitializeUI()
        {
            // Főablak beállításai
            this.Text = "Who Wants To Be A Millionaire - Control Panel";
            this.ClientSize = new Size(900, 600);
            this.BackColor = Color.FromArgb(25, 25, 65);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Kérdés megjelenítése
            _questionLabel = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Arial", 18, FontStyle.Bold),
                Location = new Point(50, 30),
                Size = new Size(800, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(_questionLabel);

            // Válasz gombok
            _answerButtons = new Button[4];
            string[] prefixes = { "A: ", "B: ", "C: ", "D: " };
            
            for (int i = 0; i < 4; i++)
            {
                _answerButtons[i] = new Button
                {
                    Tag = i,
                    Text = prefixes[i],
                    BackColor = Color.FromArgb(0, 40, 100),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 14),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(600, 60),
                    Location = new Point(150, 150 + i * 70),
                    Cursor = Cursors.Hand
                };
                _answerButtons[i].FlatAppearance.BorderColor = Color.CornflowerBlue;
                _answerButtons[i].FlatAppearance.BorderSize = 2;
                _answerButtons[i].Click += AnswerButton_Click;
                this.Controls.Add(_answerButtons[i]);
            }

            // Pénzfa lista
            _prizeList = new ListBox
            {
                BackColor = Color.FromArgb(10, 10, 40),
                ForeColor = Color.White,
                Font = new Font("Consolas", 12),
                Size = new Size(200, 400),
                Location = new Point(680, 30),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(_prizeList);

            // Aktuális nyeremény
            _currentPrizeLabel = new Label
            {
                ForeColor = Color.Gold,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(50, 500),
                Size = new Size(600, 40),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(_currentPrizeLabel);

            // Segítség gombok
            _fiftyFiftyButton = CreateLifelineButton("50-50", 50, 450);
            _fiftyFiftyButton.Click += (s, e) => UseFiftyFifty();
            
            _audienceButton = CreateLifelineButton("Közönség", 180, 450);
            _audienceButton.Click += (s, e) => UseAudienceHelp();
            
            _phoneButton = CreateLifelineButton("Telefon", 310, 450);
            _phoneButton.Click += (s, e) => UsePhoneAFriend();
        }

        private Button CreateLifelineButton(string text, int x, int y)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = Color.FromArgb(70, 30, 120),
                ForeColor = Color.White,
                Font = new Font("Arial", 12),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40),
                Location = new Point(x, y),
                Cursor = Cursors.Hand,
                Tag = false // Használtság jelzése
            };
            btn.FlatAppearance.BorderColor = Color.MediumPurple;
            this.Controls.Add(btn);
            return btn;
        }

        private void UpdateGameUI()
        {
            // Kérdés frissítése
            _questionLabel.Text = _game.GetCurrentQuestion().Text;

            // Válaszlehetőségek
            for (int i = 0; i < 4; i++)
            {
                _answerButtons[i].Text = $"{(char)('A' + i)}: {_game.GetCurrentQuestion().Answers[i]}";
                _answerButtons[i].Enabled = true;
                _answerButtons[i].BackColor = Color.FromArgb(0, 40, 100);
            }

            // Pénzfa frissítése
            _prizeList.Items.Clear();
            for (int i = 0; i < _game.PrizeLevels.Length; i++)
            {
                string prizeText = $"{_game.PrizeLevels[i]:N0} Ft";
                if (i == _game.CurrentQuestionIndex)
                {
                    prizeText = ">> " + prizeText;
                }
                _prizeList.Items.Add(prizeText);
            }
            _prizeList.SelectedIndex = _game.CurrentQuestionIndex;

            // Aktuális nyeremény
            _currentPrizeLabel.Text = $"Aktuális nyeremény: {_game.CurrentPrize:N0} Ft";

            // Segítségek állapota
            UpdateLifelinesUI();
        }

        private void UpdateLifelinesUI()
        {
            _fiftyFiftyButton.Enabled = !_game.UsedLifelines[0];
            _audienceButton.Enabled = !_game.UsedLifelines[1];
            _phoneButton.Enabled = !_game.UsedLifelines[2];
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int answerIndex = (int)btn.Tag;
            
            // Válasz vizsgálata
            bool isCorrect = _game.CheckAnswer(answerIndex);
            
            // Visszajelzés
            if (isCorrect)
            {
                btn.BackColor = Color.Green;
                this.Refresh();
                System.Threading.Thread.Sleep(500);
                
                if (_game.IsGameOver())
                {
                    MessageBox.Show($"Gratulálunk! Nyertél {_game.CurrentPrize:N0} Ft-ot!", "Győzelem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    UpdateGameUI();
                }
            }
            else
            {
                btn.BackColor = Color.Red;
                _answerButtons[_game.GetCurrentQuestion().CorrectIndex].BackColor = Color.Green;
                this.Refresh();
                
                int prize = _game.Surrender();
                MessageBox.Show($"Sajnáljuk! A játék véget ért. Nyereményed: {prize:N0} Ft", "Vége a játéknak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void UseFiftyFifty()
        {
            _game.UseFiftyFifty();
            
            // Két random hibás válasz letiltása
            Random rnd = new Random();
            int hidden1, hidden2;
            
            do {
                hidden1 = rnd.Next(4);
            } while (hidden1 == _game.GetCurrentQuestion().CorrectIndex);
            
            do {
                hidden2 = rnd.Next(4);
            } while (hidden2 == _game.GetCurrentQuestion().CorrectIndex || hidden2 == hidden1);
            
            _answerButtons[hidden1].Enabled = false;
            _answerButtons[hidden2].Enabled = false;
            
            _fiftyFiftyButton.Enabled = false;
            _fiftyFiftyButton.Tag = true;
        }

        private void UseAudienceHelp()
        {
            var votes = _game.UseAudienceHelp();
            
            string message = "A közönség szavazatai:\n";
            for (int i = 0; i < 4; i++)
            {
                message += $"{(char)('A' + i)}: {votes[i]}%\n";
            }
            
            MessageBox.Show(message, "Közönség segítség", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _audienceButton.Enabled = false;
            _audienceButton.Tag = true;
        }

        private void UsePhoneAFriend()
        {
            string[] friendResponses = {
                "Szerintem a válasz a {0}... de nem vagyok benne biztos.",
                "Egyértelműen a {0} a helyes válasz!",
                "Nem tudom... talán a {0}?"
            };
            
            Random rnd = new Random();
            int confidence = rnd.Next(3);
            char correctAnswer = (char)('A' + _game.GetCurrentQuestion().CorrectIndex);
            
            string response = string.Format(friendResponses[confidence], correctAnswer);
            MessageBox.Show($"Barátod válasza: {response}", "Telefonhívás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            _phoneButton.Enabled = false;
            _phoneButton.Tag = true;
        }

        private List<Question> LoadQuestions(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<Question>>(json);
            }
            catch
            {
                MessageBox.Show($"Hiba a kérdések betöltésekor. Ellenőrizd a {path} fájlt.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Question>();
            }
        }

        private PrizeSettings LoadPrizeSettings(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<PrizeSettings>(json);
            }
            catch
            {
                MessageBox.Show($"Hiba a nyeremények betöltésekor. Ellenőrizd a {path} fájl.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new PrizeSettings { PrizeLevels = new List<int>(), SafeHavens = new List<int>() };
            }
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectIndex { get; set; }
        public int Level { get; set; }
    }

    public class PrizeSettings
    {
        public List<int> PrizeLevels { get; set; }
        public List<int> SafeHavens { get; set; }
    }

    public class Game
    {
        public List<Question> Questions { get; }
        public int[] PrizeLevels { get; }
        public List<int> SafeHavens { get; }
        public int CurrentQuestionIndex { get; private set; }
        public int CurrentPrize => CurrentQuestionIndex > 0 ? PrizeLevels[CurrentQuestionIndex - 1] : 0;
        public bool[] UsedLifelines { get; } = new bool[3]; // 50-50, Közönség, Telefon

        public Game(List<Question> questions, PrizeSettings prizeSettings)
        {
            Questions = questions;
            PrizeLevels = prizeSettings.PrizeLevels.ToArray();
            SafeHavens = prizeSettings.SafeHavens;
            CurrentQuestionIndex = 0;
        }

        public Question GetCurrentQuestion() => Questions[CurrentQuestionIndex];

        public bool CheckAnswer(int answerIndex)
        {
            bool isCorrect = (answerIndex == GetCurrentQuestion().CorrectIndex);
            if (isCorrect) CurrentQuestionIndex++;
            return isCorrect;
        }

        public bool IsGameOver() => CurrentQuestionIndex >= Questions.Count;

        public int Surrender() => SafeHavens.Contains(CurrentPrize) ? CurrentPrize : 0;

        public void UseFiftyFifty() => UsedLifelines[0] = true;

        public Dictionary<int, int> UseAudienceHelp()
        {
            UsedLifelines[1] = true;
            var question = GetCurrentQuestion();
            Random rnd = new Random();
            int correctVotes = rnd.Next(60, 91); // 60-90% a helyes válaszra
            
            var votes = new Dictionary<int, int>();
            int remainingPercent = 100 - correctVotes;
            
            for (int i = 0; i < 4; i++)
            {
                if (i == question.CorrectIndex)
                {
                    votes[i] = correctVotes;
                }
                else
                {
                    int wrongVote = rnd.Next(0, remainingPercent);
                    votes[i] = wrongVote;
                    remainingPercent -= wrongVote;
                }
            }
            
            return votes;
        }
    }
}