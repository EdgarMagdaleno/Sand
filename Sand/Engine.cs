using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Sand
{
	public class Engine : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch sprite_batch;
		public static List<Entity> entities;
		public static Texture2D bullet_texture;
		public static Texture2D player_texture;
		public static Texture2D lifebar_texture;
		public static Texture2D background;
		public static int screen_width;
		public static int screen_height;
		public static Vector2 scale;
		public static Song song;
		public static  SoundEffect shot;
		public static int A;
		public static int B;
		public static int C;
		public static int D;
		public Engine()
		{
			graphics = new GraphicsDeviceManager (this);
			entities = new List<Entity>();

			Content.RootDirectory = "Content";
			screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			this.graphics.PreferredBackBufferWidth = screen_width;
			this.graphics.PreferredBackBufferHeight = screen_height;
			this.graphics.IsFullScreen = true;

			scale = new Vector2(screen_width / 1920f, screen_height / 1080f);
		}
			
		protected override void Initialize ()
		{
			
			// TODO: Add your initialization logic here
			A=1;B=4;
			C = 4;D=1;
			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			sprite_batch = new SpriteBatch (GraphicsDevice);
			bullet_texture = Content.Load<Texture2D>("bullet");
			//bullet_texture = Content.Load<Texture2D>("shoot2");
			player_texture = Content.Load<Texture2D>("player");
			//player_texture = Content.Load<Texture2D>("ship12");
			lifebar_texture = Content.Load<Texture2D>("lifebar");
			background = Content.Load<Texture2D> ("planet1");
			//song = Content.Load<Song> ("Space Battle (Game Music)");
			//song = Content.Load<Song> ("song");
			shot=Content.Load<SoundEffect>("shot");
			MediaPlayer.Play (song);
			MediaPlayer.IsRepeating = true;
			start();
		}

		public void start()
		{

			entities.Add(new Player(new Vector2(player_texture.Width * scale.X, player_texture.Height * scale.Y), true,shot));

			entities.Add(new Player(new Vector2(screen_width - player_texture.Width * scale.X, screen_height - player_texture.Height * scale.Y), false,shot));
		}
			
		protected override void Update (GameTime gameTime)
		{
			foreach (Entity e in entities.ToArray())
			{
				e.update(gameTime);

				foreach (Entity e2 in entities.ToArray())
					if (e.first_player != e2.first_player && (e.GetType() == typeof(Bullet) && e2.GetType() == typeof(Player)) && e.check_collision(e2)) {
						entities.Remove(e);
						Player pe = (Player) e2;
						pe.life -= 10;
					}
			}
            
			base.Update (gameTime); 
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(new Color(20, 20, 20));
			sprite_batch.Begin(SpriteSortMode.BackToFront);

			sprite_batch.Draw (background, GraphicsDevice.Viewport.Bounds, Color.White);
			foreach (Entity e in entities.ToArray())
			{//
				e.draw(sprite_batch);
			}
           
			base.Draw (gameTime);
			sprite_batch.End();
		}			
	}
}

