﻿using Microsoft.Graphics.Canvas;
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

        public List<Color> PegColors = new List<Color> { Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple, Colors.Cyan };
        public List<Color> HintColors = new List<Color> { Colors.Green, Colors.Yellow, Colors.SlateGray };

        public List<List<Peg>> Pegs;
        public List<List<Peg>> HintPegs;
        public List<Peg> PegSecretCode;

        public int RightPlace { get; set; }
        public int RightColor { get; set; }

        public Mastermind() {

            CurrentRow = 0;

            Pegs = new List<List<Peg>>();
            HintPegs = new List<List<Peg>>();

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

            PegSecretCode = new List<Peg>();

            XCoordinate = 50;
            YCoordinate = 620;

            Random random = new Random();

            for (int column = 0; column < 4; column++) {

                var peg = new Peg() {

                    X = XCoordinate,
                    Y = YCoordinate,
                    Radius = newRadius,
                    Color = PegColors[random.Next(PegColors.Count)]
                };

                PegSecretCode.Add(peg);

                XCoordinate += 60;
            }

            newRadius = 5;
            YCoordinate = 40;
            int newLine = 0;

            for (int rowNumber = 0; rowNumber < 10; rowNumber++) {

                var row = new List<Peg>();

                XCoordinate = 300;

                for (int column = 0; column < 4; column++) {

                    var peg = new Peg();

                    if (newLine >= 2) {

                        peg.X = XCoordinate - 40;
                        peg.Y = YCoordinate + 20;
                    }
                    else {

                        peg.X = XCoordinate;
                        peg.Y = YCoordinate;
                    }

                    peg.Radius = newRadius;
                    peg.Color = Colors.SlateGray;

                    if (newLine > 2) {

                        newLine = 0;
                    }

                    row.Add(peg);

                    XCoordinate += 20;

                    newLine++;
                }

                newLine = 0;

                YCoordinate += 50;
                HintPegs.Add(row);
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
                    HintPegs[rowIndex][columnIndex].Draw(drawingSession);
                }
            }

            for (int columnIndex = 0; columnIndex < PegSecretCode.Count; columnIndex++) {

                PegSecretCode[columnIndex].Draw(drawingSession);
            }
        }

        public void IsCorrect() {

            //// Get the score of the player, and set that to Score Pegs
            //int rightPlace = 0;
            //int rightColor = 0;

            ////Getting number of matching placement
            //for (int i = 0; i < 4; i++) {

            //    if (CPUPegs[i] == Pegs[i])
            //        rightPlace++;

            //}
            //if (rightPlace == 4) {

            //    win = true;

            //    for (int i = 0; i < 4; i++) {

            //        Board[Counter, i] = Pegs[i]; // THe value to show that this is the winning result
            //        ScorePegs[i] = 2;
            //    }

            //    Counter++;
            //    return 1;
            //}

            ////Getting number of matching colors
            //for (int i = 0; i < 4; i++) {

            //    for (int j = 0; j < 4; j++) {

            //        if (CPUPegs[i] == Pegs[j])
            //            rightColor++;
            //    }
            //}

            ////Right colors have to be mutally exlusive to rightPlace.
            //rightColor -= rightPlace;

            //for (int i = 0; i < 4; i++) {

            //    if (rightColor != 0) {

            //        ScorePegs[i] = 1;
            //        rightColor--;
            //    }
            //    else if (rightPlace != 0) {

            //        ScorePegs[i] = 2;
            //        rightPlace--;
            //    }
            //    else {

            //        ScorePegs[i] = 0;
            //    }
            //}
        }
    }
}
