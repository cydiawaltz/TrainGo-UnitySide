using UnityEngine;
using TMPro;
using System.IO.MemoryMappedFiles;

public class arritime :MonoBehaviour
{
    MemoryMappedViewAccessor arri;
    void Start()
    {
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("arrival");
        arri = a.CreateViewAccessor();
    }
    void Update()
    {

    }
}
