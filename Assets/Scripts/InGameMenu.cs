using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject soundPanel;
    public GameObject menu;

    public void EnterSoundPanel()
    {
        tutorialPanel.SetActive(false);
        soundPanel.SetActive(true);
    }

    public void EnterTutorialPanel()
    {
        soundPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        soundPanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        GameManager.instance.GameOver();
    }

    public void CloseMenu()
    {
        BackToMenu();
        menu.SetActive(false);
    }
}
