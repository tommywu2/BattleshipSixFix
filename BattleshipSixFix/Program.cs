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
            int boatAmount = 0;

            GameSetup(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref randomBoats, ref currentPlayer, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation, ref xCoordShot, ref yCoordShot, ref boatAmount);
            CreateBoard(playerBoardOne, playerBoardTwo, boardCounter, ref currentPlayer);
            PlayerTurn(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
            GameSetup(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref randomBoats, ref currentPlayer, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation, ref xCoordShot, ref yCoordShot, ref boatAmount);
        }

        //makes your own board where you were hit
        private static void CreateBoard(string[,] playerBoardOne, string[,] playerBoardTwo, int boardCounter, ref string currentPlayer)
        {
            //check if play is one
            if (currentPlayer == "one")
            {
                //makes the text blue
                Console.ForegroundColor = ConsoleColor.Blue;
                //draws the numbers
                Console.Write("     ");
                for (int i = 0; i < 10; i++)
                {
                    boardCounter = i + 1;
                    Console.Write("   " + boardCounter + "   ");
                }
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
                        Console.Write("   " + playerBoardOne[i, k] + "   ");
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
                Console.ResetColor();
            }
            //check if play is two
            if (currentPlayer == "two")
            {
                //makes the text blue
                Console.ForegroundColor = ConsoleColor.Red;
                //draws the numbers
                Console.Write("     ");
                for (int i = 0; i < 10; i++)
                {
                    boardCounter = i + 1;
                    Console.Write("   " + boardCounter + "   ");
                }
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
                        Console.Write("   " + playerBoardTwo[i, k] + "   ");
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
                Console.ResetColor();
            }
        }
        private static void PlayerTurn(string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, int boardCounter, ref string currentPlayer, ref int xCoordShot, ref int yCoordShot)
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
                                //make them the proper number since arrays start at 0
                                xCoordShot--;
                                yCoordShot--;
                                if (playerBoardTwo[yCoordShot, xCoordShot] == " ")
                                {
                                    playerOneAttackBoard[yCoordShot, xCoordShot] = "o";
                                    Console.WriteLine("Miss");
                                }
                                else
                                {
                                    playerOneAttackBoard[yCoordShot, xCoordShot] = "x";
                                    Console.WriteLine("Hit Boat " + playerBoardTwo[yCoordShot, xCoordShot]);
                                                                    }
                            }
                            else PlayerTurn(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                        }
                        else PlayerTurn(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                    }
                    else PlayerTurn(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
                }
                else PlayerTurn(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot);
            }
        }
        private static void GameSetup(string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, ref bool versusAI, ref bool randomBoats, ref string currentPlayer, ref int boatCoordinateX, ref int boatCoordinateY, ref int boatRotation, ref int xCoordShot, ref int yCoordShot, ref int boatAmount)
        {
            //sets all the boards to blank
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    playerBoardOne[i, j] = " ";
                    playerBoardTwo[i, j] = " ";
                    playerOneAttackBoard[i, j] = " ";
                    playerTwoAttackBoard[i, j] = " ";
                }
            }
            
            //shows which player turn
            Console.WriteLine("\nCurrent Player: " + currentPlayer);
            Console.WriteLine("VS AI?");
            versusAI = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Would you like your boats randomly placed?");
            randomBoats = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("How many boats do you want?");
            boatAmount = Convert.ToInt32(Console.ReadLine());
            //make a random local variable for random placement
            Random rnd = new Random();

            if (currentPlayer == "one")
            {

                if (randomBoats == true)
                {

                    for (int i = 0; i < boatAmount;)
                    {

                        //sets rotation and coordinates of the middle of the boat to a random location
                        boatRotation = rnd.Next(0, 2);
                        boatCoordinateX = rnd.Next(0, 10);
                        boatCoordinateY = rnd.Next(0, 10);

                        //0 = horizontal
                        if (boatRotation == 0)
                        {
                            //checks if its smaller than 10
                            if (boatCoordinateX + 1 < 10)
                            {
                                //checks if bigger than -1
                                if (boatCoordinateX - 1 > -1)
                                {
                                    //checks if those spots are not occupied
                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX - 1] == " ")
                                    {
                                        //if so adds those x coordinates to player one board
                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                        i++;
                                    }

                                }
                                else
                                {
                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX + 2] == " ")
                                    {
                                        //since its x is smaller than 0 that means its on the right edge so we'll have the rest of it go to the right
                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY, boatCoordinateX + 2] = "" + (i + 1);
                                        i++;
                                    }

                                }
                            }
                            else
                            {
                                if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX - 1] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX - 2] == " ")
                                {
                                    //since its x is bigger than 9 that means its on the left edge so we'll have the rest of it go to the left
                                    i.ToString("0000");
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                    playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                    playerBoardOne[boatCoordinateY, boatCoordinateX - 2] = "" + (i + 1);
                                    i++;
                                }

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
                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY - 1, boatCoordinateX] == " ")
                                    {
                                        //if so adds those x coordinates to player one board
                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY + 1, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                        i++;
                                    }

                                }
                                else
                                {
                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY + 2, boatCoordinateX] == " ")
                                    {
                                        //since its y is smaller than 0 that means its on the bottom edge so we'll have the rest of it go to the down
                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY + 1, boatCoordinateX] = "" + (i + 1);
                                        playerBoardOne[boatCoordinateY + 2, boatCoordinateX] = "" + (i + 1);
                                        i++;
                                    }

                                }
                            }
                            else
                            {
                                if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY - 1, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY - 2, boatCoordinateX] == " ")
                                {
                                    //since its y is bigger than 9 that means its on the top edge so we'll have the rest of it go to the up
                                    playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                    playerBoardOne[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                    playerBoardOne[boatCoordinateY - 2, boatCoordinateX] = "" + (i + 1);
                                    i++;
                                }

                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < boatAmount;)
                    {
                        Console.WriteLine("Where would you like to place your ship x");
                        boatCoordinateX = Convert.ToInt32(Console.ReadLine());

                        //checks if bigger than 0
                        if (boatCoordinateX > 0)
                        {
                            //checks if smaller than 11
                            if (boatCoordinateX < 11)
                            {
                                Console.WriteLine("Where would you like to place your ship y");
                                boatCoordinateY = Convert.ToInt32(Console.ReadLine());

                                //checks if bigger than 0
                                if (boatCoordinateY > 0)
                                {
                                    //checks if smaller than 11
                                    if (boatCoordinateY < 11)
                                    {
                                        //make them the proper number since arrays start at 0
                                        boatCoordinateX--;
                                        boatCoordinateY--;
                                        Console.WriteLine("What rotation do you want? 0. for horizontal 1. for vertical");
                                        boatRotation = Convert.ToInt32(Console.ReadLine());

                                        //0 = horizontal
                                        if (boatRotation == 0)
                                        {
                                            //checks if its smaller than 10
                                            if (boatCoordinateX + 1 < 10)
                                            {
                                                //checks if bigger than -1
                                                if (boatCoordinateX - 1 > -1)
                                                {
                                                    //checks if those spots are not occupied
                                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardOne[boatCoordinateY, boatCoordinateX - 1] == " ")
                                                    {
                                                        //if so adds those x coordinates to player one board
                                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                                        playerBoardOne[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                                        playerBoardOne[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                                        i++;
                                                    }
                                                }
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
                                                    if (playerBoardOne[boatCoordinateY, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardOne[boatCoordinateY - 1, boatCoordinateX] == " ")
                                                    {
                                                        //if so adds those x coordinates to player one board
                                                        playerBoardOne[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                                        playerBoardOne[boatCoordinateY + 1, boatCoordinateX] = "" + (i + 1);
                                                        playerBoardOne[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                                        i++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (currentPlayer == "two")
            {

            }
        }
    }
}