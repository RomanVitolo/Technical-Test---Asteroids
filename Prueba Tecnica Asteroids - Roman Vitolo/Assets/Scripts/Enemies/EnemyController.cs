using UnityEngine;

public class EnemyController : MonoBehaviour, IDie
{
    [Header("Get Asteroid DataType")]
    [SerializeField] private AsteroidDataSO _asteroidData;
    public void Die()
    {
        this.gameObject.SetActive(false);
        GameSettings.Instance.ScoreValue += _asteroidData.ScoreValue;
        GameSettings.Instance.UpdateGameScore();
    }
}
