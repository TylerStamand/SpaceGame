using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame {
    public static class Collision {

        public static bool CheckCollision(Entity entity1, Entity entity2) {
            
            Vector2[] cornersA ={entity1.UR, entity1.UL, entity1.LL, entity1.LR};
            Vector2[] cornersB = {entity2.UR, entity2.UL, entity2.LL, entity2.LR};
        
            
            List<Vector2> Axes =  Edges(cornersA);
            Axes.InsertRange(Axes.Count -1, Edges(cornersB));
            

            //Get normals of axes
            for(int i =0; i < Axes.Count; i++) {
                Axes[i] = Normal(Axes[i]);
            }


            for(int i = 0; i < 8; i++) {
               
                float maxA = 0;
                float minA = float.MaxValue;
                float maxB = 0;
                float minB = float.MaxValue;
                for(int j = 0; j < 4; j++) {
                    float result = ProjectionScalar(Axes[i], cornersA[j]);
                    if(result > maxA) {
                        maxA = result;
                    }
                    if(result < minA) {
                        minA = result;
                    }
                    result = ProjectionScalar(Axes[i], cornersB[j]);
                    if(result > maxB) {
                        maxB = result;
                    }
                    if(result < minB) {
                        minB = result;
                    }
                }
                if(!(minB <= maxA && maxB >= minA )) {
                    return false;
                }    
            }
            
            return true;
            
        }
         public static void DrawLineTo(this SpriteBatch sb, Texture2D texture, Vector2 src, Vector2 dst, Color color) {
            //direction is destination - source vectors
            Vector2 direction = dst - src;
            //get the angle from 2 specified numbers (our point)
            var angle = (float)Math.Atan2(direction.Y, direction.X);
            //calculate the distance between our two vectors
            float distance;
            Vector2.Distance(ref src, ref dst, out distance);

            //draw the sprite with rotation
            sb.Draw(texture, src, new Rectangle((int)src.X, (int)src.Y, (int)distance, 1), color, angle, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
        }

         public static float ProjectionScalar(Vector2 axis, Vector2 corner) {
            Vector2 ProjectionCoordinates = new Vector2();

            ProjectionCoordinates.X = (((corner.X * axis.X)+ (corner.Y * axis.Y))/
            (MathF.Pow(axis.X, 2) + MathF.Pow(axis.Y, 2))) * axis.X;

            ProjectionCoordinates.Y = (((corner.X * axis.X) + (corner.Y * axis.Y))/
            (MathF.Pow(axis.X, 2) + MathF.Pow(axis.Y, 2))) * axis.Y;

            return ((ProjectionCoordinates.X * axis.X) + (ProjectionCoordinates.Y * axis.Y));
            


        }

         public static Vector2 Normal(Vector2 axis) {
             return(new Vector2(-axis.Y, axis.X));
         }

         public static List<Vector2> Edges(Vector2[] vertices) {
             List<Vector2> edges = new List<Vector2>();

             for(int i =0; i < vertices.Length; i++) {
                 Vector2 edge = new Vector2(vertices[(i+1)%vertices.Length].X - vertices[i].X, vertices[(i+1)%vertices.Length].Y - vertices[i].Y);
                 edges.Add(edge);
             }
             return edges;
         }
}
    }

   