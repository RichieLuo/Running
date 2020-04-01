using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Rotate : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.Rotate(Vector3.up, Time.deltaTime * 100, Space.Self);
    }
}
