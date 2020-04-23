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

        public CanvasBitmap pegImage;

        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }

        public Peg() {


        }

        public Peg(int XCoordinate, int YCoordinate, int newRadius) {

            X = XCoordinate;
            Y = YCoordinate;
            Radius = newRadius;
        }

        public bool IsClickWithinBounds(double XCoordinate, double YCoordinate) {

            return (XCoordinate < (X + Radius)) && (XCoordinate > (X - Radius)) &&
                (YCoordinate < (Y + Radius)) && (YCoordinate > (Y - Radius));
        }

        public void Draw(CanvasDrawingSession drawingSession) {
            
            drawingSession.FillCircle(X, Y, Radius, Color);
        }

        public void UpdatePeg(CanvasDrawingSession drawingSession) {

        }
    }
}
