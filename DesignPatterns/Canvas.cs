﻿using DesignPatterns.Commands;
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
using System.Windows.Shapes;

namespace DesignPatterns
{
    class Canvas : System.Windows.Controls.Canvas
    {
        #region Types & Properties

        private ShapeType _drawingShape;
        public ShapeType DrawingShape
        {
            get
            {
                return _drawingShape;
            }
            set
            {
                _drawingShape = value;
            }
        }

        private CursorState cursorMode;
        public CursorState CursorMode
        {
            get => default;
            set
            {
                cursorMode = value;
                OnCursorModeChange();
            }
        }

        private readonly CommandInvoker _invoker = new CommandInvoker();
        public CommandInvoker Invoker { get { return _invoker; } }

        private Point startPoint;
        private Shape shape;

        private CompositeControl _group = new CompositeControl();
        public CompositeControl Group => _group;

        #endregion
        public Canvas()
        {
            Background = Brushes.Transparent;
            FocusManager.SetIsFocusScope(this, true);
            Children.Add(_group);
        }

        #region Methods
        public BaseControl CreateShape(Type shapeType, Point startPoint, int width, int height)
        {
            Shape shape;
            switch (shapeType.ToString())
            {
                case "System.Windows.Shapes.Rectangle":
                    shape = new System.Windows.Shapes.Rectangle();
                    break;
                case "System.Windows.Shapes.Ellipse":
                    shape = new System.Windows.Shapes.Ellipse();
                    break;
                default: throw new Exception();
            }

            BaseControl shapeParent = new LeafControl(shape)
            {
                Template = Resources["DesignerItemTemplate"] as ControlTemplate
            };

            shapeParent.Focusable = true;
            shapeParent.PreviewMouseLeftButtonDown += ShapeParent_MouseLeftButtonDown;
            shapeParent.GotFocus += ShapeParent_GotFocus;
            shapeParent.LostFocus += ShapeParent_LostFocus;
            Canvas.SetLeft(shapeParent, startPoint.X);
            Canvas.SetTop(shapeParent, startPoint.Y);
            shapeParent.Width = width;
            shapeParent.Height = height;
            Console.WriteLine(shapeParent);
            return shapeParent;
        }
        private void RemoveAdorner(UIElement element, AdornerLayer adLayer)
        {
            if (adLayer != null)
            {
                Adorner[] adorners = adLayer.GetAdorners(element);
                if (adorners != null)
                {
                    foreach (Adorner adorner in adorners)
                    {
                        adLayer.Remove(adorner);
                    }
                }
            }
        }
        #endregion

        #region Event Handlers
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (cursorMode != CursorState.Creator) return;

            startPoint = e.GetPosition(this);
            Console.WriteLine(DrawingShape);
            switch (DrawingShape)
            {
                case ShapeType.Rectangle:
                    shape = new System.Windows.Shapes.Rectangle();
                    break;
                case ShapeType.Ellipse:
                    shape = new System.Windows.Shapes.Ellipse();
                    break;
                default: return;
            }

            shape.Fill = Brushes.LightSteelBlue;
            shape.Stroke = Brushes.Black;
            shape.StrokeThickness = 1;
            shape.IsHitTestVisible = false;
            shape.Focusable = false;
            Canvas.SetLeft(shape, startPoint.X);
            Canvas.SetTop(shape, startPoint.Y);
            Children.Add(shape);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || shape == null)
                return;

            var pos = e.GetPosition(this);

            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);

            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;

            shape.Width = w;
            shape.Height = h;

            Canvas.SetLeft(shape, x);
            Canvas.SetTop(shape, y);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (shape != null)
            {
                _invoker.ExecuteCommand(new CreateShape(this, shape.GetType(), startPoint, (int)shape.Width, (int)shape.Height));
                Children.Remove(shape);
                shape = null;
                CursorMode = CursorState.Pointer;
            }
        }
        #endregion

        #region Control Shape Focus
        private void ShapeParent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cursorMode == CursorState.Pointer)
            {
                // Maak een adorner op de adornerLayer voor het resizen
                // Verwijder daarna alle vorige adorners zodat er maar eentje gefocust kan zijn
                ShapeAdorner ad = new ShapeAdorner((UIElement)sender, this);
                AdornerLayer adLayer = AdornerLayer.GetAdornerLayer((UIElement)sender);
                RemoveAdorner((UIElement)sender, adLayer); // Verwijder vorige adorners op de sender
                adLayer.Add(ad);
            }
        }

        private void ShapeParent_LostFocus(object sender, RoutedEventArgs e)
        {
            UIElementCollection elements = this.Children;
            foreach (UIElement element in elements)
            {
                AdornerLayer al = AdornerLayer.GetAdornerLayer(element);
                RemoveAdorner(element, al);
            }
        }
        #endregion

        private void ShapeParent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (cursorMode == CursorState.Pointer)
            {
                (sender as UIElement).Focus();
            }
        }

        private void OnCursorModeChange()
        {
            switch (cursorMode)
            {
                case CursorState.Creator:
                    this.Cursor = Cursors.Cross;
                    break;
                case CursorState.Pointer:
                    this.Cursor = Cursors.Arrow;
                    break;
            }
        }


    }
}