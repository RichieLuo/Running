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
    public List<GameObject> WarnList;
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
        bool hide = false;
        switch (collision.gameObject.tag.ToString())//以标签名做为条件
        {
            case "Tag_Chest"://碰到加速宝箱
                PlayBgm(1);//播放音效
                buff.Speed_On =true;//打开Buff并隐藏
                hide = true;
                GameBaseSetting.Score += 10;
                break;
            case "Tag_ChestJump"://碰到跳跃宝箱
                PlayBgm(1); buff.Jump_On =true;  GameBaseSetting.Score += 10000;
                hide = true;
                break;
            case "Tag_Icon"://碰到金币
                PlayBgm(0); GameBaseSetting.Score++;
                hide = true;
                break;
            case "Tag_Stabs"://碰到地刺
                if (GameBaseSetting.Life != 0)
                {
                    PlayBgm(2);  GameBaseSetting.Life--;  WarnList[0].SetActive(true);  Invoke("ActiveFalse", 0.5f); 
                }
                break;
            case "Tag_Life"://胶囊
                PlayBgm(1);
                hide = true;
                if (GameBaseSetting.Life < 10)
                {
                    GameBaseSetting.Life++;  WarnList[1].SetActive(true);  GameBaseSetting.Score += 15;  Invoke("ActiveFalse", 0.5f); 
                }
                break;
            case "Tag_GameOver"://被卡住 直接结束游戏
                GameBaseSetting.Life = 0;
                break;
            default:
                break;
        }
        if (hide)
        {
            collision.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="i"></param>
    void PlayBgm(int i)
    {
        PropBgm.GetComponent<AudioSource>().clip = PropBgm.GetComponent<BGMList>().Audio[i];
        PropBgm.GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// 一个定时方法，定时让生命值变化的提示消失
    /// </summary>
    void ActiveFalse()
    {
        for (int i = 0;  i< WarnList.Count; i++)
        {
            WarnList[i].SetActive(false);
        }
    }

}
