using mrowki.genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace mrowki
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

        Brush color = new SolidColorBrush(Color.FromRgb((byte)255,(byte)255,(byte)255));
        Point dragStart, offset;
        bool draw = false;
        bool del = false;
        int populationCount;
        float mutationChance;
        Rectangle rect;
        UIElement dragObject = null;
        int timeOfLife = 0;
        Ellipse[] ellipses = null;
        Population population = null;

        private void Rectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (del)
            {
                if (e.OriginalSource is Rectangle)
                {
                    Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                    Mrowisko.Children.Remove(activeRectangle);
                }
            }

        }
        private void Mrowisko_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!draw)
                return;
            Mrowisko.CaptureMouse();

            dragStart = e.MouseDevice.GetPosition(Mrowisko);
            rect = new Rectangle
            {
                Stroke = Brushes.White,
                StrokeThickness = 0,
                Fill=color,
            };
            Mrowisko.Children.Add(rect);
        }

        private void Mrowisko_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (!Mrowisko.IsMouseCaptured)
                    return;

                Point location = e.MouseDevice.GetPosition(Mrowisko);

                double minX = Math.Min(location.X, dragStart.X);
                double minY = Math.Min(location.Y, dragStart.Y);
                double maxX = Math.Max(location.X, dragStart.X);
                double maxY = Math.Max(location.Y, dragStart.Y);

                Canvas.SetTop(rect, minY);
                Canvas.SetLeft(rect, minX);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);
            }
            else if (this.dragObject != null)
            {
                var position = e.GetPosition(sender as IInputElement);
                Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
                Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
            }
            else return;
            
        }

        private void Mrowisko_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            Mrowisko.ReleaseMouseCapture();
        }

        private void Ellipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.Mrowisko);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.Mrowisko.CaptureMouse();
        }

        private void Radio_draw(object sender, RoutedEventArgs e)
        {
            draw = true;
            del = false;
        }
        private void Radio_delete(object sender, RoutedEventArgs e)
        {
            del = true;
            draw = false;
        }

        private void popCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.populationCount = int.Parse(popCount.Text);
        }

        private void MutationChance_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.mutationChance = float.Parse(MutationChance.Text);
            if(mutationChance>20)
                MessageBox.Show("Wysoki procent może sprawić, że program nie będzie działał poprawnie!","Mutacje", MessageBoxButton.OK,MessageBoxImage.Warning);
            this.mutationChance /= 100;
        }

        private void TimeOfLife_TextChanged(object sender, TextChangedEventArgs e)
        {
            timeOfLife = int.Parse(TimeOfLife.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point endPoint = new Point();
            endPoint.X = Canvas.GetLeft(EndPoint);
            endPoint.Y = Canvas.GetTop(EndPoint);

            Point startPoint = new Point();
            startPoint.X = Canvas.GetLeft(StartPoint);
            startPoint.Y = Canvas.GetTop(StartPoint);

            population = new Population(endPoint, mutationChance, populationCount, startPoint);

            //Step(population);
            /*while(!population.Finished())
            {
                population.Generate();
                population.CalcFitness();
                UnDraw();
                Draw(population.AllLocations(), population.GetBest());
                Thread.Sleep(10);
            }*/
        }
        private void Step_Button(object sender, RoutedEventArgs e)
        {
            Step();
        }
        private void Step()
        {
            population.Generate();
            population.CalcFitness();
            UnDraw();
            Draw(population.AllLocations(), population.GetBest());
        }
        private void UnDraw()
        {
            if(ellipses!=null)
            foreach( var x in ellipses)
            {
                Mrowisko.Children.Remove(x);
            }
        }
        private void Draw(Point[] points, int thebest)
        {
            int i = 0;
            ellipses = new Ellipse[populationCount];
            foreach( var x in points)
            {
                if(i==thebest)
                {
                    ellipses[i] = new Ellipse
                    {
                        Fill = Brushes.Purple,
                        Height = 20,
                        Width = 20,
                        StrokeThickness = 0,

                    };
                    Canvas.SetZIndex(ellipses[i],50000);
                }
                   
                else
                    ellipses[i] = new Ellipse
                    {
                        Fill = Brushes.Blue,
                        Height = 20,
                        Width = 20,
                        StrokeThickness=0,
                    };
                Canvas.SetTop(ellipses[i], x.Y);
                Canvas.SetLeft(ellipses[i], x.X);

                Mrowisko.Children.Add(ellipses[i]);
                i++;
            }
        }

        private void Step50_Button(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<50; i++)
            {
                Step();
            }
        }

        private void Radio_stop(object sender, RoutedEventArgs e)
        {
            del = false;
            draw = false;
        }

        
    }
}
