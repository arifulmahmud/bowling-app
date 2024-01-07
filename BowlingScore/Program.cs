namespace BowlingScore
{
    internal class Program
    {
        BowlingGame game;

        public Program(BowlingGame game)
        {
            this.game = game;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to bowling scoring app!");
        }


        private void ReadUserInput(string input)
        {

        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}