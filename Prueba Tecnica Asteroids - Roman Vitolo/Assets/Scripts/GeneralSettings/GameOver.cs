using TMPro;
using UnityEngine;

namespace GlobalSettings
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gameOverText;
    
        public void ActiveText() => _gameOverText.gameObject.SetActive(true);
    }
}
