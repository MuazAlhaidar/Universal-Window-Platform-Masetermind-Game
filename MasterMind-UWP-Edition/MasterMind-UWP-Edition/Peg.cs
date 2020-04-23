using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Color = Windows.UI.Color;

namespace MasterMind_UWP_Edition {

    public class Peg {

        public Color color = Colors.Black;
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public float StrokeWidth { get; set; }

        public Peg(int XCoordinate, int YCoordinate, int newRadius, int newStrokeWidth) {

            X = XCoordinate;
            Y = YCoordinate;
            Radius = newRadius;
            StrokeWidth = newStrokeWidth;
        }

        private void ChangePegColor(Color color) {

            this.color = color;
        }

        private bool IsClickWithinBounds(int XCoordinate, int YCoordinate) {

            return (XCoordinate < (X + Radius)) && (XCoordinate > (X - Radius)) &&
                (YCoordinate < (Y + Radius)) && (YCoordinate > (Y - Radius));
        }

        private void Draw(CanvasDrawingSession drawingSession, Color newColor) {

            ChangePegColor(newColor);

            drawingSession.DrawCircle(X, Y, Radius, color, StrokeWidth);
        }
    }
}
