using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Today
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public class Today1
        {

            public DateTime todaysDate { get; set; }
        }

        
        //string daytype;
        List<string> months = new List<string> { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public MainPage()
        {
            this.InitializeComponent();
            var res = new Today1();
            //res.todaysDate = new DateTime.Now;
            DateTime today = DateTime.Now;
            //Date.Text = today.DayOfWeek.ToString() + ", " + today.Day.ToString() + daytype + " of ";
            Date.Text = today.DayOfWeek.ToString() + ", " + today.Day.ToString() + giveType(today.Day.ToString().Substring(today.Day.ToString().Length - 1)) + " of " + months[today.Month - 1];
            //Date.Text = today.DayOfYear.ToString();
            
        }

        private string giveType(string a)
        {
            if (a == "1")
            {
                return "st";
            }
            else if (a == "2")
            {
                return "nd";
            }
            else if (a == "3")
            {
                return "rd";
            }
            else
            {
                return "th";
            }
        }
    }
}
