using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace SpaceGame {
    public class StateManager {
        private static StateManager instance = null;

        public delegate void UpdateHandler(GameTime gameTime);
        public event UpdateHandler UpdateEvent;

        private StateManager() {}

        public static StateManager Instance {
            get {
                if (instance == null) {
                    instance = new StateManager();
                }
                return instance;
            }
        }

        public void Update(GameTime gameTime) {
            UpdateEvent(gameTime);
        }
    } 
}