using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wather : MonoBehaviour
{
    public float eyeHeight = 1.5f;
    public float viewDistance = 60f;
    public Vector3 direction = Vector3.right;
    public LayerMask detectionLayer;
    public bool playerDetected = false;

    private Vector3 eyePosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //目線の位置を更新（少し上
        //eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);
        //rayを飛ばす
        //Ray ray = new Ray(eyePosition, transform.TransformDirection(direction));
        RaycastHit hit;
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        Vector3 direction = transform.forward;

        //デバッグ表示（Sceneビューで見える）
        //Debug.DrawRay(eyePosition, transform.TransformDirection(direction) * viewDistance, Color.red);

        //視線に何かぶつかったか判定
        if (Physics.Raycast(origin, direction,out hit, viewDistance, detectionLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (!playerDetected)
                {
                    playerDetected = true;
                    Debug.Log("プレイヤーを発見");
                    //ここでゲームオーバーやアラームの処理を呼ぶ
                }
            }
        }
        else
        {
            playerDetected = false;
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        Vector3 direction = transform.forward * viewDistance;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin+direction);
    }
}