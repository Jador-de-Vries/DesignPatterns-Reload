using DesignPatterns.Commands;
using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace DesignPatterns
{
    class ShapeAdorner : Adorner
    {
        enum MousePosition
        {
            TL,
            TR,
            BL,
            BR
        }

        private MousePosition currentPosition;
        private readonly Panel ownerPanel;
        private readonly FrameworkElement adornedElement;
        private bool isDragging = false;
        private Point startPosition;
        private readonly double renderRadius = 5.0;

        private Point _oldPosition, _newPosition;
        private double _oldWidth, _oldHeight, _newWidth, _newHeight;
        public ShapeAdorner(UIElement adornedElement, Panel ownerPanel) : base(adornedElement)
        {
            this.ownerPanel = ownerPanel;
            this.adornedElement = adornedElement as FrameworkElement;
        }

        /// <summary>
        /// Event Handler voor MouseEnter
        /// Wanneer de muis over de adorner heen gaat pak dan de muispositie.
        /// Als de muis op de juiste plekken is geef dan de juiste cursor
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            Point point = Mouse.GetPosition(adornedElement);
            currentPosition = GetMousePosition(point);
            switch (currentPosition)
            {
                case MousePosition.BR:
                case MousePosition.TL:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case MousePosition.BL:
                case MousePosition.TR:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (Mouse.Capture(this))
            {
                isDragging = true;
                startPosition = Mouse.GetPosition(ownerPanel);
                _oldPosition = new Point(Canvas.GetLeft(adornedElement), Canvas.GetTop(adornedElement));
                _oldWidth = adornedElement.Width;
                _oldHeight = adornedElement.Height;
            }
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newPosition = Mouse.GetPosition(ownerPanel);
                double diffX = (newPosition.X - startPosition.X);
                double diffY = (newPosition.Y - startPosition.Y);

                // we should decide whether to change Width and Height or to change Canvas.Left and Canvas.Right
                if (Math.Abs(diffX) >= 1 || Math.Abs(diffY) >= 1)
                {
                    switch (currentPosition)
                    {
                        case MousePosition.TL:
                        case MousePosition.BL:

                            Canvas.SetLeft(adornedElement, Math.Max(0, Canvas.GetLeft(adornedElement) + diffX));
                            adornedElement.Width = Math.Max(0, adornedElement.Width - diffX);

                            ownerPanel.InvalidateArrange();

                            break;
                        case MousePosition.BR:
                        case MousePosition.TR:

                            adornedElement.Width = Math.Max(0, adornedElement.Width + diffX);
                            break;
                    }


                    switch (currentPosition)
                    {
                        case MousePosition.TL:
                        case MousePosition.TR:
                            Canvas.SetTop(adornedElement, Math.Max(0, Canvas.GetTop(adornedElement) + diffY));
                            adornedElement.Height = Math.Max(0, adornedElement.Height - diffY);
                            break;
                        case MousePosition.BL:
                        case MousePosition.BR:

                            adornedElement.Height = Math.Max(0, adornedElement.Height + diffY);
                            break;

                    }
                }
                startPosition = newPosition;
            }
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                _newWidth = adornedElement.Width;
                _newHeight = adornedElement.Height;
                _newPosition = new Point(Canvas.GetLeft(adornedElement), Canvas.GetTop(adornedElement));
                Mouse.Capture(null);
                isDragging = false;
                Canvas canvas = ownerPanel as Canvas;
                canvas.Invoker.ExecuteCommand(new ResizeShape(adornedElement as BaseControl, _oldPosition, _newPosition, _oldWidth, _oldHeight, _newWidth, _newHeight));
            }
        }
        #region Methods
        MousePosition GetMousePosition(Point point) // point relative to element
        {
            double h2 = ActualHeight / 2;
            double w2 = ActualWidth / 2;
            if (point.X < w2 && point.Y < h2)
                return MousePosition.TL;
            else if (point.X > w2 && point.Y > h2)
                return MousePosition.BR;
            else if (point.X > w2 && point.Y < h2)
                return MousePosition.TR;
            else
                return MousePosition.BL;
        }
        #endregion
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(AdornedElement.DesiredSize);
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black)
            {
                Opacity = 0.3
            };
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Black), 1);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }
    }
}
