using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicPlayer : MonoBehaviour
{
    void Start()
    {
     
    }

    void Update()
    {
       
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Destroy(gameObject);
        }
    }
}
