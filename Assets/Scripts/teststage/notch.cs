using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.Threading;

public class ReadNotch : MonoBehaviour
{
    MemoryMappedViewAccessor powernotch;
    MemoryMappedViewAccessor brakenotch;
    int Power;//力行ノッチ
    int brake;//ブレーキノッチ
    TextMeshProUGUI = textmeshpro;
    TextMeshProUGUI = textmeshpro2;
    // Start is called before the first frame update
    void Start()
    {
        //力行ノッチ
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("PowerNotch");
        powernotch = arrivalfrombve.CreateViewAccessor();
        Power = powernotch.ReadInt32();
        //ブレーキノッチ
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("BrakeNotch");
        brakenotch = a.CreateViewAccessor();
        Brake = brakenotch.ReadInt32();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshpro.text = Power.ToString();//力行ノッチの値
        textmeshpro2.text = Brake.ToString();//ブレーキノッチの値
    }
    void OnApplicationQuit()//アプリケーションの終了時に呼び出す
    {
        powernotch.Dispose();
        brakenotch.Dispose();
    }
}
