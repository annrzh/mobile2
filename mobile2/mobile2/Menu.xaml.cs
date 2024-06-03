using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : FlyoutPage
    {
        public Menu()
        {
            InitializeComponent();
            var flyoutPage = Flyout as MenuFlyout;
            flyoutPage.ListViewControl.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as MenuFlyoutMenuItem;
                if (item == null)
                    return;

                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page);
                IsPresented = false;

                var flyoutPage = Flyout as MenuFlyout;
                flyoutPage.ListViewControl.SelectedItem = null;
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Error: {ex.Message}");
                // Вывод сообщения об ошибке
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
