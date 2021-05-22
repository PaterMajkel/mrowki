﻿using System;
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
        Rectangle rect;
        UIElement dragObject = null;

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
        private void Radio_stop(object sender, RoutedEventArgs e)
        {
            del = false;
            draw = false;
        }

        
    }
}
