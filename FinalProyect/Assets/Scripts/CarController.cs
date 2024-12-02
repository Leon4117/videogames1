using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public Transform[] waypoints; // Puntos de control
    private float speed = 18.0f;
    private float turnSpeed = 10.0f;
    private int currentWaypointIndex = 0;

    void Start() {
        //speed = Random.Range(15.0f, 20.0f);
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++) {
            waypoints[i] = waypointObjects[i].transform;
        }
    }
    
    void Update() {
        if (waypoints.Length == 0) return;
        
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized; // Dirección hacia el punto actual
        
        Quaternion targetRotation = Quaternion.LookRotation(direction); // Rotar hacia el punto actual
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        
        transform.position += transform.forward * speed * Time.deltaTime; // Mover hacia el punto actual
        
        // Verificar si alcanzó el punto actual
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f) {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Ir al siguiente punto
        }
    }
}
