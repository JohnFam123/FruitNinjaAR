using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombXR : MonoBehaviour
{
    //public Transform spawnPoint;
    public GameObject Bomb;


    // Start is called before the first frame update
    public void SpawnBombs(float value)
    {
        StartCoroutine(Spawn((int)value));
    }
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Spawn(int count)
    {
        yield return new WaitForSecondsRealtime(1.5f);
        for (int i = 0; i< count; i++){       
            Instantiate(Bomb, new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0f, 1f), Random.Range(0f, 1f)), Quaternion.identity);
            yield return new WaitForSecondsRealtime(1.5f);
        }
        
    }
}
