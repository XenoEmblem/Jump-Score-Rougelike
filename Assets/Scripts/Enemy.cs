using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _health = 5;
    [SerializeField] int _pointsGiven = 100;
    
    GameState _gameState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameState = FindAnyObjectByType<GameState>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    void ProcessHit(DamageDealer damageDealer)
    {
        _health -= damageDealer.GetDamage();
        if (_health <= 0)
        {
            Debug.Log("Noscore");
            _gameState.AddScore(_pointsGiven);
            Debug.Log("GotScore");
            Destroy(transform.parent.gameObject);
        }
    }
}
