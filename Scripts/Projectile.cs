using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace SpaceGame {
    public class Projectile : Entity {

       
        public float Speed = 1;

        private Rectangle sourceRectange; 

        private int screenW = Game1.graphics.PreferredBackBufferWidth;
        private int screenH = Game1.graphics.PreferredBackBufferHeight;

        public Projectile(Sprite sprite) {
            Sprite = sprite;
            sourceRectange = new Rectangle(0,0,Sprite.Texture.Width, Sprite.Texture.Height);
        }

        public override void Load(ContentManager contentManager) {
            
        }
        public override void Draw(SpriteBatch spriteBatch) {
           
            spriteBatch.Draw(Sprite.Texture, Sprite.Position, sourceRectange, Sprite.Color, Rotation,
            new Vector2(Sprite.Texture.Width/2, Sprite.Texture.Height/2), 1 , SpriteEffects.None, 1f);

            
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            
            Move();
            CheckCollision();

        }

        private void Move()
        {
            float positionX = Sprite.Position.X;
            float positionY = Sprite.Position.Y;
            Vector2 newPosition = new Vector2(positionX - (Speed * MathF.Sin(Rotation)), positionY + ( Speed * MathF.Cos(Rotation)));
            Sprite.Position = newPosition;
            if(newPosition.X > screenW || newPosition.X < 0 || newPosition.Y > screenH || newPosition.Y < 0) {
                Destroy();
            }
        }

        private void CheckCollision() {
            

            foreach(Entity entity in EntityManager.Instance.Entities.OfType<Enemy>()) {
                
                if(entity.isDestroyed) {
                    continue;
                }

                if(Collision.CheckCollision(this, entity)) {
                    if(entity is Character) {
                        Character character = (Character)entity;
                        character.Damage(25);
                    }
                    this.Destroy();
                    ScoreManager.Instance.Score += 1;
                }

            }
        } 


       

    }
}
