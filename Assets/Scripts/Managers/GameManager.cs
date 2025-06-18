using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject dummyPrefab;
    public Transform spawnPosition;
    public float[] spawnLoc = { 2f, -2.4f, 0f};


    [Header("Windows")]
    public GameObject invWindow;
    public static bool isInvOpen { get; private set; }
    public static event Action<bool> OnInvWindowGhanged;

    public Animator invWindowAnimator;

    void Start()
    {
        spawnPosition.position = new Vector3(spawnLoc[0], spawnLoc[1], spawnLoc[2]);

        invWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDummy();
        OpenWindows();
    }

    public void SpawnDummy()
    {
        if(NPCStatus.isAlive == false && Input.GetKeyDown(KeyCode.T)) 
        {
            Instantiate(dummyPrefab, spawnPosition.position, spawnPosition.rotation);
        }
    }

    void OpenWindows()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleStatWindow();
        }
    }
    public void ToggleStatWindow()
    {
        isInvOpen = !isInvOpen;
        //Time.timeScale = isStatOpen ? 0 : 1;
        OnInvWindowGhanged?.Invoke(isInvOpen);
        if (isInvOpen)
        {
            invWindow.SetActive(true);
            invWindowAnimator.SetTrigger("Open");
           
        }
        else
        {
            invWindowAnimator.SetTrigger("Close");
        }
    }
}
