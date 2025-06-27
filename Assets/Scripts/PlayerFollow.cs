using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Vector3 enemyPos;
    Vector3 playerPos;
    Vector3 diff;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        enemyPos = transform.position;
         diff = playerPos - enemyPos;
            
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = playerPos - diff;
        transform.position = enemyPos;
    }
}
