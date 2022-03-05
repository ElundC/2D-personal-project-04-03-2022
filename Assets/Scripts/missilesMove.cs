using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilesMove : MonoBehaviour
{
    
    [SerializeField] float speed = 10.0f;
    float xrange = 41f;
    float yrange = 24f;

    void Start()
    {
        
    }

    void Update()
    {
        Mouvement();

        DestroyOutOfBounds();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.x > xrange)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xrange)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > yrange)
        {
            Destroy(gameObject);
        }
        else if ( transform.position.y < -yrange)
        {
            Destroy(gameObject);
        }
    }

    void Mouvement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
