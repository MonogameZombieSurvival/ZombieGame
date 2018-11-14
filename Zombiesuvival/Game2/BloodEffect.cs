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
    class BloodEffect:AnimatedGameObject
    {
        /// <summary>
        /// Adds blood effect when zombies die
        /// </summary>
        /// <param name="size"></param>
        /// <param name="startPosition"></param>
        /// <param name="content"></param>
        public BloodEffect(int size, Vector2 startPosition, ContentManager content) : base(16, 44, startPosition, content, "kisspngbloode")
        {
           
        }
        public override void Update(GameTime gameTime)
        {
            if(currentAnimationIndex == 15)
            {
                GameWorld.RemoveGameObject(this);
            }
            base.Update(gameTime);
        }
    }
}
