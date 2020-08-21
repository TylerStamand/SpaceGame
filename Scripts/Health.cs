using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace SpaceGame {
    public class Health {
        private const int HEIGHTABOVECHARACTER = 40;
        private const string TEXTURENAME = "Heart";

        private Texture2D texture;
        public int CurrentHealth {get; set;}
        public int MaxHealth {get;set;}
        

        public Health(int maxHealth) {

            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            texture = AssetManager.Instance.Assets[TEXTURENAME];

          
        }
        
        public void DrawHealth(SpriteBatch spriteBatch, Vector2 position)
        
        {
            int heartValue = MaxHealth / 4;
            int numberOfHearts = CurrentHealth / heartValue;
            for(float i = 0; i < numberOfHearts; i++) {
                Vector2 heartPosition = position;
                heartPosition.Y -= HEIGHTABOVECHARACTER;
                heartPosition.X += -2* texture.Width + (texture.Width * i);
                spriteBatch.Draw(texture, heartPosition, Color.White);
            }
        }
    }
}