// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            //Set the window title
            Window.SetTitle("PinWheel Spinner");
            //Set the window size to 400x400 pixels
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //Make the background a light blue colour
            Window.ClearBackground(135, 206, 235);

            //Draw a rectangle at upper left corner position and make the colour a light brown colour
            Draw.SetLineColor(204, 119, 34);
            Draw.SetLineSize(1);
            Draw.SetFillColor(218, 160, 109);
            Draw.Rectangle(180, 200, 20, 200);

            //Draw a square at the top of rectangle and make it orange
            Draw.SetLineColor(255, 117, 24);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 165, 0);
            Draw.Rectangle(160, 140, 60, 60);

            //Draw a tiny circle at the center of the big circle and make it black
            Draw.SetFillColor(0, 0, 0);
            Draw.Circle(190, 190, 8);

            //Draw the first pinwheel blade and make it the colour green
            Draw.SetLineColor(0);
            Draw.SetLineSize(0);
            Draw.SetFillColor(0, 158, 96);
            Draw.Ellipse(190, 190, 50, 20);

        }
    }

}
