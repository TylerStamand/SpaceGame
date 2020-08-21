using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceGame {
    public class AssetManager {
        public Dictionary<String, Texture2D> Assets;
        private static AssetManager instance = null;
        public static AssetManager Instance {
            get {
                if (instance == null) {
                    instance = new AssetManager();
                }
                return instance;
            }
        }

        private AssetManager() {
            StateManager.Instance.LoadEvent += new StateManager.LoadHandler(Load);
            Assets = new Dictionary<string, Texture2D>();
        }

        private void Load(ContentManager contentManager){
            Assets.Add("ship", contentManager.Load<Texture2D>("ship"));
            Assets.Add("laser", contentManager.Load<Texture2D>("laser"));
            Assets.Add("dot", contentManager.Load<Texture2D>("dot"));
            Assets.Add("line", contentManager.Load<Texture2D>("line"));
            Assets.Add("Heart", contentManager.Load<Texture2D>("Heart"));
           
        }


    }
}