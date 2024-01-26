using UnityEngine;
using SatorImaging.AppWindowUtility;

public class onstart : MonoBehaviour
{
    private void Start()
    {
        AppWindowUtility.Transparent = true;//透明にする
        AppWindowUtility.FullScreen = true;//フルスクリーンにする
    }
}
//このスクリプトはTestStageシーンの開始時に実行するように