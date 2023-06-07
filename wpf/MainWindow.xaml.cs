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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int speedx = 0;
        private int speedy = 0;
        private int speedxnap = 1;
        private int speedynap = 1;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dispatcherTimer1.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - (speedx * speedxnap));
            Canvas.SetTop(image, Canvas.GetTop(image) - (speedy * speedynap));
            if (((Canvas.GetLeft(image) < 5) || (Canvas.GetLeft(image) > 680)))
            {
                speedxnap = speedxnap * -1;
                return;
            }
            if (((Canvas.GetTop(image) < 10) || (Canvas.GetTop(image) > 370)))
            {
                speedynap = speedynap * -1;
                return;
            }
            if ((speedxnap == -1) && (speedynap == 1))
            {
                image.Source = BitmapFrame.Create(new Uri(@"D:\wpf\направовверх.png"));
                return;
            }
            if ((speedxnap == -1) && (speedynap == -1))
            {
                image.Source = BitmapFrame.Create(new Uri(@"D:\wpf\направовниз.png"));
                return;
            }
            if ((speedxnap == 1) && (speedynap == -1))
            {
                image.Source = BitmapFrame.Create(new Uri(@"D:\wpf\налевовниз.png"));
                return;
            }

            if ((speedxnap == 1) && (speedynap == 1))
            {
                image.Source = BitmapFrame.Create(new Uri(@"D:\wpf\налевовверх.png"));
                return;
            }
        }
        private void UserControl1_RedEvent()
        {
            speedy = 0;
            speedx = 0;

        }
        private void UserControl1_YellowEvent()
        {
            speedy = 3;
            speedx = 3;

        }
        private void UserControl1_GreenEvent()
        {
            speedy = 8;
            speedx = 8;
        }
    }
}