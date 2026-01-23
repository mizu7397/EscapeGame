using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerEscape : MonoBehaviour
{
    public bool eyeApproach;//Eyeが出ているかどうか
    public bool safeCollision;//セーフブロックに隠れているかどうか
    public bool eyeCollision;//Eyeに当たっているかどうか
    private void Update()
    {
        //Eyeが出ている最中にEyeに触れたとき、セーフブロックに隠れていなければゲームオーバー
        if (eyeApproach && eyeCollision && !safeCollision)
        {
            GameManager.gameover = true;
        }
    }

    //衝突判定
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Eye")
        {
            eyeCollision = true;
        }
        if (collision.gameObject.tag == "SafeBlock")
        {
            safeCollision = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            GameManager.gameclear = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeBlock")
        {
            safeCollision = false;
        }
    }
}
