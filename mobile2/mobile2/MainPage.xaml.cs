using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace mobile2
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Spisok> Spisoks { get; set; }
        private DatabaseServer _databaseService;
        public YourViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ViewModel = new YourViewModel();
            BindingContext = ViewModel;

            //label label1 = new label() { text = "bbh" };
            //label label2 = new label() { text = "vghj" };
            //stacklayout stacklayout = new stacklayout()
            //{
            //    children = { label1, label2 }
            //};
            //this.content = stacklayout;
            //stackLayout.Children.Add(new Label { Text = "Третья метка" });


            _databaseService = new DatabaseServer(DependencyService.Get<ISQLite>().GetLocalPath("Grossery.db"));
            Spisoks = new ObservableCollection<Spisok>();
            LoadSpisok();
        }
        //private void LoadSpisok()
        //{
        //    var spis = _databaseService.GetItems();
        //    Spisoks.Clear();
        //    foreach (var spi in spis)
        //    {
        //        Spisoks.Add(spi);
        //    }
        //    TasksListView.ItemsSource = Spisoks;
        //}
        private void LoadSpisok()
        {
            var bd = new BD();
            var spis = 
            Spisoks.Clear();
            foreach (var spi in spis)
            {
                Spisoks.Add(spi);
            }
            TasksListView.ItemsSource = Spisoks;
        }
        private async void CreateSpisok(object sender, EventArgs e)
        {
            var taskPage = new NewSpis();
            taskPage.Disappearing += (s, args) => LoadSpisok();
            await Navigation.PushAsync(taskPage);
        }
        private async void Button_Click(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Spis());



        }
        //private async void OnDelete(object sender, EventArgs e)
        //{
        //    await DisplayAlert("Удаление списка", "Вы уверены, что хотите удалить список?", "OK", "Отмена");
        //    if()
        //    var menuItem = sender as MenuItem;
        //    var item = menuItem?.CommandParameter as Button; 

        //}

        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
        public ICommand OpenMenuCommand { get; private set; }
    }
    public class YourViewModel
    {
        public ICommand OpenMenuCommand { get; private set; }

        public YourViewModel()
        {
            OpenMenuCommand = new Command(OpenMenu);
        }

      

        private async void OpenMenu()
        {
            // Здесь открывайте ваше меню
            // Например, если ваше меню находится в NavigationPage, используйте следующий код:
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true; // Это откроет левое меню на FlyoutPage
            }
        }
    }  
}
