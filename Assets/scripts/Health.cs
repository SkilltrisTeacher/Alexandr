using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void TakeDamage()
    {
        lives--;
        transform.position = startPosition;
    }
        
    
}
