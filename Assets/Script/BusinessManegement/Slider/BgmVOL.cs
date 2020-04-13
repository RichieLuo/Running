using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmVOL : MonoBehaviour
{
    public GameObject BGM;
    public bool Gaming;
    public bool Prop;
    public bool Action;

    float i;
    private void Start()
    {
        if (Gaming)
        {
            i = VOLBaseSetting.BgmVOL;
        }
        else if (Prop)
        {
            i = VOLBaseSetting.PropVOL;
        }
        else if (Action)
        {
            i = VOLBaseSetting.ActionVOL;
        }

        this.gameObject.GetComponent<Scrollbar>().value = i;
    }

    public void ChangeVOL(float i)
    {
        if (Gaming)//判断该滑杆的属性
        {
            VOLBaseSetting.BgmVOL = i;//给全局变量赋值，i是当前拖动滑杆的值
        }
        else if (Prop)
        {
            VOLBaseSetting.PropVOL = i;
        }
        else if (Action)
        {
            VOLBaseSetting.ActionVOL = i;
        }
        BGM.GetComponent<AudioSource>().volume = i;
        var model = new VOLBase();
        model.ActionVOL = VOLBaseSetting.ActionVOL;
        model.PropVOL = VOLBaseSetting.PropVOL;
        model.BgmVOL = VOLBaseSetting.BgmVOL;
        var str = JsonUtility.ToJson(model);//根据最新的音量配置实例化一个新的实体，转换成Json串
        SaveJson.Save(GameBaseSetting.VolJsonPath, str);//保存到本地
    }
}
