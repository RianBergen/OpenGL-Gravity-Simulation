using System;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;



namespace OpenGL_Gravity_Simulation.Game
{
    /// <summary>
    /// Gravity Simulation Game
    /// </summary>
    class GravitySimulation : Game
    {
        /*
         * 
         * Private Variables
         * 
         */
        /// <summary>
        /// Contains the Main Shader Program
        /// </summary>
        private Rendering.ShaderProgram ShaderProgram;





        /*
         * 
         * Public Functions
         * 
         */
        public GravitySimulation()
        {
            // Initialize The Game
            this.GameClosed = !Initialize();
        }





        /*
         * 
         * Public Override Functions
         * 
         */
        public override bool Initialize()
        {
            // Error Catcher
            bool shouldGameClose = true;

            // Initialize Shaders
            ShaderProgram = new Rendering.ShaderProgram();
            shouldGameClose = ShaderProgram.LoadShaderProgram("../../../../Shaders/SimpleVertexShader.glsl", "../../../../Shaders/SimpleFragmentShader.glsl");

            return !shouldGameClose;
        }

        public override void Render()
        {
            GL.UseProgram(this.ShaderProgram.ID);
        }

        public override void Update(double deltaTime)
        {
            
        }
    }
}
