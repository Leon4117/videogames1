using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] carPrefabs;
    private Vector3 carSpawnPos;
    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    public GameObject[] obstaclePrefabs;
    private float spawnPosX;
    private float spawnPosZ;
    private float y = 69.877f;
    float startDelay;
    float repeatRate;
    public static SpawnManager Instance;

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
  
    private Vector3 GenerateSpawnPosition(int pos){
        var spawnRanges = new (Vector2 xRange, Vector2 zRange)[]{
            (new Vector2(93, 102), new Vector2(19, 55)),   // Pos 1
            (new Vector2(85, 133), new Vector2(51, 55)),  // Pos 2
            (new Vector2(133, 164), new Vector2(51, 55)), // Pos 3
            (new Vector2(160, 164), new Vector2(51, 63)), // Pos 4
            (new Vector2(161, 215), new Vector2(60, 63)), // Pos 5
            (new Vector2(210, 215), new Vector2(-6, 63)), // Pos 6
            (new Vector2(161, 215), new Vector2(5, 14))   // Pos 7
        };

        var (xRange, zRange) = spawnRanges[pos - 1];
        float spawnPosX = Random.Range(xRange.x, xRange.y);
        float spawnPosZ = Random.Range(zRange.x, zRange.y);

        return new Vector3(spawnPosX, y, spawnPosZ);
    }

    public void SpawnObstacles(){
        if (obstaclePrefabs.Length == 0){
            Debug.LogError("No hay prefabs de obstáculos asignados.");
            return;
        }

        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPosition = GenerateSpawnPosition(Random.Range(1, 8));
        Debug.Log($"Generando obstáculo {obstacleIndex} en posición {spawnPosition}.");

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, obstaclePrefabs[obstacleIndex].transform.rotation);
    }

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
