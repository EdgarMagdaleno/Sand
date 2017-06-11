using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sand
{
	public class GameStart : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch sprite_batch;
		List<Entity> entities;

		public GameStart()
		{
			graphics = new GraphicsDeviceManager (this);
			entities = new List<Entity>();

			Content.RootDirectory = "Content";
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

			//TODO: use this.Content to load your game content here 
		}
			
		protected override void Update (GameTime gameTime)
		{
			foreach (Entity e in entities)
			{
				e.update(gameTime);
			}
            
			base.Update (gameTime); 
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			foreach (Entity e in entities)
			{
				e.draw(sprite_batch);
			}
            
			base.Draw (gameTime);
		}
	}
}

