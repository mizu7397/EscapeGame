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
            //Debug.Log("�Z�[�t");
        }
    }

    //�Փ˔���
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Eye") || (collision.gameObject.tag == "SafeBlock"))
        {
            //Debug.Log("�Z�[�t");
            triggerCount++;//��d�Ȃ�x��1���Z
        }

    }
}
