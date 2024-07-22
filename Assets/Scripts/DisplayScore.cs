using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshPro component
    private int score; // The score to be displayed



    // Method to set the score
    void Awake()
    {
        
        score=ScoreStorer.Instance.getScore();
    }
    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreText();
    }

    // Method to update the score display
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "YOU SCORED: " + score.ToString();
        }
    }

    private void Start()
    {
        // Initialize the score display with a default value, if needed
        UpdateScoreText();
    }
}
