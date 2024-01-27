using UnityEngine;
//using SatorImaging.AppWindowUtility;
using Kirurobo.UniWindowController;

public class onstart : MonoBehaviour
{
    private void Start()
    {
        //AppWindowUtility.Transparent = true;//透明にする
        //AppWindowUtility.FullScreen = true;//フルスクリーンにする
        isTopmost = true;
        isZoomed = true;
        isTransparent = true;
    }
}
//このスクリプトはTestStageシーンの開始時に実行するように