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
		public bool first_player;
		public Vector2 scale;

		public Entity(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			float scale_x = (Engine.screen_width / 1920f);
			float scale_y = (Engine.screen_height / 1080f);
			this.scale = new Vector2(scale_x, scale_y);
			this.position = position;
			this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
			this.rotation = 0f;
		}

		public virtual void draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(texture, position, null, null, origin, rotation, scale, Color.White);
		}

		public bool check_collision(Entity entity)
		{
			if (this.first_player != entity.first_player & this.position.X < entity.position.X + entity.texture.Width & this.position.X + this.texture.Width > entity.position.X &
   				this.position.Y < entity.position.Y + entity.texture.Height & this.texture.Height + this.position.Y > entity.position.Y)
				return true;
			else 
				return false;
		}


		public virtual void update(GameTime gametime)
		{

		}
	}
}
