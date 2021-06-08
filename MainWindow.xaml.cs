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
using System.IO;
using System.Windows.Threading;

namespace mrowki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(0.1*howoften);
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
        List<Rectangle> rects = new List<Rectangle>();
        int i = 0;
        int howoften = 1;
        bool goFurther = false;
        bool stop50 = false;

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if(i==timeOfLife)
            {
                population.Generate();
                i = 0;
            }
            Generation.Text = i.ToString();
            try
            {
                population.CalcFitness();
            }
            catch (NullReferenceException)
            {
                timer.Stop();
                MessageBox.Show("Włącz najpierw symulację", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

                UnDraw();
            var x = population.GetBest();
                Draw(population.GetLocations(), x);

            BestFitness.Text = Math.Round(population.population[x].fitness,5).ToString();
            AvarageFitness.Text = Math.Round(population.GetAverageFitness(),5).ToString();

            population.Update(i);
            

                
            //population.NaturalSelection();

            if (population.finished && !goFurther)
            {
                timer.Stop();
                MessageBox.Show("Odnaleziono cel", "Cel", MessageBoxButton.OK, MessageBoxImage.Information);
                goFurther = true;
            }
            i++;
        }
        private void Rectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (del)
            {
                if (e.OriginalSource is Rectangle)
                {
                    Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                    rects.Remove(activeRectangle);
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
            rects.Add(rect);

        }

        private void Mrowisko_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (!Mrowisko.IsMouseCaptured)
                {
                    return;
                }

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
            try
            {
                this.populationCount = int.Parse(popCount.Text);
            }
            catch
            {
                popCount.Text = 0.ToString();
                this.populationCount = 0;
            }
        }

        private void MutationChance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.mutationChance = float.Parse(MutationChance.Text);
            }
            catch
            {
                MutationChance.Text = 0.ToString();
                this.mutationChance = 0;
            }
            if (mutationChance>20)
                MessageBox.Show("Wysoki procent może sprawić, że program nie będzie działał poprawnie!","Mutacje", MessageBoxButton.OK,MessageBoxImage.Warning);
            this.mutationChance /= 100;
        }

        private void TimeOfLife_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                timeOfLife = int.Parse(TimeOfLife.Text);
            }
            catch
            {
                timeOfLife = 0;
                TimeOfLife.Text = 0.ToString();
                MessageBox.Show("Musisz najpierw wyłączyć timer i po zmianie zresetować symulację.", "Dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                timer.Stop();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point endPoint = new Point();
            endPoint.X = Canvas.GetLeft(EndPoint);
            endPoint.Y = Canvas.GetTop(EndPoint);
            AntData.target = endPoint;

            Point startPoint = new Point();
            startPoint.X = Canvas.GetLeft(StartPoint);
            startPoint.Y = Canvas.GetTop(StartPoint);
            AntData.start = startPoint;

            AntData.mutationrate = mutationChance;
            AntData.lifetime = timeOfLife;
            population = new Population( mutationChance, populationCount,timeOfLife,ref rects, ref Mrowisko);
            goFurther = false;

            timer.Start();

            //Window1 win1 = new Window1();
            //win1.Show();

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
                //population.Move();
                //Thread.Sleep(1);
            Step();
        }
        private void Step()
        {
            //population.Generate();
            //population.CalcFitness();
            ////population.NaturalSelection();
            //
            //UnDraw();
            //
            //Draw(population.GetEndLocations(), population.GetBest());
            //
            //if (population.finished)
            //    MessageBox.Show("Odnaleziono cel", "Cel", MessageBoxButton.OK, MessageBoxImage.Information);
            i = 0;
            while(i<timeOfLife)
            {
                if (i == 0)
                {
                    population.Generate();

                }

                population.CalcFitness();

               

                population.Update(i);


                //population.NaturalSelection();

                if (population.finished && !goFurther)
                {
                    timer.Stop();
                    MessageBox.Show("Odnaleziono cel", "Cel", MessageBoxButton.OK, MessageBoxImage.Information);
                    stop50=true;
                    goFurther = true;
                }
                i++;
            }
            UnDraw();
            var x = population.GetBest();
            Draw(population.GetLocations(), x);
            BestFitness.Text = Math.Round(population.population[x].fitness, 5).ToString();
            AvarageFitness.Text = Math.Round(population.GetAverageFitness(), 5).ToString();

        }
        private void UnDraw()
        {
            if(ellipses!=null)
            foreach( var x in ellipses)
            {
                Mrowisko.Children.Remove(x);
            }
        }
        private void Draw(Point[] points,int thebest)
        {

            ellipses = new Ellipse[population.population.Length];
            for(int j=0; j< population.population.Length; j++)
            {
                if (j == thebest)
                {
                    ellipses[j] = new Ellipse
                    {
                        Fill = Brushes.Purple,
                        Height = 20,
                        Width = 20,
                        StrokeThickness = 0,

                    };
                    Canvas.SetZIndex(ellipses[j], 50000);
                }

                else
                    ellipses[j] = new Ellipse
                    {
                        Fill = Brushes.Blue,
                        Height = 20,
                        Width = 20,
                        StrokeThickness = 0,
                    };
                Canvas.SetTop(ellipses[j], points[j].Y);
                Canvas.SetLeft(ellipses[j], points[j].X);

                Mrowisko.Children.Add(ellipses[j]);
            }
            
                    
            GenCount.Text = String.Format($"Generacja: {population.generations}");
        }

        private void Step50_Button(object sender, RoutedEventArgs e)
        {
            stop50 = false;

            for (int j=0; j<50; j++)
            {
                Step();
                if (stop50)
                    break;
            }
            UnDraw();
            Draw(population.GetLocations(), population.GetBest());

        }

        private void GoOn(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void StopNow(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            howoften = (int)slValue.Value;
            if (howoften == 0)
                howoften = 1;
            timer.Interval = TimeSpan.FromMilliseconds(0.1 * howoften);
        }

        private void Radio_stop(object sender, RoutedEventArgs e)
        {
            del = false;
            draw = false;
        }
        


    }
}
