using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    //プレイヤーの情報を格納
    GameObject player;
    //Eyeの進行スピード
    public float eyeSpeed;
    //生まれてから消滅するまでの時間設定
    public float deleteTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Eyeは生れ出たら自動でPlayerを探してくる
        player = GameObject.FindGameObjectWithTag("Player");
        //変数で設定した秒後に排除
        Destroy(gameObject,deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        //生成したオブジェクト（Eye）がプレイヤーのもとへ向かっていく
        //現在地からプレイヤーの位置へ徐々に迫る
        //Lerpメソッド→第一引数から第二引数へ移動させる※第三引数で指定したスピード感で移動
        transform.position = Vector3.Lerp(transform.position, player.transform.position,eyeSpeed *Time.deltaTime);
    }
}
