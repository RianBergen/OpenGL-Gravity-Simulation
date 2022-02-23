using System;
using System.Collections.Generic;

namespace OpenGL_Gravity_Simulation.Maths.Shapes
{
    class Triangle : Shape
    {
        public Triangle()
        {
            this.Vertices = new List<float> {   -0.5f, -0.5f, 0.0f,   // Bottom Left
                                                 0.5f, -0.5f, 0.0f,   // Bottom Right
                                                 0.0f,  0.5f, 0.0f }; // Top Middle
            this.Indices = new List<uint> { 1, 2, 3 };
        }
    }
}
