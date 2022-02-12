using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Chrono
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = new TimeSpan(0, 0, 0, 0, 10)
        };

        private DateTime Depart;
        private DateTime DebutTour;
        bool pause = false;
        private DateTime Tstop;

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += delegate
            {
                maj();
            };

        }

        //MAJ
        public void maj()
        {
            Affichage.Content = Calcul();
        }

        //calcul
        public TimeSpan Calcul()
        {
            return DateTime.Now - Depart;
        }

        //boutons
        private void StartD(object sender, RoutedEventArgs e)
        {
            Arreter.IsEnabled = true;
            Tour.IsEnabled = true;
            Effacer.IsEnabled = false;
            Demarrer.IsEnabled = false;

            if (pause == true)
            {
                Depart += DateTime.Now - Tstop;
                DebutTour += DateTime.Now - Tstop;
            }
            else
                DebutTour = Depart = DateTime.Now;
            timer.Start();
        }

        private void stop(object sender, RoutedEventArgs e)
        {
            pause = true;
            Arreter.IsEnabled = false;
            Tour.IsEnabled = false;
            timer.Stop(); 
            Tstop = DateTime.Now;
            Effacer.IsEnabled = true;
            Demarrer.IsEnabled = true;
        }

        private void tour(object sender, RoutedEventArgs e)
        {
            TimeSpan DureeTour = DateTime.Now - DebutTour;
            TempsTours.Items.Add(DureeTour);
            DebutTour = DateTime.Now;
        }

        private void effacer(object sender, RoutedEventArgs e)
        {
            DebutTour = Depart = DateTime.Now;
            maj();
            Effacer.IsEnabled = false;
        }
    }
}
