using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
