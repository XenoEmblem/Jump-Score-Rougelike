using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    BoxCollider2D _bodyCollider;
    CircleCollider2D _headCollider;
    GameState _gameState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bodyCollider = GetComponent<BoxCollider2D>();
        _headCollider = GetComponent<CircleCollider2D>();
        _gameState = FindAnyObjectByType<GameState>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HeadBonk()
    {
        _gameState.AddScore();
    }
}
