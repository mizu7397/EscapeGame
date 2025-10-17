using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public GameObject eye; //Eyeオブジェクト
    float timer;//時間計測
    public float interval; //出るまでのインターバル
    bool isDisplay; //表示されているかどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        //最初にアイセンサーを非表示
        //eye.SetActive(false);
        isDisplay = false; //表示フラグをOFF
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //時間計測
        //Debug.Log(timer);
        if(timer > interval) //決めた時間が経過したら
        {
            isDisplay = !isDisplay; //逆転させる
            if(isDisplay) //フラグがtrueの時
            {
                //eye.SetActive(true);//アイセンサーを表示
                //指定した物を生成する
                Instantiate(
                    eye, //生成したいオブジェクト
                    transform.position,　//どこに生成するか
                    eye.transform.rotation　//どんな回転具合で出すか
                    );
            }
            else　//フラグがfalseの時
            {
                eye.SetActive(false);
            }
            timer = 0;
        }
    }
}
