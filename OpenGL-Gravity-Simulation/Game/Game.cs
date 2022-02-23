using System;

namespace OpenGL_Gravity_Simulation.Game
{
    /// <summary>
    /// Abstract Class to Define Neccessary Game Functions
    /// </summary>
    abstract class Game
    {
        /*
         * 
         * Priave Variables
         * 
         */
        /// <summary>
        /// True = Game Must Close, False = Game Must Stay Open
        /// </summary>
        private bool _GameClosed;

        /// <summary>
        /// True = Game Must Close, False = Game Must Stay Open
        /// </summary>
        public bool GameClosed { get { return _GameClosed; } protected set { _GameClosed = value; } }





        /*
         * 
         * Abstract Functions
         * 
         */
        public abstract bool Initialize();
        public abstract void Update(double deltaTime);
        public abstract void Render();
    }
}
