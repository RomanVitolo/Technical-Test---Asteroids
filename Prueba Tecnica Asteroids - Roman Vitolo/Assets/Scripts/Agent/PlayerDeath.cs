using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        /*Destroy(this.gameObject,1f);
        GameSettings.Instance.PlayerDieEvent();*/
    }
}
