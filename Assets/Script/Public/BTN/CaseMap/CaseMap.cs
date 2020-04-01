using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaseMap : MonoBehaviour
{
    public void Map1Click()
    {
        GameBaseSetting.Map = 1;
        SceneManager.LoadScene("PCScene");
    }
    public void Map2Click()
    {
        GameBaseSetting.Map = 2;
        SceneManager.LoadScene("PCScene2");
    }
    public void BackClick()
    {
        SceneManager.LoadScene("Showcase");
    }
}
