namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        private List<string> todos = new List<string>() { "Zakupy: Chleb, masło, ser", "Do zrobienie: obiad, umyć podłogi", "weekend: kino, spacer z psem" };
        public MainPage()
        {
            InitializeComponent();
            LvTodos.ItemsSource = todos;
        }

        private void addTodo(object sender, EventArgs e)
        {
            string temp = EntTodo.Text;
            todos.Add(temp);
            LvTodos.ItemsSource = todos.ToArray();
        }
    }
}
