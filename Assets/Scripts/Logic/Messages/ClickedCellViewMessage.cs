using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class ClickedCellViewMessage : IMessage
    {
        public int Entity { get; set; }
    }
}