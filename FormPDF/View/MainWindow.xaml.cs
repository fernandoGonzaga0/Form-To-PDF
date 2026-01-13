using System.Windows;
using System.Windows.Input;
using FormPDF.ViewModel;
using FormPDF.Services;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using QuestPDF.Infrastructure;

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

            // inicializando a licença para uso do QuestPDF
            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "form.pdf",
                DefaultExt = ".pdf",
                Filter = "PDF documents (.pdf)|*.pdf"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // instancia o gerador de PDF
                var generator = new PdfGenerator();
                var personInfoToPdf = (PersonFormViewModel)this.DataContext;

                try
                {
                    generator.Generate(dialog.FileName, personInfoToPdf);

                    // verificando se o arquivo foi realmente criado
                    if (File.Exists(dialog.FileName))
                    {
                        MessageBox.Show("PDF exported successfully!");

                        // abrindo o PDF
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = dialog.FileName,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("Error. File not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"PDF doesn't open.\n{ex.Message}");
                }

            }

        }
    }
}