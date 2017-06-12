using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sand
{
	public class Entity
	{
		public Texture2D texture;
		public Vector2 position;
		public Vector2 origin;
		public float rotation;

		public Entity(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
			this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
			this.rotation = 0f;
		}

		public virtual void draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(texture, position, null, null, origin, rotation, null, Color.White);
		}

		public virtual void update(GameTime gametime)
		{

		}
	}
}
