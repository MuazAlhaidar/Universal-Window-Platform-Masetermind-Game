using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Context;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace MasterMind_UWP_Edition {

    public class Mastermind {

        public CanvasDrawingSession session;

        public int CurrentRow { get; set; }

        public List<Color> PegColors = new List<Color> {Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple, Colors.Cyan};
        public List<Color> HintColors = new List<Color> { Colors.Green, Colors.Yellow, Colors.SlateGray };

        public List<List<Peg>> Pegs;
        public List<List<Peg>> HintPegs;
        public List<Peg> PegSecretCode;

        public Mastermind() {

            CurrentRow = 0;

            Pegs = new List<List<Peg>>();

            int XCoordinate;
            int YCoordinate = 50;
            int newRadius = 20;

            for (int rowNumber = 0; rowNumber < 10; rowNumber++) {

                var row = new List<Peg>();

                XCoordinate = 50;

                for (int column = 0; column < 4; column++) {

                    var peg = new Peg() {

                        X = XCoordinate,
                        Y = YCoordinate,
                        Radius = newRadius,
                        Color = Colors.SlateGray
                    };

                    row.Add(peg);

                    XCoordinate += 60;
                }

                YCoordinate += 50;
                Pegs.Add(row);
            }
        }

        public Color NextColor(Color currentColor) {

            if (currentColor == Colors.SlateGray) {

                return PegColors[0];
            }
            else if (currentColor == Colors.Red) {

                return PegColors[1];
            }
            else if (currentColor == Colors.Blue) {

                return PegColors[2];
            }
            else if (currentColor == Colors.Green) {

                return PegColors[3];
            }
            else if (currentColor == Colors.Yellow) {

                return PegColors[4];
            }
            else if (currentColor == Colors.Purple) {

                return PegColors[5];
            }
            else if (currentColor == Colors.Cyan) {

                return PegColors[0];
            }

            return default;
        }

        public void DrawMastermind(CanvasDrawingSession drawingSession) {

            for (int rowIndex = 0; rowIndex < Pegs.Count; rowIndex++) {

                for (int columnIndex = 0; columnIndex < Pegs[rowIndex].Count; columnIndex++) {

                    Pegs[rowIndex][columnIndex].Draw(drawingSession);
                }
            }
        }

        public void CheckIfCorrect() {


        }
    }
}
