namespace BowlingScore
{
    internal class Program
    {
        readonly BowlingGame _game;

        public Program(BowlingGame game)
        {
            _game = game;
        }

        public static void Main(string[] args)
        {
            BowlingGame game = new BowlingGame();
            Program program = new Program(game);
            Console.WriteLine("Wellcome to bowling scoring app!");
            Console.WriteLine("Please input scores for each Frame (first throw and second throw) !!");
            Console.WriteLine("For example: 9 1, 10 0, 5 5");
            Console.WriteLine("Press Enter after each frames input");
            program.ReadUIAndCalculateScore();
        }


        private void ReadUIAndCalculateScore()
        {
            int maxFrames = 10;
            for (int currentFrame = 1; currentFrame <= maxFrames; currentFrame++)
            {
                Console.WriteLine($"Enter the result of {currentFrame} Frame [FirstThrow SecondThrow]: ", currentFrame);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    var numbers = input
                                .Split(' ')
                                .Where(x => int.TryParse(x, out _))
                                .Select(int.Parse)
                                .ToArray();
                    OpenFrames(currentFrame, numbers[0], numbers[1]);

                    // check for bonus rolls
                    if (currentFrame == 10 && numbers[0] == 10)
                    {
                        maxFrames += 2;
                    }
                    else if(currentFrame == 10 && numbers[0] + numbers[1] == 10)
                    {
                        maxFrames += 1;
                    }
                }
            }
            int score = _game.Score();
            Console.WriteLine("-----The Game has ended-----");
            Console.WriteLine($"Result of the game is: {score}");
        }

        private void OpenFrames(int count, int firstThrow, int secondThrow)
        {
            // this is a strike
            if(firstThrow == 10 && count<=10)
            {
                _game.Strike();
            }
            //this is a spare
            else if(firstThrow + secondThrow == 10 && count <= 10)
            {
                _game.Spare(firstThrow, secondThrow);
            }
            // open a normal frame
            else if(count <= 10)
            {
                _game.OpenFrame(firstThrow, secondThrow);
            }
            // this is a bouns rool once the count is higher then 10
            else
            {
                _game.BonusRoll(firstThrow);
            }
        }
    }
}