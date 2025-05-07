using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _livesText;
    [SerializeField] private int _pointsPerDestroyed = 45; 

    int _score;
    int _lives;
    PlayerController _player;

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
        _player = FindAnyObjectByType<PlayerController>();
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

    public void RemoveLives()
    {
        _lives--;
    }

    public int getScore()
    {
        return _score;
    }

    public void DestroyState()
    {
        Destroy(gameObject);
    }
}
