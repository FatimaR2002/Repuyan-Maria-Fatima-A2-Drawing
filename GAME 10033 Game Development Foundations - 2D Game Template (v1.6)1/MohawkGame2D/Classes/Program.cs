/*////////////////////////////////////////////////////////////////////////
/* Copyright (c)
/* Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
/* Game Design (374): GAME 10033 Game Development Foundations
/* Source: https://github.com/MohawkRaphaelT/game10003-2d-game-template
/*////////////////////////////////////////////////////////////////////////

using MohawkGame2D;
using Raylib_cs;
using System.Numerics;

/// <summary>
///     The main underlying program. DO NOT EDIT.
/// </summary>
[GeneratorTools.OmitFromDocumentation]
public static class Program
{
    // Framebuffer information
    private const int MaxRenderSize = 4096;
    private static readonly RenderTexture2D[] buffers = new RenderTexture2D[2];
    private const ConfigFlags WindowConfigFlags = ConfigFlags.AlwaysRunWindow | ConfigFlags.VSyncHint;

    private static void Main()
    {
        // Raylib one-time setup
        Raylib.SetConfigFlags(WindowConfigFlags);
        Raylib.InitWindow(Window.Width, Window.Height, Window.Title);
        Raylib.SetTargetFPS(Window.TargetFPS);
        Raylib.InitAudioDevice();

        // Wrapper setup
        Text.Initialize();
        // Create game instance
        Game game = new();

        // Get 2 render textures through which to draw to screen
        buffers[0] = Raylib.LoadRenderTexture(MaxRenderSize, MaxRenderSize);
        buffers[1] = Raylib.LoadRenderTexture(MaxRenderSize, MaxRenderSize);
        bool drawBuffer0 = true;
        // Capture any initial rendering in Setup
        Raylib.BeginTextureMode(buffers[0]);
        game.Setup();
        Raylib.EndTextureMode();
        // Place window in centre of monitor, if able
        Window.CentreWindow();
        // Copy frame contents to other buffer
        Raylib.BeginTextureMode(buffers[1]);
        Rectangle setupRenderArea = new(0, -MaxRenderSize, Window.Width, -Window.Height);
        Raylib.DrawTextureRec(buffers[0].Texture, setupRenderArea, Vector2.Zero, Raylib_cs.Color.White);
        Raylib.EndTextureMode();

        // Raylib & wrapper frame loop
        while (!Raylib.WindowShouldClose())
        {
            // Update music buffers every frame
            foreach (var music in Audio.LoadedMusic)
                Raylib.UpdateMusicStream(music);

            // Choose current buffer
            RenderTexture2D thisFrame = drawBuffer0 ? buffers[0] : buffers[1];
            RenderTexture2D lastFrame = drawBuffer0 ? buffers[1] : buffers[0];
            Rectangle renderArea = new(0, -Window.Height, Window.Width, -Window.Height);
            // Start frame with contents of previous frame
            Raylib.BeginTextureMode(thisFrame);
            Raylib.DrawTextureRec(lastFrame.Texture, renderArea, Vector2.Zero, Raylib_cs.Color.White);
            game.Update();
            Raylib.EndTextureMode();
            // Render to screen
            Raylib.BeginDrawing();
            Raylib.DrawTextureRec(thisFrame.Texture, renderArea, Vector2.Zero, Raylib_cs.Color.White);
            Raylib.EndDrawing();
            // Swap buffers
            drawBuffer0 = !drawBuffer0;

            // Update rendered frame count
            Time.FramesElapsed++;
        }

        // Unload assets
        foreach (var music in Audio.LoadedMusic)
            Audio.UnloadMusic(music);
        foreach (var sound in Audio.LoadedSounds)
            Audio.UnloadSound(sound);
        foreach (var font in Text.LoadedFonts)
            Text.UnloadFont(font);
        foreach (var texture in Graphics.LoadedTextures)
            Graphics.UnloadTexture(texture);
        // Other shutdown operations
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}