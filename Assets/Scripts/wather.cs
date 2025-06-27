using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wather : MonoBehaviour
{
    public float eyeHeight = 1.5f;              //目の高さ
    public float viewDistance = 60f;            //視線の届く距離
    public Vector3 direction = Vector3.right;   //視線の方向
    public LayerMask detectionLayer;            //プレイヤーが属するレイヤー
    public bool playerDetected = false;         //プレイヤーを見つけたかどうか
    public float checkIntervel = 0.5f;          //チェックの時間（秒）

    private Vector3 eyePosition;
    void Start()
    {
        //一定間隔でCheckPlayerを繰り返す（0秒後に開始し、checkInteval1秒ごと）
        InvokeRepeating("CheckPlayer",0f,checkIntervel);
    }

    // Update is called once per frame
    void CheckPlayer()
    {
        playerDetected = false;
        Debug.Log("チェック開始");
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