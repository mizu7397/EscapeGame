using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wacther : MonoBehaviour
{
    public float eyeHeight = 1.5f;              //�ڂ̍���
    public float viewDistance = 60f;            //�����̓͂�����
    public Vector3 direction = Vector3.right;   //�����̕���
    public LayerMask playerLayer;            //�v���C���[�������郌�C���[
    public bool playerDetected = false;         //�v���C���[�����������ǂ���
    public float checkIntervel = 3f;          //�`�F�b�N�̎��ԁi�b�j
    public LayerMask blockLayer; //��Q���̃��C���[ 
    bool isSafe=false;//��Q������������
    bool isDisCover=false;//�v���C���[�����������ǂ���
    bool isCheck = false;
    public GameObject eyeImage;

    private Vector3 eyePosition;
    void Start()
    {
        //���Ԋu��CheckPlayer���J��Ԃ��i0�b��ɊJ�n���AcheckInteval1�b���Ɓj
        InvokeRepeating("CheckReverse",5f,checkIntervel);
    }
    private void Update()
    {
        if (isCheck==true)
        {
            //�ڋʂ�UI���o��
            CheckPlayer();
            eyeImage.SetActive(true);
        }
        else
        {
            eyeImage.SetActive(false);
        }
    }
    //�`�F�b�N�t���O�𔽓]�@��false��true ���@true��false
    void CheckReverse()
    {
        //���̎����𔽓]�����č��ɑ��
        isCheck = !isCheck;
    }
    // Update is called once per frame
    void CheckPlayer()
    {
        isDisCover = false;
        isSafe = false;
        playerDetected = false;
        Debug.Log("�`�F�b�N�J�n");
       //�W���C�A���g�̈ʒu�{�A�C�n�C�g���̍���
        Vector3 origin = transform.position + new Vector3(0, eyeHeight, 0);
        //�W���C�A���g�̑O��
        Vector3 direction = transform.forward;

        RaycastHit[] hits;�@//�z��@�������̒l���i�[�������

        hits = Physics.RaycastAll(
            origin,//�ڐ��̏ꏊ
            direction,//����
            viewDistance//����
            );

        //�J��Ԃ��\���@for��
        //hits�̒��Ɋi�[�����I�u�W�F�N�g�̓_�����J��Ԃ�
        //far (�ǂ̂��炢�J��Ԃ����̏���������){�J��Ԃ���������}
        
        // int i�̓J�E���g�ϐ�
        //�@�J�E���^�[�ϐ�i�̐錾�ƍŏ��̐������߂�
        //�Ai���������J��Ԃ��̂������߂Ă���B//hits�z��̒��̐��i�����jLength
        //�B����΂��Ő����邩�B�i������񐔂ɈႢ���o��j�ϐ���++�Ƃ����̂͂��̕ϐ���1�����₷
        for ( int i = 0; i < hits.Length; i++)
        {
            GameObject obj = hits[i].collider.gameObject;
            //��Q�����C���[���ǂ����`�F�b�N
            if (IsInLayerMask(obj,blockLayer))
            {
                Debug.Log("��Q���ɂ��Z�[�t");
                isSafe = true;
                return;//�J��Ԃ���for���������I��
            }
            else
            {
                Debug.Log("�����I");
                isDisCover = true;
            }
        }
        if (isSafe == false && isDisCover == true)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }

        //�����ɉ����Ԃ�����������
        //if (Physics.Raycast(origin, direction,out hit, viewDistance, playerLayer))
        //{
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        if (!playerDetected)
        //        {
        //            playerDetected = true;
        //            Debug.Log("�v���C���[�𔭌�");
        //            //�����ŃQ�[���I�[�o�[��A���[���̏������Ă�
        //        }
        //    }
        //}
        //else
        //{
        //    playerDetected = false;
        //}
    }

    //���C���[���`�F�b�N���郁�\�b�h
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