using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class IndexBtn : MonoBehaviour
{
    public GameObject Active;
    public GameObject msg;
    /// <summary>
    /// 前往登录页面
    /// </summary>
    public void GotoLoginClick()
    {
        SceneManager.LoadScene("Login");
    }
    public void LogoutClick()
    {
        File.Delete(GameBaseSetting.JsonPath);
        GameBaseSetting.Id = "";
    }
    /// <summary>
    /// 前往查看成绩页面
    /// </summary>
    public void GotoCourseClick()
    {
        SceneManager.LoadScene("Score");
    }

    public void player1Click()
    {
        GameBaseSetting.Player = 1;
        SceneManager.LoadScene("CaseMap");
    }
    public void player2Click()
    {
        GameBaseSetting.Player = 2;
        SceneManager.LoadScene("CaseMap");
    }


    /// <summary>
    /// 返回
    /// </summary>
    public void backClick()
    {
        SceneManager.LoadScene("Showcase");
    }


    #region 登录模块
    public void LoginClick()
    {
        Dictionary<string, string> formFields = new Dictionary<string, string>();
        string id = GameObject.Find("LoginId").GetComponent<InputField>().text;
        string pwd = GameObject.Find("LoginPwd").GetComponent<InputField>().text;
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
        {
            Active.GetComponent<Text>().text = "请将信息填写完整";
            msg.SetActive(true);
        }

        formFields.Add("userName", id);
        formFields.Add("Pwd", GetMD5(pwd));

        string url = string.Format("{0}/api/Account/Login?userName={1}&Pwd={2}",GameBaseSetting.URL, formFields["userName"], formFields["Pwd"]);
        StartCoroutine(RequestAction(true,url, formFields));
    }

    /// <summary>
    /// 前往登录
    /// </summary>
    public void GotoLogin()
    {
        GameObject.Find("PanelRegister").SetActive(false);
        Active.SetActive(true);
    }

    public void Login(HttpServer hs)
    {

        if (hs.value != "用户名或密码错误" && hs.value != "登录失败")
        {
            Save(hs.value);
            SceneManager.LoadScene("Showcase");
        }
        else
        {
            Active.GetComponent<Text>().text = hs.value;
            //GameObject.FindGameObjectWithTag("Tag_MsgTXT").SetActive(true);
            msg.SetActive(true);
        }

    }
    #endregion

    #region 注册模块
    public void RegisterClick()
    {
        Dictionary<string, string> formFields = new Dictionary<string, string>();

        string id = GameObject.Find("LoginId").GetComponent<InputField>().text;
        string pwd = GameObject.Find("LoginPwd").GetComponent<InputField>().text;
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
        {
            Active.GetComponent<Text>().text = "请将信息填写完整";
            msg.SetActive(true);
        }

        formFields.Add("userName", id);
        formFields.Add("Pwd", GetMD5(pwd));
        string url = string.Format("{0}/api/Account/Register?userName={1}&Pwd={2}", GameBaseSetting.URL, formFields["userName"], formFields["Pwd"]);
        StartCoroutine(RequestAction(false, url, formFields));
    }

    /// <summary>
    /// 前往注册
    /// </summary>
    public void GotoRegister()
    {
        GameObject.Find("PanelLogin").SetActive(false);
        Active.SetActive(true);
    }
    public void Register(HttpServer hs)
    {
        Active.GetComponent<Text>().text = hs.value;
        //GameObject.FindGameObjectWithTag("Tag_MsgTXT").SetActive(true);
        msg.SetActive(true);
    }

    #endregion




    /// <summary>
    /// Post远程服务器
    /// </summary>
    /// <returns></returns>
    public IEnumerator RequestAction(bool login, string url, Dictionary<string, string> formFields)
    {
        HttpServer hs = new HttpServer();
      
        
        yield return hs.SendPost(url, formFields);
        if (!hs.isComplete)
        {
            yield return null;
        }
        if (hs.isSucc)
        {
            if (login)
            {
                Login(hs);
            }
            else
            {
                Register(hs);
            }

        }
        else
        {
            msg.SetActive(true);
        }
    }
    /// <summary>
    /// 保存登录的信息
    /// </summary>
    /// <param name="values"></param>
    private void Save(string values)
    {
        //Debug.Log(values);
        try
        {
            SaveJson.Save(GameBaseSetting.JsonPath, values);
        }
        catch (System.Exception)
        {
            GameObject.FindGameObjectWithTag("Tag_Msg").SetActive(true);
            GameObject.FindGameObjectWithTag("Tag_MsgTXT").GetComponent<Text>().text = "连接失败";
            
        }

    }
    public void CloseMsg()
    {
        GameObject.FindGameObjectWithTag("Tag_MsgTXT").GetComponent<Text>().text = "";
        GameObject.FindGameObjectWithTag("Tag_Msg").SetActive(false);
        
    }
    public  string GetMD5(string msg)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
        byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
        md5.Clear();

        string destString = "";
        for (int i = 0; i < md5Data.Length; i++)
        {
            destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
        }
        destString = destString.PadLeft(32, '0');
        return destString;
    }

}
