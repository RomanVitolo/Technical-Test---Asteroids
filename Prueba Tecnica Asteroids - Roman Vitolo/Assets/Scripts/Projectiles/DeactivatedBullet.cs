using UnityEngine;

namespace ProjectileBehaviour
{
    public class DeactivatedBullet : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}

