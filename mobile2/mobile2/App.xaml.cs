using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "Grossery.db";
        public static BDoperations database;
        public static BDoperations Database
        {
            get
            {
                if(database==null)
                {
                    database = new BDoperations(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
