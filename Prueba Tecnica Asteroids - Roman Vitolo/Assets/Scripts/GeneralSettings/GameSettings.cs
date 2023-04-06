using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    
    [field: SerializeField] public BigInteger ScoreValue { get; set; }
    [field: SerializeField] public UnityEvent OnPlayerDie { get; set; }
    [field: SerializeField] public UnityEvent OnScoreChange { get; set; }
    [field: SerializeField] public UnityEvent OnShowGameOverUI { get; set; }

    private void Awake() =>  Instance = this;

    public void TriggerGameOverEvents()
    {
        ShowGameOverText();
        StartCoroutine(WaitForLoadScene(2f));
    }

    private IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        PlayerDieEvent();
    }

    private void PlayerDieEvent() =>  OnPlayerDie?.Invoke();
    public void UpdateGameScore() => OnScoreChange?.Invoke();
    private void ShowGameOverText() => OnShowGameOverUI?.Invoke();
}
