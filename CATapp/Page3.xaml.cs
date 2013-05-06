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
    public partial class Page3 : PhoneApplicationPage, INotifyPropertyChanged
    {
       
         // Because we have not specified a namespace, this
        // will be a System.Windows.Forms.Timer instance

        // Whether or not the timer is currently running

        private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
      //  public Int64 op;
        public Page3()
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

         
          protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
          {
              IDictionary<string, string> x = this.NavigationContext.QueryString;
              String a = Convert.ToString(x["TextData"]);
              textBox1.Text = a.ToString();
              base.OnNavigatedTo(e);
           
              
          }
      

          

         //for displaying options and questions of specific category
          public void displaycatwise()
          {

              string s = textBox1.Text;
              long l;
              long.TryParse(s, out l);

              var q = (from Question qs1 in catAppDB.Questions
                       join Question_category qs2 in catAppDB.Question_categories on qs1._id equals qs2.Q_id
                       where qs2.C_id == l
                       select qs1).Count();
              var q1 = from Question qs1 in catAppDB.Questions
                       join Question_category qs2 in catAppDB.Question_categories on qs1._id equals qs2.Q_id
                       where qs2.C_id == l
                       select qs1;
              Questions = new ObservableCollection<Question>(q1);
 
  
             
              var v = Questions.ToList();
          
              int count = 1;
          
          
            //  long l1;

              for (int i = 0; i < q;i++ )
              {
                  PivotItem pi = new PivotItem();
                  pi.Header = string.Format("Q {0}", count);
                  Opt puc = new Opt();
                 // Question s2 = v[i].Header.Replace("<br />", "\n");
                //Question s3 = v[i].Content.Replace("<br />","\n");
                  // s2 = qq.Content.ToString();
                //Question s4 = s2 + s3;
                 // Question s5=s4.ToList();
                  puc.DataContext= v[i] as Question ;
                  pi.Content = puc;
                
                  pivot1.Items.Add(pi);


                  count++;
              }
          
          }
          public void displayyearwise()
          {
              //string to long
              string s = textBox1.Text;
              long l;
              long.TryParse(s, out l);

              var q = (from Question qs1 in catAppDB.Questions
                       where qs1.T_id==l
                       select qs1).Count();
              var q1 = from Question qs1 in catAppDB.Questions
                       where qs1.T_id == l
                       select qs1;
              Questions = new ObservableCollection<Question>(q1);



              var v = Questions.ToList();

              int count = 1;


              for (int i = 0; i < q; i++)
              {
                  PivotItem pi = new PivotItem();
                  pi.Header = string.Format("Q {0}", count);
                  Opt puc = new Opt();

                  puc.DataContext = v[i] as Question;
                  pi.Content = puc;

                  pivot1.Items.Add(pi);


                  count++;
              }
              
          }
      
         // private void TestSubmit_Click(object sender, RoutedEventArgs e)
         // {
         //    Opt os = new Opt();
         //   string ss = os.quesID.ToString();
         //pivot1.Visibility = Visibility.Collapsed;
         //   NavigationService.Navigate(new Uri("/Page4.xaml?selectedQuesID="+ss, UriKind.Relative));

           
         // }
         private void OK_Click(object sender, RoutedEventArgs e)
          {
              
              DialogClosed("OK");
          }

          private void Cancel_Click(object sender, RoutedEventArgs e)
          {
              DialogClosed("Cancel");
          }

          private void DialogClosed(string ClosedBy)
          {
              txtCorrect.Text = string.Empty;
              txtInCorrect.Text = string.Empty;
              txtUnanswered.Text = string.Empty;
              
              if (ClosedBy.Equals("OK"))
              {
                  //Submit
                  MessageBox.Show("Submitted successfully");
                  NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
                  //  Messenger.Default.Send<string>("Category");
              }
              else
              {
                  //Cancel
              }
          }

          private void catwise_Loaded(object sender, RoutedEventArgs e)
          {
              displaycatwise();
          }
        
             
          
      

          private void yearwise_Loaded(object sender, RoutedEventArgs e)
          {
              noque nq = new noque();
              string st = nq.button2.Content.ToString();
              string st2 = "ON";
              if (st.Equals(st2))
              {

                    displayyearwise();
                    
              }
              
          
              else if (!(st.Equals(st2)))
              {
                  displayyearwise();
              }
              
              //displayyearwise();
          }

          private void Button_Click(object sender, RoutedEventArgs e)
          {
              NavigationService.Navigate(new Uri("/Page4.xaml", UriKind.Relative));

          }
        

    }
}