using UnityEngine;

public class Upgrades : MonoBehaviour
{
    
    [SerializeField] private int _maxNumOfDoubleJumpUpgrades = 3;
    [SerializeField] private int _baseScorePriceDoubleJump = 100;
    [SerializeField] private int _priceIncreaseDoubleJump = 100;
    [SerializeField] private int _maxNumOfFloatingUpgrades = 3;
    [SerializeField] private int _baseScorePriceFloating = 200;
    [SerializeField] private int _priceIncreaseFloating = 250;
    
    
    PlayerController _playerController;
    GameState _gameState;
    
    int _doubleJumpUpgrades = 0;
    int _floatingUpgrades = 0;
    int _currentPriceDoubleJump = 0;
    int _currentPriceFloating = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
        _currentPriceDoubleJump = _baseScorePriceDoubleJump;
        _currentPriceFloating = _baseScorePriceFloating;
    }

    public void PurchaseDoubleJump()
    {
        if (_gameState.getScore() >= _currentPriceDoubleJump)
        {
            _doubleJumpUpgrades++;
            _currentPriceDoubleJump = _currentPriceDoubleJump + (_priceIncreaseDoubleJump * _doubleJumpUpgrades);
        }
    }

    public void PurchaseFloating()
    {
        if (_gameState.getScore() >= _currentPriceFloating)
        {
            _floatingUpgrades++;
            _currentPriceFloating = _currentPriceFloating + (_priceIncreaseFloating * _floatingUpgrades);
        }
    }

    public int GetNumOfDoubleJumps()
    {
        return _doubleJumpUpgrades;
    }

    public float GetFloatingTime()
    {
        return (float)(_floatingUpgrades * 1.5);
    }
}