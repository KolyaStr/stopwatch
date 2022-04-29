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
using System.Timers;

namespace stopwatch
{
    public partial class MainWindow : Window
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;


        Timer timer = new Timer(1000);
        delegate void Reset();
        event Reset Notify;

        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += timer_Tick;
            Notify += () =>
            {
                timer.Stop();
                hours = 0;
                minutes = 0;
                seconds = 0;
                label1.Content = $"0{hours}:0{minutes}:0{seconds}";
            };
        }

        private void Stop_CLick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Start_CLick(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Notify();
        }
        private void timer_Tick(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }
                label1.Content = $"{Print(hours)}:{Print(minutes)}:{Print(seconds)}";
            });

        }
        private string Print(int num)
        {
            if (num < 10)
                return $"0{num}";
            return $"{num}";
        }
    }
}
