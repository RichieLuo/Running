using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制地图场景的启用
/// </summary>
public class MapController : MonoBehaviour
{
    /// <summary>
    /// 需要隐藏的对象
    /// </summary>
    public int HideObject;
    /// <summary>
    ///需要现实的对象
    /// </summary>
    public int ShowObject;

    private int[] PartPosition;
    // Start is called before the first frame update
    void Start()
    {
        PartPosition = GameBaseSetting.PartPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collision)
     {
        if (HideObject != -1)
        {
           //var del= GameObject.FindGameObjectWithTag("Tag_GoPool").GetComponent<GoPool>().GetGo(HideObject, false);
            var result = GameObject.Find("Part"+HideObject+"(Clone)");
            
            if (result != null)
            {
                PartPosition[HideObject] = PartPosition[HideObject] + 68;
                Destroy(result);//销毁
            }
            
        }
        if (ShowObject != -1)
        {
            var create= GameObject.FindGameObjectWithTag("Tag_GoPool").GetComponent<GoPool>().GetGo(ShowObject, false);
            create.transform.position =new Vector3(PartPosition[ShowObject],0,0);
            create.SetActive(true);//启用
        }
        var pst = this.gameObject.transform.position;
        this.gameObject.transform.position=new Vector3(pst.x+68f,pst.y,pst.z);//将该碰撞器转移到下一个位置

    }
}
