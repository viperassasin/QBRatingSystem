using QBRatingSystem.Implementations;
using QBRatingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace QBRatingSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<QuarterbackAware, NationalCollegiateAthleticAssociationQB>();
            container.RegisterType<QuarterbackAware, NationalCollegiateAthleticAssociationQB>();
            container.RegisterType<QuarterbackAware, CanadianFootbalLeagueQB>();
            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
