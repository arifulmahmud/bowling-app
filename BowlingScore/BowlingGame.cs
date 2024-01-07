using BowlingScore.Model;
using System.Collections;

namespace BowlingScore
{
    public class BowlingGame
    {
        readonly ArrayList throws;
        readonly ArrayList frames;

        public BowlingGame()
        {
            throws = new ArrayList();
            frames = new ArrayList();
        }

        public void OpenFrame(int firstThrow, int secondThrow)
        {
            frames.Add(new OpenFrame(throws, firstThrow, secondThrow));
        }

        public void Spare(int firstThrow, int secondThrow)
        {
            frames.Add(new SpareFrame(throws, firstThrow, secondThrow));
        }

        public void Strike()
        {
            frames.Add(new StrikeFrame(throws));
        }

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
