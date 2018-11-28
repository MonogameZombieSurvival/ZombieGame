﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class Solid: AnimatedGameObject
    {
        /// <summary>
        /// Adds blood effect when zombies die
        /// </summary>
        /// <param name="size"></param>
        /// <param name="startPosition"></param>
        /// <param name="content"></param>
        /// 


        public Solid(ContentManager content) : base(1, 5, content, "Tileset")
        {
            position = new Vector2(200, 200);
        }

        public Solid(ContentManager content, string name,int X,int Y) : base(1, 5, content, name)
        {
            
            position = new Vector2(X, Y);
        }
        public Solid(ContentManager content, string name, int X, int Y, float Rotation) : base(1, 5, content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }

        public override void Update(GameTime gameTime)
        {
        
        }

      

    }
}
