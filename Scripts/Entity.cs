using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SpaceGame {
    public abstract class Entity {

        public Entity() {
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            StateManager.Instance.UpdateEvent += new StateManager.UpdateHandler(Update);
            StateManager.Instance.DrawEvent += new StateManager.DrawHandler(Draw);
        }
        public virtual void Load(ContentManager contentManager) {
            
        }
        public virtual void Update(GameTime gameTime) {
            
        }
        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}