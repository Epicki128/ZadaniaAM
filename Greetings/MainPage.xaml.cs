namespace Greetings
{
    public partial class MainPage : ContentPage
    {
        private List<string> Greetings = new List<string> { "Dzień dobry", "Buenos dias", "Good morning" };
        private int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Quote.Text = Greetings[count];
        }

        private void FontSizeChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)FontSizeSlider.Value;
            Output.Text = $"Rozmiar {value}";
            Quote.FontSize = value;
        }

        private void BtnClicked(object sender, EventArgs e)
        {
            if (count < Greetings.Count - 1)
            {
                count++;
            }
            else
            {
                count = 0;
            }

            Quote.Text = Greetings[count];
        }
    }
}
