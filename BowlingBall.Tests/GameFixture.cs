using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
	[TestClass]
	public class GameFixture
	{
		public Game game;

		[TestInitialize]
		public void Initialize()
		{
			game = new Game();
		}

		/// <summary>
		/// Test case to check when all pins are 0
		/// </summary>
		[TestMethod]
		public void Gutter_game_score_should_be_zero_test()
		{
			Roll(game, 0, 20);
			Assert.AreEqual(0, game.GetScore());
		}

		/// <summary>
		/// Test case to check when all pins are 1 or 2
		/// </summary>
		[TestMethod]
		[DataRow(1)]
		[DataRow(2)]
		public void Roll_all_with_same_pins_test(int pins)
		{
			Roll(game, pins, 20);
			if (pins == 1)
				Assert.AreEqual(20, game.GetScore());
			else
				Assert.AreEqual(40, game.GetScore());
		}

		/// <summary>
		/// Test case to check when there is spare
		/// </summary>
		[TestMethod]
		public void Roll_spare_test()
		{
			game.Roll(3);
			game.Roll(3);
			game.Roll(5);
			game.Roll(5);
			game.Roll(7);
			Roll(game, 0, 15);
			Assert.AreEqual(30, game.GetScore());
		}

		/// <summary>
		/// Test case to check when there is strike
		/// </summary>
		[TestMethod]
		public void Roll_strike_test()
		{
			game.Roll(10);
			game.Roll(1);
			game.Roll(2);
			Roll(game, 0, 16);
			Assert.AreEqual(16, game.GetScore());
		}

		/// <summary>
		/// This method is used to set fixed pins to roll.
		/// </summary>
		/// <param name="game"></param>
		/// <param name="pins"></param>
		/// <param name="times"></param>
		private void Roll(Game game, int pins, int times)
		{
			for (int i = 0; i < times; i++)
			{
				game.Roll(pins);
			}
		}
	}
}
