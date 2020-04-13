using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public GameObject TXT;
    public GameObject Content;
    public bool btn;
    // Start is called before the first frame update
    void Start()
    {
        if (!btn)
        {
            Continue("1");
        }

    }

    public void Btn1Click()
    {
        Content.transform.DetachChildren();
        Continue("1");
    }
    public void Btn2Click()
    {
        Content.transform.DetachChildren();
        Continue("2");
    }


    void Continue(string map)
    {
        StartCoroutine(RequestAction(GameBaseSetting.URL + "/api/score/GetScore?map=" + map));
    }
    IEnumerator RequestAction(string url)
    {
        HttpServer hs = new HttpServer();
        yield return hs.SendGet(url);
        if (!hs.isComplete)
        {
            yield return null;
        }
        if (hs.isSucc && hs.value != "查询失败")
        {
            var list = new List<Score>();
            var str = hs.value;
            str = "{ \"list\": " + str + "}";
            Response<Score> List = JsonUtility.FromJson<Response<Score>>(str);
            foreach (Score item in List.list)//遍历列表
            {
                GameObject _Instance = Instantiate(TXT);//实例化该预制件
                _Instance.GetComponent<Text>().text = item.UserName;//赋值并显示
                _Instance.transform.parent = Content.transform;
                GameObject _Instance2 = Instantiate(TXT);
                _Instance2.GetComponent<Text>().text = item.Credits.ToString();
                _Instance2.transform.parent = Content.transform;
            }
        }
    }
    // Json解析为该对象
    public class Response<T>
    {
        public List<T> list;
    }




}
