using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class DeleteSignMessage : IMessage
    {
        public int Id { get; set; }
    }
}