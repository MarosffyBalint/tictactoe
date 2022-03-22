namespace tictactoe
{
    public interface ILogic
    {
        char[,] Board { get; }
        bool GameIsOver { get; }

        void BoardClick(int row, int col);
    }
}