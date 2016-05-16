using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using superCoolGame.View;
namespace superCoolGame
{
	public class Player
	{
		private int score;
		private bool active;
		private int health;
		public Texture2D PlayerTexture;
		public Vector2 Position;
		private Animation playerAnimation;
		public Animation PlayerAnimation
		{
			get{ return playerAnimation; }
			set { playerAnimation = value; }
		}
		public bool Active
		{
			get { return active;}
			set { active = value; }
		}

	
		public int Health
		{
			get { return health; }
			set { health = value; }
		}



		public int Width
		{
			get { return playerAnimation.FrameWidth; }
		}


		public int Height
		{
			get { return PlayerAnimation.FrameHeight; }

		}

		public int Score
		{
			get {return score;}
			set {score = value;}
		}

		public void Initialize(Texture2D texture, Vector2 position)
		{
			this.active = true;
			this.health = 100;

			this.score = 0;
			this.PlayerTexture = texture;
			this.Position = position;
		}
		public void Initialize(Animation animation, Vector2 position)
		{
			PlayerAnimation = animation;

			// Set the starting position of the player around the middle of the screen and to the back
			Position = position;

			// Set the player to be active
			Active = true;

			// Set the player health
			Health = 100;
			this.score = 0;
		}

		public void Update()
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			PlayerAnimation.Draw(spriteBatch);
		}
	}
}

