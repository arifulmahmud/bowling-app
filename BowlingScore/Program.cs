using System.Runtime.Serialization;

namespace BowlingScore
{
    internal class Program
    {
        readonly BowlingGame _game;
        private const int TotalPinCount = 10;

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
            Console.WriteLine("Press Enter after each frames input scores [FirstThrow SecondThrow]");
            Console.WriteLine($"In case of bonus roll, enter scores like [10 0] [9 0]");
            program.ReadInputsAndCalculateScore();
        }


        private void ReadInputsAndCalculateScore()
        {
            int maxFrames = 10;
            for (int currentFrame = 1; currentFrame <= maxFrames; currentFrame++)
            {
                Console.WriteLine($"Enter the result of {currentFrame} Frame: ", currentFrame);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    int[]? scores = ParseFrameScores(input);
                    if (scores.Length != 2)
                    {
                        Console.WriteLine("Invalid input, please try again");
                        currentFrame--;
                        continue;
                    }
                    else
                    {
                        StartGameFrame(currentFrame, scores[0], scores[1]);
                    }

                    // check for bonus rolls
                    if (currentFrame == 10)
                    {
                        maxFrames += CheckForBonusRolls(scores[0], scores[1]);
                    }
                }
            }
            int score = _game.Score();
            Console.WriteLine("-----The Game has ended-----");
            Console.WriteLine($"Result of the game is: {score}");
        }

        private static int CheckForBonusRolls(int firstThrow, int secondThrow)
        {
            if (firstThrow == TotalPinCount)
            {
                return 2;
            }
            else if (firstThrow + secondThrow == TotalPinCount)
            {
                return 1;
            }
            return 0;
        }

        private static int[] ParseFrameScores(string input)
        {
            var scores = input.Split(' ');
            if (scores.Length == 2 && int.TryParse(scores[0], out int firstThrow) && int.TryParse(scores[1], out int secondThrow))
            {
                return new int[] { firstThrow, secondThrow };
            }
            return null;
        }

        private void StartGameFrame(int frameCount, int firstThrowPins, int secondThrowPins)
        {
            // this is a strike
            if (firstThrowPins == TotalPinCount && frameCount <= 10)
            {
                _game.Strike();
            }
            //this is a spare
            else if (firstThrowPins + secondThrowPins == TotalPinCount && frameCount <= 10)
            {
                _game.Spare(firstThrowPins, secondThrowPins);
            }
            // open a normal frame
            else if (frameCount <= 10)
            {
                _game.OpenFrame(firstThrowPins, secondThrowPins);
            }
            // this is a bouns roll once the frameCount is higher then 10
            else
            {
                _game.BonusRoll(firstThrowPins);
            }
        }
    }
}