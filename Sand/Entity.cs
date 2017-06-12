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
			Rectangle rect1 = new Rectangle((int) (position.X - origin.X), (int) (position.Y - origin.Y), (int) (texture.Width * Engine.scale.X), (int) (texture.Height * Engine.scale.Y));
			Rectangle rect2 = new Rectangle((int) (entity.position.X - entity.origin.X) , (int) (entity.position.Y - entity.origin.Y), (int) (entity.texture.Width * Engine.scale.X), (int)(entity.texture.Height * Engine.scale.Y));

			if (rect1.X < rect2.X + rect2.Width && rect1.X + rect1.Width > rect2.X && rect1.Y < rect2.Y + rect2.Height && rect1.Height + rect1.Y > rect2.Y)
			{
				return true;
			}

			return false;
		}

		public virtual void update(GameTime gametime)
		{

		}
	}
}
