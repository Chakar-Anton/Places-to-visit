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
    /// Логика взаимодействия для CountryPage.xaml
    /// </summary>
    public partial class CountryPage : Page
    {
        public CountryPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label_error.Content = "";
            for (int i = 0; i < Functions.GeneralList.Count(); i++)
            {
                if (TextBox_Name.Text == Functions.GeneralList[i].Name) Label_error.Content = "Страна с таким именем уже существует";

            }
            if (Label_error.Content == "")
            {
                List<Sight> tempList = new List<Sight>();
                Functions.GeneralList.Add(new Country(TextBox_Name.Text, tempList));
                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
                nav.GoBack();
            }

        }
    }
}
