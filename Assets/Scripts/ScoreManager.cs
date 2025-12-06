using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText; // live score
    [SerializeField] private TextMeshProUGUI recordText; // highest

    private int score;
    private int record;

    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        record = PlayerPrefs.GetInt("Record", 0);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score > record)
        {
            record = score;
            PlayerPrefs.SetInt("Record", record);
        }
        UpdateUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (recordText != null) recordText.text = "Record: " + record;
    }
}