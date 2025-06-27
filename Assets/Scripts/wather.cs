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
        //�ڐ��̈ʒu���X�V�i������
        //eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);
        //ray���΂�
        //Ray ray = new Ray(eyePosition, transform.TransformDirection(direction));
        RaycastHit hit;
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        Vector3 direction = transform.forward;

        //�f�o�b�O�\���iScene�r���[�Ō�����j
        //Debug.DrawRay(eyePosition, transform.TransformDirection(direction) * viewDistance, Color.red);

        //�����ɉ����Ԃ�����������
        if (Physics.Raycast(origin, direction,out hit, viewDistance, detectionLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (!playerDetected)
                {
                    playerDetected = true;
                    Debug.Log("�v���C���[�𔭌�");
                    //�����ŃQ�[���I�[�o�[��A���[���̏������Ă�
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