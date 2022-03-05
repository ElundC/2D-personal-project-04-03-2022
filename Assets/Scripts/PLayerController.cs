using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] Animator animator;
    float smooth = 100.0f;
    float xrange = 38.5f;
    float yrange = 21f;
    bool Canshoot = true;
    [SerializeField] float FireRate = 0.5f;
    [SerializeField] float Nextshot = -1.0f;
    public GameObject projectilePrefab;

    void Start()
    {

    }

    void Update()
    {
        Mouvement();
        Animation();
        KeepInBound();
        LaunchMissiles();
    }



    void Mouvement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction(90, -1, horizontalInput);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction(-90, 1, horizontalInput);
        }  

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction(0, 1, verticalInput);
        }        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Direction(180, -1, verticalInput);
        }

    }

    void KeepInBound()
    {
        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }

        if (transform.position.y > yrange)
        {
            transform.position = new Vector3(transform.position.x, yrange, transform.position.z);
        }
        else if ( transform.position.y < -yrange)
        {
            transform.position = new Vector3(transform.position.x, -yrange, transform.position.z);
        }

    }

    void Animation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isInputdown", true);
        }
        else
        {
            animator.SetBool("isInputdown", false);
        }
    }

    void Direction(int zdirection, int negapo, float input)
    {  
        Quaternion target = Quaternion.Euler(0, 0, zdirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime* smooth);
        transform.Translate(Vector3.up * Time.deltaTime * speed * input * negapo);
    }

    void LaunchMissiles()
    {
        if (Time.time > Nextshot)
        {
            Canshoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Canshoot == true)
        {
            Instantiate(projectilePrefab, transform.position, gameObject.transform.rotation);
            Nextshot = Time.time + FireRate;
        }
        
    }

}
