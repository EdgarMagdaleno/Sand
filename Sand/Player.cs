using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

		public Player(Vector2 position, bool from_first_player) : base(Engine.player_texture, position)
		{
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
			base.update(gametime);
		}

		public void attempt_basic(GameTime gametime)
		{
			double current_time = gametime.TotalGameTime.TotalMilliseconds;
			if (current_time - last_time > basic_delay)
			{
				last_time = current_time;
				Engine.entities.Add(new Bullet(position, rotation, first_player));
			}
		}

		public void calculate_rotation(Vector2 vector)
		{
			rotation = (float) Math.Atan2(vector.Y, vector.X);
		}

		public override void draw(SpriteBatch sprite_batch){
			base.draw(sprite_batch);
		}
	}
}
