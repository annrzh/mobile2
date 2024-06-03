using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class NewSpis : ContentPage
    {
        private DatabaseServer _databaseService;
        public NewSpis()
        {
            InitializeComponent();

            _databaseService = new DatabaseServer(DependencyService.Get<ISQLite>().GetLocalPath("Grossery.db"));
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void Save(object sender, EventArgs e)
        {
            
            var spisok = new Spisok
            {
                Name = NameEntry.Text,
                Date = DateEntry.Date
            };

            if (!string.IsNullOrEmpty(spisok.Name))
            {
                _databaseService.SaveItem(spisok);
                await Navigation.PopAsync();
            }



        }
        private async void ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}