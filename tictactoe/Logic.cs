using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Logic : ILogic
    {
        private Random random;
        public bool GameIsOver { get; private set; }

        public Logic()
        {
            board = new char[3, 3];
            random = new(new DateTime().Millisecond);
            GameIsOver = false;
        }
        private char[,] board;
        public char[,] Board { get { return board; } private set { board = value; } }
        private bool CheckWin(char symbol)
        {
            if ((board[0, 0] == symbol && board[0, 1] == symbol && board[0, 2] == symbol) ||
                (board[1, 0] == symbol && board[1, 1] == symbol && board[1, 2] == symbol) ||
                (board[2, 0] == symbol && board[2, 1] == symbol && board[2, 2] == symbol) ||
                (board[0, 0] == symbol && board[1, 0] == symbol && board[2, 0] == symbol) ||
                (board[0, 1] == symbol && board[1, 1] == symbol && board[2, 1] == symbol) ||
                (board[0, 2] == symbol && board[1, 2] == symbol && board[2, 2] == symbol) ||
                (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
                (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol))
                return true;
            else return false;
        }

        private bool CheckFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'x' && board[i, j] != 'o')
                        return false ;
                }
            }
            return true;
        }
        private void AiPlace()
        {
            string boardEmpty = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'x' && board[i, j] != 'o')
                        boardEmpty += ' ';
                }
            }
            int chosen = random.Next(0, boardEmpty.Length);
            int current = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'x' && board[i, j] != 'o')
                    {
                        if (current == chosen)
                        {
                            board[i, j] = 'o';
                            return;
                        }
                        else current++;
                    }
                }
            }
        }
        public void BoardClick(int row, int col)
        {
            if (board[row, col] != 'x' && board[row, col] != 'o' && !GameIsOver)
            {
                board[row, col] = 'x';
                GameIsOver = CheckWin('x') || CheckFull();
                if (!GameIsOver)
                {
                    Thread.Sleep(500);
                    AiPlace();
                    GameIsOver = CheckWin('o') || CheckFull();
                }
            }
        }

        public void Reset()
        {
            board = new char[3, 3];
            random = new(new DateTime().Millisecond);
            GameIsOver = false;
        }
    }
}
