
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


namespace SpaceGame {
    public class EntityManager {
        
        private Texture2D playerTexture;
        private Texture2D enemyTexture;
        private Random rand = new Random();
        private int screenW = Game1.graphics.PreferredBackBufferWidth;
        private int screenH = Game1.graphics.PreferredBackBufferHeight;
        private float timeSinceLastEnemy = 0;

        public Player Player;
        private EntityManager() {
            Player = new Player("ship", new Vector2(240,240), 3, MathHelper.ToRadians(180), .1f);

            
    
        }
        private static EntityManager instance = null;
        public static EntityManager Instance {
            get {
                if (instance == null) {
                    instance = new EntityManager();
                }
                return instance;
            }
        }
        public void Load(ContentManager contentManager) {
            playerTexture = contentManager.Load<Texture2D>("ship");
            enemyTexture = contentManager.Load<Texture2D>("ship");
           
        }

        public void Update(GameTime gameTime) {
            if(gameTime.TotalGameTime.Seconds - timeSinceLastEnemy > 5) {
                SpawnEnemy();
                timeSinceLastEnemy = gameTime.TotalGameTime.Seconds;
            }
        }

        public void SpawnEnemy() {
            Enemy enemy = new Enemy(enemyTexture);
            enemy.Position = new Vector2(rand.Next(screenW + 1), rand.Next(screenH + 1));

        }
    }
}