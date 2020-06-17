using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace SpaceGame {
    public class StateManager {
        private static StateManager instance = null;

        public delegate void LoadHandler(ContentManager content);
        public delegate void UpdateHandler(GameTime gameTime);
        public delegate void DrawHandler(SpriteBatch spriteBatch);
        public event UpdateHandler UpdateEvent;
        public event LoadHandler LoadEvent;
        public event DrawHandler DrawEvent;

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
        
        public void Load(ContentManager content) {
            LoadEvent(content);
        }

        public void Draw(SpriteBatch spriteBatch) {
            DrawEvent(spriteBatch);
        }
    } 
}