using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _healthText;

    int _score = 99999;
    int _health;

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
        _scoreText.text = _score.ToString();
        _healthText.text = _health.ToString();
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
        _healthText.text = _health.ToString();
    }

    public void AddScore(int pointsPerDestroyed)
    {
        _score += pointsPerDestroyed;
    }

    public void RemoveHealth()
    {
        _health--;
    }

    public int GetScore()
    {
        return _score;
    }

    public void RemoveScore(int scoreToRemove)
    {
        _score -= scoreToRemove;
    }

public void DestroyState()
    {
        Destroy(gameObject);
    }
}
