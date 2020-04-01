using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本音量设置
/// </summary>
public class VOLBaseSetting 
{
    public static float BgmVOL;
    public static float PropVOL;
    public static float ActionVOL;
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
