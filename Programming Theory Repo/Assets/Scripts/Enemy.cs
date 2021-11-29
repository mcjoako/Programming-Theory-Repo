using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    [SerializeField]
    private GameObject Goal;
    // Start is called before the first frame update
    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody>();
        float multiplier = 5;
        Vector3 lookDirection = (Goal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime * multiplier, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        BallDirection();
        DestroyBalls();
    }

    private void BallDirection()
    {
        float multiplier = 3;
        Vector3 lookDirection = (Goal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime * multiplier, ForceMode.Impulse);
    }
    

    private void DestroyBalls()
    {
        if (transform.position.y < -3000)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enviroment"))
        {
            Debug.Log("Enemy Jump");
            enemyRb.AddForce(Vector3.up * speed * Time.deltaTime * 200, ForceMode.Impulse);
        }
    }



}
