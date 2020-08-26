using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public class Character : Entity {

        protected Health health;

        public Character(int healthPoints) {
            health = new Health(healthPoints);
        } 

        public override void  Draw(SpriteBatch spriteBatch){
            base.Draw(spriteBatch);
            
            health.DrawHealth(spriteBatch, Position);
        }

        public void Damage(int damageDelt)
        {
            health.CurrentHealth -= damageDelt;
            if(health.CurrentHealth < 0 ) {
                health.CurrentHealth = 0;
            }
            if(health.CurrentHealth == 0) {
                this.Destroy();
            }
        }

    }
}