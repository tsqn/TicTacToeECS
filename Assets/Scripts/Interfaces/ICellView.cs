namespace TicTacToe.Interfaces
{
    public interface ICellView : ITransform, IObject
    {
        public int Entity { get; set; }
    }
}