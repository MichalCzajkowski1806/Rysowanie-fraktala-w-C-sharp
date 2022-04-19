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

namespace Domowe_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void RysujGwiazde(double srodekX, double srodekY, int dlugosc, int minimalna, SolidColorBrush kol)
        {
            SolidColorBrush[] kolory = new SolidColorBrush[6] { Brushes.Green, Brushes.Blue, Brushes.Red, Brushes.Yellow, Brushes.Pink, Brushes.Violet };

            for (int i = 0; i < 6; i++)
            {
                var myLine = new Line();
                myLine.Stroke = kol;
                myLine.X1 = srodekX;
                myLine.X2 = srodekX + dlugosc / 2;
                myLine.Y1 = srodekY;
                myLine.Y2 = srodekY;
                myLine.StrokeThickness = 2;
                
                RotateTransform rotacja = new RotateTransform(60 * i);
                rotacja.CenterX = myLine.X1;
                rotacja.CenterY = myLine.Y1;
                myLine.RenderTransform = rotacja;
                Point obrocony_punkt = rotacja.Transform(new Point(myLine.X2, myLine.Y2));
                cvGwiazda.Children.Add(myLine);
                
                if (dlugosc > minimalna)
                {
                    RysujGwiazde(obrocony_punkt.X, obrocony_punkt.Y, dlugosc / 3, minimalna, kolory[i]);
                }
            }
        }

        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            RysujGwiazde(250, 250, 300, 20, Brushes.BlueViolet);
        }
    }
}
