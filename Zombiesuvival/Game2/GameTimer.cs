using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    /// <summary>
    /// Class that represents a game time to set waves
    /// </summary>
    class GameTimer
    {
        private double GameTimerSec;
        private int WaveTimerSec;
        private int WaveTime = 0;
        private int WaveTimeOutPut;

        private float WaveTimermilisec;
        private double WaveTimeDouble ;
        /// <summary>
        /// Wave time manager loops every 30 secs
        /// </summary>
        public int gameTimerSec(GameTime gameTime, int WaveIntervale)
        {
            GameTimerSec += gameTime.ElapsedGameTime.TotalSeconds;// Adds gamtime til double
            WaveTimerSec = (int)GameTimerSec;// Adds double to a int

            if (WaveTime == 0)
            {
                WaveTime = WaveIntervale;
            }
            if (WaveTimerSec == 1)
            {
                WaveTime -= 1;
                WaveTimerSec = 0;
                GameTimerSec = 0;
            }
            return WaveTime;
        }
        
        public double gameTimerMIlilesecs(GameTime gameTime, double WaveIntervale, double CountDponSpeed)
        {
            /// Timer counts down from 30 to 0
            GameTimerSec += gameTime.ElapsedGameTime.TotalSeconds;
            WaveTimermilisec = (float)GameTimerSec;

            if (WaveTimeDouble <=0)
            {
                WaveTimeDouble = WaveIntervale;
            }

            if (WaveTimermilisec >= CountDponSpeed)
            {
               WaveTimeDouble -= 0.01;
               WaveTimerSec = 0;
               GameTimerSec = 0;
            }
            return WaveTimeDouble;
        }
    }
}
