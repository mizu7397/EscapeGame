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
        Debug.Log("ÉçÅ[Éh");
        SceneManager.LoadScene(sceneName);
    }
}
