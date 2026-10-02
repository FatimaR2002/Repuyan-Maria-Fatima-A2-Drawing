// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Text.RegularExpressions;

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
            Window.SetTitle("Colourful Daisy");
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

            //Draw Ellipses and Capsules for the leaves and stem of the flower
            //Ellipse for the leaves and make the colour green
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Ellipse(100, 330, 20, 60);
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Ellipse(130, 360, 60, 20);
            //Capsule for the stem and make the colour green
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Capsule(200, 200,80,400, 6);

            ///////////////////////////////////////////////////////////

            //Draw Capsules for the petals of the flower and make the colour white
            //First Petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 160, 100, 30);
            //Second Petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 240, 100, 30);
            //Third petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 100, 160, 30);
            //Fourth petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 100, 240, 30);
            //Fifth petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 160, 300, 30);
            //Sixth petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 240, 300, 30);
            //Seventh petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 300, 260, 30);
            //Eighth petal
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(255, 255, 240);
            Draw.Capsule(200, 200, 300, 160, 30);

            //Draw Circle to remove lines from the capsules to make the petals more uniformed
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, 255, 240);
            Draw.Circle(200, 200, 70);
            //Draw a circle in the middle of the flower and make the colour yellow
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(254, 216, 94);
            Draw.Circle(200, 200, 40);

            ////////////////////////////////////////////////////////////////
            
            //Draw a circle at the upper right corner of the window and make the colour yellow
            //Circle for the sun and make the colour yellow
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(253, 218, 13);
            Draw.Circle(400, 0, 50);
            //Adding a smaller circle to make the sun look more realistic and make the colour yellow
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, 255, 255, 128);
            Draw.Circle(400, 0, 40);
            //Adding small capsules to make the reflection of the sun and make it light yellow and transparent
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, 255, 143, 80);
            Draw.Circle(400, 0, 60);
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, 255, 143, 50);
            Draw.Circle(400, 0, 90);

            ////////////////////////////////////////////////////////////////
            
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space) == true)
            {
                //If pressed, change background to a darker colour
                Window.ClearBackground(48, 25, 52);

                //if pressed, change the leaves and stem to a darker colour
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Ellipse(100, 330, 20, 60);
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Ellipse(130, 360, 60, 20);
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Capsule(200, 200, 80, 400, 6);

                //If pressed,changed flower colour into another a darker colour
                //First Petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 160, 100, 30);
                //Second Petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 240, 100, 30);
                //Third petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 100, 160, 30);
                //Fourth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 100, 240, 30);
                //Fifth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 160, 300, 30);
                //Sixth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 240, 300, 30);
                //Seventh petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 300, 260, 30);
                //Eighth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(211, 211, 211);
                Draw.Capsule(200, 200, 300, 160, 30);

                ////////////////////////////////////////////////////////////////

                //if pressed, change the circle to a darker colour to remove lines from the capsules to make the petals more uniformed
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(0);
                Draw.SetFillColor(211, 211, 211);
                Draw.Circle(200, 200, 70);

                // if pressed, change the middle of the flower to a darker colour
                Draw.SetLineColor(0,0,0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(184, 115, 51);
                Draw.Circle(200, 200, 40);

                //if  pressed change the sun's colour to white to represent the moon
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(250, 249, 246);
                Draw.Circle(400, 0, 50);
                Draw.SetLineSize(0);
                Draw.SetFillColor(250, 249, 246, 128);
                Draw.Circle(400, 0, 40);
                Draw.SetLineSize(0);
                Draw.SetFillColor(250, 249, 246, 30);
                Draw.Circle(400, 0, 60);
                Draw.SetLineSize(0);
                Draw.SetFillColor(250, 249, 246, 15);
                Draw.Circle(400, 0, 90);

            }
        }
    }

}
