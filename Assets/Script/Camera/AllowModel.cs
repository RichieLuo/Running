using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowModel : MonoBehaviour
{
    //游戏人物猫或老鼠
    public GameObject P1;
    public GameObject P2;
    public Transform tsf;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //根据一个Static的数值来决定是哪一个角色
        if (GameBaseSetting.Player == 1)
        {
            P1.SetActive(true);
            P2.SetActive(false);
        }
        else
        {

            P2.SetActive(true);
            P1.SetActive(false);
        }
        //获取根据标签获取角色的位置，使摄像机跟随
        tsf = GameObject.FindGameObjectWithTag("Tag_Player").transform;
        offset = transform.position - tsf.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = offset + tsf.position;

        transform.position = new Vector3()
        {
            x = Position.x,
            y = Position.y,
            z = -5.74f
        };
    }
}
