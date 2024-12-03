using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] carPrefabs;
    private Vector3 carSpawnPos;
    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void SpawnRandomCar() {
        carSpawnPos = new Vector3(Random.Range(10.0f, 30.0f), 0, Random.Range(-28.0f, -21.0f));
        int carIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[carIndex], carSpawnPos, carPrefabs[carIndex].transform.rotation);
    }
}
