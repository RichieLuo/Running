﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      this.gameObject.GetComponent<Toggle>().isOn=GameBaseSetting.Test;
    }

    public void btnTest(bool test)
    {
        GameBaseSetting.Test = test;
    }
}
