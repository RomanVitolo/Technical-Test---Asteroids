using GlobalSettings;
using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerDeath : MonoBehaviour, IDie
    {
        public void Die()
        {
            Destroy(gameObject);
            GameSettings.Instance.TriggerGameOverEvents();
        }
    }
}
