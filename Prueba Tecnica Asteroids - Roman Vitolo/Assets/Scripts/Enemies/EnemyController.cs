using UnityEngine;

public class EnemyController : MonoBehaviour, IDie
{
    [SerializeField] private AsteroidDataSO _asteroidData;
    public void Die()
    {
        this.gameObject.SetActive(false);
        GameSettings.Instance.ScoreValue += _asteroidData.ScoreValue;
        GameSettings.Instance.UpdateGameScore();
    }
}
