using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vehicle vehicle;
    public bool keepSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public System.Random random = new System.Random();
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("TrafficControlResource");
        InvokeRepeating("SpawnVehicle", spawnTime, spawnDelay);
    }

    public void SpawnVehicle()
    {
        vehicle.GetComponent<SpriteRenderer>().sprite = sprites[random.Next(sprites.Length)];
        Instantiate(vehicle, transform.position, Quaternion.identity);

        if (!keepSpawning)
        {
            CancelInvoke("SpawnVehicle");
        }
    }
}
