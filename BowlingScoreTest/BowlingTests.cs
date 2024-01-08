using BowlingScore;

namespace BowlingScoreTest
{
    [TestFixture]
    public class BowlingTest
    {
        BowlingGame game;

        public BowlingTest()
        {
        }

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }

        [Test]
        public void AllLostBalls()
        {
            ManyOpenFrames(10, 0, 0);
            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void ThreesScore()
        {
            ManyOpenFrames(10, 3, 3);
            Assert.That(game.Score(), Is.EqualTo(60));
        }

        [Test]
        public void GameWithSpareAndGutters()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            Assert.That(game.Score(), Is.EqualTo(21));
        }

        [Test]
        public void GameWithSpares()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.That(game.Score(), Is.EqualTo(23));
        }

        [Test]
        public void GameWithStrikes()
        {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.That(game.Score(), Is.EqualTo(26));
        }

        [Test]
        public void GameWithStrikeInFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);
            Assert.That(game.Score(), Is.EqualTo(18));
        }

        [Test]
        public void GameWithSpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(3, 7);
            game.BonusRoll(5);
            Assert.That(game.Score(), Is.EqualTo(15));
        }

        [Test]
        public void GameWithAllStrikes()
        {
            for (int i = 0; i < 10; i++)
                game.Strike();
            game.BonusRoll(10);
            game.BonusRoll(10);
            Assert.That(game.Score(), Is.EqualTo(300));
        }

        [Test]
        public void GameWithStrikeAndSpare()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);
            Assert.That(game.Score(), Is.EqualTo(200));
        }

        // test helper
        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}