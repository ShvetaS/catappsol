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
using System.Windows.Navigation;
using System.Windows.Threading;


namespace CATapp
{
    public partial class Opt : PhoneApplicationPage
    {
        // Data context for the local database
        private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";

        DispatcherTimer dt = new DispatcherTimer();
        DateTime startDt = new DateTime();
        TimeSpan ts = new TimeSpan();
        
        public string IsAnswerCorrect = null;
        public Opt()
        {
            InitializeComponent();

            // Connect to the database and instantiate data context.
            catAppDB = new CatAppDataContext(DBConnectionString);

            // Data context and observable collection are children of the main page.
            this.DataContext = this;

            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt.Tick += new EventHandler(dt_Tick);
            startDt = DateTime.Now;
            dt.Start();

           

        }
        //#region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;

        //// Used to notify the app that a property has changed.
        //private void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion


        void dt_Tick(object sender, EventArgs e)
        {

            ts = DateTime.Now.Subtract(startDt);
            txtHour.Text = ts.Hours.ToString();
            txtMin.Text = ts.Minutes.ToString();
            txtSec.Text = ts.Seconds.ToString();

            if (txtHour.Text.Length == 1) txtHour.Text = "0" + txtHour.Text;
            if (txtMin.Text.Length == 1) txtMin.Text = "0" + txtMin.Text;
            if (txtSec.Text.Length == 1) txtSec.Text = "0" + txtSec.Text;

        }
     
        private void radioButton1_Click_1(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            Boolean b = true;


            if (radio.Tag.ToString().Equals(b.ToString()))
            {
                IsAnswerCorrect = "true";

            }
            else
            {
                IsAnswerCorrect = "false";
            }


        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string ss = quesID.Text.ToString();
            // pivot1.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/Page4.xaml?selectedValue="+ ss, UriKind.Relative));
         
        }

       
    }
}