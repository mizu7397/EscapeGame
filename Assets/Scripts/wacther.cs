using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wacther : MonoBehaviour
{
    public float eyeHeight = 1.5f;              //目の高さ
    public float viewDistance = 60f;            //視線の届く距離
    public Vector3 direction = Vector3.right;   //視線の方向
    public LayerMask playerLayer;            //プレイヤーが属するレイヤー
    public bool playerDetected = false;         //プレイヤーを見つけたかどうか
    public float checkIntervel = 3f;          //チェックの時間（秒）
    public LayerMask blockLayer; //障害物のレイヤー 
    bool isSafe=false;//障害物を見つけたか
    bool isDisCover=false;//プレイヤーを見つけたかどうか
    bool isCheck = false;
    public GameObject eyeImage;

    private Vector3 eyePosition;
    void Start()
    {
        //一定間隔でCheckPlayerを繰り返す（0秒後に開始し、checkInteval1秒ごと）
        InvokeRepeating("CheckReverse",5f,checkIntervel);
    }
    private void Update()
    {
        if (isCheck==true)
        {
            //目玉のUIを出す
            CheckPlayer();
            eyeImage.SetActive(true);
        }
        else
        {
            eyeImage.SetActive(false);
        }
    }
    //チェックフラグを反転　今false→true 今　true→false
    void CheckReverse()
    {
        //今の自分を反転させて左に代入
        isCheck = !isCheck;
    }
    // Update is called once per frame
    void CheckPlayer()
    {
        isDisCover = false;
        isSafe = false;
        playerDetected = false;
        Debug.Log("チェック開始");
       //ジャイアントの位置＋アイハイト分の高さ
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        //ジャイアントの前方
        Vector3 direction = transform.forward;

        RaycastHit[] hits;　//配列　※複数の値を格納するもの

        hits = Physics.RaycastAll(
            origin,//目線の場所
            direction,//方向
            viewDistance//距離
            );

        //繰り返し構文　for分
        //hitsの中に格納したオブジェクトの点検を繰り返す
        //far (どのくらい繰り返すかの条件を書く){繰り返したい処理}
        
        // int iはカウント変数
        //①カウンター変数iの宣言と最初の数を決める
        //②iがいくつか繰り返すのかを決めている。//hits配列の中の数（長さ）Length
        //③何個飛ばしで数えるか。（数える回数に違いが出る）変数名++というのはその変数を1ずつ増やす
        for ( int i = 0; i < hits.Length; i++)
        {
            GameObject obj = hits[i].collider.gameObject;
            //障害物レイヤーかどうかチェック
            if (IsInLayerMask(obj,blockLayer))
            {
                Debug.Log("障害物によりセーフ");
                isSafe = true;
                return;//繰り返しのfor文を強制終了
            }
            else
            {
                Debug.Log("発見！");
                isDisCover = true;
            }
        }
        if (isSafe == false && isDisCover == true)
        {
            Debug.Log("ゲームオーバー");
        }

        //視線に何かぶつかったか判定
        //if (Physics.Raycast(origin, direction,out hit, viewDistance, playerLayer))
        //{
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        if (!playerDetected)
        //        {
        //            playerDetected = true;
        //            Debug.Log("プレイヤーを発見");
        //            //ここでゲームオーバーやアラームの処理を呼ぶ
        //        }
        //    }
        //}
        //else
        //{
        //    playerDetected = false;
        //}
    }

    //レイヤーをチェックするメソッド
    bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return ((1 << obj.layer) & mask) != 0;
    }
    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        Vector3 direction = transform.forward * viewDistance;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin+direction);
    }
}