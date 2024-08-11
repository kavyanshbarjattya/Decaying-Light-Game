using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _dialougeScreen, _mainMenu;

    private void Start()
    {
        Time.timeScale = 0;
        _mainMenu.SetActive(true);
        _dialougeScreen.SetActive(false);
    }

    public void PlayBtn()
    {
        _mainMenu.SetActive(false);
        _dialougeScreen.SetActive(true);
        Time.timeScale = 1;
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/@bhartiya-gamedev");
    }
    public void Website()
    {
        Application.OpenURL("https://anmolmittal.vercel.app/");
    }
}
