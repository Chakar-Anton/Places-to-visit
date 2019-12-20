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
using System.Windows.Shapes;

namespace ТурОператор
{
    /// <summary>
    /// Логика взаимодействия для SightEdit.xaml
    /// </summary>
    public partial class SightEdit : Window
    {
        public SightEdit(string s1, string s2, string s3)
        {
            InitializeComponent();
            Label_County.Content = s1;
            Label_Sight.Content = s2;
            TextBox_Describe.Text = s3;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Functions.GeneralList.Count; i++)
            {
                if (Functions.GeneralList[i].Name == Label_County.Content)
                {
                    for (int j = 0; j < Functions.GeneralList[i].Sights.Count; j++)
                        if (Functions.GeneralList[i].Sights[j].Name == Label_Sight.Content)
                        {
                            Functions.GeneralList[i].Sights[j].Describe = TextBox_Describe.Text;
                            this.Close();
                        }
                }
            }
        }
    }
}