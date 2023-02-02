using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclesSpawn;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstaclesSpawn",2,3);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ObstaclesSpawn(){
        if (!playerController.gameOver)
            Instantiate(obstaclesSpawn,obstaclesSpawn.transform.position,obstaclesSpawn.transform.rotation);
    }
}
