using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wather : MonoBehaviour
{
    public float waitUP = 11f;
    public Vector3 startposition;  //�ڐ��̈ʒu�Ɏg������
    public Vector3 direction;  //�ڐ����΂�����
    public float distansce = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //�ڐ��̈ʒu
        startposition = new Vector3(transform.position.x,transform.position.y + 11,transform.position.z);
        direction = new Vector3(1, 0, 0);  //�ڐ����΂�������x����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
