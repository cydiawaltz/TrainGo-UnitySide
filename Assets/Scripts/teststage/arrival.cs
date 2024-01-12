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
    int past;
    int passtype1;
    public TextMeshProUGUI  textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //BVE側から
        //停車
        arrivalfrombve = MemoryMappedFile.OpenExisting("Arrival");
        arrival = arrivalfrombve.CreateViewAccessor();
        arrivaltime = arrival.ReadInt32(0);
        //通過
        MemoryMappedFile pastfrombve = MemoryMappedFile.OpenExisting("Past");
        pasttime = pastfrombve.CreateViewAccessor();
        past = pasttime.ReadInt32(0);
        //通貨停車判定
        MemoryMappedFile passfrombve = MemoryMappedFile.OpenExisting("Pass");
        pass = passfrombve.CreateViewAccessor();
        passtype1 =pass.ReadInt32(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(passtype1==1)//停車
        {
            textMeshPro.text= arrivaltime.ToString();//到着時刻の値をテキストに代入
        }
        if(passtype1==0)//通過
        {
            textMeshPro.text= past.ToString();//通貨時刻の値をテキストに代入
        }
        else
        {
            textMeshPro.text= "You can (not) advanced.";//You can (not) redo.
        }
    }
}
