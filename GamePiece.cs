using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace RPSsimulation
{
    public class GamePiece
    {
        public Vector2 positon;
        public Vector2 Velocity;
        public Texture2D image;
        public Rectangle rect;
        public GamePiece target;

        public Texture2D targetType;

        public GamePiece(Vector2 pos, Texture2D sprite, Texture2D targettype, Texture2D hunter)
        {
            positon = pos;
            image = sprite;
            targetType = targettype;
        }
        // update method
        public void Update()
        { 
            // find the neares gamepeice, move towards it, and if it's close, "infect" it
            NearestGamePiece(targetType, positon);
            MoveTowards(target);
            if (DistanceTo(target) < 10)
            {
                target.image = image;
                target.targetType = targetType;
            }
            
        }
        public void Draw(SpriteBatch spritebatch)
        {
               spritebatch.Draw(image,
               new Rectangle((int)positon.X, (int)positon.Y, 48, 48),
               new Rectangle(0, 0, 16, 16),
               Color.White);
               
        }
        public void NearestGamePiece(Texture2D type, Vector2 positiontocheckfrom)
        {
            GamePiece nearest = Game1.GamePieces[0];
            float nearestdistance = 10000000000000000000;

            foreach (GamePiece i in Game1.GamePieces)
            {
                float dist = DistanceTo(i);
                if (nearestdistance > dist && i.image == type)
                {
                    nearestdistance = dist;
                    nearest = i;
                }
            }
            target = nearest;
        }
        public float DistanceTo(GamePiece target)
        {
            float xdif = target.positon.X - positon.X;
            float ydif = target.positon.Y - positon.Y;
            float distance = (float)Math.Sqrt(xdif * xdif + ydif * ydif);
            return distance;
            
        }
        public void MoveTowards(GamePiece target)
        {
            if (target.image == image) return;
            if (positon.X < target.positon.X)
            {
                positon.X += 1;
            }
            else
            {
                positon.X -= 1;
            }
            if (positon.Y < target.positon.Y)
            {
                positon.Y += 1;
            }
            else
            {
                positon.Y -= 1;
            }
        }
        public void MoveAway()
        {
            if (positon.X < target.positon.X)
            {
                positon.X += 1;
            }
            else
            {
                positon.X -= 1;
            }
            if (positon.Y < target.positon.Y)
            {
                positon.Y += 1;
            }
            else
            {
                positon.Y -= 1;
            }
        }

    }
}
