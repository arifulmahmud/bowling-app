using BowlingScore.Model;
using System.Collections;

namespace BowlingScore
{
    /// <summary>
    /// Bowling Game
    /// </summary>
    public class BowlingGame
    {
        readonly ArrayList throws;
        readonly ArrayList frames;

        public BowlingGame()
        {
            throws = new ArrayList();
            frames = new ArrayList();
        }

        /// <summary>
        /// Opens a normal game frame.
        /// When player is unable to strike down all the pins in two throw.
        /// </summary>
        /// <param name="firstThrow"></param>
        /// <param name="secondThrow"></param>
        public void OpenFrame(int firstThrow, int secondThrow)
        {
            frames.Add(new OpenFrame(throws, firstThrow, secondThrow));
        }

        /// <summary>
        /// Opens a spare frame for game
        /// This means player has strike down all pins in two throw
        /// </summary>
        /// <param name="firstThrow"></param>
        /// <param name="secondThrow"></param>
        public void Spare(int firstThrow, int secondThrow)
        {
            frames.Add(new SpareFrame(throws, firstThrow, secondThrow));
        }

        /// <summary>
        /// Opens a strike frame for game
        /// This means player has strike down all pins in 1st throw
        /// </summary>
        /// <param name="firstThrow"></param>
        /// <param name="secondThrow"></param>
        public void Strike()
        {
            frames.Add(new StrikeFrame(throws));
        }

        /// <summary>
        /// This opens a bonus frame.
        /// If player strikes or spares in last throw then bonusroll is added
        /// </summary>
        /// <param name="roll"></param>
        public void BonusRoll(int roll)
        {
            frames.Add(new BonusRoll(throws, roll));
        }


        public int Score()
        {
            int total = 0;
            foreach (Frame frame in frames)
                total += frame.Score();
            return total;
        }
    }
}
