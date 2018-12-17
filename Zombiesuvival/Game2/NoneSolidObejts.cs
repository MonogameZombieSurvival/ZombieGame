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
    class NoneSolidObejts: AnimatedGameObject
    {


      public static string Tag;
        ContentManager Content;

        public NoneSolidObejts(ContentManager content, string name, int X, int Y) : base(1, 5, content, name)
        {
            Content = content;
            position = new Vector2(X, Y);
        }

        public NoneSolidObejts(ContentManager content, string name, int X, int Y,string tag) : base(1, 5, content, name)
        {
            Tag = tag;
            Content = content;
            position = new Vector2(X, Y);
        }
        public NoneSolidObejts(ContentManager content, string name, int X, int Y, string tag, float Rotation) : base(1, 5, content, name)
        {
            rotation = Rotation;
            position = new Vector2(X, Y);
        }
     override   public void Update(GameTime gameTime)
        {

            base.Update(gameTime);

        }

        public override void DoCollision(GameObject otherObject)
        {
            MouseState mouse = Mouse.GetState();

            if (otherObject is sighte && Tag == "TeakstBox" && mouse.LeftButton == ButtonState.Pressed)
            {
                GameWorld.GameEnding1 = true;
                Blood blood = new Blood(Position, Content);
                BloodEffect bloodEffect = new BloodEffect(1, position, Content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
                GameWorld.cutScenemanager = 1;
            }
            if (otherObject is sighte && Tag == "TeakstBox2" && mouse.LeftButton == ButtonState.Pressed)
            {
                GameWorld.GameEnding2 = true;

                GameWorld.cutScenemanager = 1;

                Blood blood = new Blood(Position, Content);
                BloodEffect bloodEffect = new BloodEffect(1, position, Content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
            }
        }
    }
}
