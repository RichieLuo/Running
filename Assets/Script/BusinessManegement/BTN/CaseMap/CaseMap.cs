using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaseMap : MonoBehaviour
{
    public void Map1Click()//关卡1点击事件
    {
        GameBaseSetting.Map = 1;//设置地图编号参数
        SceneManager.LoadScene("PCScene");//跳转
    }
    public void Map2Click()
    {
        GameBaseSetting.Map = 2;
        SceneManager.LoadScene("PCScene2");
    }
    public void BackClick()
    {
        SceneManager.LoadScene("Showcase");
    }
}
