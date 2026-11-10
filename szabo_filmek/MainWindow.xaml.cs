using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szabo_filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Film> filmek = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
            filmek.Add(new Film("Csillagok háborúja", "sci-fi", 121, 8.6));
            filmek.Add(new Film("Titanic", "dráma", 195, 7.8));
            filmek.Add(new Film("A Gyűrűk Ura", "fantasy", 201, 8.8));
            filmek.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            filmek.Add(new Film("Shrek", "animáció", 90, 7.9));
        }

        private void filmek_betoltese(object sender, RoutedEventArgs e)
        {
            filmekdtg.Columns.Clear();
            filmekdtg.AutoGenerateColumns = true;

            filmekdtg.ItemsSource = filmek;
        }

        private void hany_film_van(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {filmek.Count()} film van");
        }

        private void leghosszabb_film(object sender, RoutedEventArgs e)
        {
            Film leghosszabb = filmek[0];

            foreach (var item in filmek)
            {
                if (item.Hossz > leghosszabb.Hossz)
                {
                    leghosszabb = item;
                }
            }

            MessageBox.Show($"A leghosszabb film: {leghosszabb.Cim}, perc: {leghosszabb.Hossz}");
        }

        private void atlagos_ertekeles(object sender, RoutedEventArgs e)
        {
            double osszeg = 0;
            int db = 0;

            foreach (var item in filmek)
            {
                osszeg += item.Ertekeles;
                db++;
            }
            double atlag = osszeg / db;
            MessageBox.Show($"Az átlagos értékelése: {atlag}");
        }

        private void csak_scifi(object sender, RoutedEventArgs e)
        {
            List<Film> sci_fi = new List<Film>();

            foreach (var item in filmek)
            {
                if (item.Mufaj == "sci-fi".ToLower())
                {
                    sci_fi.Add(item);
                }
            }
            filmekdtg.ItemsSource = sci_fi;
        }

        private void csak_cimek(object sender, RoutedEventArgs e)
        {
            List<string> cimek = new List<string>();

            foreach (var item in filmek)
            {
                cimek.Add(item.Cim);
            }

            filmekdtg.AutoGenerateColumns = false;
            filmekdtg.Columns.Clear();

            DataGridTextColumn oszlop = new DataGridTextColumn();

            oszlop.Header = "Film címe";
            oszlop.Binding = new Binding();

            filmekdtg.Columns.Add(oszlop);

            filmekdtg.ItemsSource = cimek;
        }

        
    }
}