using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace mobile2
{
    public partial class MenuFlyout : ContentPage
    {
        public ObservableCollection<MenuFlyoutMenuItem> MenuItems { get; set; }

        public MenuFlyout()
        {
            InitializeComponent();
            MenuItems = new ObservableCollection<MenuFlyoutMenuItem>
            {
                 new MenuFlyoutMenuItem { Title = "Page 1", TargetType = typeof(Spis) },
   new MenuFlyoutMenuItem { Title = "Page 2", TargetType = typeof(Spis) },
   new MenuFlyoutMenuItem { Title = "Page 3", TargetType = typeof(Spis) },
            };
            BindingContext = this;
        }

        public ListView ListViewControl => ListView;
    }
}
