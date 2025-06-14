using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int coin = 0;
    private int silverCoin = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI silverText;

    public GemCollector gemCollector;

    public GameObject silverPopup;
    public AudioSource silverMilestoneSound;
   

    void Start()
    {
        gemCollector = GameObject.FindWithTag("Player").GetComponent<GemCollector>();
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin++;
            Destroy(other.gameObject);
            Debug.Log("Coins: " + coin);

            if (coin % 20 == 0 && gemCollector != null)
            {
                gemCollector.AddGem();
            }

            UpdateScoreUI();
            
        }
        else if (other.CompareTag("SilverCoin"))
        {
            silverCoin++;
            Destroy(other.gameObject);
            Debug.Log("Silver Coins: " + silverCoin);

            if (gemCollector != null)
            {
                gemCollector.AddSilverCoin();

                if (silverCoin % 15 == 0)
                {
                    gemCollector.AddGem();
                    ShowSilverMilestone();
                }
            }

            UpdateScoreUI();
        }
    }

    private void ShowSilverMilestone()
    {
        if (silverPopup != null)
        {
            silverPopup.SetActive(true);

            Animator anim = silverPopup.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Pop");
            }

            if (silverMilestoneSound != null)
            {
                silverMilestoneSound.Play();
            }

            StartCoroutine(HideSilverPopupAfterDelay());
        }
    }


    private IEnumerator HideSilverPopupAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        if (silverPopup != null)
            silverPopup.SetActive(false);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + coin;
        }

        if (silverText != null)
        {
            silverText.text = "x " + silverCoin;
        }
    }


    public int GetCoinCount()
    {
        return coin;
    }
}

