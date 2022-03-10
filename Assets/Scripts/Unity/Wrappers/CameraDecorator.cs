using Interfaces;
using Unity.Extensions;
using UnityEngine;

namespace Unity.Wrappers
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

        public IRay ScreenPointToRay(System.Numerics.Vector3 mousePosition)
        {
            return new RayDecorator(_camera.ScreenPointToRay(mousePosition.Convert()));
        }

        public Ray ScreenPointToRay(Vector3 mousePosition)
        {
            return _camera.ScreenPointToRay(mousePosition);
        }
    }

    public class RayDecorator : IRay
    {
        private readonly Ray _ray;


        public RayDecorator(Ray screenPointToRay)
        {
            _ray = screenPointToRay;
        }

        public System.Numerics.Vector3 Origin => _ray.origin.Convert();
        public System.Numerics.Vector3 Destination => _ray.direction.Convert();
    }
}