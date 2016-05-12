using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace superCoolGame
{
	public class Animation
	{
		Texture2D spriteStrip;
		float scale;
		int elapsedTime;
		int frameTime;
		int frameCount;
		int currentFrame;

		Color color;
		public Color Color
		{
			get{ return color; }
			set{ color = value; }
		}
		Rectangle sourceRect = new Rectangle();
		Rectangle destinationRect = new Rectangle();

		public int frameWidth;
		public int FrameWidth
		{
			get { return FrameWidth; }
			set { FrameWidth = value; }
		}
		public int FrameHeight;

		public bool Active;
		public bool active
		{
			get { return Active; }
			set { Active = value; }
		}
		public bool Looping;

		public Vector2 Position;
		public Vector2 position
		{
			get { return Position; }
			set { Position = value; }
		}


		public void Initialize()
		{
			this.color = color;
			this.FrameWidth = FrameWidth;
			this.FrameHeight = FrameHeight;
			this.frameCount = frameCount;
			this.frameTime = frameTime;
			this.scale = scale;
			Looping = Looping;
			Position = position;
			spriteStrip = Texture;
			elapsedTime = 0;
			currentFrame = 0;
			Active = true;

		}
		public void Update(GameTime gameTime)
		{
			// Do not update the game if we are not active
			if (Active == false)
				return;

			// Update the elapsed time
			elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			// If the elapsed time is larger than the frame time
			// we need to switch frames
			if (elapsedTime > frameTime)
			{
				// Move to the next frame
				currentFrame++;

				// If the currentFrame is equal to frameCount reset currentFrame to zero
				if (currentFrame == frameCount)
				{
					currentFrame = 0;
					// If we are not looping deactivate the animation
					if (Looping == false)
						Active = false;
				}

				// Reset the elapsed time to zero
				elapsedTime = 0;
			}

			// Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
			sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

			// Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
			destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2,
				(int)Position.Y - (int)(FrameHeight * scale) / 2,
				(int)(FrameWidth * scale),
				(int)(FrameHeight * scale));
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			// Only draw the animation when we are active
			if (Active)
			{
				spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
			}
		}
		public Animation ()
		{
		}

	}
}

