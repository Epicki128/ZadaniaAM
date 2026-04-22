namespace QuadraticEquation
{
    public partial class MainPage : ContentPage
    {
        private string baseResult = "y = ax² + bx + c";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Calculate(object sender, EventArgs e)
        {
            double x = 0, a = 0, b = 0, c = 0;
            double.TryParse(EntryX.Text.ToString(), out x);
            double.TryParse(EntryA.Text.ToString(), out a);
            double.TryParse(EntryB.Text.ToString(), out b);
            double.TryParse(EntryC.Text.ToString(), out c);

            string result = baseResult;

            result += $"\ny = {a}*{x}² + {b}*{x} {(c >= 0 ? "+ " + c : c)}";
            result += $"\ny = {a}*{Math.Pow(x, 2)} + {b * x} {(c >= 0 ? "+ " + c : c)}";
            result += $"\ny = {a * Math.Pow(x, 2)} + {(b * x) + c}";
            result += $"\ny = {(a * Math.Pow(x, 2)) + (b * x) - c}";

            LabelResult.Text = result;

            GraphicsViewGraph.Drawable = new QuadraticDrawable(a, b, c);
        }
    }

    // Klasa wykresu funkcji kwadratowej
    public class QuadraticDrawable : IDrawable
    {
        private double _a;
        private double _b;
        private double _c;

        public QuadraticDrawable(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        //funkcja rysująca wykres i funkcję kwadratową
        public void Draw(ICanvas canvas, RectF plainRect)
        {
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(plainRect);

            float width = plainRect.Width;
            float height = plainRect.Height;

            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;

            canvas.DrawLine(0, height / 2, width, height / 2);

            canvas.DrawLine(width / 2, 0, width / 2, height);

            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 3;

            float scale = 10f;

            for (float x = -width / 2; x < width / 2; x += 1)
            {
                double mathX = x / scale;
                double mathY = _a * mathX * mathX + _b * mathX + _c;

                float screenX = width / 2 + x;
                float screenY = height / 2 - (float)(mathY * scale);

                if (x > -width / 2)
                {
                    float prevMathX = (x - 1) / scale;
                    double prevMathY = _a * prevMathX * prevMathX + _b * prevMathX + _c;

                    float prevScreenX = width / 2 + (x - 1);
                    float prevScreenY = height / 2 - (float)(prevMathY * scale);

                    canvas.DrawLine(prevScreenX, prevScreenY, screenX, screenY);
                }
            }
        }
    }
}
