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
    class Motorcyekel: GameObject
    {


        public Motorcyekel(ContentManager content, string name, int X, int Y) : base(content, name)
        {

            position = new Vector2(X, Y);
        }
        public Motorcyekel(ContentManager content, string name, int X, int Y, float Rotation) : base(content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }

        public override void Update(GameTime gameTime)
        {

        }
        /// <summary>
        /// Tjekker om playern klar til næsten lvl ved tage motocykeln
        /// </summary>
        /// <param name="otherObject"></param>
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Player && Player.HaveGas == true&& Player.KilledBoss == true)
            {
                GameWorld.levels = 3;
            }
        }
    }
}
