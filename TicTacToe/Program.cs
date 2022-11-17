using System;
using System.Numerics;
namespace TIC_TAC_TOE
{
    class Program
    {
       
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //Array needed to show in what location the player wants to place x or o.
        static int player = 1; 

        static string player1 = "", player2 = "";
        static int choice; 
        //This holds the choice at which position user want to mark.

        static int flag = 0;
        //Flag checks who has won or lost .  1 won , -1 draw , if 0 the game is still running.

        

        static void Main(string[] args)
        {
             Console.WriteLine("Hello, in this proggram you can play Tic Tac Toe !\n");  
                Console.WriteLine("The first player is x, the second is O.");
                Console.WriteLine("Players take turns putting their marks in the  squares they want by pracing the number in the square. \n");             
                Console.WriteLine("The first player to get 3 of hes marks in a row (up, down, across, or diagonally) is the winner.");
                Console.WriteLine("When all 9 squares are full, the game is over.(no winners)\n");
                Console.WriteLine("What is the name of player 1?");
                player1 = Console.ReadLine();
                Console.WriteLine("Very good. What is the name of player 2?");
                player2 = Console.ReadLine();
                Console.WriteLine("Okay good. {0} is X and {1} is O." , player1, player2);
                Console.WriteLine("{0} goes first." , player1);
                Console.ReadLine();
            do
            {
                Console.Clear();
                // in order to make the game feel responsive , clear deletes the previous resaults and shows the last board .

               
                
                if (player % 2 == 0)//checking the whos turn it is.
                {
                    Console.WriteLine("{0} is choosing a square",player2);
                }
                else
                {
                    Console.WriteLine("{0} is choosing a square\n" , player1);
                }
              
                Board();// calling the board Function.
                choice = int.Parse(Console.ReadLine());//Taking users choice of what square he chooses .
                
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //if the turn is of player 2 then mark O else mark X.
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                // checking if the position where user want to run is marked already.
                //if its marked it lets the player choose again.
                {
                    Console.WriteLine("Sorry the square {0} is already marked with {1}\n", choice, arr[choice]);
                    Console.WriteLine("choose another square which is not picked yet. ");
                    Thread.Sleep(5000);//gives the massage 5 sec to disapear.
                }
                flag = CheckWin();// calling of check win.
            }
            while (flag != 1 && flag != -1);
            //Flag checks who has won or lost .  1 won , -1 draw , if 0 the game is still running(as mantioned above).
            // This loop will run until some one wins or  all the squares will be marked .
            Console.Clear();
            Board();// getting filled board again.

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }

            else
            {
                Console.WriteLine("no winners , try again!.");
            }

            Console.ReadLine();
        }
        // The board - design + gets the array in every square
        static void Board()
        {
            Console.WriteLine(" _______________________");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", arr[1], arr[2], arr[3]);
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|-------|-------|-------|");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", arr[4], arr[5], arr[6]);
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|-------|-------|-------|");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", arr[7], arr[8], arr[9]);
            Console.WriteLine("|_______|_______|_______|");

        }

        //Ways to win the game
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning condition : for  rows
            if (arr[1] == arr[2] && arr[2] == arr[3]) { return 1; }       

            else if (arr[4] == arr[5] && arr[5] == arr[6]) { return 1; }

            else if (arr[6] == arr[7] && arr[7] == arr[8]) { return 1; }
           
            #endregion
            #region vertical Winning Condtion
            //columns
            else if (arr[1] == arr[4] && arr[4] == arr[7]) { return 1; }

            else if (arr[2] == arr[5] && arr[5] == arr[8]) { return 1;}

            else if (arr[3] == arr[6] && arr[6] == arr[9]) { return 1; }
          
            #endregion
            #region diognal winning condition
            //diognal
            else if (arr[1] == arr[5] && arr[5] == arr[9]) { return 1; }

            else if (arr[3] == arr[5] && arr[5] == arr[7]) { return 1; }

            #endregion
            #region Checking For Draw
            // If all the cells or values filled with X or O then no wone has won.
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9') { return -1; }
        
            #endregion
            else { return 0; }
           
        }
    }
}

       
    


