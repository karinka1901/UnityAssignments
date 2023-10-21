using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handSpawner : MonoBehaviour
{
    public GameObject hand;  
    public Transform cookie; // cookie around which hands will be spawned
    public int maxHands = 20; // maximum hands per circle
    public float radius = 300.0f; // initial cookie radius
    private int spawnedHands = 0;



    public void SpawnHands()
    {

        if (spawnedHands >= maxHands)
        {
            radius += 80.0f; // radius increase
            spawnedHands = 0;
        }



        float angle = spawnedHands * (360f / maxHands);
        Vector2 spawnPosition = cookie.position + Quaternion.Euler(0, 0, angle) * Vector2.right * radius;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, cookie.position - (Vector3)spawnPosition); // rotate hands to face the cookie

        Instantiate(hand, spawnPosition, rotation);
        

        spawnedHands++;

    }
}



