/*////////////////////////////////////////////////////////////////////////
/* Copyright (c)
/* Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
/* Game Design (374): GAME 10033 Game Development Foundations
/* Source: https://github.com/MohawkRaphaelT/game10003-2d-game-template
/*////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    /// <summary>
    ///     Access window information.
    /// </summary>
    public static class Window
    {

        #region Fields and Properties

        /// <summary>
        ///     Window height in pixels.
        /// </summary>
        private static int height = 256;

        /// <summary>
        ///     Window width in pixels.
        /// </summary>
        private static int width = 256;

        /// <summary>
        ///     Program window target FPS.
        /// </summary>
        private static int targetFPS = 60;

        /// <summary>
        ///     Program window title.
        /// </summary>
        private static string title = "2D Game Template";

        /// <summary>
        ///     How many frames-per-second the window is running at.
        /// </summary>
        public static float CurrentFPS => Raylib.GetFPS();

        /// <summary>
        ///     Height of window in pixels.
        /// </summary>
        public static int Height
        {
            get => height;
            set => SetWidth(value);
        }

        /// <summary>
        ///     Size of window in pixels.
        /// </summary>
        public static Vector2 Size
        {
            get => new(width, height);
            set => SetSize(value);
        }

        /// <summary>
        ///     How many frames-per-second (FPS) the game tries to output every second.
        /// </summary>
        public static int TargetFPS
        {
            get => targetFPS;
            set => SetTargetFpsOrWarn(value);
        }

        /// <summary>
        ///     Title displayed on top of program window.
        /// </summary>
        public static string Title
        {
            get => title;
            set => title = value;
        }

        /// <summary>
        ///     Width of window in pixels.
        /// </summary>
        public static int Width
        {
            get => width;
            set => SetHeight(value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Clears the window canvas to the specified <paramref name="color"/>.
        /// </summary>
        /// <param name="color">The background color to paint.</param>
        public static void ClearBackground(Color color)
        {
            // Not sure what it does, but not working with double buffer
            //Raylib.ClearBackground(color);

            // Alternative
            Raylib.DrawRectangle(0, 0, width, height, color);
        }

        /// <summary>
        ///     Clears the window canvas to the specified <paramref name="hexColor"/>.
        /// </summary>
        /// <param name="hexColor">The color represented in hex, eg. "#00FF00" (green) or "0080FF80" (blue-cyan, half transparent).
        public static void ClearBackground(string hexColor) => ClearBackground(new Color(hexColor));

        /// <summary>
        ///     Clears the window canvas to the specified <paramref name="intensity"/> (greyscale value).
        /// </summary>
        /// <param name="intensity">The greyscale color intensity. 0 is black, 255 is white, 128 is mid-tone grey.</param>
        public static void ClearBackground(int intensity) => ClearBackground(new Color(intensity));

        /// <summary>
        ///     Clears the window canvas to the color constructred from the specified <paramref name="red"/>, 
        ///     <paramref name="green"/>, and <paramref name="blue"/> color components.
        /// </summary>
        /// <param name="red">The red colour component. 0 means no red, 255 means max red.</param>
        /// <param name="green">The green colour component. 0 means no green, 255 means max green.</param>
        /// <param name="blue">The blue colour component. 0 means no blue, 255 means max blue.</param>
        public static void ClearBackground(int red, int green, int blue) => ClearBackground(new Color(red, green, blue));



        /// <summary>
        ///     Centre window within the current monitor.
        /// </summary>
        public static void CentreWindow()
        {
            // Position window in centre of screen
            int monitorID = Raylib.GetCurrentMonitor();
            int monitorWidth = Raylib.GetMonitorWidth(monitorID);
            int monitorHeight = Raylib.GetMonitorHeight(monitorID);
            Vector2 windowPosition = new Vector2(
                Width > monitorWidth ? 0 : (monitorWidth - Width) / 2,
                Height > monitorHeight ? 0 : (monitorHeight - Height) / 2);
            Raylib.SetWindowPosition((int)windowPosition.X, (int)windowPosition.Y);
        }

        /// <summary>
        ///     Set the window size in pixels.
        /// </summary>
        /// <param name="width">Width of window in pixels.</param>
        /// <param name="height">Height of window in pixels.</param>
        public static void SetSize(int width, int height)
        {
            Window.width = width;
            Window.height = height;
            Raylib.SetWindowSize(width, height);
        }

        /// <summary>
        ///     Set the program window title.
        /// </summary>
        /// <param name="value">The new title to display.</param>
        public static void SetTitle(string value)
        {
            Raylib.SetWindowTitle(value);
        }

        /// <summary>
        ///     VSync. Sets the FPS target to the monitor's refresh rate.
        /// </summary>
        /// <remarks>
        ///     The monitor selected is based on which monitor the
        ///     window is currently in.
        /// </remarks>
        public static void SetFpsToMonitorRefreshRate()
        {
            int monitorIndex = Raylib.GetCurrentMonitor();
            int hz = Raylib.GetMonitorRefreshRate(monitorIndex);
            SetTargetFpsOrWarn(hz);
        }

        #endregion

        #region Private Methods

        private static void SetHeight(int height)
        {
            Window.height = height;
            Raylib.SetWindowSize(width, height);
        }

        private static void SetSize(Vector2 size)
        {
            int width = (int)size.X;
            int height = (int)size.Y;
            Raylib.SetWindowSize(width, height);
        }

        private static void SetTargetFpsOrWarn(int targetFPS)
        {
            // Warn when trying to set impossible FPS
            if (targetFPS <= 0)
            {
                string msg = "FPS must be greater than 0!";
                Console.WriteLine(msg);
            }
            // Only update FPS if not current FPS
            else if (targetFPS != TargetFPS)
            {
                Window.targetFPS = targetFPS;
                Raylib.SetTargetFPS(targetFPS);
            }
        }

        private static void SetWidth(int width)
        {
            Window.width = width;
            Raylib.SetWindowSize(width, height);
        }

        #endregion

    }
}
