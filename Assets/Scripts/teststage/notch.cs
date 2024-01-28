using UnityEngine;
using TMPro;
using System.IO.MemoryMappedFiles;

public class ReadNotch : MonoBehaviour
{
    MemoryMappedViewAccessor powernotch;
    MemoryMappedViewAccessor brakenotch;
    public int Power;//力行ノッチ
    public int Brake;//ブレーキノッチ
    public TextMeshProUGUI textMeshpro;
    public TextMeshProUGUI textmeshpro;
    // Start is called before the first frame update
    void Start()
    {
        //力行ノッチ
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("Power");
        powernotch = arrivalfrombve.CreateViewAccessor();
        Power = powernotch.ReadInt32(1);
        //ブレーキノッチ
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("Brake");
        brakenotch = a.CreateViewAccessor();
        Brake = brakenotch.ReadInt32(1);
    }

    // Update is called once per frame
    void Update()
    {
        textMeshpro.text = Power.ToString();//力行ノッチの値
        textmeshpro.text = Brake.ToString();//ブレーキノッチの値
    }
    void OnApplicationQuit()//アプリケーションの終了時に呼び出す
    {
        //powernotch.Dispose();
        //brakenotch.Dispose();
    }
}
