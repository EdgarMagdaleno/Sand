using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sand
{

	public class AnimatedSprite
	{
		public Texture2D Texture { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		private int currentFrame;
		private int totalFrames;
		public int width{ get; set; }
		public int height{get;set;}
		public float CambioX=1f;
		public float CambioY=1f;
		public bool algo = true;
		public bool algo2= true;
		public Vector2 Vec;

		public AnimatedSprite(Texture2D texture, int rows, int columns)
		{
			Texture = texture;
			Rows = rows;
			Columns = columns;
			currentFrame = 0;
			totalFrames = Rows * Columns;

			Vec= Vector2.Zero;
		}

		public void UpdateImage()
		{
			currentFrame++;
			if (currentFrame == totalFrames)
				currentFrame = 0;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			width = Texture.Width / Columns;
			height = Texture.Height / Rows;
			int row = (int)((float)currentFrame / (float)Columns);
			int column = currentFrame % Columns;

			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			Rectangle destinationRectangle = new Rectangle((int)Vec.X, (int)Vec.Y, width, height);

			spriteBatch.Begin();
			spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
			spriteBatch.End();
		}

		private bool Move(int menor,int mayor , int comprobar, int dimension, ref bool x){
			if (comprobar<=menor) {
				x = false;
				return x;
			} else {
				if (comprobar>=(mayor-dimension)) {
					x = true;
					return x;
				} else {
					return x;
				}
			}

		}


		public void UpdateVec(int menorX,int menorY,int mayorX,int mayorY,int Rate1,int Rate2){

			if (Move(menorX, mayorX,(int)Math.Ceiling(Vec.X),width,ref algo)== false) {
				if (Move(menorY,mayorY,(int)Math.Ceiling(Vec.Y),height,ref algo2)==false) {
					CambioX +=  Rate1;
					CambioY += Rate2;
					Vec.X=CambioX;
					Vec.Y = CambioY;
				} else {
					CambioX +=  Rate1;
					CambioY -= Rate2;
					Vec.X=CambioX;
					Vec.Y = CambioY;
				}
			} else {
				if (Move(0,600,(int)Math.Ceiling(Vec.Y),height,ref algo2)==false) {
					CambioX -=  Rate1;
					CambioY += Rate2;
					Vec.X=CambioX;
					Vec.Y = CambioY;
				} else {
					CambioX -=  Rate1;
					CambioY -= Rate2;
					Vec.X=CambioX;
					Vec.Y = CambioY;
				}
			}
		}






	}
}

