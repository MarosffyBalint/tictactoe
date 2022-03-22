namespace tictactoe
{
    public interface ILogic
    {
        char[,] Board { get; }
        bool GameIsOver { get; }
        void Reset();
        void BoardClick(int row, int col);
    }
}