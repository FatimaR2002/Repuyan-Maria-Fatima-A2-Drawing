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
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Rectangle(200, 200, 10, 200);

            //Draw a circle at the top of the rectangle and make the colour orange
            Draw.SetLineColor(255, 117, 24);
            Draw.SetLineSize(1);
            Draw.SetFillColor(254, 216, 94);
            Draw.Circle(200, 200, 30);


            //Draw the 4 pinwheel triangles and make them follow the mouse cursor position, from the center of the square
            //The First Pinwheel triangle is coloured green
            //Draw.SetLineColor(79, 121, 66);
            //Draw.SetLineSize(1);
            //Draw.SetFillColor(0, 158, 96);
            //Draw.Triangle(200, 200, 340, 360, 220,340);

            //The Second Pinwheel triangle is coloured yellow
            Draw.SetLineColor(255, 170, 51);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 192, 0);
            Draw.Triangle(200, 200, 360, 60, 340, 180);

            //The Third Pinwheel triangle is coloured red
          



        }
    }

}
