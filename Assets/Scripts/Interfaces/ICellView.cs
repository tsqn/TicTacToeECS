using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface ICellView : ITransform, IObject
    {
        public int Entity { get; set; }
        
    }
    
    public interface IObject
    {
        object Instantiate();
        
        public object Instantiate(Vector3 vector3);
    }
}