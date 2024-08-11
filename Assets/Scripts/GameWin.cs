using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] GameObject _gameWin;

    private void Start()
    {
        _gameWin.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
