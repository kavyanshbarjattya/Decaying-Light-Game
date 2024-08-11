using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _gameStartPoint , _gameEndPoint;
    [SerializeField] Transform _playerTrans;

    [SerializeField] float _gameTimer;
    float counter;

    bool _isGameStarted;
    void Start()
    {
        _playerTrans.position = _gameStartPoint.position;
        _isGameStarted = true;
        counter = _gameTimer;
    }

   
    void Update()
    {
        if (_isGameStarted)
        {
            if (counter > 0)
            {
                counter -= Time.deltaTime;
            }
            else
            {
                _isGameStarted = false;
            }
        }
        
        if(_playerTrans.position == _gameEndPoint.position && counter > 0)
        {
            // game win screen
        }
        else if(_playerTrans.position != _gameEndPoint.position && counter < 0)
        {
            // game loose screen
        }

        float progress = counter / _gameTimer;

    }
}
