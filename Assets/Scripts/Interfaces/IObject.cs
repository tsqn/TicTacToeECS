using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface IObject
    {
        object Instantiate(int id);

        public object Instantiate(int id, Vector3 vector3);
    }
}