using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace SpaceGame {
    public class Projectile {
        public Sprite Sprite {get; set;}
        public float Rotation = 0;
        public float Speed = 1;


        private StateManager stateManager = StateManager.Instance;
        private Rectangle sourceRectange; 

        private int screenW = Game1.graphics.PreferredBackBufferWidth;
        private int screenH = Game1.graphics.PreferredBackBufferHeight;

        public Projectile(Sprite sprite) {
            Sprite = sprite;
            sourceRectange = new Rectangle(0,0,Sprite.Texture.Width, Sprite.Texture.Height);

            StateManager.Instance.DrawEvent += new StateManager.DrawHandler(Draw);
            StateManager.Instance.UpdateEvent += new StateManager.UpdateHandler(Update);
            
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Sprite.Texture, Sprite.Position, sourceRectange, Color.White, Rotation,
             new Vector2(Sprite.Texture.Width/2, Sprite.Texture.Height/2), 1 , SpriteEffects.None, 1f);
        }

        public void Update(GameTime gameTime) {
             
            Move();
            

            if(Sprite.Position.X > screenW || Sprite.Position.X < 0
            || Sprite.Position.Y > screenH || Sprite.Position.Y < 0) {
                StateManager.Instance.DrawEvent -= new StateManager.DrawHandler(Draw);
                StateManager.Instance.UpdateEvent -= new StateManager.UpdateHandler(Update);
            }

        }

        private void Move()
        {
            float positionX = Sprite.Position.X;
            float positionY = Sprite.Position.Y;
            Vector2 newPosition = new Vector2(positionX - (Speed * MathF.Sin(Rotation)), positionY + ( Speed * MathF.Cos(Rotation)));
            Sprite.Position = newPosition;
        }
    }
}