using System;
using System.Collections.Generic;

namespace OpenGL_Gravity_Simulation.Maths.Shapes
{
    /// <summary>
    /// Class to Define Neccessary Shape Functions
    /// </summary>
    class Shape
    {
        /// <summary>
        /// List of Vertices for OpenGL
        /// </summary>
        private List<float> _Vertices;

        /// <summary>
        /// List of Vertices for OpenGL
        /// </summary>
        public List<float> Vertices { get { return _Vertices; } set { _Vertices = value; } }

        

        /// <summary>
        /// List of Indices for OpenGL
        /// </summary>
        private List<uint> _Indices;

        /// <summary>
        /// List of Indices for OpenGL
        /// </summary>
        public List<uint> Indices { get { return _Indices; } set { _Indices = value; } }
    }
}
