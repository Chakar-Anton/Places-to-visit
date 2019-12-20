using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ТурОператор
{
    /// <summary>
    /// Логика взаимодействия для First.xaml
    /// </summary>
    public partial class First : Page
    {
        public First()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            CountryPage CP = new CountryPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Functions.Write();
            Functions.SerializationWrite();
            Environment.Exit(0);
            //Application.Shutdown();

        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Country> list;
            if (Functions.GeneralList.Count == 0)
                list = Functions.ReadSerialization();
            // list = Functions.Read();
            else
                list = Functions.GeneralList;
            List<string> CountryName = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                CountryName.Add(list[i].Name);
            }
            ComboBox_Country.ItemsSource = CountryName;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Country.SelectedValue == null) Label_error.Content = "Выберите страну";
            else
            {
                if (ComboBox_Country.SelectedValue != "") Functions.choice = ComboBox_Country.SelectedValue.ToString();
                NavigationService nav;
                Sights CP = new Sights();
                nav = NavigationService.GetNavigationService(this);
                nav.Navigate(CP);
            }
        }
    }
}
