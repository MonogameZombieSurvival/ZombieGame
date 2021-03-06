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
   public class GameObject
    {
        protected Texture2D sprite;
        protected string spiteName;
        protected float rotation;
        protected Vector2 Direction;
        protected Vector2 position;
        public Vector2 Position {
            get => position;
            set
            {
                position = value;
            }
        }
        protected Vector2 realTimeplayerPosition;
        protected Vector2 sightposition;
        protected int Playerhealth;
     
        protected ContentManager content;
      
        /// <summary>
        /// The Collision Box of the GameObject. The default box is based upon the GameObject position and sprite size
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width*0.5), (int)(position.Y-sprite.Height*0.5), sprite.Width, sprite.Height);
            }
        }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, sprite.Width, sprite.Height); }
        }

        /// <summary>
        /// Checks if the current object collides with another object
        /// </summary>
        /// <param name="otherObject">The other GameObject that should be tested against</param>
        /// <returns>Returns true if current object collides with otherObject otherwise false</returns>
        public bool IsColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }

        /// <summary>
        /// Enabled the GameObject to handle collisions in a custom way
        /// </summary>
        /// <param name="otherObject">The GameObject that the current GameObject collides with</param>
        public virtual void DoCollision(GameObject otherObject)
        {
            
        }

        /// <summary>
        /// The default constructor for a GameObject
        /// </summary>
        /// <param name="content">Reference to a ContentManager for loading resources</param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(ContentManager content, string spriteName) : this(Vector2.Zero, content,spriteName)
        {
            this.content = content;
        }

        /// <summary>
        /// Gets the position and rotaion of player
        /// </summary>
        /// <param name="PlayerPosition"></param>
        public void GetPlayerPosition(Vector2 PlayerPosition)
        {
              realTimeplayerPosition = PlayerPosition;
        }

        public void GetPlayerHealth(int playerHeath)
        {
            Playerhealth = playerHeath;
        }

        public void GetSightePosition(Vector2 sigte)
        {
            sightposition = sigte;
            
        }


        /// <summary>
        /// Constructor the sets the staring position of the GameObject
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="content">Reference to a ContentManager for loading resources</param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(Vector2 startPosition,ContentManager content, string SpriteName)
        {
            position = startPosition;
            spiteName = SpriteName;
           
            sprite = content.Load<Texture2D>(spiteName);
        }

        /// <summary>
        /// Enabled the GameObject to have game logic defined
        /// </summary>
        /// <param name="gameTime">The elasped time since last update call</param>
        public virtual void Update(GameTime gameTime)
        {
 
        }

        /// <summary>
        /// Enables the GameObject to be drawn. The std. functionality is to draw its sprite.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use for drawing</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(sprite, position, null,Color.White, rotation,new Vector2(sprite.Width*0.5f, sprite.Height * 0.5f), 1, new SpriteEffects(),0f );
        }
    }
}
