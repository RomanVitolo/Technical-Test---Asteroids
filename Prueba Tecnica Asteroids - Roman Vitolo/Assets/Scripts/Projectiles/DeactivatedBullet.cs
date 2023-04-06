
using UnityEngine;

public class DeactivatedBullet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
