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
using System.Windows.Threading;

namespace wpf
{
    
    public partial class svetofor : UserControl
    {
        public delegate void myHandler();
        public event myHandler RedEvent;
        public event myHandler GreenEvent;
        public event myHandler YellowEvent;
        string reg;


        public svetofor()
        {
            InitializeComponent();
            green.Fill = Brushes.Gray;
            red.Fill = Brushes.Gray;
            yellow.Fill = Brushes.Gray;
            reg = "Red";

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (reg == "Red")
            {
                red.Fill = Brushes.Red;
                yellow.Fill = Brushes.Gray;
                green.Fill = Brushes.Gray;
                RedEvent?.Invoke();
                reg = "Yellow";
            }
            else if (reg == "Yellow")
            {
                red.Fill = Brushes.Gray;
                green.Fill = Brushes.Gray;
                yellow.Fill = Brushes.Yellow;
                YellowEvent?.Invoke();
                reg = "Green";
            }
            else if (reg == "Green")
            {
                red.Fill = Brushes.Gray;
                green.Fill = Brushes.Green;
                yellow.Fill = Brushes.Gray;
                GreenEvent?.Invoke();
                reg = "Yellow2";

            }
            else if (reg == "Yellow2")
            {
                red.Fill = Brushes.Gray;
                green.Fill = Brushes.Gray;
                yellow.Fill = Brushes.Yellow;
                YellowEvent?.Invoke();
                reg = "Red";
            }
        }
    


    }
}
