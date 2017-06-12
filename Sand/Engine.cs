using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
		public static int screen_width;
		public static int screen_height;
		public static Vector2 scale;

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
            
			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			sprite_batch = new SpriteBatch (GraphicsDevice);
			bullet_texture = Content.Load<Texture2D>("bullet");
			player_texture = Content.Load<Texture2D>("player");
			lifebar_texture = Content.Load<Texture2D>("lifebar");

			start();
		}

		public void start()
		{
			entities.Add(new Player(new Vector2(20, 20), true));
			entities.Add(new Player(new Vector2(screen_width - 20, screen_height - 20), false));
		}
			
		protected override void Update (GameTime gameTime)
		{
			foreach (Entity e in entities.ToArray())
			{
				e.update(gameTime);

				foreach (Entity e2 in entities.ToArray())
					if (e != e2 & e.check_collision(e2))
						Console.WriteLine("HIT!");
			}
            
			base.Update (gameTime); 
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(new Color(20, 20, 20));
			sprite_batch.Begin(SpriteSortMode.BackToFront);

			foreach (Entity e in entities.ToArray())
			{
				e.draw(sprite_batch);
			}
           	
			base.Draw (gameTime);
			sprite_batch.End();
		}			
	}
}

