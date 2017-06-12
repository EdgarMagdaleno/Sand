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

		public Entity(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			float scale_x = (Engine.screen_width / 1920f);
			float scale_y = (Engine.screen_height / 1080f);
			this.position = position;
			this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
			this.rotation = 0f;
		}

		public virtual void draw(SpriteBatch sprite_batch) {
			sprite_batch.Draw(texture, position, null, null, origin, rotation, Engine.scale, Color.White, SpriteEffects.None, 0);
		}

		public bool check_collision(Entity entity) {
			return (this.first_player != entity.first_player & this.position.X < entity.position.X + entity.texture.Width + origin.X & this.position.X + this.texture.Width + origin.X > entity.position.X &
					this.position.Y < entity.position.Y + entity.texture.Height + origin.Y & this.texture.Height + origin.Y + this.position.Y > entity.position.Y);
		}

		public virtual void update(GameTime gametime)
		{

		}
	}
}
