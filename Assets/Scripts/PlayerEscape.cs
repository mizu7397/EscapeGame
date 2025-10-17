using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEscape : MonoBehaviour
{
    int triggerCount = 0;
    private void Update()
    {
        if (triggerCount >=2)
        {
            //Debug.Log("セーフ");
        }
    }

    //衝突判定
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Eye") || (collision.gameObject.tag == "SafeBlock"))
        {
            //Debug.Log("セーフ");
            triggerCount++;//一つ重なる度に1加算
        }

    }
}
