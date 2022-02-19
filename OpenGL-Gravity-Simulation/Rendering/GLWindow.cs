using System;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;



namespace OpenGL_Gravity_Simulation.Rendering
{
    /// <summary>
    /// OpenGL Window Class
    /// </summary>
    public class GLWindow
    {
        /*
         * 
         * Private Variables
         * 
         */

        /// <summary>
        /// Container for OpenTK Window
        /// </summary>
        private GameWindow GLGameWindow;

        /// <summary>
        /// Window Title
        /// </summary>
        private string Title;

        /// <summary>
        /// Window Width
        /// </summary>
        private int Width;

        /// <summary>
        /// Window Height
        /// </summary>
        private int Height;

        // TO DO: Move this to Game
        private ShaderProgram shaderProgram;



        /*
         * 
         * Public Functions
         * 
         */

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="title">Window Title</param>
        /// <param name="width">Window Width</param>
        /// <param name="height">Window Height</param>
        /// <param name="macOSCompatible">OpenGL 4.1 if True, OpenGL 4.6 if False</param>
        public GLWindow(string title, int width, int height, bool macOSCompatible)
        {
            // Save Variables
            if (title == "")
                title = "OpenGL Window";
            if (width == 0)
                width = 1280;
            if (height == 0)
                height = 720;

            this.Title = title;
            this.Width = Math.Abs(width);
            this.Height = Math.Abs(height);

            // Load OpenTK Default Window Settings For A Baseline
            GameWindowSettings gws = GameWindowSettings.Default;
            NativeWindowSettings nws = NativeWindowSettings.Default;

            // Override Defaults
            gws.RenderFrequency = 60; // 60 Frames Per Second
            gws.UpdateFrequency = 60; // 60 Updated Per Second

            if (macOSCompatible)
                nws.APIVersion = Version.Parse("4.1");
            else
                nws.APIVersion = Version.Parse("4.6");

            nws.Size = new Vector2i(this.Width, this.Height);
            nws.Title = this.Title;

            // Create Game Window
            this.GLGameWindow = new GameWindow(gws, nws);

            // Setup Event Callbacks
            this.GLGameWindow.Load += () => { this.OnLoad(); }; // Load Window Callback
            this.GLGameWindow.UpdateFrame += (FrameEventArgs e) => { this.UpdateFrame(e); }; // Update Frame Callback
            this.GLGameWindow.RenderFrame += (FrameEventArgs e) => { this.RenderFrame(e); }; // Render Frame Callback
            this.GLGameWindow.Resize += (ResizeEventArgs e) => { this.ResizeViewport(e); }; // Resize Viewport Callback

            // Print Information
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Graphics Details:");
            Console.WriteLine("     Vendor:         " + GL.GetString(StringName.Vendor));
            Console.WriteLine("     Graphics Card:  " + GL.GetString(StringName.Renderer));
            Console.WriteLine("     OpenGL Version: " + GL.GetString(StringName.Version));
            Console.WriteLine("     Shader Version: " + GL.GetString(StringName.ShadingLanguageVersion));
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        ~GLWindow()
        {
            // Dispose of Window Object
            this.GLGameWindow.Dispose();
        }

        /// <summary>
        /// Displays the Window and Starts the Game Loop
        /// </summary>
        public void Run()
        {
            // Run The Game
            this.GLGameWindow.Run();
        }

        /// <summary>
        /// Gets Called Before Window Is Displayed, and After OpenGL Has Been Loaded
        /// </summary>
        private void OnLoad()
        {
            // Set GL Clear Color
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            // TO DO: Move this to Game
            shaderProgram = new ShaderProgram();
            shaderProgram.LoadShaderProgram("../../../../Shaders/SimpleVertexShader.glsl", "../../../../Shaders/SimpleFragmentShader.glsl");

            // Load Any Assets

        }

        /// <summary>
        /// This Gets Called Once Per Update Cyle
        /// </summary>
        /// <param name="e">Provided By OpenTK</param>
        private void UpdateFrame(FrameEventArgs e)
        {
            // Update Logic

        }

        /// <summary>
        /// This Gets Called Once Per Render Cycle
        /// </summary>
        /// <param name="e">Provided By OpenTK</param>
        private void RenderFrame(FrameEventArgs e)
        {
            // Clear Buffer
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Draw
            GL.UseProgram(this.shaderProgram.GetID());



            // Swap Buffer
            this.GLGameWindow.SwapBuffers();
        }

        /// <summary>
        /// This Gets Called When The User Resizes The Window
        /// </summary>
        /// <param name="e">Provided By OpenTK</param>
        private void ResizeViewport(ResizeEventArgs e)
        {
            // Set GL Viewport
            this.Width = e.Width;
            this.Height = e.Height;

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}