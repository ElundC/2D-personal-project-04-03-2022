using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody enemyRb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {}
        else
        {
            Destroy(gameObject);
        }
    }
}
