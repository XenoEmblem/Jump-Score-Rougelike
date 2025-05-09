using System;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float bounce;
    private Rigidbody2D _rb2d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _rb2d.linearVelocity = new Vector2(_rb2d.linearVelocity.x, bounce);
        }
    }
}
