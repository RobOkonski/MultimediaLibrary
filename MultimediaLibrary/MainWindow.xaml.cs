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

namespace MultimediaLibrary
{
    using Models;
    using Interfaces;
    using Repositories;
    using System.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //---------------Debug--------------
        DebugOutput outputter;
        //----------------------------------
        /// <summary>
        /// Constructor that initialise MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //---------Debug----------
            outputter = new DebugOutput(DebugBox);
            Console.SetOut(outputter);
            Console.WriteLine("Started");
            //-----------------------------------
        }

        /// <summary>
        /// Button1 action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open new AddArtistPage
        /// </remarks>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddArtistPage();
        }

        /// <summary>
        /// Button2 action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open new AddTrackPage
        /// </remarks>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddTrackPage();
        }

        /// <summary>
        /// Button3 action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open new DisplayArtistPage
        /// </remarks>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DisplayArtistPage();
        }
    }
}
