using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _gameStartPoint , _gameEndPoint;
    [SerializeField] Transform _playerTrans;

    [SerializeField] float _gameTimer;

    bool _isGameStarted;
    void Start()
    {
        _playerTrans.position = _gameStartPoint.position;
        _isGameStarted = true;
    }

   
    void Update()
    {
        if (_isGameStarted)
        {
            if (_gameTimer > 0)
            {
                _gameTimer -= Time.deltaTime;
            }
            else
            {
                _isGameStarted = false;
            }
        }
        
        if(_playerTrans.position == _gameEndPoint.position && _gameTimer > 0)
        {
            // game win screen
        }
        else if(_playerTrans.position != _gameEndPoint.position && _gameTimer < 0)
        {
            // game loose screen
        }
        Debug.Log(_gameTimer);
    }
}
