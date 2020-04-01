using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 进入开始游戏界面时执行的相关操作
/// </summary>
public class StartGame : MonoBehaviour
{

    public GameObject BGM;
    public GameObject ActionBGM;
    public GameObject PropBGM;

    void Start()
    {
        //生成首个地图模块
        GameObject go = GetComponent<GoPool>().GetGo(0,false);
        go.SetActive(true);

        //设置音量
        var Vol = SaveJson.ReadJson<VOLBase>(GameBaseSetting.VolJsonPath);
       
        VOLBaseSetting.BgmVOL = Vol.BgmVOL;
        VOLBaseSetting.ActionVOL = Vol.ActionVOL;
        VOLBaseSetting.PropVOL = Vol.PropVOL;

        BGM.GetComponent<AudioSource>().volume = Vol.BgmVOL;
        ActionBGM.GetComponent<AudioSource>().volume = Vol.ActionVOL;
        PropBGM.GetComponent<AudioSource>().volume = Vol.PropVOL;


    }
}
