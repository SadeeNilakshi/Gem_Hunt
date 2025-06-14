using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCollector : MonoBehaviour
{
    private int gem = 0;
    private int coins = 0;
    private int silverCoins = 0; 

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI silverCoinText; 

    public GameObject gemPopup;
    public AudioSource gemSound;

    public GameObject gemsCompletedPanel;
    public AudioSource gemsCompleteSound;

    private bool gemsCompleteShown = false;
    private bool winTriggered = false;

    private void Start()
    {
        UpdateUI();

        if (gemPopup != null) gemPopup.SetActive(false);
        if (gemsCompletedPanel != null) gemsCompletedPanel.SetActive(false);
    }

    public void AddGem()
    {
        gem++;
        Debug.Log("Gems Collected: " + gem);
        UpdateUI();
        PlayGemFeedback();

        if (gem >= 5 && !gemsCompleteShown)
        {
            gemsCompleteShown = true;
            ShowGemsCompleted();
        }

        CheckWinCondition();
    }

    public void AddCoin()
    {
        coins++;
        Debug.Log("Coins Collected: " + coins);

        if (coins % 20 == 0)
        {
            AddGem();
        }

        UpdateUI();
    }

    public void AddSilverCoin()
    {
        silverCoins++;
        Debug.Log("Silver Coins Collected: " + silverCoins);

        if (silverCoins % 15 == 0)
        {
            AddGem();
        }

        UpdateUI();
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (!winTriggered && gem >= 15)
        {
            winTriggered = true;
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.WinGame();
            }
        }
    }

    private void ShowGemsCompleted()
    {
        if (gemsCompletedPanel != null) gemsCompletedPanel.SetActive(true);
        if (gemsCompleteSound != null) gemsCompleteSound.Play();

        Invoke("HideGemsCompleted", 2f);
    }

    private void HideGemsCompleted()
    {
        if (gemsCompletedPanel != null) gemsCompletedPanel.SetActive(false);
    }

    private void PlayGemFeedback()
    {
        if (gemPopup != null)
        {
            StopAllCoroutines();
            StartCoroutine(PopupRoutine());
        }

        if (gemSound != null)
            gemSound.Play();
    }

    private IEnumerator PopupRoutine()
    {
        gemPopup.SetActive(true);
        yield return new WaitForSeconds(1f);
        gemPopup.SetActive(false);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "x " + gem;
        if (coinText != null)
            coinText.text = "x " + coins;
        if (silverCoinText != null)
            silverCoinText.text = "x " + silverCoins;
    }

    public int GetGemCount() => gem;
    public int GetSilverCoinCount() => silverCoins;
}
