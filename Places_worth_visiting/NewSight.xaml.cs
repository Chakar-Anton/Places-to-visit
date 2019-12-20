using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для NewSight.xaml
    /// </summary>
    public partial class NewSight : Page
    {
        public NewSight()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                Sight temp = new Sight(TextBox_Name.Text, TextBox_Describe.Text, "");
                for (int i = 0; i < Functions.GeneralList.Count; i++)
                {
                    if (Functions.GeneralList[i].Name == ComboBox_Country.SelectedValue)
                    {
                        Functions.GeneralList[i].Sights.Add(temp);
                        NavigationService nav;
                        Sights n = new Sights();
                        nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(n);
                    }
                }
            }

        }

        private void Button_Add_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> CountryName = new List<string>();
            for (int i = 0; i < Functions.GeneralList.Count; i++)
            {
                CountryName.Add(Functions.GeneralList[i].Name);
            }
            ComboBox_Country.ItemsSource = CountryName;
        }

        bool check()
        {
            if (ComboBox_Country.SelectedValue == null) return false;
            List<Country> list = Functions.GeneralList;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == ComboBox_Country.SelectedValue.ToString())
                {

                    for (int j = 0; j < list[i].Sights.Count; j++)
                        if (TextBox_Name.Text == list[i].Sights[j].Name)
                        {
                            Label_error.Content = "Достопримечательность с таким названием уже есть";
                            return false;
                        }
                }

            }
            for (int i = 0; i < TextBox_Name.Text.Length; i++)
                if ((TextBox_Name.Text[i] > '0' && TextBox_Name.Text[i] < '9') || (TextBox_Name.Text[i] > 'a' && TextBox_Name.Text[i] < 'z') || (TextBox_Name.Text[i] > 'A' && TextBox_Name.Text[i] < 'Z') || (TextBox_Name.Text[i] > 'А' && TextBox_Name.Text[i] < 'Я') || (TextBox_Name.Text[i] > 'а' && TextBox_Name.Text[i] < 'я') || TextBox_Name.Text[i] == ' ')
                { }
                else
                {
                    Label_error.Content = "В названии есть недопустимые знаки. Используйте только латинские буквы, кириллицу или цифры.";
                    return false;
                }
            if (TextBox_Describe.Text == "" || TextBox_Name.Text == "")
            {
                Label_error.Content = "Проверьте, заполнили ли вы все поля";
                return false;
            }
            return true;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            Sights n = new Sights();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(n);
        }
    }
}
