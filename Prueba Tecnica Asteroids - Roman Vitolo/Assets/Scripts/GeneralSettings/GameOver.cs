using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    
    public void ActiveText() => _gameOverText.gameObject.SetActive(true);
}
