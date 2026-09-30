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

            //Draw Ellipses for the leaves on the stem
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Ellipse(100, 330, 20, 60);
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Ellipse(130, 360, 60, 20);

            //Draw a capsule for the stem and make the colour green
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(138, 154, 91);
            Draw.Capsule(200, 200,80,400, 6);

            ////////////////////////////////////////////////////////////
            
            //Draw Capsules for the petals
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

          
            //Draw a Circle to remove lines from the capsules to make the petals more uniformed//
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(0);
            Draw.SetFillColor(255, 255, 240);
            Draw.Circle(200, 200, 70);

           
            //Draw a circle at the top of the rectangle and make the colour yellow
            Draw.SetLineColor(0,0,0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(254, 216, 94);
            Draw.Circle(200, 200, 40);

            //Added a circle for the sun
            Draw.SetLineColor(0, 0, 0);
            Draw.SetLineSize(1);
            Draw.SetFillColor(Color.Yellow);
            Draw.Circle(400, 0, 50);

            ////////////////////////////////////////////////////////////////
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space) == true)
            {
                //If pressed, change background to a darker colour
                Window.ClearBackground(48, 25, 52);

                //Draw Ellipses for the leaves on the stem
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Ellipse(100, 330, 20, 60);
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Ellipse(130, 360, 60, 20);

                //Draw a capsule for the stem and make the colour green
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(2, 48, 32);
                Draw.Capsule(200, 200, 80, 400, 6);

                //If pressed, flower is changed into another a darker colour
                //First Petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 160, 100, 30);

                //Second Petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 240, 100, 30);

                //Third petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 100, 160, 30);

                //Fourth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 100, 240, 30);

                //Fifth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 160, 300, 30);

                //Sixth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 240, 300, 30);

                //Seventh petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 300, 260, 30);

                //Eighth petal
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(226, 223, 210);
                Draw.Capsule(200, 200, 300, 160, 30);

                ////////////////////////////////////////////////////////////////
                //Draw a Circle to remove lines from the capsules
                //to make the petals more uniformed//
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(0);
                Draw.SetFillColor(226, 223, 210);
                Draw.Circle(200, 200, 70);

                //Draw a circle at the top of the rectangle and make the colour yellow
                Draw.SetLineColor(0,0,0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(184, 115, 51);
                Draw.Circle(200, 200, 40);

                //Changed the colour to white to represent the moon
                Draw.SetLineColor(0, 0, 0);
                Draw.SetLineSize(1);
                Draw.SetFillColor(250, 249, 246);
                Draw.Circle(400, 0, 50);


            }
        }
    }

}
