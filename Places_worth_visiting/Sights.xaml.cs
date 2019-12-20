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
    /// Логика взаимодействия для Sights.xaml
    /// </summary>
    public partial class Sights : Page
    {

        public Sights()
        {
            InitializeComponent();

        }

        private void StackPanel_first_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Functions.GeneralList.Count; i++)
            {
                if (Functions.choice == Functions.GeneralList[i].Name)
                {
                    for (int j = 0; j < Functions.GeneralList[i].Sights.Count; j++)
                    {
                        Label number = new Label();
                        number.Content = (j + 1).ToString();
                        StackPanel_first.Children.Add(number);

                        Label label = new Label();
                        label.Content = Functions.GeneralList[i].Sights[j].Name;
                        StackPanel_first.Children.Add(label);

                        Label label2 = new Label();
                        label2.Content = Functions.GeneralList[i].Sights[j].Describe;
                        StackPanel_first.Children.Add(label2);

                        Button editbutton = new Button();
                        editbutton.Name = "a" + i.ToString() + "Edit_Button" + j.ToString();
                        editbutton.Click += (s, e1) =>
                        {
                            string s1, s2;
                            int pos = 0;
                            s1 = "";
                            for (int counter = 1; counter < editbutton.Name.Length; counter++)
                                if (editbutton.Name[counter] != 'E') { s1 += editbutton.Name[counter]; pos = counter; }
                                else
                                    break;
                            s2 = editbutton.Name.Substring(pos + 12);


                            SightEdit se = new SightEdit(Functions.choice, Functions.GeneralList[int.Parse(s1)].Sights[int.Parse(s2)].Name, Functions.GeneralList[int.Parse(s1)].Sights[int.Parse(s2)].Describe);
                            se.ShowDialog();
                            NavigationService nav;
                            Sights sight = new Sights();
                            nav = NavigationService.GetNavigationService(this);
                            nav.Navigate(sight);

                        };
                        editbutton.Height = 25;
                        editbutton.Width = 100;
                        editbutton.HorizontalAlignment = HorizontalAlignment.Left;
                        editbutton.Margin = new Thickness(0, 0, 0, 10);
                        editbutton.Content = "Редактировать";
                        StackPanel_first.Children.Add(editbutton);

                        Button button = new Button();
                        button.Name = "button" + j.ToString();
                        button.Click += (s, e1) => Delete(int.Parse(button.Name.Substring(6)));
                        button.Height = 25;
                        button.Width = 60;
                        button.HorizontalAlignment = HorizontalAlignment.Left;
                        button.Margin = new Thickness(0, 0, 0, 10);
                        button.Content = "Удалить";
                        StackPanel_first.Children.Add(button);
                    }


                    WrapPanel wp = new WrapPanel();
                    Button buttonBack = new Button();
                    buttonBack.Content = "Назад";
                    buttonBack.Height = 25;
                    buttonBack.Width = 60;
                    buttonBack.HorizontalAlignment = HorizontalAlignment.Left;
                    buttonBack.Margin = new Thickness(0, 0, 10, 10);
                    buttonBack.Click += (s, e1) =>
                    {
                        NavigationService nav;
                        First f = new First();
                        nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(f);
                    };

                    Button buttonNext = new Button();
                    buttonNext.Content = "Добавить достопримечательность";
                    buttonNext.Height = 25;
                    buttonNext.Width = 60;
                    buttonNext.HorizontalAlignment = HorizontalAlignment.Left;
                    buttonNext.Margin = new Thickness(0, 0, 0, 10);
                    buttonNext.Click += (s, e1) =>
                    {
                        NavigationService nav;
                        NewSight n = new NewSight();
                        nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(n);
                    };
                    wp.Children.Add(buttonBack);
                    wp.Children.Add(buttonNext);
                    StackPanel_first.Children.Add(wp);
                    break;
                }
            }

        }


        void Delete(int numberDel)
        {
            for (int i = 0; i < Functions.GeneralList.Count; i++)
            {
                if (Functions.choice == Functions.GeneralList[i].Name)
                {
                    Functions.GeneralList[i].Sights.RemoveAt(numberDel);

                }
            }

            NavigationService nav;
            Sights s = new Sights();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(s);
        }
    }
}