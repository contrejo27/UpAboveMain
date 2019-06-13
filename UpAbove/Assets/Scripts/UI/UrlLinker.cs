using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlLinker : MonoBehaviour
{
    public void GoToURL()
    {
        Application.OpenURL("www.MagicBytes.com");
    }

    public void GoToURLCustom(string url)
    {
        Application.OpenURL(url);

    }
}
