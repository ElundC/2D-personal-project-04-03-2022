using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public float spawnRate = 5.0f;
    float limity = 50;
    float limitx = 70;
    float limitz = -10;
    
    
    void Start()
    {

        if(PLayerController.life > 0)
        {
        StartCoroutine(SpawnEnnemy());
        StartCoroutine(SpawnEnnemyBig());
        }
    }

    
    void Update()
    {
        
    }

        
    IEnumerator SpawnEnnemy()
    {
        if(PLayerController.life > 0)
        {
        yield return new WaitForSeconds(spawnRate);

        float spawnPosY = Random.Range(-limity, limity);
        float spawnPosX = Random.Range(-limitx,limitx);
    

        Vector3 randomPos = new Vector3(limitx, spawnPosY, limitz);
        Vector3 randomPos2 = new Vector3(limitx, spawnPosY, limitz);
        

        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, randomPos2, enemyPrefab.transform.rotation);

        StartCoroutine(SpawnEnnemy());
        }

    }

    IEnumerator SpawnEnnemyBig()
    {
        if(PLayerController.life > 0)
        {
            float spawnPosY = Random.Range(-limity, limity);
            float spawnPosX = Random.Range(-limitx,limitx);
        
            yield return new WaitForSeconds(spawnRate*3);
            Vector3 randomPosBig = new Vector3(spawnPosX, limity, limitz);
            Instantiate(enemyPrefab2, randomPosBig, enemyPrefab2.transform.rotation);

            StartCoroutine(SpawnEnnemyBig());
        }
    }
}
