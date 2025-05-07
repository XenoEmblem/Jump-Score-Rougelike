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
    int doubleJumpUpgrades = 0;
    int floatingUpgrades = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int _getNumOfDoubleJumps()
    {
        return doubleJumpUpgrades;
    }
    
}