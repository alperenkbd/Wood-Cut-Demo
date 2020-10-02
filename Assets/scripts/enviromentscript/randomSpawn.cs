using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomSpawn : MonoBehaviour
{


    [SerializeField] GameObject rock, wood;
    [SerializeField] float spawnTime = 2.0f;
    [SerializeField] float nextSpawn = 0f;
    [SerializeField] int whatToSpawn;
    [SerializeField] Vector2 screenBound;
    [SerializeField] GameObject spawner;
    

    void Start()
    {

        StartCoroutine(RandomSpawn());
        
    }



    void Update()
    {
        
        
        if (Time.time > nextSpawn)
            {
             whatToSpawn = Random.Range(1, 3);


             switch (whatToSpawn)
             {

             case 1:
             Instantiate(wood,spawner.transform.position, Quaternion.Euler(new Vector3(90,-90,0)));
                break;

             case 2:
             Instantiate(rock, spawner.transform.position, Quaternion.identity);
                break;       
                    
                }

                nextSpawn = Time.time + spawnTime;
            }

    }

    

    IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            spawner.transform.position = new Vector3(Random.Range(-4, 4), 
                spawner.transform.position.y , spawner.transform.position.z);
            
        }
    }


    
}