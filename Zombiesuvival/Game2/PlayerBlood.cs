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
    class PlayerBlood : AnimatedGameObject
    {
        /// <summary>
        /// Adds blood effect when zombies walk into player
        /// </summary>
        /// <param name="size"></param>
        /// <param name="startPosition"></param>
        /// <param name="content"></param>
        /// 


        public PlayerBlood(int size, Vector2 startPosition, ContentManager content) : base(20, 60, startPosition, content, "PlayerBlood")
        {
        
        }


        /// <summary>
        /// afspillder animation i 19 frames som den er lavet og der sellet obejtet
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (currentAnimationIndex == 19)
            {
                GameWorld.RemoveGameObject(this);
            }
            base.Update(gameTime);
        }
    }
}
