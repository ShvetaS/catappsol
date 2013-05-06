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
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Threading;

namespace CATapp
{
    public partial class Page4 : PhoneApplicationPage,INotifyPropertyChanged
    {
         private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
      //  public Int64 op;
        public Page4()
        {
            InitializeComponent();
            // Connect to the database and instantiate data context.
            catAppDB = new CatAppDataContext(DBConnectionString);

            // Data context and observable collection are children of the main page.
            this.DataContext = this;
           
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        private ObservableCollection<Question> _ques;
        public ObservableCollection<Question> Questions
        {
            get
            {
                return _ques;
            }
            set
            {
                if (_ques != value)
                {
                    _ques = value;
                    NotifyPropertyChanged("Questions");
                }
            }
        }

        /*protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            IDictionary<string, string> x = this.NavigationContext.QueryString;
            String a = Convert.ToString(x["TextData"]);
            txtQID.Text = a.ToString();
            base.OnNavigatedTo(e);
        }*/

        private void displaysol()
        {
            string sl = txtQID.Text;
            long qid;
            long.TryParse(sl, out qid);

            var q1 = from Question qs1 in catAppDB.Questions
                     where qs1._id == 50
                     select qs1;
            Questions = new ObservableCollection<Question>(q1);

        }

        private void catListBox_Loaded(object sender, RoutedEventArgs e)
        {
            displaysol();
        }

    }
}