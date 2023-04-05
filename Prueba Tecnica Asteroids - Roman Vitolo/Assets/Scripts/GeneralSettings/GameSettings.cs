using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    [field: SerializeField] public UnityEvent OnPlayerDie { get; set; }
    [field: SerializeField] public UnityEvent OnScoreChange { get; set; }

    [field: SerializeField] public BigInteger ScoreValue { get; set; }
   
    private void Awake()
    {
        Instance = this;
        if (Instance != null)
        {
            Destroy(this);
        }
    }

    public void PlayerDieEvent()
    {
        OnPlayerDie?.Invoke();
    }

    public void UpdateGameScore()
    {
        OnScoreChange?.Invoke();
    }
}
