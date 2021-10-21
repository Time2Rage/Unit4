using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Components
    private Rigidbody enemyRb;
    private GameObject player;
    // Tuning
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Connect Components
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        // Orientation
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // Chase Functionality
        enemyRb.AddForce( lookDirection * speed);
        // Despawn
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
