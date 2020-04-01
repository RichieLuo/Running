using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNClick : MonoBehaviour
{
    public GameObject Settingpanel;
    public GameObject Begin;
    public void Setting()
    {
        Time.timeScale = 0;
        Settingpanel.SetActive(true);
        Begin.SetActive(false);
    }
    public void Cintiune()
    {
        Settingpanel.SetActive(false);
        Time.timeScale = 1;
        var go = GameObject.FindGameObjectWithTag("Tag_Player").GetComponent<ActionController>();
        go.IsStart = false;
        go.runing = true;
    }
    public void BackIndex()
    {
        SceneManager.LoadScene("Showcase");
    }
    public void Play()
    {
        var go = GameObject.FindGameObjectWithTag("Tag_Player").GetComponent<ActionController>();
        go.IsStart = false;
        go.runing = true;
        this.gameObject.SetActive(false);

    }
    public void Jump()
    {
        var go = GameObject.FindGameObjectWithTag("Tag_Player").GetComponent<ActionController>();
        go.isJump = true;
        //this.gameObject.SetActive(false);

    }
}
