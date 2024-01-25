using UnityEngine;
using TMPro;
using System.IO.MemoryMappedFiles;
using System;

public class ReadArrival : MonoBehaviour
{
    //共有メモリの読み込み
    //停車
    MemoryMappedViewAccessor arrival;
    //通過
    MemoryMappedViewAccessor pasttime;
    //判定

    MemoryMappedViewAccessor pass;
    MemoryMappedViewAccessor nownow;
    public int now;
    TimeSpan nowtime;
    public int arrivaltime;
    TimeSpan Arritime;
    public int past;
    TimeSpan pastti;
    int passtype;
    public TextMeshProUGUI  textMeshPro;
    public TextMeshProUGUI text;
    public bool passhantei;
    // Start is called before the first frame update
    void Start()
    {
        //BVE側から
        //停車
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("arrival");
        arrival = arrivalfrombve.CreateViewAccessor();
        arrivaltime = arrival.ReadInt32(0);
        Arritime = TimeSpan.FromMilliseconds(arrivaltime);
        //通過
        MemoryMappedFile pastfrombve = MemoryMappedFile.OpenExisting("past");
        pasttime = pastfrombve.CreateViewAccessor();
        past = pasttime.ReadInt32(0);
        pastti = TimeSpan.FromMilliseconds(past);
        //通貨停車判定
        MemoryMappedFile passfrombve = MemoryMappedFile.OpenExisting("Passornot");
        pass = passfrombve.CreateViewAccessor();
        passtype =pass.ReadInt32(0);
        //現在
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("now");
        nownow = a.CreateViewAccessor();
        now =nownow.ReadInt32(0);
        nowtime = TimeSpan.FromMilliseconds(now);
    }

    // Update is called once per frame
    void Update()
    {
        if(passtype==0)//停車
        {
            textMeshPro.text = Arritime.ToString();
            passhantei = true;
        }
        if(passtype==1)//通過
        {
            textMeshPro.text= pastti.ToString();//通貨時刻の値をテキストに代入
            passhantei = false;
        }
        else
        {
            textMeshPro.text= "You can (not) redo.";//You can (not) advanced.
        }
        text.text = now.ToString();
    }
}
