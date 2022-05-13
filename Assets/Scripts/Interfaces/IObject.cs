using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface IObject
    {
        object Instantiate(int id);

        void Destroy();

        object Instantiate(int id, Vector3 vector3);
    }
}