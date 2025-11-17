namespace DiceRoll
{
    public partial class MainPage : ContentPage
    {
        private string[] dicesImgSrc = { "k1.jpg", "k2.jpg", "k3.jpg", "k4.jpg", "k5.jpg", "k6.jpg" };

        private string lblScoreTxt, lblCurrentTxt;

        private int totalScore = 0, roundScore = 0;

        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            lblCurrentTxt = lblCurrent.Text;
            lblScoreTxt = lblScore.Text;
        }

        private void Roll(object sender, EventArgs e)
        {
            int[] numbers = new int[5];
            roundScore = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(0, 6);
                roundScore += numbers[index] + 1;
            }

            totalScore += roundScore;

            var images = grid.Children.ToArray();
            int i = 0;
            images.OfType<Image>().ToList().ForEach((img) =>
            {
                img.Source = ImageSource.FromFile(dicesImgSrc[numbers[i]]);
                i++;
            });


            lblCurrent.Text = lblCurrentTxt + roundScore;
            lblScore.Text = lblScoreTxt + totalScore;
        }

        private void Clear(object sender, EventArgs e)
        {
            var images = grid.Children.ToArray();
            images.OfType<Image>().ToList().ForEach((img) =>
            {
                img.Source = ImageSource.FromFile("question.jpg");
            });
            lblCurrent.Text = lblCurrentTxt;
            lblScore.Text = lblScoreTxt;
            totalScore = 0;
        }

    }
}
