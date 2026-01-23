using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour

{
    public GameObject gameoverPanel;
    public GameObject gameclearPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false); //ゲームオーバーパネルを表示しないようにする
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.gameover); 
        //もしゲームマネージャーのゲームオーバーという変数がtrueになったらゲームオーバーパネルを表示する
        if (GameManager.gameover == true)
        {
            //Debug.Log("パネルを出す");
            gameoverPanel.SetActive (true);
        }
        if (GameManager.gameclear == true)
        {
            //Debug.Log("パネルを出す");
            gameclearPanel.SetActive(true);
        }
    }
}
