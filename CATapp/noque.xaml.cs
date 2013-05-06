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
    public partial class noque : PhoneApplicationPage,INotifyPropertyChanged
    {
        


        private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
        public noque()
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

        private ObservableCollection<Option> _opts;
        public ObservableCollection<Option> Options
        {
            get
            {
                return _opts;
            }
            set
            {
                if (_opts != value)
                {
                    _opts = value;
                    NotifyPropertyChanged("Options");
                }
            }
        }
        private ObservableCollection<Category> _cats;
          public ObservableCollection<Category> Categories
        {
            get
            {
                return _cats;
            }
            set
            {
                if (_cats != value)
                {
                    _cats = value;
                    NotifyPropertyChanged("Categories");
                }
            }
        }

          private ObservableCollection<Question_category> _quecats;
          public ObservableCollection<Question_category> Question_categories
          {
              get
              {
                  return _quecats;
              }
              set
              {
                  if (_quecats != value)
                  {
                      _quecats = value;
                      NotifyPropertyChanged("Question_categories");
                  }
              }
          }
          private ObservableCollection<Test> _tests;

          public ObservableCollection<Test> Tests
          {
              get
              {
                  return _tests;
              }
              set
              {
                  if (_tests != value)
                  {
                      _tests = value;
                      NotifyPropertyChanged("Tests");
                  }
              }
          }

          public void displaynoqueyr()
          {

              string s = textBox1.Text;
              long l;
              long.TryParse(s, out l);

              var q = (from Question qs1 in catAppDB.Questions
                       where qs1.T_id == l
                       select qs1).Count();
              txtque.Text = q.ToString();
          }
          public void displaytimeyr()
          {
              
              string s = textBox1.Text;
              long l;
              long.TryParse(s, out l);

              var q = from Test qs1 in catAppDB.Tests
                       where qs1._id == l
                       select qs1;
              Tests = new ObservableCollection<Test>(q);
              var time = Tests.ToList();
              var t = time[0] as Test;
              
             var tt=(t.Allowed_time)/60;
              txttime.Text = tt.ToString();

              
            
           }
         
         
  protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            IDictionary<string, string> x = this.NavigationContext.QueryString;
            String a = Convert.ToString(x["selectedValue"]);
            textBox1.Text= a.ToString();
            base.OnNavigatedTo(e);

        }

  private void txtque_Loaded(object sender, RoutedEventArgs e)
  {
      displaynoqueyr();
  }

  private void txttime_Loaded(object sender, RoutedEventArgs e)
  {
      displaytimeyr();
  }
  

  private void button1_Click(object sender, RoutedEventArgs e)
  {
     
      NavigationService.Navigate(new Uri("/Page3.xaml?TextData=" + textBox1.Text, UriKind.Relative));
      

}
     int count = 0;
             private void button2_Click(object sender, RoutedEventArgs e)
  {
      count++; ;
      if (count % 2 == 0)
      {
          button2.Content = "OFF";
          //NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
      }
      else
      {
          button2.Content = "ON";
          // NavigationService.Navigate(new Uri("/Opt.xaml? Opt()", UriKind.Relative));
          // NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
      }
  }

    }

        //int count=0;

  //private void button2_Click(object sender, RoutedEventArgs e)
  //{
  //    count++; ;
  //    if (count % 2 == 0)
  //    {
  //        button2.Content = "OFF";
  //        //NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
  //    }
  //    else
  //    {
  //        button2.Content = "ON";
  //        // NavigationService.Navigate(new Uri("/Opt.xaml? Opt()", UriKind.Relative));
  //        // NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
  //    }
  //}

  /*System.Windows.Controls.Button AddButton = new System.Windows.Controls.Button();
  void AddButton_Click(object sender, RoutedEventArgs e)
  {
      // AddButton.Content = "off";
      string s = AddButton.Content.ToString();
      string txt = "off";
      if (s.Equals(txt))
      {
          AddButton.Content = "on";
          //lstbtn.Items.Add(AddButton);
          // MessageBox.Show("timer:" + btntimer.Content);
      }
      else
      {
          AddButton.Content = "off";
          //lstbtn.Items.Add(AddButton);
          //MessageBox.Show("timer:" + btntimer.Content);
      }
        */
  }

  
/*  private void lstbtn_Loaded_1(object sender, RoutedEventArgs e)
  {
      AddButton = new Button();
      AddButton.Content = "off";
      lstbtn.Items.Add(AddButton);
      AddButton.Click += new RoutedEventHandler(AddButton_Click);

  }*/



  //private void btn1(object sender, RoutedEventArgs e)
  //{
  //    string s = btntimer.Content.ToString();
  //    string txt = "off";
  //    if (s.Equals(txt))
  //    {
  //        btntimer.Content = "on";
  //        // MessageBox.Show("timer:" + btntimer.Content);
  //    }
  //    else
  //    {
  //        btntimer.Content = "off";
  //        //MessageBox.Show("timer:" + btntimer.Content);
  //    }

  //}

    

