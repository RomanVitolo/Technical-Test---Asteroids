using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

namespace GlobalSettings
{
    public class GameSettings : MonoBehaviour
    {
        public static GameSettings Instance;
        [field: SerializeField] public UnityEvent OnPlayerDie { get; set; }
        [field: SerializeField] public UnityEvent OnScoreChange { get; set; }
        [field: SerializeField] public UnityEvent OnShowGameOverUI { get; set; }
        [field: SerializeField] public bool RandomSpawnObjects { get; private set; }
        [field: SerializeField] public BigInteger ScoreValue { get; set; }

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
}

