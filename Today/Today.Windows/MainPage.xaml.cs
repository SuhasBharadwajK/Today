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
using Windows.UI.Xaml.Shapes;
using Windows.ApplicationModel.Core;
using System.Threading.Tasks;
using System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Globalization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Today
{
    /*
     * Reference for names of objects and elements and what they do:
     *  Static UIElements that are declared in the XAML code:
     *      MainThing - The main page. All the other elements are its children. This is of type 'Page'.
     *      PageGrid - The only child of MainThing and the parent of all the other elements except MainThing and itself. This of type 'Grid'.
     *      Today - Text block that serves as the header to the app. It's value is initialized as "Today" and will not change. This of type 'TextBlock'
     *      Date - Text block that shows the date and day of today as soon as the app starts. This is of type 'TextBlock'
     *      tasksapce - The main element into which reminders are added. It has three children: addplus, remadder and remViewer. This is of type 'Canvas'.
     *      canceller - This is not really important. The sole purpose of this is to close the popup when clicked anywhere outside it. This is of type 'Rectangle'.
     *      TimerLog - This hasn't been used anywhere yet. This is of type 'TextBlock'.
     *      addplus - This is grey colored plus sign seen when a reminder is to be added and is a child of taskspace. This is of type 'Image'.
     *      remadder - The rectangle that pops up when the plus sign or addplus is clicked. This is of type 'Rectangle'.
     *      remViewer - This is the child of taskspace that provides for scorllability for the reminders. This is of type 'ScrollViewer'.
     *      remContainer - This is the child of remViewer and it is a container that hold all the reminders, vertically. This is of type 'StackPanel'.
     *      
     *  UIElements and objects that are created as the app starts and executes:
     *      months - A List of strings that has the months arranges in order. This is for getting the month name as a string for updating Date on the app page. This is of type 'List<string>'.
     *      reminders - A List of rectangles that are the actual reminders. Each object of this list is a child of corresponding Canvas object of remHolders This is of type 'List<rectangle>'.
     *      remNames - A list of text blocks that has the names or information of the reminders in the order they are created. This is of type 'List<TextBlock>'.
     *      remHolders - A list of Canvas objects whose children are objects at corresponding indexes of reminders and remNames.  This is of type 'List<Canvas>'.
     *      
     */

    public sealed partial class MainPage : Page
    {

        List<string> months = new List<string> { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        List<Rectangle> reminders = new List<Rectangle>();
        List<TextBlock> remNames = new List<TextBlock>();
        List<Canvas> remHolders = new List<Canvas>();
        
        //TextBox todo;
        //TextBox remTime;

        int remNumber = 0; /*The number of reminders added for a day.*/

        //Rectangle popuprem = new Rectangle();
        //DispatcherTimer dispatcherTimer;
        //DateTimeOffset startTime;
        //DateTimeOffset lastTime;
        //DateTimeOffset stopTime;
        //int timesTicked = 1;
        //int timesToTick = 0;
        //int flag = 0;
        

        bool addingTask = false; /*Shows if the pop up for adding a reminder is open or not.*/

        public MainPage()
        {
            this.InitializeComponent();

            Canvas.SetZIndex(remadder, 10);
            DateTime today = DateTime.Now;

            Date.Text = today.DayOfWeek.ToString() + ", " + today.Day.ToString() + giveType(today.Day.ToString().Substring(today.Day.ToString().Length - 1)) + " of " + months[today.Month - 1];

            //eventName.PlaceholderText = "Name of the event";
            //eventName.Height = 30;
            //eventName.Width = 400;
            //Canvas.SetLeft(eventName, taskspace.Margin.Left + 175);
            //Canvas.SetTop(eventName, taskspace.Margin.Top + 50);
            //var res = new Today1();
            //res.todaysDate = new DateTime.Now;
            //remadder.Tapped += cancelAdding;
            
            //Date.Text = today.DayOfWeek.ToString() + ", " + today.Day.ToString() + daytype + " of ";
            
            //Date.Text = today.DayOfYear.ToString();
            
        }

        /*This method is used for writing the suffix for the date in the Date*/
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

        /*This method is 'Tapped' event handler for addplus.*/
        private void addRem(object sender, TappedRoutedEventArgs e)
        {
            Canvas.SetLeft(remadder, Canvas.GetLeft(taskspace) + taskspace.Width / 2);
            Canvas.SetTop(remadder, Canvas.GetTop(taskspace) + taskspace.Height / 2);
            remadder.Visibility = Visibility.Visible;
            //taskspace.IsTapEnabled = false;
            addingTask = true;
            //taskspace.Children.Add(popuprem);
            //flag = 0;
            //taskspace.Children.Remove(((TextBox)taskspace.FindName("eventName")));
            //DispatcherTimerSetup();
            //dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimerTick;

            //dispatcherTimer.Tick += addElements;

            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 600);
            //dispatcherTimer.Start();

            //await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    //TextBlock tblock = new TextBlock();
            //    //tblock.Margin = new Thickness(100, 400, 0, 0);
            //    //tblock.Height = 0.06;
            //    //tblock.Width = 0.67;
            //    //tblock.RenderTransform = new CompositeTransform();
            //    //Storyboard.SetTarget(popupscaleX, tblock);
            //    //Storyboard.SetTarget(popupscaleY, tblock);
            //    //tblock.Text = "Suhas Bharadwaj";
            //    //Task.Delay(5200);
            //    //PageGrid.Children.Add(tblock);

            //    //dispatcherTimer.Tick += dispatcherTimerTick;
            //});

            DatePicker remDate = new DatePicker();
            Calendar cal = new Calendar();

            TextBox todo = new TextBox();
            todo.Name = "todo";
            todo.PlaceholderText = "Must do...";
            todo.Height = 30;
            todo.Width = 400;
            Canvas.SetLeft(todo, 175);
            Canvas.SetTop(todo, 50);
            Canvas.SetZIndex(todo, 20);

            Image closeButton = new Image();
            closeButton.Source = new BitmapImage(new Uri("ms-appx:///Assets/closer.png"));
            closeButton.Name = "closeButton";
            closeButton.Height = 20;
            closeButton.Width = 20;
            Canvas.SetLeft(closeButton, 700);
            Canvas.SetTop(closeButton, 20);
            Canvas.SetZIndex(closeButton, 21);
            closeButton.Tapped += cancelAdding;            

            Button addNew = new Button();
            addNew.Content = "Add";
            addNew.Width = 100;
            addNew.Height = 50;
            addNew.Name = "addNew";
            Canvas.SetLeft(addNew, 550);
            Canvas.SetTop(addNew, 400);
            Canvas.SetZIndex(addNew, 21);
            addNew.Click += createNew;

            TimePicker remTime = new TimePicker();
            remTime.Name = "remTime";
            remTime.MinuteIncrement = 5;
            remTime.Time = new TimeSpan(0, 0, 0);
            remTime.ClockIdentifier = Windows.Globalization.ClockIdentifiers.TwelveHour;
            remTime.Header = "When?";
            Canvas.SetLeft(remTime, 175);
            Canvas.SetTop(remTime, 120);
            Canvas.SetZIndex(remTime, 21);

            Canvas.SetZIndex(addplus, -5);
            Canvas.SetZIndex(canceller, 5);
            Canvas.SetZIndex(taskspace, 10);
            Canvas.SetZIndex(remadder, 15);
            addplus.Opacity = 0;
            addplus.Visibility = Visibility.Collapsed;
            

            popup.Begin();
            

            popup.Completed += delegate
            {
                taskspace.Children.Remove(((TextBox)this.FindName("todo")));
                taskspace.Children.Remove(((Button)this.FindName("addNew")));
                taskspace.Children.Remove(((Image)this.FindName("closeButton")));
                taskspace.Children.Remove(((TimePicker)this.FindName("remTime")));
                taskspace.Children.Add(todo);
                taskspace.Children.Add(addNew);
                taskspace.Children.Add(closeButton);
                taskspace.Children.Add(remTime);
            };
            //popup.AutoReverse = true;

            //eventName.Text = dispatcherTimer.IsEnabled.ToString();
        }

        //Testthis thing:
        //Is invoked when 'Add' button is clicked.
        void createNew(object sender, RoutedEventArgs e)
        {
            if (((TextBox)taskspace.FindName("todo")).Text == "")
            {
                TextBlock error = new TextBlock();
                error.Text = "What exactly is the thing that you want to do?";
                error.IsColorFontEnabled = true;
                error.Foreground = Error;
                error.Name = "error";
                Canvas.SetTop(error, 250);
                Canvas.SetLeft(error, 160);
                Canvas.SetZIndex(error, 21);
                error.FontSize = 22;
                taskspace.Children.Remove(error);
                taskspace.Children.Add(error);
            }

            else
            {

                remHolders.Add(new Canvas());
                remHolders[remNumber].Height = 150;
                remHolders[remNumber].Width = 400;
                remHolders[remNumber].Margin = new Thickness(-100, 20, 0, 0);

                reminders.Add(new Rectangle());
                //Date.Text = remNumber.ToString();
                reminders[remNumber].Height = 150;
                reminders[remNumber].Width = 400;
                reminders[remNumber].Fill = ColorOfRemGreey;
                //reminders[remNumber].Margin = new Thickness(-100, 20, 0, 0);
                reminders[remNumber].RadiusX = 15;
                reminders[remNumber].RadiusY = 15;
                //Canvas.SetZIndex(reminders[remNumber], 2);
                //reminders[remNumber].RenderTransform = new CompositeTransform();
                reminders[remNumber].Name = "rem" + remNumber.ToString();

                remNames.Add(new TextBlock());
                remNames[remNumber].Text = ((TextBox)taskspace.FindName("todo")).Text;
                remNames[remNumber].Width = 300;
                remNames[remNumber].Height = 50;
                remNames[remNumber].FontSize = 30;
                Canvas.SetLeft(remNames[remNumber], 50);
                Canvas.SetTop(remNames[remNumber], 10);
                //remNames[remNumber].Margin = new Thickness(0, 20, 0, 0);            

                remHolders[remNumber].Children.Add(reminders[remNumber]);
                remHolders[remNumber].Children.Add(remNames[remNumber]);

                //Canvas.SetZIndex(remNames[remNumber], 3);
                //remNames[remNumber].Margin = new Thickness

                //remTimes.Add(new TextBlock());

                //Canvas.SetLeft(reminders[remNumber], -100);
                //Canvas.SetTop(reminders[remNumber], 50);
                //Storyboard.SetTarget(slideInRem, reminders[remNumber]);
                //reminders[remNumber]

                taskspace.Children.Remove(((TextBox)taskspace.FindName("todo")));
                taskspace.Children.Remove(((Button)taskspace.FindName("addNew")));
                taskspace.Children.Remove(((Image)taskspace.FindName("closeButton")));
                taskspace.Children.Remove(((TimePicker)taskspace.FindName("remTime")));
                taskspace.Children.Remove(((TextBlock)taskspace.FindName("error")));
                //remContainer.Children.Add(reminders[remNumber]);
                //PageGrid.Children.Add(reminders[remNumber]);

                //remNumber++;
                if (remNumber >= 2)
                {
                    remContainer.Height += 170;
                }

                cancelPopup.Begin();

                addingNewRem.Completed += delegate
                {
                    addingNewRem.Stop();
                };


                //taskspace.Children.Remove(reminders[remNumber]);
                //PageGrid.Children.Remove(reminders[remNumber]);
                //taskspace.Children.Remove(remNames[remNumber]);
                //PageGrid.Children.Remove(remNames[remNumber]);

                taskspace.Children.Remove(remHolders[remNumber]);
                PageGrid.Children.Remove(remHolders[remNumber]);

                //remContainer.Children.Remove(reminders[remNumber]);
                //reminders[remNumber].Margin = new Thickness(100, 20, 0, 0);
                ////reminders[remNumber].Margin = new Thickness(0, 20, 0, 0);
                remContainer.Children.Add(remHolders[remNumber]);
                //remContainer.Children.Add(reminders[remNumber]);
                remNumber++;

                //remContainer.Children.Remove(reminders[remNumber]);

                cancelPopup.Completed += delegate
                {

                    Canvas.SetZIndex(addplus, 5);
                    Canvas.SetZIndex(canceller, -15);
                    addplus.Visibility = Visibility.Visible;
                    addingTask = false;



                    Canvas.SetLeft(addplus, 650);
                    Canvas.SetTop(addplus, 400);
                    addplus.Opacity = 1;
                    remadder.Visibility = Visibility.Collapsed;

                    //taskspace.Children.Add(reminders[remNumber]);
                    //remContainer.Children.Add(reminders[remNumber]);
                    //remNumber++;               

                    //addingNewRem.Begin(); // Enable this after uncommenting RenderTransform and Storyboard.SetTarget, to enable animation of adding.

                    //addingNewRem.Completed += delegate
                    //{
                    //    addingNewRem.Stop();
                    //};
                    //taskspace.Children.Remove(reminders[remNumber]);

                    //reminders[remNumber].Margin = new Thickness(100, 20, 0, 0);
                    //reminders[remNumber].Margin = new Thickness(0, 20, 0, 0);
                    //remContainer.Children.Add(reminders[remNumber]);
                    //remNumber++;

                };
            }
        }

        //Is invoked when red cross is clicked.
        private void cancelAdding(object sender, TappedRoutedEventArgs e)
        {

            if (addingTask)
            {
                cancelPopup.Begin();
                Canvas.SetZIndex(addplus, 5);
                //taskspace.IsTapEnabled = true;
                //await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
                //{
                //    Task.Delay(200);
                //});
                
                //Canvas.SetZIndex(remadder, -15);
                Canvas.SetZIndex(canceller, -15);
                addplus.Visibility = Visibility.Visible;
                addingTask = false;
                //Task.Delay(1000);
                //((TextBox)taskspace.FindName("eventName")).Opacity = 0;
                //((TextBox)taskspace.FindName("eventName")).Visibility = Visibility.Collapsed;
                taskspace.Children.Remove(((TextBox)taskspace.FindName("todo")));
                taskspace.Children.Remove(((Button)taskspace.FindName("addNew")));
                taskspace.Children.Remove(((Image)taskspace.FindName("closeButton")));
                taskspace.Children.Remove(((TimePicker)taskspace.FindName("remTime")));
                taskspace.Children.Remove(((TextBlock)taskspace.FindName("error")));

                cancelPopup.Completed += delegate
                {
                    addplus.Opacity = 1;
                    remadder.Visibility = Visibility.Collapsed;
                };
            }
        }

        private void doNothing(object sender, TappedRoutedEventArgs e)
        {

        }

        //public void DispatcherTimerSetup()
        //{
        //    dispatcherTimer = new DispatcherTimer();
        //    //dispatcherTimer.Tick += dispatcherTimerTick;

        //    dispatcherTimer.Tick += delegate(object sender, object e)
        //    {
        //        if (flag == 0)
        //        {
        //            TextBox eventName = new TextBox();
        //            dispatcherTimer.Stop();
        //            eventName.Name = "eventName";
        //            eventName.PlaceholderText = "Name of the event";
        //            eventName.Height = 30;
        //            eventName.Width = 400;
        //            Canvas.SetLeft(eventName, 175);
        //            Canvas.SetTop(eventName, 50);
        //            Canvas.SetZIndex(eventName, 20);
        //            taskspace.Children.Add(eventName);
        //            dispatcherTimer.Stop();
        //            flag = 1;

        //            //The other text box
        //            //eventName.Text = dispatcherTimer.IsEnabled.ToString();
        //        }
        //        //dispatcherTimer.Stop();
                
        //    };

        //    dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 600);
        //    //IsEnabled defaults to false
        //    //TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        //    startTime = DateTimeOffset.Now;
        //    lastTime = startTime;
        //    //TimerLog.Text += "Calling dispatcherTimer.Start()\n";
        //    dispatcherTimer.Start();
        //    //dispatcherTimer.Tick -= dispatcherTimerTick;
        //    //IsEnabled should now be true after calling start
        //    //taskspace.Children.Add(eventName);

        //    //TextBox eventName = new TextBox();
        //    //eventName.PlaceholderText = "Name of the event";
        //    //eventName.Height = 30;
        //    //eventName.Width = 400;
        //    //Canvas.SetLeft(eventName, 175);
        //    //Canvas.SetTop(eventName, 50);
        //    //Canvas.SetZIndex(eventName, 20);
        //    //taskspace.Children.Add(eventName);

        //    //dispatcherTimer.Tick += delegate(object sender, object e)
        //    //{
        //    //    TextBox eventName = new TextBox();
        //    //    dispatcherTimer.Stop();
        //    //    eventName.PlaceholderText = "Name of the event";
        //    //    eventName.Height = 30;
        //    //    eventName.Width = 400;
        //    //    Canvas.SetLeft(eventName, 175);
        //    //    Canvas.SetTop(eventName, 50);
        //    //    Canvas.SetZIndex(eventName, 20);
        //    //    taskspace.Children.Add(eventName);
        //    //    dispatcherTimer.Stop();
        //    //};

        //    //eventName.Text = taskspace.Margin.Left + ", " + taskspace.Margin.Top;
           
        //    TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        //    //dispatcherTimer.Stop();
        //    TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";

        //}

        //private void dispatcherTimerTick(object sender, object e)
        //{
        //    //TextBox eventName = new TextBox();
        //    //eventName.PlaceholderText = "Name of the event";
        //    //eventName.Height = 30;
        //    //eventName.Width = 400;
        //    //Canvas.SetLeft(eventName, taskspace.Margin.Left + 175);
        //    //Canvas.SetTop(eventName, taskspace.Margin.Top + 50);
        //    //taskspace.Children.Add(eventName);


        //    DateTimeOffset time = DateTimeOffset.Now;
        //    TimeSpan span = time - lastTime;
        //    lastTime = time;
        //    //Time since last tick should be very very close to Interval
        //    TimerLog.Text += timesTicked + " time since last tick: " + span.ToString() + "\n";
        //    timesTicked++;


        //    dispatcherTimer.Stop();

        //    if (timesTicked > timesToTick)
        //    {

        //        TextBox eventName = new TextBox();
        //        dispatcherTimer.Stop();
        //        eventName.PlaceholderText = "Name of the event";
        //        eventName.Height = 30;
        //        eventName.Width = 400;
        //        Canvas.SetLeft(eventName, 175);
        //        Canvas.SetTop(eventName, 50);
        //        Canvas.SetZIndex(eventName, 20);
        //        taskspace.Children.Add(eventName);
        //        dispatcherTimer.Tick -= dispatcherTimerTick;

        //        stopTime = time;
        //        TimerLog.Text += "Calling dispatcherTimer.Stop()\n";
        //        dispatcherTimer.Stop();
        //        //IsEnabled should now be false after calling stop
        //        TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        //        span = stopTime - startTime;
        //        TimerLog.Text += "Total Time Start-Stop: " + span.ToString() + "\n";
        //    }
        //}

        //private void addElements(object sender, object args)
        //{
        //    if (flag == 0)
        //    {
        //        TextBox eventName = new TextBox();
        //        dispatcherTimer.Stop();
        //        eventName.Name = "eventName";
        //        eventName.PlaceholderText = "Name of the event";
        //        eventName.Height = 30;
        //        eventName.Width = 400;
        //        Canvas.SetLeft(eventName, 175);
        //        Canvas.SetTop(eventName, 50);
        //        Canvas.SetZIndex(eventName, 20);
        //        taskspace.Children.Add(eventName);
        //        dispatcherTimer.Stop();
        //        dispatcherTimer.Tick -= addElements;
        //        flag = 1;

        //        //The other text box
        //        //eventName.Text = dispatcherTimer.IsEnabled.ToString();
        //    }
        //}
    }
}
