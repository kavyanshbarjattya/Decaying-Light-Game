using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _gameStartPoint;
    [SerializeField] Transform _playerTrans;
    [SerializeField] GameObject _gameLooseScreen;

    [SerializeField] float _gameTimer;
    float counter;

    bool _isGameStarted;
    void Start()
    {
        _playerTrans.position = _gameStartPoint.position;
        _isGameStarted = true;
        counter = _gameTimer;
        _gameLooseScreen.SetActive(false);
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

        if (counter < 0)
        {
            _gameLooseScreen.SetActive(true);
            Time.timeScale = 0.5f;
        }

        float progress = counter / _gameTimer;

        Debug.Log(progress);

        MusicLerp.instance.Progress(progress);

    }
}
