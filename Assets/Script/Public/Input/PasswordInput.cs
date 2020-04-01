using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
   public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.contentType = InputField.ContentType.Password;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
