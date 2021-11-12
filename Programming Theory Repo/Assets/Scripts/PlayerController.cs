using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // All variables that could be private for encapsulation
    public float forceMove;
    public float forceJump;
    private Rigidbody playerRb;
    public float gravityValue;
    private float zBound = 22;
    private float xBound = 22;
    public float crash;
    private float playerSpeed;
    public float maxSpeed;
    private Vector3 oldPosition;
    private float normalStrength = 1500; // how hard to hit enemy without powerup
    private float powerupStrength = 5000;
    private GameObject focalPoint;
    private bool hasPowerSpeed = false;
    private bool hasPowerForce = false;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {

        Physics.gravity *= gravityValue;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }

    private void FixedUpdate()
    {
        playerSpeed = Vector3.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;
        Debug.Log("Speed: " + playerSpeed.ToString("F2"));
    }

    // Update is called once per frame
    void Update()
    {
        // Abstraction
        PlayerLimits();
        PlayerJump();
        PLayerMove();
        
        

    }

    private void PlayerLimits()
    {
        if (transform.position.z < -zBound)
        {
            playerRb.AddForce(Vector3.forward * forceMove * crash, ForceMode.Impulse);
        }
        if (transform.position.z > zBound)
        {
            playerRb.AddForce(Vector3.back * forceMove * crash, ForceMode.Impulse);
        }
        if (transform.position.x < -xBound)
        {
            playerRb.AddForce(Vector3.right * forceMove * crash, ForceMode.Impulse);
        }
        if (transform.position.x > xBound)
        {
            playerRb.AddForce(Vector3.left * forceMove * crash, ForceMode.Impulse);
        }
    }
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            if (hasPowerSpeed)
            {
                playerRb.AddForce(Vector3.up * (forceJump + powerupStrength), ForceMode.Impulse);
                isOnGround = false;
            }
            else
            {
                playerRb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

    private void PLayerMove()
    {
        if (Input.GetKeyDown(KeyCode.D) && playerSpeed < maxSpeed)
        {
            if (hasPowerSpeed)
            {
                playerRb.AddForce(focalPoint.transform.right * (forceMove + powerupStrength), ForceMode.Impulse);
            }
            else
            {
                playerRb.AddForce(focalPoint.transform.right * forceMove, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && playerSpeed < maxSpeed)
        {
            if (hasPowerSpeed)
            {
                playerRb.AddForce(focalPoint.transform.right * (-forceMove - powerupStrength), ForceMode.Impulse);
            }
            else
            {
                playerRb.AddForce(focalPoint.transform.right * -forceMove, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && playerSpeed < maxSpeed)
        {
            if (hasPowerSpeed)
            {
                playerRb.AddForce(focalPoint.transform.forward * (forceMove + powerupStrength), ForceMode.Impulse);
            }
            else
            {
                playerRb.AddForce(focalPoint.transform.forward * forceMove, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && playerSpeed < maxSpeed)
        {
            if (hasPowerSpeed)
            {
                playerRb.AddForce(focalPoint.transform.forward * (-forceMove - powerupStrength), ForceMode.Impulse);
            }
            else
            {
                playerRb.AddForce(focalPoint.transform.forward * -forceMove, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Speed"))
        {
            hasPowerSpeed = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerSpeedCountdownRoutine());
        }
        if(other.CompareTag("Power Force"))
        {
            hasPowerForce = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerForceCountdownRoutine());
        }
    }

    IEnumerator PowerSpeedCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerSpeed = false;
    }

    IEnumerator PowerForceCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerForce = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            playerRb.AddForce(Vector3.right * forceMove * crash, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("WallRight"))
        {
            playerRb.AddForce(Vector3.left * forceMove * crash, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("WallForward"))
        {
            playerRb.AddForce(Vector3.back * forceMove * crash, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("WallBack"))
        {
            playerRb.AddForce(Vector3.forward * forceMove * crash, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            Vector3 awayFromEnemy = transform.position - collision.gameObject.transform.position;
            if(hasPowerForce)
            {
                enemyRigidbody.AddForce(awayFromPlayer * (normalStrength + powerupStrength) * 0.3f, ForceMode.Impulse);
                playerRb.AddForce(awayFromEnemy * (normalStrength - powerupStrength) * 0.3f, ForceMode.Impulse);
            }
            else
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength * 0.3f, ForceMode.Impulse);
                playerRb.AddForce(awayFromEnemy * normalStrength * 0.3f, ForceMode.Impulse);
            }
            
            Debug.Log("Choque Enemigo");

           
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 awayFromObstacle = transform.position - collision.gameObject.transform.position;
            playerRb.AddForce(awayFromObstacle * normalStrength * 0.3f, ForceMode.Impulse);
            Debug.Log("Choque obstaculo");
        }

    }

}
