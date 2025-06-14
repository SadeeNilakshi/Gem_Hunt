using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalGemsText;
    public Button restartButton;
    public Button quitButton;

    private CoinCollector coinCollector;
    private GemCollector gemCollector;

    void Start()
    {
        gameOverPanel.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);

        coinCollector = FindObjectOfType<CoinCollector>();
        gemCollector = FindObjectOfType<GemCollector>();
    }

    public void ShowGameOverScreen()
    {
        int coinScore = coinCollector != null ? coinCollector.GetCoinCount() : 0;
        int gemScore = gemCollector != null ? gemCollector.GetGemCount() : 0;

        finalScoreText.text = "Score: " + coinScore;
        finalGemsText.text = "Gems: " + gemScore;

        gameOverPanel.SetActive(true);
    }

    void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
}
