using System;

namespace GC_Roshambo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");

            // Create new HumanPlayer instance
            HumanPlayer humanPlayer = new HumanPlayer();
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine("Would you like to play against Jerry Seinfeld or A Random Ant?");
                string opponent = Console.ReadLine().ToLower().Trim();

                if (opponent == "jerry seinfeld" || opponent == "jerry" || opponent == "seinfeld" || opponent == "j")
                {
                    RockPlayer rockOpponent = new RockPlayer();
                    humanPlayer.PlayRockPlayer(humanPlayer, rockOpponent);
                }
                else if (opponent == "a random ant" || opponent == "ant" || opponent == "a" || opponent.Contains("ant") || opponent.Contains("random"))
                {
                    RandomPlayer randomOpponent = new RandomPlayer();
                    humanPlayer.PlayRandomPlayer(humanPlayer, randomOpponent);
                }
                else
                {
                    Console.WriteLine("That is not an option.");
                }

                Console.WriteLine("You won " + humanPlayer.Wins + " time(s)");
                Console.WriteLine("You lost " + humanPlayer.Losses + " time(s)");

                Console.WriteLine("Keep playing? (y/n)");
                string getContinue = Console.ReadLine().ToLower().Trim();
                if (getContinue == "yes" || getContinue == "y")
                {
                    keepPlaying = true;
                }
                else if (getContinue == "no" || getContinue == "n")
                {
                    // Stop Play Loop
                    break;
                }
            }

            Console.WriteLine("Thanks for playing!");

        }

        #region roshambo
        public enum Roshambo
        {
            rock,
            paper,
            scissors
        }
        #endregion roshambo

        public abstract class Player
        {
            public string Name { get; set; }
            public Roshambo RPS { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }

            public abstract Roshambo GenerateRoshambo();
        }

        public class RockPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                return Roshambo.rock;
            }
        }

        public class RandomPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                Random rnd = new Random();
                int number = rnd.Next(3);
                RPS = (Roshambo)number;
                return RPS;
            }
        }

        public class HumanPlayer : Player
        {
            public HumanPlayer()
            {
                Console.WriteLine("Enter your name:");
                Name = Console.ReadLine();
            }

            public override Roshambo GenerateRoshambo()
            {
                Console.WriteLine("Rock, paper, or scissors? (R/P/S)");
                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "rock" || input.ToLower().Trim() == "r")
                {
                    RPS = Roshambo.rock;
                }
                else if (input.ToLower().Trim() == "paper" || input.ToLower().Trim() == "p")
                {
                    RPS = Roshambo.paper;
                }
                else if (input.ToLower().Trim() == "scissors" || input.ToLower().Trim() == "s")
                {
                    RPS = Roshambo.scissors;
                }
                else
                {
                    Console.WriteLine("Exception: wrong input.");
                }
                return RPS;
            }

            public void PlayRandomPlayer(HumanPlayer humanPlayer, RandomPlayer opponent)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = opponent.GenerateRoshambo().ToString();

                // Draw
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("Draw!");
                }
                // Win
                else if (yourRPS == "rock" && opponentRPS == "scissors" || yourRPS == "scissors" && opponentRPS == "paper" || yourRPS == "paper" && opponentRPS == "rock")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You win!");
                    humanPlayer.Wins++;
                }
                // Lose
                else
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Losses++;
                }
            }

            public void PlayRockPlayer(HumanPlayer humanPlayer, RockPlayer RockLee)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = RockLee.GenerateRoshambo().ToString();
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("Draw!");
                }
                else if (yourRPS == "paper")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You win!");
                    humanPlayer.Wins++;
                }
                else
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Losses++;
                }
            }
        }
    }
}
