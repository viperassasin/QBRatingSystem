using QBRatingSystem.Enums;
using QBRatingSystem.Implementations;
using QBRatingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        [Dependency]
        public QBRatingViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public MainWindow()
        {
            //DataContext = new QBRatingViewModel();
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var qBRatingViewModel = DataContext as QBRatingSystem.ViewModels.QBRatingViewModel;
            qBRatingViewModel.Quarterback.SetPasserRating();
            PasserRatingLabel.Content = qBRatingViewModel.Quarterback.PasserRating;
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {

        }

        private void LeagueListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                var comboBox = sender as ComboBox;
                var qBViewModel = DataContext as QBRatingViewModel;
                switch (comboBox.SelectedItem)
                {
                    case LevelOfPlayer.NFL:
                        {
                            qBViewModel.SetQuarterBack(new NationalFootballLeagueQB());
                            break;
                        }
                    case LevelOfPlayer.CFL:
                        {
                            qBViewModel.SetQuarterBack(new CanadianFootbalLeagueQB());
                            break;
                        }
                    case LevelOfPlayer.NCAA:
                        {
                            qBViewModel.SetQuarterBack(new NationalCollegiateAthleticAssociationQB());
                            break;
                        }
                    default:
                        break;
                }
                DataContext = qBViewModel;
            }
        }
    }
}
