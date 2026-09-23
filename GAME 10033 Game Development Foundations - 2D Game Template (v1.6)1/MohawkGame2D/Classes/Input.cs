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
    ///     Access player input functions.
    /// </summary>
    /// <remarks>
    ///     A static wrapper to standardize raylib's gamepad API.
    /// </remarks>
    public static class Input
    {
        #region Public Methods

        /// <summary>
        ///     Disables mouse cursor while inside window.
        /// </summary>
        public static void DisableMouseCursor() => Raylib.DisableCursor();

        /// <summary>
        ///     Enables mouse cursor while inside window.
        /// </summary>
        public static void EnableMouseCursor() => Raylib.EnableCursor();

        /// <summary>
        ///     Get the <paramref name="controllerAxis"/> value of any controller.
        ///     Minimum value to register activity is defined by <paramref name="deadzone"/>.
        /// </summary>
        /// <param name="controllerAxis">The controller axis to check.</param>
        /// <param name="deadzone">The minimum value needed to register an axis value.</param>
        /// <returns>
        ///     Returns average value of all active controller's <paramref name="controllerAxis"/>.
        /// </returns>
        public static float GetAnyControllerAxis(ControllerAxis controllerAxis, float deadzone = 0.05f)
        {
            GamepadAxis axis = (GamepadAxis)controllerAxis;
            float finalValue = 0f;
            int activeControllers = 0;

            int controllerCount = GetConnectedControllerCount();
            for (int i = 0; i < controllerCount; i++)
            {
                float value = Raylib.GetGamepadAxisMovement(i, axis);
                bool isActive = Math.Abs(value) > deadzone;
                if (isActive)
                {
                    finalValue += value;
                    activeControllers++;
                }
            }

            if (controllerCount > 1)
                finalValue /= controllerCount;

            return finalValue;
        }

        /// <summary>
        ///     Create an axis from specified inputs.
        /// </summary>
        /// <param name="negative">The negative input key.</param>
        /// <param name="positive">The positive input key.</param>
        /// <returns>
        ///     Returns a float axis that combines both inputs,
        ///     ranges from -1f to +1f.
        /// </returns>
        public static float GetAxis(KeyboardKey negative, KeyboardKey positive)
        {
            float value = 0;

            if (IsKeyboardKeyDown(negative))
                value -= 1f;

            if (IsKeyboardKeyDown(positive))
                value += 1f;

            return value;
        }

        /// <summary>
        ///     Create two axes from specified inputs.
        /// </summary>
        /// <param name="negativeX">The negative X input key.</param>
        /// <param name="positiveX">The positive X input key.</param>
        /// <param name="negativeY">The negative Y input key.</param>
        /// <param name="positiveY">The positive Y input key.</param>
        /// <returns>
        ///     Returns a Vector2 axis that combines both X inputs,
        ///     both Y inputs, each ranging from -1f to +1f. The
        ///     input is clamped to a max length of 1f.
        /// </returns>
        public static Vector2 GetAxis2(KeyboardKey negativeX, KeyboardKey positiveX, KeyboardKey negativeY, KeyboardKey positiveY)
        {
            // Combine axes
            float x = GetAxis(negativeX, positiveX);
            float y = GetAxis(negativeY, positiveY);
            Vector2 value = new(x, y);

            // Clamp to unit circle
            if (value.Length() > 1f)
                value = Vector2.Normalize(value);

            return value;
        }


        /// <summary>
        ///     Get keyboard <see cref="char"/> characters pressed.
        ///     Call multiple times to get queued characters.
        /// </summary>
        /// <returns>
        ///     The character pressed if present, otherwise '\0'
        ///     (null character) when the queue is empty.
        /// </returns>
        public static char GetCharsPressed() => (char)Raylib.GetCharPressed();

        /// <summary>
        ///     Get number of controllers connected to the host device.
        /// </summary>
        /// <returns>
        ///     Returns number of controllers connected to this device.
        /// </returns>
        public static int GetConnectedControllerCount()
        {
            int controllerCount = 0;
            int index = 0;
            while (Raylib.IsGamepadAvailable(index++))
                controllerCount++;
            return controllerCount;
        }

        /// <summary>
        ///     Get the <paramref name="controllerAxis"/> value of
        ///     <paramref name="controllerIndex"/>.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check.</param>
        /// <param name="controllerAxis">The controller axis to check.</param>
        /// <returns>
        ///     Returns a value 0-1 of specified controller.
        /// </returns>
        public static float GetControllerAxis(int controllerIndex, ControllerAxis controllerAxis)
        {
            GamepadAxis axis = (GamepadAxis)controllerAxis;
            float value = Raylib.GetGamepadAxisMovement(controllerIndex, axis);
            return value;
        }

        /// <summary>
        ///     Gets the movement of mouse X between last frame and this frame.
        /// </summary>
        /// <returns>
        ///     Returns the pixel delta position X between frames.
        /// </returns>
        public static int GetMouseDeltaX() => (int)Raylib.GetMouseDelta().X;

        /// <summary>
        ///     Gets the movement of mouse Y between last frame and this frame.
        /// </summary>
        /// <returns>
        ///     Returns the pixel delta position Y between frames.
        /// </returns>
        public static int GetMouseDeltaY() => (int)Raylib.GetMouseDelta().Y;

        /// <summary>
        ///     Gets the movement of mouse between last frame and this frame.
        /// </summary>
        /// <returns>
        ///     Returns the pixel delta position between frames.
        /// </returns>
        public static Vector2 GetMouseDeltaPosition() => Raylib.GetMouseDelta();

        /// <summary>
        ///     Gets the mouse position on screen this frame.
        /// </summary>
        /// <returns>
        ///     Returns the Vector2 mouse position on screen in pixel coordinates.
        /// </returns>
        public static Vector2 GetMousePosition() => ClampedMousePositionV();

        /// <summary>
        ///     Gets the mouse X position on screen this frame.
        /// </summary>
        /// <returns>
        ///     Returns the X mouse position on screen in pixel coordinates.
        /// </returns>
        public static int GetMouseX() => (int)ClampedMousePositionX();

        /// <summary>
        ///     Gets the mouse Y position on screen this frame.
        /// </summary>
        /// <returns>
        ///     Returns the mouse Y position on screen in pixel coordinates.
        /// </returns>
        public static int GetMouseY() => (int)ClampedMousePositionY();

        /// <summary>
        ///     Gets the mouse wheel movement this frame.
        /// </summary>
        /// <returns>
        ///     Returns the Vector2 mouse wheel movement.
        /// </returns>
        public static Vector2 GetMouseWheel() => Raylib.GetMouseWheelMoveV();

        /// <summary>
        ///     Gets the mouse wheel's X movement this frame.
        /// </summary>
        /// <returns>
        ///     Returns the mouse wheel X movement.
        /// </returns>
        public static int GetMouseWheelX() => (int)Raylib.GetMouseWheelMoveV().X;

        /// <summary>
        ///     Gets the mouse wheel's Y movement this frame.
        /// </summary>
        /// <returns>
        ///     Returns the mouse wheel Y movement.
        /// </returns>
        public static int GetMouseWheelY() => (int)Raylib.GetMouseWheelMoveV().Y;

        /// <summary>
        ///     Hides mouse cursor in window.
        /// </summary>
        public static void HideMouseCursor() => Raylib.HideCursor();

        /// <summary>
        ///     Checks if <paramref name="controllerButton"/>
        ///     is down on any controller this frame.
        /// </summary>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of any controller 
        ///     is down this frame, false otherwise.
        /// </returns>
        public static bool IsAnyControllerButtonDown(ControllerButton controllerButton)
            => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonDown);

        /// <summary>
        ///     Checks if <paramref name="controllerButton"/>
        ///     was pressed on any controller this frame.
        /// </summary>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of any controller 
        ///     was pressed this frame, false otherwise.
        /// </returns>
        public static bool IsAnyControllerButtonPressed(ControllerButton controllerButton)
            => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonPressed);

        /// <summary>
        ///     Checks if <paramref name="controllerButton"/>
        ///     was released on any controller this frame.
        /// </summary>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of any controller 
        ///     was releaed this frame, false otherwise.
        /// </returns>
        public static bool IsAnyControllerButtonReleased(ControllerButton controllerButton)
            => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonReleased);

        /// <summary>
        ///     Checks if <paramref name="controllerButton"/>
        ///     is up on any controller this frame.
        /// </summary>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of any controller 
        ///     is up this frame, false otherwise.
        /// </returns>
        public static bool IsAnyControllerButtonUp(ControllerButton controllerButton)
            => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonUp);

        /// <summary>
        ///     Checks to see if controller number <paramref name="controllerIndex"/>
        ///     is connected to the host device.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check availability of.</param>
        /// <returns>
        ///     Returns true if controller is connected, false otherwise.
        /// </returns>
        public static bool IsControllerAvailable(int controllerIndex)
        {
            bool isAvailable = Raylib.IsGamepadAvailable(controllerIndex);
            return isAvailable;
        }

        /// <summary>
        ///     Checks if controller number <paramref name="controllerIndex"/>'s 
        ///     <paramref name="controllerButton"/> is down this frame.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check.</param>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of
        ///     <paramref name="controllerIndex"/> is down this frame, false otherwise.
        /// </returns>
        public static bool IsControllerButtonDown(int controllerIndex, ControllerButton controllerButton)
            => Raylib.IsGamepadButtonDown(controllerIndex, (GamepadButton)controllerButton);

        /// <summary>
        ///     Checks if controller number <paramref name="controllerIndex"/>'s 
        ///     <paramref name="controllerButton"/> was pressed this frame.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check.</param>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of
        ///     <paramref name="controllerIndex"/> was pressed this frame, false otherwise.
        /// </returns>
        public static bool IsControllerButtonPressed(int controllerIndex, ControllerButton controllerButton)
            => Raylib.IsGamepadButtonPressed(controllerIndex, (GamepadButton)controllerButton);

        /// <summary>
        ///     Checks if controller number <paramref name="controllerIndex"/>'s 
        ///     <paramref name="controllerButton"/> was released this frame.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check.</param>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of
        ///     <paramref name="controllerIndex"/> was released this frame, false otherwise.
        /// </returns>
        public static bool IsControllerButtonReleased(int controllerIndex, ControllerButton controllerButton)
            => Raylib.IsGamepadButtonReleased(controllerIndex, (GamepadButton)controllerButton);

        /// <summary>
        ///     Checks if controller number <paramref name="controllerIndex"/>'s 
        ///     <paramref name="controllerButton"/> is up this frame.
        /// </summary>
        /// <param name="controllerIndex">Which controller to check.</param>
        /// <param name="controllerButton">The controller button to check.</param>
        /// <returns>
        ///     Returns true if <paramref name="controllerButton"/> of
        ///     <paramref name="controllerIndex"/> is up this frame, false otherwise.
        /// </returns>
        public static bool IsControllerButtonUp(int controllerIndex, ControllerButton controllerButton)
            => Raylib.IsGamepadButtonUp(controllerIndex, (GamepadButton)controllerButton);

        /// <summary>
        ///     Checks if keyboard key is down this frame.
        /// </summary>
        /// <param name="key">The keyboard key to check.</param>
        /// <returns>
        ///     Returns true if key is down this frame, false otherwise.
        /// </returns>
        public static bool IsKeyboardKeyDown(KeyboardKey key) => Raylib.IsKeyDown((Raylib_cs.KeyboardKey)key);

        /// <summary>
        ///     Checks if keyboard key was pressed this frame.
        /// </summary>
        /// <param name="key">The keyboard key to check.</param>
        /// <returns>
        ///     Returns true if key was pressed this frame, false otherwise.
        /// </returns>
        public static bool IsKeyboardKeyPressed(KeyboardKey key) => Raylib.IsKeyPressed((Raylib_cs.KeyboardKey)key);

        /// <summary>
        ///     Checks if keyboard key was released this frame.
        /// </summary>
        /// <param name="key">The keyboard key to check.</param>
        /// <returns>
        ///     Returns true if key was released this frame, false otherwise.
        /// </returns>
        public static bool IsKeyboardKeyReleased(KeyboardKey key) => Raylib.IsKeyReleased((Raylib_cs.KeyboardKey)key);

        /// <summary>
        ///     Checks if keyboard key is up this frame.
        /// </summary>
        /// <param name="key">The keyboard key to check.</param>
        /// <returns>
        ///     Returns true if key is up this frame, false otherwise.
        /// </returns>
        public static bool IsKeyboardKeyUp(KeyboardKey key) => Raylib.IsKeyUp((Raylib_cs.KeyboardKey)key);

        /// <summary>
        ///     Checks if mouse button is down this frame.
        /// </summary>
        /// <param name="button">The mouse button to check.</param>
        /// <returns>
        ///     Returns true if mouse button is down this frame, false otherwise.
        /// </returns>
        public static bool IsMouseButtonDown(MouseButton button) => Raylib.IsMouseButtonDown((Raylib_cs.MouseButton)button);

        /// <summary>
        ///     Checks if mouse button was pressed this frame.
        /// </summary>
        /// <param name="button">The mouse button to check.</param>
        /// <returns>
        ///     Returns true if mouse button was pressed this frame, false otherwise.
        /// </returns>
        public static bool IsMouseButtonPressed(MouseButton button) => Raylib.IsMouseButtonPressed((Raylib_cs.MouseButton)button);

        /// <summary>
        ///     Checks if mouse button was released this frame.
        /// </summary>
        /// <param name="button">The mouse button to check.</param>
        /// <returns>
        ///     Returns true if mouse button was released this frame, false otherwise.
        /// </returns>
        public static bool IsMouseButtonReleased(MouseButton button) => Raylib.IsMouseButtonReleased((Raylib_cs.MouseButton)button);

        /// <summary>
        ///     Checks if mouse button is up this frame.
        /// </summary>
        /// <param name="button">The mouse button to check.</param>
        /// <returns>
        ///     Returns true if mouse button is up this frame, false otherwise.
        /// </returns>
        public static bool IsMouseButtonUp(MouseButton button) => Raylib.IsMouseButtonUp((Raylib_cs.MouseButton)button);

        /// <summary>
        ///     Check if the mouse is hidden.
        /// </summary>
        /// <returns>
        ///     Returns true if mouse is hidden, false otherwise.
        /// </returns>
        public static bool IsMouseCursorHidden() => Raylib.IsCursorHidden();

        /// <summary>
        ///     Checks if the mouse is inside the window.
        /// </summary>
        /// <returns>
        ///     Returns true if mouse is inside the window, false otherwise.
        /// </returns>
        public static bool IsMouseCursorOnScreen() => Raylib.IsCursorOnScreen();

        /// <summary>
        ///     Shows mouse cursor in window.
        /// </summary>
        public static void ShowMouseCursor() => Raylib.ShowCursor();

        #endregion

        #region Private Methods

        private delegate CBool RaylibGamepadButtonFunc(int controllerIndex, GamepadButton controllerButton);

        private static bool IsAnyControllerButtonXXX(ControllerButton controllerButton, RaylibGamepadButtonFunc gamepadFunc)
        {
            int controllerCount = GetConnectedControllerCount();
            for (int i = 0; i < controllerCount; i++)
            {
                GamepadButton button = (GamepadButton)controllerButton;
                bool isTriggered = gamepadFunc(i, button);
                if (isTriggered)
                    return true;
            }
            return false;
        }

        private static float ClampedMousePosition(float position, float max)
        {
            position = Math.Clamp(position, 0, max);
            return position;
        }
        private static float ClampedMousePositionX() => ClampedMousePosition(Raylib.GetMouseX(), Window.Width);
        private static float ClampedMousePositionY() => ClampedMousePosition(Raylib.GetMouseY(), Window.Height);
        private static Vector2 ClampedMousePositionV()
        {
            Vector2 mousePosition = new()
            {
                X = ClampedMousePositionX(),
                Y = ClampedMousePositionY(),
            };
            return mousePosition;
        }

        #endregion

    }
}
