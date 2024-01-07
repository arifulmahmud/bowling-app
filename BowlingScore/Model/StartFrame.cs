using System.Collections;

namespace BowlingScore.Model
{
    public class OpenFrame : Frame
    {
        public OpenFrame(ArrayList throws, int firstThrow, int secondThrow) : base(throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        override public int Score()
        {
            return (int)throws[startingThrow] + (int)throws[startingThrow + 1];
        }

        override protected int FrameSize()
        {
            return 2;
        }
    }
}
