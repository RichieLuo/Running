using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 碰撞检测 触发器
/// </summary>
public class Collide_Player : MonoBehaviour
{
    private Player_Buff buff;
    public GameObject PropBgm;
    // Start is called before the first frame update
    void Start()
    {
        buff = GetComponent<Player_Buff>();
    }

    
    /// <summary>
    /// 触发器
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag.ToString())
        {
            case "Tag_Chest"://碰到加速宝箱
                PlayBgm(1);
                buff.Speed_On = true;
                collision.gameObject.SetActive(false);
                GameBaseSetting.Score += 30;
                break;
            case "Tag_ChestJump"://碰到跳跃宝箱
                PlayBgm(1);
                buff.Jump_On = true;
                collision.gameObject.SetActive(false);
                GameBaseSetting.Score += 30;
                break;
            case "Tag_Icon"://碰到金币
                PlayBgm(0);
                collision.gameObject.SetActive(false);
                GameBaseSetting.Score++;
                break;
            case "Tag_Stabs"://碰到地刺
                if (GameBaseSetting.Life != 0)
                {
                    PlayBgm(2);
                    GameBaseSetting.Life--;
                }
                break;
            case "Tag_GameOver"://被卡住 直接结束游戏
                GameBaseSetting.Life = 0;
                break;
            default:
                break;
        }
        
    }

    void PlayBgm(int i)
    {
        PropBgm.GetComponent<AudioSource>().clip = PropBgm.GetComponent<BGMList>().Audio[i];
        PropBgm.GetComponent<AudioSource>().Play();
    }
}
