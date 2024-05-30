using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnerXR : MonoBehaviour
{
    public GameObject Bomb;
    public float SpawnCount;
    // Start is called before the first frame update
    void Awake()
    {
        //SpawnBombs(SpawnCount);
        
        
    }

    void SpawnBombs(float value){
        //Vector3 position = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 1);
        
        for(float i = 0; i < value; i= i+1){
            Instantiate(Bomb, new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
