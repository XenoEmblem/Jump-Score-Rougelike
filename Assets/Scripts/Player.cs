using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] int _lives = 3;
    
    GameState _gameState;
    SceneLoader _sceneLoader;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameState = FindAnyObjectByType<GameState>();
        _sceneLoader = FindAnyObjectByType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLives()
    {
        return _lives;
    }
    
}