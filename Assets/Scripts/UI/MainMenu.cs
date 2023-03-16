using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasMain;
    [SerializeField] GameObject canvasCredits;

    public void CloseMain()
    {
        canvasMain.SetActive(false);
        canvasCredits.SetActive(true);
    }

    public void CloseCredits()
    {
        canvasMain.SetActive(true);
        canvasCredits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
