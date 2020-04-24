using Microsoft.Graphics.Canvas.Text;
using Windows.Media.Playback;
using Windows.Media.Core;
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
        MediaPlayer Player;
        //---------------------------- Constructor -------------------------------
        static GameLogic gamelogic;
        public MainPage()
        {
            this.InitializeComponent();
            Player = new MediaPlayer();
            gamelogic = new GameLogic();
            changeBox();
            for(int i=0; i<10; i++)
            {
                Score.Children[i].Visibility = Visibility.Collapsed;
            }

        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            DrawGameTitle(args);
            DrawStartButton(args);
            DrawInstructionsButton(args);
            DrawCreditsButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawGameTitle(CanvasAnimatedDrawEventArgs args)
        {

            using (CanvasTextFormat format = new CanvasTextFormat
            {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 50.0f
            })
            {

                args.DrawingSession.DrawText("Master Mind", 250, 150, Colors.DeepPink, format);
            }
        }

        private static void DrawStartButton(CanvasAnimatedDrawEventArgs args)
        {

            using (CanvasTextFormat format = new CanvasTextFormat
            {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            })
            {

                args.DrawingSession.DrawText("Start", 250, 300, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 275, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawInstructionsButton(CanvasAnimatedDrawEventArgs args)
        {

            using (CanvasTextFormat format = new CanvasTextFormat
            {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            })
            {

                args.DrawingSession.DrawText("Instructions", 250, 400, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 375, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawCreditsButton(CanvasAnimatedDrawEventArgs args)
        {

            using (CanvasTextFormat format = new CanvasTextFormat
            {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            })
            {

                args.DrawingSession.DrawText("Credits", 250, 500, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 475, 200, 55, Colors.DeepPink);
            }
        }

        //----------------------------- Button Clicks -----------------------------
        // Buttons clicks print out to the Output (Debug Setting) window when they where pressed/
        // Buttons also navigate to the appropriate page when clicked
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage));

            Debug.WriteLine("(Start) Click Event");
        }

        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(InstructionsPage));

            Debug.WriteLine("(Instructions) Click Event");
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(CreditsPage));

            Debug.WriteLine("(Credits) Click Event");
        }

        private void changeBox()
        {
            int[,] Board = new int[10, 4];
            Board = gamelogic.Board;

            var temp = Peg.Children;
            var Array = temp.ToArray();
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<4; j++)
                {
                    switch (Board[i, j])
                    {
                        // NO color
                        case -1: Array[4 * i + j].Visibility = Visibility.Collapsed; break;

                        //Color
                        case 0:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Red"); break;
                        case 1:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Blue"); break;
                        case 2:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Green"); break;
                        case 3:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Yellow"); break;
                        case 4:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Purple"); break;
                        case 5:Array[4 * i + j].Visibility = Visibility.Visible;  Array[4 * i + j].SetValue(TextBlock.TextProperty, "Cyan"); break;
                    }

                }
            }

        }

        private async void Sumbit_Results(object sender, RoutedEventArgs e)
        {

            int[] colors = new int[4];
            { // Setting the color values
                int pos = 0;
                if (Select1.SelectedIndex != -1)
                {
                    string Text = ((ComboBoxItem)Select1.SelectedItem).Content.ToString();
                    switch (Text)
                    {
                        case "Red":
                            colors[pos] = 0;
                            break;
                        case "Blue":
                            colors[pos] = 1;
                            break;
                        case "Green":
                            colors[pos] = 2;
                            break;
                        case "Yellow":
                            colors[pos] = 3;
                            break;
                        case "Purple":
                            colors[pos] = 4;
                            break;
                        case "Cyan":
                            colors[pos] = 5;
                            break;
                    }
                    pos++;
                }
                else
                {
                    var MessageDialog = new MessageDialog("OOf\t" + pos + "\t is not setup.");
                    MessageDialog.ShowAsync();
                    return;
                }
                if (Select2.SelectedIndex != -1)
                {
                    string Text = ((ComboBoxItem)Select2.SelectedItem).Content.ToString();
                    switch (Text)
                    {
                        case "Red":
                            colors[pos] = 0;
                            break;
                        case "Blue":
                            colors[pos] = 1;
                            break;
                        case "Green":
                            colors[pos] = 2;
                            break;
                        case "Yellow":
                            colors[pos] = 3;
                            break;
                        case "Purple":
                            colors[pos] = 4;
                            break;
                        case "Cyan":
                            colors[pos] = 5;
                            break;
                    }
                    pos++;
                }
                else
                {
                    var MessageDialog = new MessageDialog("OOf\t" + pos + "\t is not setup.");
                    MessageDialog.ShowAsync();
                    return;
                }
                if (Select3.SelectedIndex != -1)
                {
                    string Text = ((ComboBoxItem)Select3.SelectedItem).Content.ToString();
                    switch (Text)
                    {
                        case "Red":
                            colors[pos] = 0;
                            break;
                        case "Blue":
                            colors[pos] = 1;
                            break;
                        case "Green":
                            colors[pos] = 2;
                            break;
                        case "Yellow":
                            colors[pos] = 3;
                            break;
                        case "Purple":
                            colors[pos] = 4;
                            break;
                        case "Cyan":
                            colors[pos] = 5;
                            break;
                    }
                    pos++;
                }
                else
                {
                    var MessageDialog = new MessageDialog("OOf\t" + pos + "\t is not setup.");
                    MessageDialog.ShowAsync();
                    return;
                }
                if (Select4.SelectedIndex != -1)
                {
                    string Text = ((ComboBoxItem)Select4.SelectedItem).Content.ToString();
                    switch (Text)
                    {
                        case "Red":
                            colors[pos] = 0;
                            break;
                        case "Blue":
                            colors[pos] = 1;
                            break;
                        case "Green":
                            colors[pos] = 2;
                            break;
                        case "Yellow":
                            colors[pos] = 3;
                            break;
                        case "Purple":
                            colors[pos] = 4;
                            break;
                        case "Cyan":
                            colors[pos] = 5;
                            break;
                    }
                    pos++;
                }
                else
                {
                    var MessageDialog = new MessageDialog("OOf\t" + pos + "\t is not setup.");
                    MessageDialog.ShowAsync();
                    return;
                }
                //Colors should be setup now
            }
            int score;
            score = gamelogic.setPlayerPegsAndScore(colors);
            Debug.WriteLine(gamelogic.Counter + " COunter");
            changeBox();
            displayRight();

            if (score == -1)
            {
                MessageDialog temp = new MessageDialog("You lost the game. WAAA WAAA LOSER");
                temp.ShowAsync();
                Windows.Storage.StorageFolder  folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync("Lose.mp3");
                Player.AutoPlay = true;
                Player.Source = MediaSource.CreateFromStorageFile(file);

                Player.Play();




            }
            else if (score == 1)
            {
                MessageDialog temp = new MessageDialog("You won the game. CLAP CLAP");
                temp.ShowAsync();
                Windows.Storage.StorageFolder  folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync("Win.wav");
                Player.AutoPlay = true;
                Player.Source = MediaSource.CreateFromStorageFile(file);

                Player.Play();
            }

        }

        private void displayRight() // Display how many pegs they got right or not
        {

            int[] ScorePegs = gamelogic.ScorePegs;
            int Counter = gamelogic.Counter;
            var Array = Score.Children.ToArray();
            if(Counter<=10){
                Array[Counter-1].Visibility = Visibility.Visible;
                int Black = 0;
                int White = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (ScorePegs[j] == 1)
                        Black++;
                    else if (ScorePegs[j] == 2)
                        White++;
                }

                string temp = "Black " + Black + "\t White" + White;

                Array[Counter-1].SetValue(TextBlock.TextProperty, temp);

            }


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Return(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(NewMainMenuPage));


        }
    }
}
