using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TicTacToe.Unity.Decorators
{
    public class CameraDecorator : MonoDecorator, ICamera
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        public bool Orthographic
        {
            get => _camera.orthographic;
            set => _camera.orthographic = value;
        }

        public float OrthographicSize
        {
            get => _camera.orthographicSize;
            set => _camera.orthographicSize = value;
        }

        public IRay ScreenPointToRay(Vector3 mousePosition)
        {
            return new RayDecorator(_camera.ScreenPointToRay(mousePosition.Convert()));
        }
    }

    public class RayDecorator : IRay
    {
        private readonly Ray _ray;


        public RayDecorator(Ray screenPointToRay)
        {
            _ray = screenPointToRay;
        }

        public Vector3 Origin => _ray.origin.Convert();
        public Vector3 Destination => _ray.direction.Convert();
    }
}