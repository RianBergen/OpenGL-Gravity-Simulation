using System;
using System.Collections.Generic;

namespace OpenGL_Gravity_Simulation.Maths.Shapes
{
    class Shape
    {
        private List<float> _Vertices;
        public List<float> Vertices { get { return _Vertices; } set { _Vertices = value; } }

        private List<uint> _Indices;
        public List<uint> Indices { get { return _Indices; } set { _Indices = value; } }
    }
}
