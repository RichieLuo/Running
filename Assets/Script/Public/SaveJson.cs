using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class SaveJson
{
    public static void Save(string Path, string values)
    {
        try
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Dispose();
            }
            File.WriteAllText(Path, values);
            Debug.Log("保存成功");
        }
        catch (System.Exception)
        {

        }

    }
    public static T ReadJson<T>(string Path)
    {
        //T t;
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
           T t = JsonUtility.FromJson<T>(json);
            return t;
        }
        else
            return default;
    }

}

