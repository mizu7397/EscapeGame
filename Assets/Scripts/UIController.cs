using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour

{
    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false); //�Q�[���I�[�o�[�p�l����\�����Ȃ��悤�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        //�����Q�[���}�l�[�W���[�̃Q�[���I�[�o�[�Ƃ����ϐ���true�ɂȂ�����Q�[���I�[�o�[�p�l����\������
        if (GameManager.gameover == true)
        {
            gameoverPanel.SetActive (true);
        }
    }
}
