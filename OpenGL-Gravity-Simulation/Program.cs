using System;

namespace OpenGL_Gravity_Simulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Start and Run the 
            Rendering.OpenGLWindow application = new Rendering.OpenGLWindow("OpenGLGravity Simulation", 1280, 720, false);

            application.Run();
        }
    }
}