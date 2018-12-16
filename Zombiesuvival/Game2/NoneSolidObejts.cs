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
    class NoneSolidObejts: AnimatedGameObject
    {


      public static string Tag;


        public NoneSolidObejts(ContentManager content, string name, int X, int Y) : base(1, 5, content, name)
        {

            position = new Vector2(X, Y);
        }

        public NoneSolidObejts(ContentManager content, string name, int X, int Y,string tag) : base(1, 5, content, name)
        {
            Tag = tag;

            position = new Vector2(X, Y);
        }
        public NoneSolidObejts(ContentManager content, string name, int X, int Y, string tag, float Rotation) : base(1, 5, content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }


    }
}
