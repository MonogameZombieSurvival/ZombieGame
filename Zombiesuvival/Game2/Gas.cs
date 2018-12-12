using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Gas : GameObject
    {
        public Gas(ContentManager content) : base(content, "Tileset")
        {
            position = new Vector2(200, 200);

        }
        public Gas(ContentManager content, string name, int X, int Y) : base(content, name)
        {

            position = new Vector2(X, Y);
        }
        public Gas(ContentManager content, string name, int X, int Y, float Rotation) : base(content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }

        public override void Update(GameTime gameTime)
        {

        }
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                GameWorld.RemoveGameObject(this);
            }
        }
    }
}