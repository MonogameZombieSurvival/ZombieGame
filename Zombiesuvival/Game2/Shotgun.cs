using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class Shotgun : GameObject
    {


        public Shotgun(ContentManager content) : base(content, "Tileset")
        {
            position = new Vector2(200, 200);

        }

        public Shotgun(ContentManager content, string name, int X, int Y) : base(content, name)
        {

            position = new Vector2(X, Y);
        }
        public Shotgun(ContentManager content, string name, int X, int Y, float Rotation) : base(content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player)
            {
                GameWorld.RemoveGameObject(this);
            }
        }
    }
}
