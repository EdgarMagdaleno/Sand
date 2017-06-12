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
		public Vector2 Vec;
	
		public AnimatedSprite(Texture2D texture, int rows, int columns){
			Texture = texture;
			Rows = rows;
			Columns = columns;
			currentFrame = 0;
			totalFrames = Rows * Columns;

			Vec= Vector2.Zero;
		}

		public void UpdateImage(){
			currentFrame++;
			if (currentFrame == totalFrames)
				currentFrame = 0;
		}

		public void Draw(SpriteBatch spriteBatch ,int  x,int  y){
			width = Texture.Width / Columns;
			height = Texture.Height / Rows;
			int row = (int)((float)currentFrame / (float)Columns);
			int column = currentFrame % Columns;
			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			Rectangle destinationRectangle = new Rectangle(x, y, width, height);
			spriteBatch.Begin();
			spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
			spriteBatch.End();
		}
	}
}

