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
        //BGM.GetComponent<AudioSource>().volume = i;


    }

    public void ChangeVOL(float i)
    {
        if (Gaming)
        {
            VOLBaseSetting.BgmVOL = i;
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
        var str = JsonUtility.ToJson(model);
        SaveJson.Save(GameBaseSetting.VolJsonPath, str);
    }
}
