using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Logic : ILogic
    {
        private Random random;
        public bool GameIsOver { get; }

        public Logic()
        {
            board = new char[3, 3];
            random = new(new DateTime().Millisecond);
        }
        private char[,] board;
        public char[,] Board { get; }
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

        private void PlayerPlace(int row, int column)
        {
            board[row, column] = 'x';
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
        }
        public void BoardClick(int row, int col)
        {

        }
    }
}
