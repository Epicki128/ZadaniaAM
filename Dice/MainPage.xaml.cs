namespace Dice
{
    public partial class MainPage : ContentPage
    {
        private bool[] isImageButtonEnabled = { true, true, true, true, true };

        private Random rng = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private void img_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            int btnIdx = Convert.ToInt16(btn.StyleId.Split("img")[1]);
            isImageButtonEnabled[btnIdx] = !isImageButtonEnabled[btnIdx];
            int btnBoneValue = Convert.ToInt16(btn.Source.ToString()?.Split("kosc")[1].Split(".png")[0]);

            if (!isImageButtonEnabled[btnIdx])
            {
                btn.Opacity = 0.5;
                return;
            }

            btn.Opacity = 1;
        }

        private void buttonThrow_Clicked(object sender, EventArgs e)
        {
            int finalResult = 0;
            Button button = (Button)sender;

            for (int i = 0; i < 5; i++)
            {
                if (isImageButtonEnabled[i])
                {
                    int res = rng.Next(1, 7);
                    ImageButton imgBtn = (ImageButton)button.FindByName($"img{i}");
                    finalResult += res;
                    imgBtn.Source = $"kosc{res}.png";
                }
            }


            lblResult.Text = $"{finalResult}";
        }
    }
}
