using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour, IDie
{
    [SerializeField] private AsteroidDataSO _asteroidData;
    public void Die()
    {
        this.gameObject.SetActive(false);
        ObjectPooler.Instance.GetAllPooledObjects(_asteroidData.index);
        GameSettings.Instance.ScoreValue += _asteroidData.ScoreValue;
        GameSettings.Instance.UpdateGameScore();
    }
}
