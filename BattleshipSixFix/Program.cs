using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipSixFix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            string[,] playerBoardOne = new string[10, 10];
            string[,] playerBoardTwo = new string[10, 10];
            string[,] playerOneAttackBoard = new string[10, 10];
            string[,] playerTwoAttackBoard = new string[10, 10];
            bool versusAI = false;
            bool randomBoats = false;
            string currentPlayer = "one";
            int boatRotation = 0;
            int boatCoordinateX = 0;
            int boatCoordinateY = 0;
            int boardCounter = 0;
            int xCoordShot = 0;
            int yCoordShot = 0;


            CreateBoard(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer);
            GameSetup(playerBoardOne, playerBoardTwo, ref versusAI, ref randomBoats, ref currentPlayer, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation, ref xCoordShot, ref yCoordShot);
            CreateBoard(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer);
            PlayerTurn(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
        }

        //makes your own board where you were hit
        private static void CreateBoard(string[,] playerBoardOne, string[,] playerBoardTwo, int boardCounter, ref string currentPlayer)
        {
            //draws the numbers
            Console.Write("     ");
            for (int i = 0; i < 10; i++)
            {
                boardCounter = i + 1;
                Console.Write("   " + boardCounter + "   ");
            }
            //check if play is one
            if (currentPlayer == "one")
            {
                //draws the horizontal line
                Console.Write("\n     ");
                for (int m = 0; m < 10; m++)
                {
                    Console.Write("O--  --");
                }
                Console.Write("O");
                //draws the player's board
                for (int i = 0; i < 10; i++)
                {
                    //sets draw counter to i + 1
                    boardCounter = i + 1;
                    //draws the top part of the square
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write("|      ");
                    }
                    Console.Write("|");

                    //draws the middle with the player's board
                    Console.WriteLine();
                    Console.Write("  " + boardCounter + "  ");
                    for (int k = 0; k < 10; k++)
                    {
                        Console.Write("    " + playerBoardOne[i, k] + "   ");
                    }

                    //draws the bottom of the square
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int l = 0; l < 10; l++)
                    {
                        Console.Write("|      ");
                    }
                    Console.Write("|");

                    //draws the horizontal line
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int m = 0; m < 10; m++)
                    {
                        Console.Write("O--  --");
                    }
                    Console.Write("O");
                }
            }
            //check if play is two
            if (currentPlayer == "two")
            {
                //draws the horizontal line
                Console.Write("\n     ");
                for (int m = 0; m < 10; m++)
                {
                    Console.Write("O--  --");
                }
                Console.Write("O");
                //draws the player's board
                for (int i = 0; i < 10; i++)
                {
                    //sets draw counter to i + 1
                    boardCounter = i + 1;
                    //draws the top part of the square
                    Console.WriteLine();
                    Console.Write("  " + boardCounter + "  ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write("|      ");
                    }
                    Console.Write("|");

                    //draws the middle with the player's board
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int k = 0; k < 10; k++)
                    {
                        Console.Write("    " + playerBoardTwo[i, k] + "   ");
                    }

                    //draws the bottom of the square
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int l = 0; l < 10; l++)
                    {
                        Console.Write("|      ");
                    }
                    Console.Write("|");

                    //draws the horizontal line
                    Console.WriteLine();
                    Console.Write("     ");
                    for (int m = 0; m < 10; m++)
                    {
                        Console.Write("O--  --");
                    }
                    Console.Write("O");
                }
            }
        }
        private static void PlayerTurn(string[,] playerBoardOne, string[,] playerBoardTwo, int boardCounter, ref string currentPlayer, ref int xCoordShot, ref int yCoordShot)
        {
            //shows which player turn
            Console.WriteLine("\nCurrent Player: " + currentPlayer);
            if (currentPlayer == "one")
            {
                Console.WriteLine("What x coordinate for shot");
                xCoordShot = Convert.ToInt32(Console.ReadLine());
                //checks if bigger than 0
                if (xCoordShot > 0)
                {
                    //checks if smaller than 11
                    if (xCoordShot < 11)
                    {
                        Console.WriteLine("What y coordinate for shot");
                        yCoordShot = Convert.ToInt32(Console.ReadLine());
                        //checks if bigger than 0
                        if (yCoordShot > 0)
                        {
                            //checks if smaller than 11
                            if (yCoordShot < 11)
                            {
                                
                            }
                            else PlayerTurn(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                        }
                        else PlayerTurn(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                    }
                    else PlayerTurn(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                }
                else PlayerTurn(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
            }
        }
        private static void GameSetup(string[,] playerBoardOne, string[,] playerBoardTwo, ref bool versusAI, ref bool randomBoats, ref string currentPlayer,  ref int boatCoordinateX, ref int boatCoordinateY, ref int boatRotation, ref int xCoordShot, ref int yCoordShot)
        {
            //shows which player turn
            Console.WriteLine("\nCurrent Player: " + currentPlayer);
            Console.WriteLine("VS AI?");
            versusAI = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Would you like your boats randomly placed?");
            randomBoats = Convert.ToBoolean(Console.ReadLine());
            if (randomBoats == true)
            {
                
                if (currentPlayer == "one")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //sets rotation and coordinates of the middle of the boat to a random location
                        boatRotation = new Random().Next(0, 2);
                        boatCoordinateX = new Random().Next(0, 10);
                        boatCoordinateY = new Random().Next(0, 10);
                        //0 = horizontal
                        if (boatRotation == 0)
                        {
                            //checks if its smaller than 10
                            if (boatCoordinateX + 1 < 10)
                            {
                                //checks if bigger than -1
                                if (boatCoordinateX - 1 > -1)
                                {
                                    //if so adds those x coordinates to player one board
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY, boatCoordinateX + 1] = "+";
                                    playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "+";
                                }
                                else
                                {
                                    //since its x is smaller than 0 that means its on the right edge so we'll have the rest of it go to the right
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY, boatCoordinateX + 1] = "+";
                                    playerBoardOne[boatCoordinateY, boatCoordinateX + 2] = "+";
                                }
                            }
                            else
                            {
                                //since its x is bigger than 9 that means its on the left edge so we'll have the rest of it go to the left
                                playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "+";
                                playerBoardOne[boatCoordinateY, boatCoordinateX - 2] = "+";
                            }

                        }
                        //1 = vertical
                        if (boatRotation == 1)
                        {
                            //checks if its smaller than 10
                            if (boatCoordinateY + 1 < 10)
                            {
                                //checks if bigger than -1
                                if (boatCoordinateY - 1 > -1)
                                {
                                    //if so adds those x coordinates to player one board
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY + 1, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY - 1, boatCoordinateX] = "+";
                                }
                                else
                                {
                                    //since its y is smaller than 0 that means its on the bottom edge so we'll have the rest of it go to the down
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY + 1, boatCoordinateX] = "+";
                                    playerBoardOne[boatCoordinateY + 2, boatCoordinateX] = "+";
                                }
                            }
                            else
                            {
                                //since its y is bigger than 9 that means its on the top edge so we'll have the rest of it go to the up
                                playerBoardOne[boatCoordinateY, boatCoordinateX] = "+";
                                playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "+";
                                playerBoardOne[boatCoordinateY, boatCoordinateX - 2] = "+";
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Where would you like to place your ship");
            }
            
        }
    }
}

