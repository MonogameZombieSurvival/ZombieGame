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
    class NoTwalkerbelObejt:AnimatedGameObject
    {


        public NoTwalkerbelObejt(ContentManager content) : base(1, 5, content, "Tileset")
        {
            position = new Vector2(200, 200);
        }

        public NoTwalkerbelObejt(ContentManager content, string name, int X, int Y) : base(1, 5, content, name)
        {

            position = new Vector2(X, Y);
        }
        public NoTwalkerbelObejt(ContentManager content, string name, int X, int Y, float Rotation) : base(1, 5, content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void DoCollision(GameObject otherObject)
        {






        }
    }
}
