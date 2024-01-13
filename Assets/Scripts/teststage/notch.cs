using UnityEngine;
using TMPro;
using System.IO.MemoryMappedFiles;

public class ReadNotch : MonoBehaviour
{
    MemoryMappedViewAccessor powernotch;
    MemoryMappedViewAccessor brakenotch;
    int Power;//力行ノッチ
    int brake;//ブレーキノッチ
    public TextMeshProUGUI textMeshpro;
    public TextMeshProUGUI textmeshpro;
    // Start is called before the first frame update
    void Start()
    {
        //力行ノッチ
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("PowerNotch");
        powernotch = arrivalfrombve.CreateViewAccessor();
        Power = powernotch.ReadInt32(0);
        //ブレーキノッチ
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("BrakeNotch");
        brakenotch = a.CreateViewAccessor();
        brake = brakenotch.ReadInt32(0);
    }

    // Update is called once per frame
    void Update()
    {
        textMeshpro.text = Power.ToString();//力行ノッチの値
        textmeshpro.text = brake.ToString();//ブレーキノッチの値
    }
    void OnApplicationQuit()//アプリケーションの終了時に呼び出す
    {
        powernotch.Dispose();
        brakenotch.Dispose();
    }
}