using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using DesignPatterns.Commands;
using DesignPatterns.UIElements;

namespace DesignPatterns
{
    class MoveThumb : Thumb
    {
        private Point _startPoint;
        public Point StartPoint { get { return _startPoint; } }

        private Point _endPoint;
        public Point EndPoint { get { return _endPoint; } }

        public MoveThumb()
        {
            DragStarted += new DragStartedEventHandler(this.MoveThumb_DragStarted);
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
            DragCompleted += new DragCompletedEventHandler(this.MoveThumb_DragCompleted);
        }

        private void MoveThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            BaseControl item = this.DataContext as BaseControl;
            _endPoint = new Point(Canvas.GetLeft(item), Canvas.GetTop(item));
            MainWindow.mainWindow.canvas.Invoker.ExecuteCommand(new MoveShape(item, _startPoint, _endPoint));
        }

        private void MoveThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            BaseControl item = this.DataContext as BaseControl;
            _startPoint = new Point(Canvas.GetLeft(item), Canvas.GetTop(item));
            
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (DataContext is BaseControl item)
            {
                // item.Visibility = System.Windows.Visibility.Hidden;
                double left = Canvas.GetLeft(item);
                double top = Canvas.GetTop(item);

                Canvas.SetLeft(item, left + e.HorizontalChange);
                Canvas.SetTop(item, top + e.VerticalChange);

            }
        }
    }
}
