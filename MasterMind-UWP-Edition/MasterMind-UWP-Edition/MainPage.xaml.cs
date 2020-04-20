using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MasterMind_UWP_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //---------------------------- Constructor -------------------------------

        public MainPage()
        {
            this.InitializeComponent();
        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            DrawGameTitle(args);
            DrawStartButton(args);
            DrawInstructionsButton(args);
            DrawCreditsButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {

            
        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawGameTitle(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 50.0f
            }) {

                args.DrawingSession.DrawText("Master Mind", 250, 150, Colors.DeepPink, format);
            }
        }

        private static void DrawStartButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Start", 250, 300, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 275, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawInstructionsButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Instructions", 250, 400, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 375, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawCreditsButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Credits", 250, 500, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 475, 200, 55, Colors.DeepPink);
            }
        }

        //----------------------------- Button Clicks -----------------------------
        // Buttons clicks print out to the Output (Debug Setting) window when they where pressed/
        // Buttons also navigate to the appropriate page when clicked
        private void StartButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(MastermindGamePage));

            Debug.WriteLine("(Start) Click Event");
        }

        private  void InstructionsButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(InstructionsPage));

            Debug.WriteLine("(Instructions) Click Event");
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(CreditsPage));

            Debug.WriteLine("(Credits) Click Event");
        }
    }
}
