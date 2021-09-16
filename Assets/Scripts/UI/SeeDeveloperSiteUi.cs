using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeeDeveloperSiteUi : MonoBehaviour
{
    public void OpenSite(string URL) 
    {
        Application.OpenURL(URL);
    }
}
