using UnityEngine;

namespace Systems
{
    public class Screen : MonoBehaviour
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}