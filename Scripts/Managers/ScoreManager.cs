using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceGame {
    public class ScoreManager {

        private SpriteFont font;
        public int Score {get; set;}
        private static ScoreManager instance = null;
        public static ScoreManager Instance {
            get {
                if (instance == null) {
                    instance = new ScoreManager();
                }
                return instance;
            }
        }

        private ScoreManager() {
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            StateManager.Instance.DrawEvent += new StateManager.DrawHandler(Draw);
        }

        public void Load(ContentManager contentManager) {
            font = contentManager.Load<SpriteFont>("Score");
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, "Score: " +  Score, new Vector2(100, 100), Color.White);
        }
        
    }
}