using QBRatingSystem.Enums;
using QBRatingSystem.Implementations;
using QBRatingSystem.ViewModels;
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

namespace QBRatingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QBRatingViewModel qBRatingViewModel;
        public MainWindow()
        {
            DataContext = new QBRatingViewModel()
            {
                Quarterback = new NationalFootballLeagueQB()
            };
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            QBRatingViewModel qBRatingViewModel1 = DataContext as QBRatingViewModel;
            PasserRatingLabel.Content = qBRatingViewModel1.Quarterback.PasserStats.Attempts;
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
