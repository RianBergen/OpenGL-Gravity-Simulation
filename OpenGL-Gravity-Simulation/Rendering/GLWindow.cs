using System;

using OpenTK;
using OpenTK.Mathematics;
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
        private GameWindow GameWindow;

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
            this.GameWindow = new GameWindow(gws, nws);
        }

        ~GLWindow()
        {
            // Dispose of Window Object
            this.GameWindow.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            // Run The Game
            this.GameWindow.Run();
        }
    }
}
