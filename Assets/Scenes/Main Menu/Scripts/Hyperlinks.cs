using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    // Start is called before the first frame update

    public void OpenURL(string link)
    {
        Application.OpenURL (link);
    }
}
