namespace Hangman
{
    public partial class MainPage : ContentPage
    {
        private readonly char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private string selectedWord = "";
        private int errors = 0;
        private List<char> resultList = new();
        private List<int> populatedIdxs = new();
        private string[] words = {
            "kot",
            "las",
            "dom",
            "pies",
            "most",
            "ogon",
            "kawa",
            "sen",
            "mrok",
            "dym",
            "plan",
            "ruch",
            "wiatr",
            "skok",
            "bruk",
            "droga",
            "miasto",
            "chmura",
            "jezioro",
            "kamien",
            "telefon",
            "ogrodek",
            "samolot",
        };
        private Random rng = new();

        public MainPage()
        {
            InitializeComponent();

            selectedWord = words[rng.Next(0, words.Length)];

            foreach (char letter in letters)
            {
                Button button = new();
                button.WidthRequest = 10;
                button.HeightRequest = 10;
                button.Margin = 7;
                button.Clicked += letterBtn_Clicked;

                button.Text = Convert.ToString(letter);
                keyboard.Add(button);
            }
        }

        private void VerticalStackLayout_Loaded(object sender, EventArgs e)
        {
            word.Children.Clear();
            for (int i = 0; i < selectedWord.Length; i++)
            {
                VerticalStackLayout stack = new();
                stack.HorizontalOptions = LayoutOptions.Start;
                stack.VerticalOptions = LayoutOptions.Center;
                stack.Margin = 10;

                BoxView box = new();
                box.WidthRequest = 20;
                box.HeightRequest = 5;
                box.BackgroundColor = Color.FromArgb("#000");

                Label letter = new();
                letter.WidthRequest = 30;
                letter.HeightRequest = 35;
                letter.FontSize = 22;
                letter.HorizontalTextAlignment = TextAlignment.Center;

                stack.Add(letter);
                stack.Add(box);
                word.Add(stack);
            }
        }

        private void resetBtn_Clicked(object sender, EventArgs e)
        {
            resultList.Clear();
            populatedIdxs.Clear();
            selectedWord = words[rng.Next(0, words.Length)];
            foreach (Button btn in keyboard.Children)
                if (!btn.IsEnabled)
                    btn.IsEnabled = true;

            VerticalStackLayout_Loaded(sender, e);
            errors = 0;
            erro.Text = "Errors: 0 of 6";
        }
        private void letterBtn_Clicked(object sender, EventArgs e)
        {

            char letter = ((Button)sender).Text.ToCharArray()[0];

            if (resultList.Contains(letter)) return;

            if (selectedWord.IndexOf(letter) == -1)
            {
                ((Button)sender).IsEnabled = false;
                errors += 1;
                erro.Text = $"Errors: {errors} of 6";
            }

            if (errors >= 6)
            {
                erro.Text = $"You lost! The word is: {selectedWord}";
                foreach (Button button in keyboard.Children)
                    button.IsEnabled = false;
                return;
            }

            foreach (char wordLetter in selectedWord)
            {
                int letterIdx;

                if (wordLetter != letter)
                    continue;

                if (!populatedIdxs.Contains(selectedWord.IndexOf(wordLetter)))
                    letterIdx = selectedWord.IndexOf(wordLetter);
                else
                    letterIdx = selectedWord.LastIndexOf(wordLetter);

                resultList.Add(letter);
                populatedIdxs.Add(letterIdx);

                ((Label)((VerticalStackLayout)word.Children[letterIdx]).Children[0]).Text = letter.ToString();

                if (resultList.Count == selectedWord.Length)
                {
                    erro.Text = "You won!";
                    break;
                }
            }

        }
    }
}
