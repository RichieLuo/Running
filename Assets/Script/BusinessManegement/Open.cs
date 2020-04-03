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
    void Start()
    {
        Time.timeScale = 1;
        GameBaseSetting.Life = 5;
        GameBaseSetting.PartPosition = new int[] { -68, 0, 20, 36 };
        GameBaseSetting.Score = 0;
        User u= SaveJson.ReadJson<User>(GameBaseSetting.JsonPath);
        if (u != null)
        {
            GameBaseSetting.Sname = u.SName;
            GameBaseSetting.Id = u.Id;
        }
        SetValue();
        //初次打开设置音量
        if (!File.Exists(GameBaseSetting.VolJsonPath))
        {
            File.Create(GameBaseSetting.VolJsonPath).Dispose();

            VOLBase vOL = new VOLBase();
            vOL.ActionVOL = 1;
            vOL.BgmVOL = 1;
            vOL.PropVOL = 1;
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
    

}
