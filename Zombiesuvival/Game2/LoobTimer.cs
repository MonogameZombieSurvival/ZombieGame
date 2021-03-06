﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class LoobTimer
    {
        private double GameTimerSec;
        private int WaveTimerSec;
        private int WaveTime = 0;
  

        private float WaveTimermilisec;
        private double WaveTimeDouble ;
    /// <summary>
    /// A loop timmer der teller ned i skunde der smeder et interval in og tæller ned der fra
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="WaveIntervale"></param>
    /// <returns></returns>
        public int gameTimerSec(GameTime gameTime, int WaveIntervale)
        {
            /// Timer for the Wave goes for 30 sec and dow to 0 int a loob

            GameTimerSec += gameTime.ElapsedGameTime.TotalSeconds;// adder gamtime til doube

            WaveTimerSec = (int)GameTimerSec;// smider den double i en int

            // hvis sætter loob til den valgte lobe længe i sec
            if (WaveTime == 0)
            {
                WaveTime = WaveIntervale;
            }
            // når der er går et sec minus loob timed med et sec
            if (WaveTimerSec == 1)
            {

                WaveTime -= 1;

                WaveTimerSec = 0;
                GameTimerSec = 0;
            }

            return WaveTime;


        }

        /// <summary>
        /// loob timer for miliseconder. bruges hvis man skal have en ned telling der vare under en et sekund
        /// </summary>   
        public double gameTimerMIlilesecs(GameTime gameTime, double WaveIntervale, double CountDponSpeed)
        {
            /// Timer for the Wave goes for 30 sec and dow to 0 int a loob

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

    class GameTimer
    {
    }
}
