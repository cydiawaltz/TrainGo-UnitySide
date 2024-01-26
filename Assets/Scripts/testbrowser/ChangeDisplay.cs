using UnityEngine;
using SatorImaging.AppWindowUtility;

public class ChangeDisplay : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1366,768,true);
        AppWindowUtility.AlwaysOnTop = true;//常に最前面に表示
    }
}