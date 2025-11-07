using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public GameObject eye; //Eyeオブジェクト
    float timer;//時間計測
    public float interval; //出るまでのインターバル


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //時間計測
        //Debug.Log(timer);
        if (timer > interval) //決めた時間が経過したら
        {


            //eye.SetActive(true);//アイセンサーを表示
            //指定したゲームオブジェクト（Eye）を生成して、変数objに情報を格納
            GameObject obj = Instantiate(
                 eye, //生成したいオブジェクト
                 transform.position, //どこに生成するか
                 eye.transform.rotation //どんな回転具合で出すか
                 );
            //生成したEyeの親オブジェクトは自分(gameObject)だとする Parent＝親
            obj.transform.SetParent(gameObject.transform);
            //obj.transform.localPosition = new Vector3(0, 2.2f, 1.2f); //親に対しての相対位置
            obj.transform.localPosition = new Vector3(0, 2.7f, 0.2f); //親に対しての相対位置
            obj.transform.localScale = new Vector3(1, 0.2f, 2);
            obj.transform.localRotation = Quaternion.Euler(30, 0, 0);
            // 生成したオブジェクト（Eye）がプレイヤーのもとへ向かっていく

            timer = 0;
        }
    }
}
