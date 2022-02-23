using System;
using System.Collections.Generic;

namespace OpenGL_Gravity_Simulation.Maths.Shapes
{
    class Square : Shape
    {
        public Square()
        {
            this.Vertices = new List<float> {    0.5f,  0.5f, 0.0f,   // Top Right
                                                 0.5f, -0.5f, 0.0f,   // Bottom Right
                                                -0.5f, -0.5f, 0.0f,   // Bottom Left
                                                -0.5f,  0.5f, 0.0f }; // Top Left
            this.Indices = new List<uint> { 0, 1, 3,   // First Triangle
                                            1, 2, 3 }; // Second Triangle
        }
    }
}
