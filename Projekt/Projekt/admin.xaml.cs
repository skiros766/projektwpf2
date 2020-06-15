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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tworzenieprzejazdu(object sender, RoutedEventArgs e)
        {
            string dir = @"C:\Przejazdy\" + przejazd1.Text + przejazd2.Text;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);

            }
            DirectoryInfo fl = new DirectoryInfo(dir);
           

            
                using (StreamWriter writer = new StreamWriter(fl + @"\" + przystanek1dodaj.Text + przystanek2dodaj.Text + ".txt", append: true))
                {
                    writer.WriteLine("Nazwa przystanku: " + przejazd1.Text);
                    writer.WriteLine("Nazwa przystanku końcowego: " + przejazd2.Text);
                    writer.WriteLine("Numer tramwaju: " + przystanek.Text);
                    writer.WriteLine("Godzina odjazdu: " + godzina.Text);
                    writer.WriteLine("====================================");

                    MessageBox.Show("Dodano!");
                }
               

                try
                {

                    InitializeComponent();
                    string line;
                    var file = new System.IO.StreamReader(fl + @"\" + przystanek1dodaj.Text + przystanek2dodaj.Text + ".txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        adminrozklad.Items.Add(line);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Wystąpił błąd, spróbuj ponownie.");
                }

            }

            private void wroc(object sender, RoutedEventArgs e)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }

            private void usuwanieprzejazdu(object sender, RoutedEventArgs e)
            {


            using (StreamWriter writer = File.AppendText(@"C:\Przejazdy\" + przystanek1dodaj.Text + przystanek2dodaj.Text + ".txt"))
            {
                while (adminrozklad.SelectedItems.Count > 0)
                {
                    writer.WriteLine(adminrozklad.SelectedItems[0].ToString());
                    adminrozklad.Items.Remove(adminrozklad.SelectedItems[0]);
                }
                writer.Close();



            }
            }

            private void load(object sender, RoutedEventArgs e)
            {
                try
                {

                adminrozklad.Items.Clear();
                InitializeComponent();
                    string line;
                    var file = new System.IO.StreamReader(@"C:\Przejazdy\" + przystanek1dodaj.Text + przystanek2dodaj.Text + ".txt");

                    while ((line = file.ReadLine()) != null)
                    {
                        adminrozklad.Items.Add(line);
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
        }
    }


