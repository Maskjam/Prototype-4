using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float PowerupStrength = 15.0f;
    public GameObject powerupIndicator;

    bool hasExplosion;
    // Start is called before the first frame update
    void Start()
    {
        playRb = GetComponent<Rigidbody>();
        focalPoint =   GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playRb.AddForce( focalPoint.transform.forward * speed * forwardInput );
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (hasExplosion == true && Input.GetKeyDown(KeyCode.Space))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(100.0f, transform.position, 20.0f, 0, ForceMode.Impulse);

            }


        }


    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if(other.CompareTag("Explosion"))
        {
            hasExplosion = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
        
        
          
        
    }
    
    IEnumerator PowerupCountdownRoutine()
    {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            hasExplosion = false;
            powerupIndicator.gameObject.SetActive(false);
    }
            
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
             Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position );
            
            Debug.Log("Collided with " + collision.gameObject.name + " with power set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
        }

       
    }
}
