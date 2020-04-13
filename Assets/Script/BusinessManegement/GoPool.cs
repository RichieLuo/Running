using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 创建地图预制件的对象池
/// </summary>
public class GoPool : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();//创建一个游戏对象列表
    public  GameObject GoPrefab;//默认使用的对象
    /// <summary>
    /// 获取列表的对象
    /// </summary>
    /// <param name="i">表示列表的第几个对象</param>
    /// <param name="remove">获取完对象之后是否从列表中删除</param>
    /// <returns></returns>
    public GameObject GetGo(int i,bool remove)
    {
        if (list[i] !=null)//判断对象列表书否为空，为空则返回默认对象
        {
            GameObject go = list[i];
            if (remove)
            {
                list.RemoveAt(i);//从列表删除
            }
            return Instantiate(go);//取到对象并将其实例化返回
        }
        else
        {
            return Instantiate(GoPrefab);
        }

    }
}
