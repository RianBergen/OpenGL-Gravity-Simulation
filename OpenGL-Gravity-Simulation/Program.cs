using System;

namespace OpenGL_Gravity_Simulation
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // https://www.youtube.com/watch?v=X0uv8x0f70g
            // https://opentk.net/learn/chapter1/2-hello-triangle.html

            Console.WriteLine("Hello World!");
            Rendering.GLWindow application = new Rendering.GLWindow("OpenGLGravity Simulation", 1920, 1080, false);

            application.Run();
        }
    }
}
