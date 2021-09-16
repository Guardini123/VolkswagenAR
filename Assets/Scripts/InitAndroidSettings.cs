using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAndroidSettings : MonoBehaviour
{
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.TranslucentOverContent;
        ApplicationChrome.statusBarColor = ApplicationChrome.navigationBarColor = 0xff003068;
    }
}
