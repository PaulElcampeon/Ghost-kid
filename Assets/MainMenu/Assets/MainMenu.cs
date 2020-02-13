using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SoundEngine.instance.PlayPlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundEngine.instance.PlayExitSound();
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

    public void PlayCreditsSound()
    {
        SoundEngine.instance.PlayPlaySound();
    }

    public void PlayBackSound()
    {
        SoundEngine.instance.PlayExitSound();
    }
}
