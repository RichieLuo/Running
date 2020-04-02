using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏的基本设置
/// </summary>
public class GameBaseSetting
{
    /// <summary>
    /// 默认选择角色
    /// </summary>
    public static int Player = 1;
    /// <summary>
    /// 默认地图
    /// </summary>
    public static int Map = 1;
    /// <summary>
    /// 初始分数
    /// </summary>
    public static int Score = 0;
    /// <summary>
    /// 初始生命值
    /// </summary>
    public static int Life = 5;
    /// <summary>
    /// 发送分数
    /// </summary>
    public static bool SendScore = false;
    /// <summary>
    /// 关卡地图初始位置
    /// </summary>
    public static int[] PartPosition = new int[] { -68, 0, 20, 36 };
    /// <summary>
    /// 文件的路径
    /// </summary>
    public static string JsonPath = Application.persistentDataPath + "/U.json";
    public static string ScoreJsonPath = Application.persistentDataPath + "/S.json";
    public static string VolJsonPath = Application.persistentDataPath + "/V.json";
    //public const string URL = "http://192.168.2.242:8088";
    public const string URL = "http://localhost:4751";
    /// <summary>
    /// 用户名
    /// </summary>
    public static string Sname = "未登录";
    /// <summary>
    /// 用户Id
    /// </summary>
    public static string Id = "";


}
