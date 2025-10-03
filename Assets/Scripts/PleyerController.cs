using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PleyerController : MonoBehaviour
{
    public int x;
    public float speed;
    public Rigidbody rbody;
    public LayerMask groundLayer;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameover == true) 
        {
            return;
        }
        else
        {
            onGround = Physics.Raycast(transform.position, Vector3.down, 1.0f, groundLayer);
            if (Input.GetKey("right"))
            {
                transform.localScale = new Vector3(1, 1, 1);
                //Debug.Log("右押された");
                transform.position += transform.forward * speed * Time.deltaTime;
                x += 1;
            }
            if (Input.GetKey("left"))
            {
                transform.localScale = new Vector3(1, 1, -1);
                //Debug.Log("左押された");
                transform.position += transform.forward * -speed * Time.deltaTime;
                x -= 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
            {
                //Debug.Log("ジャンプ押した");
                //もしも地面に触れていたら
                rbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            }
        }
        
    }   
}
