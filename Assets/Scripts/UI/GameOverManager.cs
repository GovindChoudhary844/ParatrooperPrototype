using System.Collections;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject gameOverCanvas; // drag Canvas here

    void OnEnable()
    {
        // listen to turret death
        TurretHealth.OnTurretDestroyed += ShowGameOver;
    }

    void OnDisable()
    {
        TurretHealth.OnTurretDestroyed -= ShowGameOver;
    }

    void ShowGameOver()
    {
        StartCoroutine(DelayedGameOver());
    }

    private IEnumerator DelayedGameOver()
    {
        // play the sound first
        AudioManager.Instance.PlaySound(AudioManager.Instance.GameOver);

        // wait 1 second (sound + any extra feel)
        yield return new WaitForSecondsRealtime(2f);

        // then show UI and freeze
        if (gameOverCanvas != null) gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}