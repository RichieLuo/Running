using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 计算成绩、生命值
/// </summary>
public class UpdateScore : MonoBehaviour
{

    public GameObject TxtScore;
    public GameObject TxtLife;
    // Update is called once per frame
    void Update()
    {
        TxtScore.GetComponent<Text>().text = GameBaseSetting.Score.ToString();
        TxtLife.GetComponent<Text>().text = GameBaseSetting.Life.ToString();

    }
}
