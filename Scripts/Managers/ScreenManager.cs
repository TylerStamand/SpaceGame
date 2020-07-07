using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SpaceGame {
    public class ScreenManager {
        public void LoadContent(ContentManager Content) {
            ContentManager content = new ContentManager(Content.ServiceProvider, "Content");
        }
        
    }
}