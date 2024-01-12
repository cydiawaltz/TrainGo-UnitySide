using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.Threading;

public class ReadLife : MonoBehaviour
{
    //共有メモリの読み込み
    MemoryMappedFile lifefrombve;
    MemoryMappedViewAccessor life;
    public int lifetime;
    public TextMeshProUGUI =textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //BVE側から
        MemoryMappedFile lifefrombve = MemoryMappedFile.OpenExisting("Life");
        life = lifefrombve.CreateViewAccessor();
        lifetime = life.ReadInt32(0);
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text= lifetime.ToString();//持ち時間の値をテキストに代入
    }
}
