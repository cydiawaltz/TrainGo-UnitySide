using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.Threading;

public class ReadArrival : MonoBehaviour
{
    //共有メモリの読み込み
    //停車
    MemoryMappedFile arrivalfrombve;
    MemoryMappedViewAccessor arrivaltime;
    //通過
    MemoryMappedFile pastfrombve;
    MemoryMappedViewAccessor pasttime;
    //判定
    MemoryMappedFile passfrombve;
    MemoryMappedViewAccessor passhantei;
    public int lifetime;
    public int pass
    public TextMeshProUGUI =textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //BVE側から
        //停車
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("Arrival");
        arrival = arrivalfrombve.CreateViewAccessor();
        arrivaltime = arrival.ReadInt32(0);
        //通過
        MemoryMappedFile pastfrombve = MemoryMappedFile.OpenExisting("Past");
        pasttime = pastfrombve.CreateViewAccessor();
        past = pasttime.ReadInt32(0);
        //通貨停車判定
        MemoryMappedFile passfrombve = MemoryMappedFile.OpenExisting("Past");
        pass = passhantei.CreateViewAccessor();
    }

    // Update is called once per frame
    void Update()
    {
        if(pass=1)//停車
        {
            textMeshPro.text= arrival.ToString();//到着時刻の値をテキストに代入
        }
        if(pass=0)//通過
        {
            textMeshPro.text= arrival.ToString();
        }
    }
}
