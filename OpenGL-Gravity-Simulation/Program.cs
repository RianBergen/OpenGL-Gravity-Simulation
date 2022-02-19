using System;

namespace OpenGL_Gravity_Simulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Start and Run the 
            Rendering.GLWindow application = new Rendering.GLWindow("OpenGLGravity Simulation", 1280, 720, false);

            application.Run();
        }
    }
}