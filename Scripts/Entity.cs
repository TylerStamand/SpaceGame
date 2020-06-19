using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SpaceGame {
    public abstract class Entity {
        

        public bool isDead = false;
        public Sprite Sprite {get; set;} = new Sprite();
        public Vector2 Position {
            get {
                return Sprite.Position;
            }
            set {
                Sprite.Position = value;
            }
        }

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

        public virtual void Die() {
            isDead = true;
        }
    }
}