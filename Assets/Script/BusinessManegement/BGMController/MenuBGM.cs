using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (GameBaseSetting.DestoryBGM)
        {
            Destroy(this.gameObject);
        }
    }
}
