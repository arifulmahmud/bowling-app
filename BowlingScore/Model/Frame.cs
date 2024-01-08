using System.Collections;

namespace BowlingScore.Model
{
    /// <summary>
    /// Base frame class
    /// </summary>
    abstract public class Frame
    {
        protected ArrayList throws;
        protected int startingThrow;

        public Frame(ArrayList throws)
        {
            this.throws = throws;
            this.startingThrow = throws.Count;
        }
        
        /// <summary>
        /// Stores the score of the frames
        /// </summary>
        abstract public int Score();

        /// <summary>
        /// Frame size
        /// </summary>
        abstract protected int FrameSize();

        /// <summary>
        /// Caluculates the first bonus throw
        /// </summary>
        protected int FirstBonusBall()
        {
            return (int)throws[startingThrow + FrameSize()];
        }

        /// <summary>
        /// Caluculates the second bonus throw
        /// </summary>
        protected int SecondBonusBall()
        {
            return (int)throws[startingThrow + FrameSize() + 1];
        }
    }
}
