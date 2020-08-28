using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public class GameScreen {

        protected ContentManager content;
        public GameScreen() {
            
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            StateManager.Instance.DrawEvent += new StateManager.DrawHandler(Draw);
            StateManager.Instance.UpdateEvent += new StateManager.UpdateHandler(Update);
        }

        public virtual void Load(ContentManager contentManager) {
            content = new ContentManager(contentManager.ServiceProvider, "Content");
        }
        public virtual void Update(GameTime gameTime) {
            
        }
        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}