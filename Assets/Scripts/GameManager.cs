using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource gameOverMusic;
    public GameObject gameOverUI;

    public AudioSource winMusic;
    public GameObject winUI;

    public void GameOver()
    {
        if (gameOverMusic != null && !gameOverMusic.isPlaying)
            gameOverMusic.Play();

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        Debug.Log("Game Over!");
    }
    public void WinGame()
    {
        if (winMusic != null && !winMusic.isPlaying)
            winMusic.Play();

        if (winUI != null)
            winUI.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("You Win!");
    }
}
