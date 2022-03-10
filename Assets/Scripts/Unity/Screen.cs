using Interfaces;
using UnityEngine;

namespace Unity
{
    public class Screen : MonoBehaviour, IScreen
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}