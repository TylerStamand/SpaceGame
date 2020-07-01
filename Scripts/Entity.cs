using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SpaceGame {
    public abstract class Entity {
        
        public Vector2 UR = new Vector2(), 
                UL = new Vector2(), 
                LR = new Vector2(), 
                LL = new Vector2(),
                Center = new Vector2();
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

        public float Rotation {
            get {
                return Sprite.Rotation;
            }
            set {
                Sprite.Rotation = value;
            }
        }

        public Entity() {
            EntityManager.Instance.Entities.Add(this);
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            StateManager.Instance.UpdateEvent += new StateManager.UpdateHandler(Update);
            StateManager.Instance.DrawEvent += new StateManager.DrawHandler(Draw);
        }
        public virtual void Load(ContentManager contentManager) {
            
        }
        public virtual void Update(GameTime gameTime) {
               if(isDead) {
                EntityManager.Instance.Entities.Remove(this);
                StateManager.Instance.LoadEvent -= new StateManager.LoadHandler(Load);
                StateManager.Instance.UpdateEvent -= new StateManager.UpdateHandler(Update);
                StateManager.Instance.DrawEvent -= new StateManager.DrawHandler(Draw);
                
            }
       
            updatePositions();
        }
        public virtual void Draw(SpriteBatch spriteBatch) {
           
        }

        public virtual void Die() {
            
            isDead = true;
        }

        protected void updatePositions() {
            Center = new Vector2(Position.X + Sprite.Width/2, Position.Y + Sprite.Height/2);
             LL = new Vector2(
                Center.X - (MathF.Cos(Rotation) * 25) - (MathF.Sin(Rotation) * 25), 
                Center.Y - (MathF.Sin(Rotation) * 25) + (MathF.Cos(Rotation) * 25)
            );

            LR = new Vector2(
                Center.X + (MathF.Cos(Rotation) * 25) - (MathF.Sin(Rotation) * 25), 
                Center.Y + (MathF.Sin(Rotation) * 25) + (MathF.Cos(Rotation) * 25)
            );
            
            UL = new Vector2(
                Center.X - (MathF.Cos(Rotation) * 25) + (MathF.Sin(Rotation) * 25), 
                Center.Y - (MathF.Sin(Rotation) * 25) - (MathF.Cos(Rotation) * 25)
            );

            UR = new Vector2(
                Center.X + (MathF.Cos(Rotation) * 25) + (MathF.Sin(Rotation) * 25), 
                Center.Y + (MathF.Sin(Rotation) * 25) - (MathF.Cos(Rotation) * 25)
            );
        }

        protected void DrawDebugDots(SpriteBatch spriteBatch) {
            Rectangle sourceRectangle = new Rectangle(0,0, 32,32);
            spriteBatch.Draw(EntityManager.Instance.Dot, new Vector2(LL.X - 16, LL.Y - 16), sourceRectangle, Color.White, Rotation, new Vector2(16, 16), 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(EntityManager.Instance.Dot, new Vector2(LR.X - 32, LR.Y -32), Color.White);
            spriteBatch.Draw(EntityManager.Instance.Dot, new Vector2(UL.X - 32, UL.Y -32), Color.White);
            spriteBatch.Draw(EntityManager.Instance.Dot, new Vector2(UR.X - 32, UR.Y -32), Color.White);
        }
    }
}