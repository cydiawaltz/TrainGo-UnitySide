using UnityEngine;
using TMPro;
using System.IO.MemoryMappedFiles;
using UnityEngine.Rendering;

public class ReadArrival : MonoBehaviour
{
    //共有メモリの読み込み
    //停車
    MemoryMappedViewAccessor arrival;
    MemoryMappedFile arrivalfrombve;
    //通過
    MemoryMappedViewAccessor pasttime;
    //判定
    MemoryMappedViewAccessor passhantei;
    MemoryMappedViewAccessor pass;
    int arrivaltime;
    TimeSpan Arritime;
    int past;
    TimeSpan pastti;
    int passtype;
    public TextMeshProUGUI  textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //BVE側から
        //停車
        arrivalfrombve = MemoryMappedFile.OpenExisting("arrival");
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
    }

    // Update is called once per frame
    void Update()
    {
        if(passtype==0)//停車
        {
            textMeshPro.text = Arritime.ToString();
        }
        if(passtype==1)//通過
        {
            textMeshPro.text= pastti.ToString();//通貨時刻の値をテキストに代入
        }
        else
        {
            textMeshPro.text= "You can (not) redo.";//You can (not) advanced.
        }
    }
}
