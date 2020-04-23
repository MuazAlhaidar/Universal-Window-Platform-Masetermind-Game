using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MasterMind_UWP_Edition {

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MastermindGamePage : Page {

        Mastermind mastermind;

        public MastermindGamePage() {

            this.InitializeComponent();

            mastermind = new Mastermind();

            Window.Current.CoreWindow.PointerPressed += Canvas_Click;
        }

        private void Canvas_Click(CoreWindow sender, PointerEventArgs args) {

            for (int column = 0; column < mastermind.Pegs[mastermind.CurrentRow].Count; column++) {

                if(mastermind.Pegs[mastermind.CurrentRow][column].IsClickWithinBounds(args.CurrentPoint.Position.X, args.CurrentPoint.Position.Y)) {

                    mastermind.Pegs[mastermind.CurrentRow][column].Color = mastermind.NextColor(mastermind.Pegs[mastermind.CurrentRow][column].Color);
                }
            }
        }

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            mastermind.DrawMastermind(args.DrawingSession);
            DrawCheckButton(args);
            DrawReturnButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        private static void DrawCheckButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Check", 400, 600, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(300, 575, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawReturnButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Return", 400, 660, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(300, 635, 200, 55, Colors.DeepPink);
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e) {

            mastermind.CheckIfCorrect();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
