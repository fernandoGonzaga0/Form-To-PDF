using System.Windows;
using System.Windows.Input;
using FormPDF.ViewModel;

namespace FormPDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ligando a View ao ViewMOdel
            this.DataContext = new PersonFormViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}