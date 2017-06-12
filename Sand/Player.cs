using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Audio;

namespace Sand
{
	public class Player : Entity
	{
		public float speed;
		public Vector2 past_vector;
		double last_time;
		long basic_delay = 250;
		PlayerIndex player_index;
		GamePadCapabilities capabilities;
		public int life;
		public static SoundEffect shoot;
		public static SoundEffectInstance Instance;
		public Player(Vector2 position, bool from_first_player, SoundEffect sh) : base(Engine.player_texture, position,true)
		{
			
			shoot = sh;
			life = 100;
			first_player = from_first_player;
			speed = 2.0f;
			rotation = 0f;
			past_vector = Vector2.Zero;
			last_time = 0;
			if (from_first_player)
				player_index = PlayerIndex.One;
			else
				player_index = PlayerIndex.Two;
			capabilities = GamePad.GetCapabilities(player_index);
		}

		public override void update(GameTime gametime)
		{
			Vector2 final_vector = past_vector;

			if (capabilities.IsConnected)
			{
				GamePadState state = GamePad.GetState(player_index);

				final_vector.X += state.ThumbSticks.Left.X * speed;
				final_vector.Y -= state.ThumbSticks.Left.Y * speed;

				if (state.Triggers.Right > 0)
				{
					attempt_basic(gametime);
				}
			}

			position += final_vector;
			past_vector = final_vector * 0.9f;
			calculate_rotation(final_vector);
			check_bounds();
			base.update(gametime);
		}

		public void attempt_basic(GameTime gametime)
		{
			SoundEffect.MasterVolume = 0.25f;
			double current_time = gametime.TotalGameTime.TotalMilliseconds;
			if (current_time - last_time > basic_delay)
			{
				last_time = current_time;
				Engine.entities.Add(new Bullet(position, rotation, first_player));
				shoot.CreateInstance ().Play ();
			}
		}

		public void check_bounds()
		{
			if (position.X + (texture.Width / 2f) * Engine.scale.X > Engine.screen_width)
			{
				position.X = Engine.screen_width - ((texture.Width / 2f) - 1) * Engine.scale.X;
			}

			if (position.X - (texture.Width / 2f) * Engine.scale.X < 0)
			{
				position.X = 1 + (texture.Width / 2f) * Engine.scale.X;
			}

			if (position.Y + (texture.Height / 2f) * Engine.scale.Y > Engine.screen_height)
			{
				position.Y = Engine.screen_height - ((texture.Height / 2f) - 1) * Engine.scale.Y;
			}

			if (position.Y - (texture.Height / 2f) * Engine.scale.Y < 0)
			{
				position.Y = 1 + (texture.Height / 2f) * Engine.scale.Y;
			}
		}

		public void calculate_rotation(Vector2 vector)
		{
			rotation = (float)Math.Atan2(vector.Y, vector.X);
		}

		public override void draw(SpriteBatch sprite_batch){
			float length = (Engine.screen_width / 2 - 40 * Engine.scale.X) * (life / 100f);
			Vector2 lifebar_position = new Vector2(20 * Engine.scale.X, 20 * Engine.scale.Y);

			if (!first_player)
			{
				lifebar_position = new Vector2(Engine.screen_width - 20 - length, 20 * Engine.scale.Y);
			}

			sprite_batch.Draw(Engine.lifebar_texture, lifebar_position, null, null, null, 0, new Vector2(length, 1));
			base.draw(sprite_batch);
		}
	}
}
