using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _gameScore;

   public void GameScore()
   {
      _gameScore.text = GameSettings.Instance.ScoreValue.ToString();
   }
}
