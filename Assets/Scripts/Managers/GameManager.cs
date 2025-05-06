using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject dummyPrefab;
    public Transform spawnPosition;
    public float[] spawnLoc = { 2f, -2.4f, 0f};

    void Start()
    {
        spawnPosition.position = new Vector3(spawnLoc[0], spawnLoc[1], spawnLoc[2]);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDummy();
    }

    public void SpawnDummy()
    {
        if(NPCStatus.isAlive == false && Input.GetKeyDown(KeyCode.T)) 
        {
            Instantiate(dummyPrefab, spawnPosition.position, spawnPosition.rotation);
        }
    }
}
