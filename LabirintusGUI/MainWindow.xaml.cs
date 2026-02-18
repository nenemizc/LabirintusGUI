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
using System.IO;

namespace LabirintusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 5; i < 21; i++)
            {
                cbSorokSzama.Items.Add(i);
                cbOszlopokSzama.Items.Add(i);
            }
            for (int i = 1; i < 17; i++)
            {
                cbAllomanyIndexe.Items.Add(i);
            }
            cbSorokSzama.SelectedItem = 12;
            cbOszlopokSzama.SelectedItem = 12;
            cbAllomanyIndexe.SelectedItem = 3;
        }

        private void btnLetrehoz_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < MyLab.Children.Count;)
            {
                if (MyLab.Children[i] is CheckBox)
                {
                    MyLab.Children.Remove(MyLab.Children[i] as CheckBox);
                }
                else
                {
                    i++;
                }
            }
            int sorokSzama = (int)cbSorokSzama.SelectedItem;
            int oszlopokSzama = (int)cbOszlopokSzama.SelectedItem;
            for (int r = 0; r < sorokSzama; r++)
            {
                for (int c = 0; c < oszlopokSzama; c++)
                {
                    CheckBox aktualisCheckBox = new CheckBox();
                    aktualisCheckBox.Margin = new Thickness(20 + c * 15, 90 + r * 15, 0, 0);
                    if (c == 0 || r == 0 || c == oszlopokSzama - 1 || r == oszlopokSzama - 1)
                    {
                        aktualisCheckBox.IsChecked = true;
                        aktualisCheckBox.IsEnabled = false;
                    }
                    if (r == 1 && c == 0 || c == oszlopokSzama -1 && r == sorokSzama - 2)
                    {
                        aktualisCheckBox.IsChecked = false;
                    }

                    MyLab.Children.Add(aktualisCheckBox);
                }
            }



        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> ki = new();
            int allomanyIndex = (int)cbAllomanyIndexe.SelectedItem;
            int oszlopokSzama = (int)cbOszlopokSzama.SelectedItem;
            string sor = "";
            int sz = 0;
            foreach(var item in MyLab.Children)
            {
                if (item is CheckBox)
                {
                    CheckBox aktualisCB = (CheckBox)item;
                    sor += (bool)aktualisCB.IsChecked ? "X" : " ";
                    sz++;
                }
                if (sz == oszlopokSzama)
                {
                    ki.Add(sor);
                    sz = 0;
                    sor = "";
                }
            }
            try
            {
                File.WriteAllLines($"Lab{allomanyIndex}.txt", ki);
                MessageBox.Show("Az állomány mentésre került");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}