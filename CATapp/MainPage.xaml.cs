using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CATapp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
             
            // Connect to the database and instantiate data context.
          

        }
        
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
           

            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
       
       

       

    }
}