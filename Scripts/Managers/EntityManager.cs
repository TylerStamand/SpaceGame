
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


namespace SpaceGame {
    public class EntityManager {
        
        public Player Player;
        public List<Entity> Entities;

        public int EnemySpawnRateSeconds {get; set;} = 1;

        public Texture2D Dot;
        public Texture2D Line;
        private Texture2D playerTexture;
        private Texture2D enemyTexture;
        private Random rand = new Random();
        private int screenW = Game1.graphics.PreferredBackBufferWidth;
        private int screenH = Game1.graphics.PreferredBackBufferHeight;
        private double timeSinceLastEnemy = 0;
        private EntityManager() {
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            StateManager.Instance.UpdateEvent += new StateManager.UpdateHandler(Update);
            Entities = new List<Entity>();
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
            playerTexture = 
            enemyTexture = contentManager.Load<Texture2D>("ship");
            contentManager.Load<Texture2D>("laser");
            Dot = contentManager.Load<Texture2D>("dot");
            Line = contentManager.Load<Texture2D>("line");

            //Player initialization is put here in order to avoid looping. Attemps to use entitymanager while it is initializing
            Player = new Player("ship", new Vector2(240,240), 3, MathHelper.ToRadians(180), .1f);
        }

        public void Update(GameTime gameTime) {
            if(gameTime.TotalGameTime.TotalSeconds - timeSinceLastEnemy > EnemySpawnRateSeconds) {
                SpawnEnemy();
                timeSinceLastEnemy = gameTime.TotalGameTime.TotalSeconds;
            }
    
        }

        public void SpawnEnemy() {
            
            Enemy enemy = new Enemy(enemyTexture);
            enemy.Position = new Vector2(rand.Next(screenW + 1), rand.Next(screenH + 1));
            EntityManager.Instance.Entities.Add(enemy);
        }
    }
}