using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wather : MonoBehaviour
{
    public float waitUP = 11f;
    public Vector3 startposition;  //–Úü‚ÌˆÊ’u‚Ég‚¤‚à‚Ì
    public Vector3 direction;  //–Úü‚ğ”ò‚Î‚·•ûŒü
    public float distansce = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //–Úü‚ÌˆÊ’u
        startposition = new Vector3(transform.position.x,transform.position.y + 11,transform.position.z);
        direction = new Vector3(1, 0, 0);  //–Úü‚ğ”ò‚Î‚·•ûŒü‚Íx•ûŒü
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
