using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUi : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public GameObject musicOnButton;  
    public GameObject musicOffButton;  

    private bool isMusicOn = true;

    void Start()
    {
       
        backgroundMusic.Play();
        UpdateButtonVisuals();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
            backgroundMusic.Play();
        else
            backgroundMusic.Pause();

        UpdateButtonVisuals();
    }

    private void UpdateButtonVisuals()
    {
        musicOnButton.SetActive(!isMusicOn);  
        musicOffButton.SetActive(isMusicOn);   
    }
}
