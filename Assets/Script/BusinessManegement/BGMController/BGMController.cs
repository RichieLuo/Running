using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背景音乐
/// </summary>
public class BGMController : MonoBehaviour
{
    public GameObject BGM;
    public bool destory;
    GameObject CloneObj;
    void Start()
    {
        try
        {
            if (!GameBaseSetting.HasBGM)
            {
                CloneObj = Instantiate(BGM, BGM.transform) as GameObject;
                GameBaseSetting.HasBGM = true;
                CloneObj.GetComponent<AudioSource>().volume = VOLBaseSetting.BgmVOL;
            }

            DontDestroyOnLoad(CloneObj);
        }
        catch (System.Exception)
        {

            throw;
        }
        


    }
}
