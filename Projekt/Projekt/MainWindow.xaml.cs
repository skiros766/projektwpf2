using System;
using System.IO;
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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Szukaj(object sender, RoutedEventArgs e)
        {
            try
            {
                string dir = @"C:\Users\jokke\Desktop\Projekt\Projekt\Przejazdy";
                
                foreach (var files in Directory.GetFiles(dir, przystanek1.Text + przystanek2.Text + ".txt", SearchOption.AllDirectories))
                {
                    DirectoryInfo fl = new DirectoryInfo(dir);

                    InitializeComponent();
                    string line;
                    var file = new System.IO.StreamReader(fl);

                    while ((line = file.ReadLine()) != null)
                    {
                        Rozklad.Items.Add(line);
                    }

                }
            }


            catch (Exception)
            {
                MessageBox.Show("Nie można znaleźć przejazdu");
            }
        }



       

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void admin(object sender, RoutedEventArgs e)
        {

            admin ad = new admin();
            ad.Show();
            this.Close();

        }
    }
}
