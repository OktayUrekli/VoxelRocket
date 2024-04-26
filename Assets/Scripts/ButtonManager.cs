using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel,muteImage,unmuteImage;

    private void Awake()
    {
        stopPanel.SetActive(false);
        muteImage.SetActive(true);
        unmuteImage.SetActive(false);
    }


    public void NextLevelButton()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1<SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }

    public void StopAndPlayGameButton()
    {
        if (stopPanel.activeInHierarchy==false)
        {
            stopPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            stopPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void MuteAndUnMuteButtons()
    {
        if (muteImage.activeInHierarchy == true)
        {   
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().Pause();
           // playMusic.Pause();
            muteImage.SetActive(false);
            unmuteImage.SetActive(true);
        }
        else
        {
            // playMusic.UnPause();
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().UnPause();
            muteImage.SetActive(true);
            unmuteImage.SetActive(false);
        }
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadLevelButton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
