using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        Destroy(gameObject);
        GameSettings.Instance.TriggerGameOverEvents();
    }
}
