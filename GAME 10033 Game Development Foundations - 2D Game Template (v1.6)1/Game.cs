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

            //Draw a capsule for the stem and make the colour green
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Capsule(200, 200,80,400, 6);

            //Drawing first layer of petals
            //First petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 200, 360, 10);
            //Second petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 280, 360, 10);
            ////Third petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 270, 360, 10);


            //Draw a circle at the top of the rectangle and make the colour orange
            Draw.SetLineColor(255, 117, 24);
            Draw.SetLineSize(1);
            Draw.SetFillColor(254, 216, 94);
            Draw.Circle(200, 200, 30);
        }
    }

}
