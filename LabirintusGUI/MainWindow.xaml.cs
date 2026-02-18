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

        }
    }
}