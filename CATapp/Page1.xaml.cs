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
    public partial class Page1 : PhoneApplicationPage,INotifyPropertyChanged
    {
             // Data context for the local database
        private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
        // Constructor
        public Page1()
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

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<Test> _tests;
        private ObservableCollection<Category> _cats;
      
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
         
       
        private void testsListBox_Loaded(object sender, RoutedEventArgs e)
        {
            var testsInDB = from Test test in catAppDB.Tests
                            select test;

            // Execute the query and place the results into a collection.
            Tests = new ObservableCollection<Test>(testsInDB);

        }

        private void catListBox_Loaded(object sender, RoutedEventArgs e)
        {

            
        var catsInDB = from Category cat in catAppDB.Categories
                           select cat;

            // Execute the query and place the results into a collection.
            Categories = new ObservableCollection<Category>(catsInDB);
            
        }

        private void catListBox_Tap(object sender, GestureEventArgs e)
        {
            //  string selectedText = "";
              string selectId=""  ;
               var selected = catListBox.SelectedValue as Category;
            // selectedText = selected.Name;
             selectId = selected._id.ToString();
            NavigationService.Navigate(new Uri("/noque.xaml?selectedValue="+ selectId, UriKind.Relative));
               

        }

        private void testsListBox_Tap(object sender, GestureEventArgs e)
        {
            string selectId = "";
            var selected = testsListBox.SelectedValue as Test;
            // selectedText = selected.Name;
            selectId = selected._id.ToString();
            NavigationService.Navigate(new Uri("/noque.xaml?selectedValue=" + selectId, UriKind.Relative));
            
        }
    


        //private void SelectionToText(object sender, EventArgs e)
        //{
        //    ListBoxItem selection = (ListBoxItem)catListBox.SelectedItem;

        //    //   string selectedValueText = catListBox.Items[index].ToString();
        //    seltext.Text = selection.Content.ToString();
        //    MessageBox.Show("selected value" + seltext.Text);
                
        //}

       
    }
           // int index = catListBox.SelectedIndex;

            //if (index != -1)
            //{

            //  //  if (seltext.Text == "")
            //    //{
            //        ListBoxItem selection = (ListBoxItem)catListBox.SelectedItem;

            //        //  string selectedValueText =catListBox.Items[index].ToString();
            //      //  seltext.Text = selectedValueText.Text;
            //        MessageBox.Show("selected value" + selection);
            // //   }
            ////    else
            //  //  {
            //    //    MessageBox.Show("empty");
            //    //}
            //}
            //catListBox.SelectedIndex = -1;
   
    //        int index = catListBox.SelectedIndex;

    //        if (index != -1)
    //        {

    //            if (seltext.Text == "")
    //            {
    //                string selectedValueText = catListBox.Items[index].ToString();
    //                seltext.Text = selectedValueText;
    //                MessageBox.Show("selected value" + seltext.Text);
    //            }
    //            else
    //            {
    //                MessageBox.Show("empty");
    //            }
    //        }
    //        catListBox.SelectedIndex = -1;
    //////        if (catListBox.SelectedIndex==-1)
    //            return;
    //          switch (catListBox.SelectedValue.ToString())
    //    {
    //        case "Pythagoras Theorem":// Navigate to the page
    //NavigationService.Navigate(new Uri("/Page3.xaml?selectedItem="+ catListBox.SelectedValue, UriKind.Relative)); break;
    //        case "Number System":// Navigate to the page
    //NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative)); break;default:break;
    //    }


    // Reset selected index to -1 (no selection)
  
}

      
            // Navigate to the new page
            //NavigationService.Navigate(new Uri("/Page3.xaml?selectedItem=" +catListBox.SelectedItem.ToString(), UriKind.Relative));

            // Reset selected index to -1 (no selection)
      //       catListBox.SelectedIndex = -1;

           // NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        



     /*   private void catnametxt_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            string urlofdestinationpage = "/Page3.xaml";
            urlofdestinationpage += string.Format("?selectedItem=" + catListBox.SelectedItem);
            this.NavigationService.Navigate(new Uri(urlofdestinationpage, UriKind.Relative));
            e.Complete();
            e.Handled = true;

        }*/


     
    

    
