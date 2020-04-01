using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 创建地图预制件的对象池
/// </summary>
public class GoPool : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public  GameObject GoPrefab;
    public GameObject GetGo(int i,bool remove)
    {
        if (list[i] !=null)
        {
            //Debug.Log(list[0].name);
            GameObject go = list[i];
            if (remove)
            {
                list.RemoveAt(i);
            }
            return Instantiate(go);
        }
        else
        {
            return Instantiate(GoPrefab);
        }

    }
}
