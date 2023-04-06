using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    private bool gameIsPaused;

    public void ActiveText()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}
