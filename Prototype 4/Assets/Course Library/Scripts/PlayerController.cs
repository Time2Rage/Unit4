using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody playerRb;
    private GameObject focalPoint;
    // Tuning
    public float speed = 5.0f;
    public float powerupStrength = 15.0f;
    //--- MECHANICS ---
    // Powerup
    public bool hasPowerup;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        // Connect Components
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        // Powerup Indicator Follow
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    //--- EVENTS ---
    // Collision Events
    private void OnTriggerEnter(Collider other)
    {
        // Powerup Pickup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    // Poweruptimer
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        Debug.Log("Powerup Disabled!");
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Powerup Enemy Collision
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Get Enemy and Direction
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            // Pushback
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
