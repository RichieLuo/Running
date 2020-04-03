using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class IndexBtn : MonoBehaviour
{
    public GameObject Active;
    public GameObject msg;
    /// <summary>
    /// 前往登录页面
    /// </summary>
    public void GotoLoginClick()
    {
        SceneManager.LoadScene("Login");
    }
    public void LogoutClick()
    {
        File.Delete(GameBaseSetting.JsonPath);
        GameBaseSetting.Id = "";
    }
    /// <summary>
    /// 前往查看成绩页面
    /// </summary>
    public void GotoCourseClick()
    {
        SceneManager.LoadScene("Score");
    }

    public void player1Click()
    {
        GameBaseSetting.Player = 1;
        SceneManager.LoadScene("CaseMap");
    }
    public void player2Click()
    {
        GameBaseSetting.Player = 2;
        SceneManager.LoadScene("CaseMap");
    }


 
}
