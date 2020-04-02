using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本音量设置
/// </summary>
public class VOLBaseSetting 
{
    public static float BgmVOL=1;
    public static float PropVOL=1;
    public static float ActionVOL=1;
}

/// <summary>
/// 用于Json序列化
/// </summary>
[System.Serializable]
public class VOLBase
{
    public float BgmVOL;
    public float PropVOL;
    public float ActionVOL;
}
