using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;


namespace SpaceGame {
    public class Enemy : Entity {
        public float Rotation {get; set;}
    
        public float Speed {get; set;} = 1;

        private int screenW = Game1.graphics.PreferredBackBufferWidth ;
        private int screenH = Game1.graphics.PreferredBackBufferHeight;
       
        private Rectangle sourceRectangle;
        

        public Enemy(Texture2D texture) {
            Sprite.Texture = texture;
            sourceRectangle = new Rectangle(0,0, texture.Width, texture.Height);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Sprite.Texture, Sprite.Position, sourceRectangle, Color.White, Rotation, new Vector2(Sprite.Texture.Width/2, Sprite.Texture.Height/2), 1, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime){
            if(isDead) {
                EntityManager.Instance.Entities.Remove(this);
                StateManager.Instance.LoadEvent -= new StateManager.LoadHandler(Load);
                StateManager.Instance.UpdateEvent -= new StateManager.UpdateHandler(Update);
                StateManager.Instance.DrawEvent -= new StateManager.DrawHandler(Draw);
            }
            Move();
        }


        private void Move() {
            Vector2 playerPosition = EntityManager.Instance.Player.Position;
            float differenceY = Sprite.Position.Y - playerPosition.Y;
            float differenceX = Sprite.Position.X - playerPosition.X;
            if(differenceX < 0) {
                Rotation = MathF.Atan(differenceY/differenceX) - (MathF.PI/2);
            }
            else {
                Rotation = MathF.Atan(differenceY/differenceX) + (MathF.PI/2);
            }
            
            Position = new Vector2(Position.X - (Speed * MathF.Sin(Rotation)), Position.Y + ( Speed * MathF.Cos(Rotation)));
            
        }
    }
}