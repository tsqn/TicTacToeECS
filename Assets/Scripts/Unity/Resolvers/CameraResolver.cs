using TicTacToe.Logic.Messages;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace TicTacToe.Unity.Resolvers
{
    public class CameraResolver
    {
        public static void SetCameraSettings(ApplyCameraSettingsMessage message)
        {
            var camera = Camera.main;

            Assert.IsNotNull(camera);

            camera.orthographic = message.Orthographic;
            camera.orthographicSize = message.OrthographicSize;
            camera.transform.position = message.Position.Convert();
        }
    }
}