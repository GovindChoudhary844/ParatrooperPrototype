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
        if (gameOverCanvas != null) gameOverCanvas.SetActive(true);

        // freeze everything
        Time.timeScale = 0f;
    }
}