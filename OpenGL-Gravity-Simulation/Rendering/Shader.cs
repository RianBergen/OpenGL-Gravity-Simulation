using System;
using System.IO;

using OpenTK.Graphics.OpenGL4;



namespace OpenGL_Gravity_Simulation.Rendering
{
    /// <summary>
    /// Individual OpenGL Shader COntainer
    /// </summary>
    public struct Shader
    {
        /*
         * 
         * Private Variables
         * 
         */
        /// <summary>
        /// Stores The OpenGL Shader Handler ID
        /// </summary>
        private int ID;





        /*
         * 
         * Public Functions
         * 
         */
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="id">Sets ID At Start, Default 0</param>
        public Shader(int id = 0)
        {
            this.ID = id;
        }

        /// <summary>
        /// Loads Shader from File
        /// </summary>
        /// <param name="shaderLocation">File Location</param>
        /// <param name="shaderType">OpenGL ShaderType</param>
        /// <returns>False If Failed, True If Successful</returns>
        public bool LoadShader(string shaderLocation, ShaderType shaderType)
        {
            // Check if File Exists
            if (File.Exists(shaderLocation))
            {
                // Read Text
                string source = File.ReadAllText(shaderLocation);

                // Create Shader
                this.ID = GL.CreateShader(shaderType);

                GL.ShaderSource(this.ID, source);
                GL.CompileShader(this.ID);

                // Check Info Log
                string infoLog = GL.GetShaderInfoLog(this.ID);

                if (string.IsNullOrEmpty(infoLog))
                {
                    // Shader Creation Successful
                    Console.WriteLine("Load Shader Success: " + this.ID.ToString());
                    Console.WriteLine("Source Code:");
                    Console.WriteLine(source);
                    Console.WriteLine("---------------------------------------------------------------------------");

                    return true;
                }

                // Shader Creation Failed
                Console.WriteLine("Load Shader Error: " + infoLog);
                Console.WriteLine("Source Code:");
                Console.WriteLine(source);
            }
            else
                Console.WriteLine("Load Shader Error: File Location Does Not Exist '" + shaderLocation + "'");

            Console.WriteLine("---------------------------------------------------------------------------");

            // Failed To Create Shader
            return false;
        }

        /// <summary>
        /// Returns OpenGL Shader Handler as Integer
        /// </summary>
        /// <returns>OpenGL Shader Handler as Integer</returns>
        public int GetID()
        {
            return this.ID;
        }
    }




    /// <summary>
    /// A Collection of Individual Shaders For The OpenGL Shader Program
    /// </summary>
    public struct ShaderProgram
    {
        /*
         * 
         * Private Variables
         * 
         */
        /// <summary>
        /// Stores the OpenGL Shader Program Handler ID
        /// </summary>
        private int ID;





        /*
         * 
         * Public Functions
         * 
         */
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="id">Sets ID At Start, Default 0</param>
        public ShaderProgram(int id = 0)
        {
            this.ID = id;
        }

        /// <summary>
        /// Loads All Required Shaders from their File Locations and then Creates the Shader Program
        /// </summary>
        /// <param name="vertexShaderLocation">Vertex Shader File Location</param>
        /// <param name="fragmentShaderLocation">Fragment Shader File Location</param>
        /// <returns>Flase If Failed, True If Successful</returns>
        public bool LoadShaderProgram(string vertexShaderLocation, string fragmentShaderLocation)
        {
            // Create Individual Shaders
            Shader vertexShader = new Shader();
            Shader fragmentShader = new Shader();

            if(vertexShader.LoadShader(vertexShaderLocation, ShaderType.VertexShader) && fragmentShader.LoadShader(fragmentShaderLocation, ShaderType.FragmentShader))
            {
                // Attach and Link Shaders To Shader Program
                this.ID = GL.CreateProgram();

                GL.AttachShader(this.ID, vertexShader.GetID());
                GL.AttachShader(this.ID, fragmentShader.GetID());

                GL.LinkProgram(this.ID);

                // Detach And Delete Used Shaders
                GL.DetachShader(this.ID, vertexShader.GetID());
                GL.DetachShader(this.ID, fragmentShader.GetID());

                GL.DeleteShader(vertexShader.GetID());
                GL.DeleteShader(fragmentShader.GetID());

                // Check Info Log
                string infoLog = GL.GetProgramInfoLog(this.ID);

                if (string.IsNullOrEmpty(infoLog))
                {
                    // Shader Program Creation Successful
                    Console.WriteLine("Create Shader Program Success: " + this.ID.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------");

                    return true;
                }

                // Shader Program Creation Failure
                Console.WriteLine("Create Shader Program Error: " + infoLog);
            }
            else
                Console.WriteLine("Create Shader Program Error: Shaders Loaded Incorrectly!");

            Console.WriteLine("---------------------------------------------------------------------------");

            // Shader Program Failed To Create
            return false;
        }

        /// <summary>
        /// Returns The Shader Program Handler ID
        /// </summary>
        /// <returns>The Shader Program Handler ID</returns>
        public int GetID()
        {
            return ID;
        }
    }
}