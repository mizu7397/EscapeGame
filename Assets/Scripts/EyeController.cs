using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public GameObject eye; //Eye�I�u�W�F�N�g
    float timer;//���Ԍv��
    public float interval; //�o��܂ł̃C���^�[�o��
    bool isDisplay; //�\������Ă��邩�ǂ����̃t���O

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��ɃA�C�Z���T�[���\��
        //eye.SetActive(false);
        isDisplay = false; //�\���t���O��OFF
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //���Ԍv��
        //Debug.Log(timer);
        if(timer > interval) //���߂����Ԃ��o�߂�����
        {
            isDisplay = !isDisplay; //�t�]������
            if(isDisplay) //�t���O��true�̎�
            {
                //eye.SetActive(true);//�A�C�Z���T�[��\��
                //�w�肵�����𐶐�����
                Instantiate(
                    eye, //�����������I�u�W�F�N�g
                    transform.position,�@//�ǂ��ɐ������邩
                    eye.transform.rotation�@//�ǂ�ȉ�]��ŏo����
                    );
            }
            else�@//�t���O��false�̎�
            {
                eye.SetActive(false);
            }
            timer = 0;
        }
    }
}
