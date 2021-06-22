using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
   	public GameObject platformPrefab;

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();

        for (int i = 0; i < 10; i++)
        {
        	SpawnerPosition.x = Random.Range(-5f, 5f);
        	SpawnerPosition.y += Random.Range(1f, 2.5f);

        	Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);
            
        }
    }
}
