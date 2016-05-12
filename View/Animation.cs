using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace superCoolGame.View
{
	public class Animation
	{
		private Texture2D spriteStrip;
		public Texture2D SpriteStrip
		{
			get{ return spriteStrip; }
			set { spriteStrip = value; }
		}

		private float scale;
		public float Scale
		{
			get { return scale; }
			set { scale = value; }
		}

		private int elapsedTime;
		public int ElapsedTime
		{
			get { return elapsedTime; }
			set { elapsedTime = value; }
		}

		private int frameTime;
		public int FrameTime
		{
			get { return frameTime; }
			set{ frameTime = value; }

		}

		private int frameCount;
		public int FrameCount
		{
			get { return frameCount; }
			set { frameCount = value; }
		}

		private int currentFrame;

		private Color color;
		public Color Color
		{
			get{ return color; }
			set{ color = value; }
		}
		Rectangle sourceRect = new Rectangle();
		Rectangle destinationRect = new Rectangle();

		private  int frameWidth;
		public int FrameWidth
		{
			get { return FrameWidth; }
			set { FrameWidth = value; }
		}
		private int FrameHeight;
		public int frameHeight
		{
			get { return FrameHeight;}
			set { FrameHeight = value;}
		}

		private  bool Active;
		public bool active
		{
			get { return Active; }
			set { Active = value; }
		}

		private  bool Looping;
		public bool looping
		{
			get{ return Looping; }
			set { Looping = value; }
		}

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

