using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    [Range(.1f,3f)][SerializeField] private float _gameSpeed = 1f;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _livesText;
    [SerializeField] private int _pointsPerDestroyed = 45; 

    int _score;
    int _lives;
    Player _player;

    void Awake()
    {  
        int gameStateCount = FindObjectsByType<GameState>(FindObjectsSortMode.None).Length;

        if (gameStateCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _lives = _player.GetLives();
        Time.timeScale = _gameSpeed;
        _scoreText.text = _score.ToString();
        _livesText.text = _lives.ToString();
        
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
        _livesText.text = _lives.ToString();
    }

    public void AddScore()
    {
        _score += _pointsPerDestroyed;
    }

    public void DestroyState()
    {
        Destroy(gameObject);
    }
}
