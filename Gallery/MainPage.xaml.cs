namespace Gallery
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        String[] sources = { "kot1.jpg", "kot2.jpg", "kot3.jpg", "kot4.jpg" };
        int counter = 0;

        void Carousel(object Sender, EventArgs e)
        {
            if (Sender.Equals(prevBtn))
            {
                if (counter > 0)
                {
                    counter--;
                }
                else
                {
                    counter = 3;
                }

            }
            else
            {
                if (counter < 3)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

            }
            imageCarousel.Source = sources[counter];
        }

        void Entry(object Sender, TextChangedEventArgs e)
        {
            int temp = 0;
            try { temp = int.Parse(imgIdEnt.Text) - 1; } catch { }

            if (temp >= 0 && temp <= 3)
            {
                counter = temp;
            }

            imageCarousel.Source = sources[counter];
        }

        private void bgChange(object sender, ToggledEventArgs e)
        {

            if (e.Value)
            {
                main.SetDynamicResource(VisualElement.StyleProperty, "bgBlue");
            }
            else
            {
                main.SetDynamicResource(VisualElement.StyleProperty, "bgGreen");
            }
        }
    }
}
