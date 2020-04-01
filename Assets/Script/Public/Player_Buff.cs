using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Buff类
/// </summary>
public class Player_Buff : MonoBehaviour
{
    //速度,速度Buff,开关
    public float Speed;
    private float Speed_Buff = 3;
    public float Jumpheigh = 2;
    public bool Speed_On = false;
    public bool Jump_On = false;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //开启速度buff
        if (Speed_On)
        {
            Speed = Speed_Buff + Speed;
            Speed_On = false;
            Invoke("Reset", 5);//计时
        }
        if (Jump_On)
        {
            Jumpheigh= Jumpheigh + 0.5f;
            Jump_On = false;
            Invoke("Reset", 10);//计时
        }
    }
    /// <summary>
    /// 重置
    /// </summary>
    private void Reset()
    {
        if (!Speed_On)
        {
            Speed = 4;
        }
        if (!Jump_On)
        {
            Jumpheigh = 2;
        }

    }
}
