using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public class Character : Entity {

        protected Health health;

        public void Damage(int damageDelt)
        {
            health.CurrentHealth -= damageDelt;
            if(health.CurrentHealth < 0 ) {
                health.CurrentHealth = 0;
            }
            if(health.CurrentHealth == 0) {
                this.Die();
            }
        }

    }
}