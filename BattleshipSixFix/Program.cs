using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleshipSixFix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            Random rnd = new Random();
            string[,] playerBoardOne = new string[10, 10];
            string[,] playerBoardTwo = new string[10, 10];
            string[,] playerOneAttackBoard = new string[10, 10];
            string[,] playerTwoAttackBoard = new string[10, 10];
            bool versusAI = false;
            bool randomBoats = false;
            bool aiCheating = false;
            string currentPlayer = "one";
            int boatRotation = 0;
            int boatCoordinateX = 0;
            int boatCoordinateY = 0;
            int boardCounter = 0;
            int xCoordShot = 0;
            int yCoordShot = 0;
            int boatAmount = 0;
            int playerOneHits = 0;
            int playerTwoHits = 0;

            GameSetup(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, ref randomBoats, ref currentPlayer, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation, ref xCoordShot, ref yCoordShot, ref boatAmount, ref boardCounter, ref playerOneHits, ref playerTwoHits);

        }

        //makes your own board where you were hit and your boats
        private static void CreateBoard(string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, int boardCounter, ref string currentPlayer)
        {
            //check if play is one
            if (currentPlayer == "one")
            {
                //makes the text blue
                Console.ForegroundColor = ConsoleColor.Blue;
                //draws the numbers
                Console.Write("Player One Board\n     ");
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
                Console.Write("Player Two Board\n     ");
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
        private static void PlayerTurn(ref Random rnd, string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, ref bool versusAI, ref bool aiCheating, int boardCounter, ref string currentPlayer, ref int xCoordShot, ref int yCoordShot, ref int boatAmount, ref int playerOneHits, ref int playerTwoHits, ref bool randomBoats, ref int boatCoordinateX, ref int boatCoordinateY, ref int boatRotation)
        {
            //variables and other useful things
            string playAgain = null;
            string hitAreaLetter = null;

            //checks if any player has hit all enemy boats
            if (playerOneHits == boatAmount * 3 || playerTwoHits == boatAmount * 3)
            {
                Console.Clear();

                if (playerOneHits == boatAmount * 3)
                {
                    Console.WriteLine("Player One Wins");
                }

                if (playerTwoHits == boatAmount * 3)
                {
                    Console.WriteLine("Player Two Wins");
                }

                Thread.Sleep(500);
                Console.WriteLine("Do you want to play again?");
                playAgain = Convert.ToString(Console.ReadLine());
                if (playAgain == "yes")
                {
                    Console.Clear();
                    GameSetup(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, ref randomBoats, ref currentPlayer, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation, ref xCoordShot, ref yCoordShot, ref boatAmount, ref boardCounter, ref playerOneHits, ref playerTwoHits);
                }
                else
                {
                    //close the application
                    Environment.Exit(0);
                }

            }

            //checks if versing ai and player is two since player two is ai
            if (versusAI == true && currentPlayer == "two")
            {
                xCoordShot = rnd.Next(0, 10);
                yCoordShot = rnd.Next(0, 10);
            }

            //checks player is one or its player two but not versing ai thus being a player
            if (currentPlayer == "one" || (currentPlayer == "two" && versusAI == false))
            {
                //if not versing ai it doesnt show the code unless enter is press to allow the computer to be pass to other player
                if (versusAI == false)
                {
                    Console.WriteLine("Press Enter to show Player " + currentPlayer + " board");
                    Console.ReadLine();
                }
                //creates the players board and the attack board
                Thread.Sleep(500);
                CreateBoard(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer);
                Console.WriteLine("\nPress Enter to go to Attack Phase");
                Console.ReadLine();
                //clears the top scrollable part
                Console.WriteLine("\x1b[3J");
                Console.Clear();
                Thread.Sleep(500);
                CreateAttackBoard(playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, boardCounter, ref currentPlayer);

            }

            //this where the action happens with the ai logic
            if (versusAI == true && currentPlayer == "two")
            {
                
                
                if (aiCheating == false)
                {
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.WriteLine("Current Player: " + currentPlayer);
                    Thread.Sleep(500);
                    Console.WriteLine("Shot x: " + (xCoordShot + 1) + " y: " + (yCoordShot + 1));
                }
                if (playerBoardOne[yCoordShot, xCoordShot] == "o" || playerBoardOne[yCoordShot, xCoordShot] == "x")
                {
                    if (aiCheating == false)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Already shot there try again");
                    }
                    PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);

                }
                if (playerBoardOne[yCoordShot, xCoordShot] == " ")
                {
                    if (aiCheating == false)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Miss");
                        playerTwoAttackBoard[yCoordShot, xCoordShot] = "o";
                        playerBoardOne[yCoordShot, xCoordShot] = "o";
                    }
                    if (aiCheating == true)
                    {
                        PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
                    }

                }
                else
                {
                    if (aiCheating == true)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Current Player: " + currentPlayer);
                        Thread.Sleep(500);
                        Console.WriteLine("Shot x: " + (xCoordShot + 1) + " y: " + (yCoordShot + 1));
                    }
                    //changes the score of hits
                    playerTwoHits++;
                    Thread.Sleep(500);
                    Console.WriteLine("Hit Boat " + playerBoardOne[yCoordShot, xCoordShot]);
                    playerTwoAttackBoard[yCoordShot, xCoordShot] = "x";
                    playerBoardOne[yCoordShot, xCoordShot] = "x";

                }

                if (currentPlayer == "one")
                {
                    //changes to next player
                    currentPlayer = "two";
                }
                else
                {
                    //changes to next player
                    currentPlayer = "one";
                }
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Shot x: " + (xCoordShot + 1) + " y: " + (yCoordShot + 1));
                //let other player go
                PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);

            }

            //your attacking and all that
            if (currentPlayer == "one" || (currentPlayer == "two" && versusAI == false))
            {
                //shows which player turn
                Thread.Sleep(500);
                Console.WriteLine("\nCurrent Player: " + currentPlayer);

                Thread.Sleep(500);
                Console.WriteLine("What x coordinate for shot");
                xCoordShot = Convert.ToInt32(Console.ReadLine());

                //checks if x is bigger than 0 and smaller than 11
                if (xCoordShot > 0 && xCoordShot < 11)
                {
                    //makes it the proper number for the array since array starts at 0
                    xCoordShot--;

                    Thread.Sleep(500);
                    Console.WriteLine("What y coordinate for shot");
                    yCoordShot = Convert.ToInt32(Console.ReadLine());

                    //checks if y is bigger than 0 and smaller than 11
                    if (yCoordShot > 0 && yCoordShot < 11)
                    {
                        //makes it the proper number for the array since array starts at 0
                        yCoordShot--;
                        //clears the top scrollable part
                        Console.WriteLine("\x1b[3J");
                        Console.Clear();
                        Thread.Sleep(500);
                        Console.WriteLine("Player: " + currentPlayer + " shot x: " + (xCoordShot + 1) + " y: " + (yCoordShot + 1));
                        Thread.Sleep(500);

                        //checks if the spot is a boat, has been hit or nothing and than reports it
                        if (currentPlayer == "one")
                        {
                            if (playerBoardTwo[yCoordShot, xCoordShot] == "o" || playerBoardTwo[yCoordShot, xCoordShot] == "x")
                            {
                                Console.WriteLine("Already shot there try again");
                                PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
                            }
                            if (playerBoardTwo[yCoordShot, xCoordShot] == " ")
                            {
                                Console.WriteLine("Miss");
                                //sets the letter to o
                                hitAreaLetter = "o";

                            }
                            else
                            {
                                //changes the score of hits
                                playerOneHits++;
                                Console.WriteLine("Hit Boat " + playerBoardTwo[yCoordShot, xCoordShot]);
                                //sets the letter to x
                                hitAreaLetter = "x";

                            }
                            //puts the letter on the board
                            playerOneAttackBoard[yCoordShot, xCoordShot] = hitAreaLetter;
                            playerBoardTwo[yCoordShot, xCoordShot] = hitAreaLetter;

                        }

                        if (currentPlayer == "two")
                        {
                            if (playerBoardOne[yCoordShot, xCoordShot] == "o" || playerBoardOne[yCoordShot, xCoordShot] == "x")
                            {
                                Console.WriteLine("Already shot there try again");
                                PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
                            }
                            if (playerBoardOne[yCoordShot, xCoordShot] == " ")
                            {
                                Console.WriteLine("Miss");
                                //sets the letter to o
                                hitAreaLetter = "o";

                            }
                            else
                            {
                                //changes the score of hits
                                playerTwoHits++;
                                Console.WriteLine("Hit Boat " + playerBoardOne[yCoordShot, xCoordShot]);
                                //sets the letter to x
                                hitAreaLetter = "x";

                            }
                            playerTwoAttackBoard[yCoordShot, xCoordShot] = hitAreaLetter;
                            playerBoardOne[yCoordShot, xCoordShot] = hitAreaLetter;

                        }

                        if (currentPlayer == "one")
                        {
                            //changes to player two since turn is over
                            currentPlayer = "two";

                        }
                        else
                        {
                            //changes to player one since turn is over
                            currentPlayer = "one";

                        }
                        
                        Thread.Sleep(2000);
                        if (versusAI == true)
                        {
                            Console.Clear();
                        }

                        //let other player go
                        PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
                    }
                    else PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
                }
                else PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
            }
        }
        private static void GameSetup(ref Random rnd, string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, ref bool versusAI, ref bool randomBoats, ref bool aiCheating, ref string currentPlayer, ref int boatCoordinateX, ref int boatCoordinateY, ref int boatRotation, ref int xCoordShot, ref int yCoordShot, ref int boatAmount, ref int boardCounter, ref int playerOneHits, ref int playerTwoHits)
        {
            //sets all variables to default
            Console.Clear();
            rnd = new Random();
            versusAI = false;
            randomBoats = false;
            aiCheating = false;
            currentPlayer = "one";
            boatRotation = 0;
            boatCoordinateX = 0;
            boatCoordinateY = 0;
            boardCounter = 0;
            xCoordShot = 0;
            yCoordShot = 0;
            boatAmount = 0;
            playerOneHits = 0;
            playerTwoHits = 0;

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

            Thread.Sleep(500);
            Console.WriteLine("Game Setup");
            Console.WriteLine("VS AI? true/false");
            versusAI = Convert.ToBoolean(Console.ReadLine());
            if (versusAI == true)
            {
                Console.WriteLine("Hard AI? true/false");
                aiCheating = Convert.ToBoolean(Console.ReadLine());
            }
            Thread.Sleep(500);
            Console.WriteLine("How many boats do you want?");
            boatAmount = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(500);
            Console.WriteLine("Would you like the boats randomly placed? true/false");
            randomBoats = Convert.ToBoolean(Console.ReadLine());
            Thread.Sleep(500);
            Console.Clear();

            if (versusAI == true || randomBoats == true)
            {
                //player two boat randomisation
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
                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] == " ")
                                {
                                    //if so adds those x coordinates to player one board
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                    i++;
                                }

                            }
                            else
                            {
                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX + 2] == " ")
                                {
                                    //since its x is smaller than 0 that means its on the right edge so we'll have the rest of it go to the right
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX + 2] = "" + (i + 1);
                                    i++;
                                }

                            }
                        }
                        else
                        {
                            if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX - 2] == " ")
                            {
                                //since its x is bigger than 9 that means its on the left edge so we'll have the rest of it go to the left
                                playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                playerBoardTwo[boatCoordinateY, boatCoordinateX - 2] = "" + (i + 1);
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
                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] == " ")
                                {
                                    //if so adds those x coordinates to player one board
                                    playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY + 1, boatCoordinateX] = "" + (i + 1);
                                    playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                    i++;
                                }

                            }
                            else
                            {
                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY + 2, boatCoordinateX] == " ")
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
                            if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY - 2, boatCoordinateX] == " ")
                            {
                                //since its y is bigger than 9 that means its on the top edge so we'll have the rest of it go to the up
                                playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                playerBoardTwo[boatCoordinateY - 2, boatCoordinateX] = "" + (i + 1);
                                i++;
                            }

                        }
                    }
                }
            }
            if (randomBoats == true)
            {
                //player one boat randomisation
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
            if (randomBoats == false)
            {
                //player one boat placement
                Console.WriteLine("Boat Placement Player One");
                for (int i = 0; i < boatAmount;)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("What x coordinate would you like for the middle of your ship");
                    boatCoordinateX = Convert.ToInt32(Console.ReadLine());

                    //checks if bigger than 0
                    if (boatCoordinateX > 0)
                    {
                        //checks if smaller than 11
                        if (boatCoordinateX < 11)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("What y coordinate would you like for the middle of your ship");
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
                                    Thread.Sleep(1000);
                                    Console.WriteLine("What rotation for the ship do you want? 0. for horizontal 1. for vertical");
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
                                            //if not tells player to try again
                                            else
                                            {
                                                Console.WriteLine("Invalid Position: Place Again");
                                            }
                                        }
                                        //if not tells player to try again
                                        else
                                        {
                                            Console.WriteLine("Invalid Position: Place Again");
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
                                                //if not tells player to try again
                                                else
                                                {
                                                    Console.WriteLine("Invalid Position: Place Again");
                                                }
                                            }
                                            //if not tells player to try again
                                            else
                                            {
                                                Console.WriteLine("Invalid Position: Place Again");
                                            }
                                        }
                                        //if not tells player to try again
                                        else
                                        {
                                            Console.WriteLine("Invalid Position: Place Again");
                                        }
                                    }
                                }
                                else
                                {
                                    //says that coordinate is invalid
                                    Console.WriteLine("Y Coordinate Invalid");
                                }
                            }
                            else
                            {
                                //says that coordinate is invalid
                                Console.WriteLine("Y Coordinate Invalid");
                            }
                        }
                        else
                        {
                            //says that coordinate is invalid
                            Console.WriteLine("X Coordinate Invalid");
                        }
                    }
                    else
                    {
                        //says that coordinate is invalid
                        Console.WriteLine("X Coordinate Invalid");
                    }
                }

            }
            if (versusAI == false && randomBoats == false)
            {
                //place two boat placement
                Console.WriteLine("Boat Placement Player Two");
                for (int i = 0; i < boatAmount;)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("What x coordinate would you like for the middle of your ship");
                    boatCoordinateX = Convert.ToInt32(Console.ReadLine());

                    //checks if bigger than 0
                    if (boatCoordinateX > 0)
                    {
                        //checks if smaller than 11
                        if (boatCoordinateX < 11)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("What y coordinate would you like for the middle of your ship");
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
                                    Thread.Sleep(1000);
                                    Console.WriteLine("What rotation for the ship do you want? 0. for horizontal 1. for vertical");
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
                                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] == " " && playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] == " ")
                                                {
                                                    //if so adds those x coordinates to player one board
                                                    playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                                    playerBoardTwo[boatCoordinateY, boatCoordinateX + 1] = "" + (i + 1);
                                                    playerBoardTwo[boatCoordinateY, boatCoordinateX - 1] = "" + (i + 1);
                                                    i++;
                                                }
                                            }
                                            //if not tells player to try again
                                            else
                                            {
                                                Console.WriteLine("Invalid Position: Place Again");
                                            }
                                        }
                                        //if not tells player to try again
                                        else
                                        {
                                            Console.WriteLine("Invalid Position: Place Again");
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
                                                if (playerBoardTwo[boatCoordinateY, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY + 1, boatCoordinateX] == " " && playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] == " ")
                                                {
                                                    //if so adds those x coordinates to player one board
                                                    playerBoardTwo[boatCoordinateY, boatCoordinateX] = "" + (i + 1);
                                                    playerBoardTwo[boatCoordinateY + 1, boatCoordinateX] = "" + (i + 1);
                                                    playerBoardTwo[boatCoordinateY - 1, boatCoordinateX] = "" + (i + 1);
                                                    i++;
                                                }
                                            }
                                            //if not tells player to try again
                                            else
                                            {
                                                Console.WriteLine("Invalid Position: Place Again");
                                            }
                                        }
                                        //if not tells player to try again
                                        else
                                        {
                                            Console.WriteLine("Invalid Position: Place Again");
                                        }
                                    }
                                }
                                else
                                {
                                    //says that coordinate is invalid
                                    Console.WriteLine("Y Coordinate Invalid");
                                }
                            }
                            else
                            {
                                //says that coordinate is invalid
                                Console.WriteLine("Y Coordinate Invalid");
                            }
                        }
                        else
                        {
                            //says that coordinate is invalid
                            Console.WriteLine("X Coordinate Invalid");
                        }
                    }
                    else
                    {
                        //says that coordinate is invalid
                        Console.WriteLine("X Coordinate Invalid");
                    }
                }
            }

            //starts the game
            PlayerTurn(ref rnd, playerBoardOne, playerBoardTwo, playerOneAttackBoard, playerTwoAttackBoard, ref versusAI, ref aiCheating, boardCounter, ref currentPlayer, ref xCoordShot, ref yCoordShot, ref boatAmount, ref playerOneHits, ref playerTwoHits, ref randomBoats, ref boatCoordinateX, ref boatCoordinateY, ref boatRotation);
        }
        private static void CreateAttackBoard(string[,] playerBoardOne, string[,] playerBoardTwo, string[,] playerOneAttackBoard, string[,] playerTwoAttackBoard, int boardCounter, ref string currentPlayer)
        {
            //check if play is one
            if (currentPlayer == "one")
            {
                //makes the text blue
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                //draws the numbers
                Console.Write("Player One Attack Board\n     ");
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
                        Console.Write("   " + playerOneAttackBoard[i, k] + "   ");
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //draws the numbers
                Console.Write("Player Two Attack Board\n     ");
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
                        Console.Write("   " + playerTwoAttackBoard[i, k] + "   ");
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
    }
}
