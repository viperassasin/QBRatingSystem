using QBRatingSystem.Enums;
using QBRatingSystem.Dependencies;
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
        public MainWindow()
        {
            //DataContext = new QBRatingViewModel();
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var qbViewModel = DataContext as QBRatingViewModel;
            if (qbViewModel!=null && qbViewModel.BoxesAreValid())
            {
                PasserRatingLabel.Content = (DataContext as QBRatingSystem.ViewModels.QBRatingViewModel).GetPasserRating(); 
            }
        }

        private void LeagueCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {
                var comboBox = sender as ComboBox;
                QBRatingViewModel qBRatingViewModel = null;
                switch (comboBox.SelectedItem)
                {
                    case League.NFL:
                        {
                            qBRatingViewModel = new QBRatingViewModel(new NationalFootballLeagueQB());
                            break;
                        }
                    case League.CFL:
                        {
                            qBRatingViewModel = new QBRatingViewModel(new CanadianFootbalLeagueQB());
                            break;
                        }
                    case League.NCAA:
                        {
                            qBRatingViewModel = new QBRatingViewModel(new NationalCollegiateAthleticAssociationQB());
                            break;
                        }
                    default:
                        break;
                }
                DataContext = qBRatingViewModel;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            PasserRatingLabel.Content = "";
            QBRatingViewModel qbViewModel=null;
            switch (LeagueCombo.SelectedItem)
            {
                case League.NFL:
                    {
                        qbViewModel = new QBRatingViewModel(new NationalFootballLeagueQB());
                        break;
                    }
                case League.CFL:
                    {
                        qbViewModel = new QBRatingViewModel(new CanadianFootbalLeagueQB());
                        break;
                    }
                case League.NCAA:
                    {
                        qbViewModel = new QBRatingViewModel(new NationalCollegiateAthleticAssociationQB());
                        break;
                    }
                default:
                    break;
            }
            DataContext = qbViewModel;
        }
    }
}
