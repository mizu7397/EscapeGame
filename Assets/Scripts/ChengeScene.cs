using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeScene : MonoBehaviour
{
    public string sceneName;
    public void Load()
    {
        Debug.Log("���[�h");
        SceneManager.LoadScene(sceneName);
    }
}
