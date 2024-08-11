using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _gameStartPoint;
    [SerializeField] Transform _playerTrans;
    [SerializeField] GameObject _gameLooseScreen;

    [SerializeField] float _gameTimer;
    public static GameManager instance;
    public float timer()
    {
        return counter;
    }
    float counter;

    bool _isGameStarted;

    private void Awake()
    {
        instance = this;
    }
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
        }

        float progress = counter / _gameTimer;

    }
}
