using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    /// <summary>
    /// Class that represents a boss
    /// </summary>
    class Boss : Enemy
    {
        /// <summary>
        /// Sets the boss stats
        /// </summary>
        float moveSpeed = 70;
        Random rand = new Random();
        Vector2 distance;
        private int holdNumber;
        private int damnge = 200;
        private double LastAttck = 0;
        private int bosshealth = 4;



        public Boss(ContentManager content,int x,int y) : base(content, "bosszombie", x, y, 1, 1)
        {

        }

        /// <summary>
        /// Sets the direction of the boss in direction of the player
        /// </summary>
        /// 
  
 
        /// <summary>
        /// Collide actions if bullet zombies die and boss loses health. If bullet it gets removed and if player it gets damage.
        /// </summary>
        /// <param name="otherObject">The object it collided with</param>
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Bullet)
            {
                Blood blood = new Blood( Position, content);
                BloodEffect bloodEffect = new BloodEffect(1, position, content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
                bosshealth --;
                if (bosshealth == 0) {
                    Player.KilledBoss = true;
                    GameWorld.RemoveGameObject(this);
                    GameWorld.addKill();
                }
            }

            if (otherObject is Player && LastAttck > 0.5f)
            {
                PlayerBlood playerBlood = new PlayerBlood(realTimeplayerPosition, content);
                GameWorld.DealDamngeToPlayer(damnge);
                GameWorld.AddGameObject(playerBlood);
                LastAttck = 0;
            }

            if (otherObject is Bullet)
            {
                GameWorld.RemoveGameObject(otherObject);
            }
        }
    }
}
