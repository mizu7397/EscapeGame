using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour 

{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3 (5, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(5, 1.5f, 0);
    }
}
