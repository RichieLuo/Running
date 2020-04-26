using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 当游戏打开时所执行的方法
/// </summary>
public class Open : MonoBehaviour
{
    public GameObject Loginbtn;
    public GameObject Logoutbtn;
    public GameObject TT;
    // 
    void Awake()
    {
        Time.timeScale = 1; GameBaseSetting.Life = 5;//初始化生命值
        GameBaseSetting.PartPosition = new int[] { -68, 0, 20, 36 };//初始化地图位置
        GameBaseSetting.Score = 0;//分数
        GetValue();
        SetValue();
        if (!File.Exists(GameBaseSetting.VolJsonPath))//初次打开设置音量
        {
            File.Create(GameBaseSetting.VolJsonPath).Dispose();
            VOLBase vOL = new VOLBase()
            {
                ActionVOL = 0.5f, BgmVOL = 0.5f, PropVOL = 0.5f
            };
            File.WriteAllText(GameBaseSetting.VolJsonPath, JsonUtility.ToJson(vOL));
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetValue();
    }
    public void SetValue()
    {
        if (GameBaseSetting.Id != "")
        {
            Loginbtn.SetActive(false);
            Logoutbtn.SetActive(true);
            TT.SetActive(true);
            TT.GetComponent<Text>().text = "欢迎：" + GameBaseSetting.Sname;

        }
        else
        {
            Loginbtn.SetActive(true);
            Logoutbtn.SetActive(false);
            TT.SetActive(false);
        }
    }

    void GetValue()
    {
        User u = SaveJson.ReadJson<User>(GameBaseSetting.JsonPath);//用户文件
        if (u != null)
        {
            GameBaseSetting.Sname = u.SName;
            GameBaseSetting.Id = u.Id;
        }
    }
    

}
