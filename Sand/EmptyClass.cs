using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sand
{
	public class Entity
	{
		Texture2D texture;
		Vector2 position;

		public Entity(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
		}

		public void draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(texture, position);
		}

		public void update(GameTime gametime)
		{

		}
	}
}
