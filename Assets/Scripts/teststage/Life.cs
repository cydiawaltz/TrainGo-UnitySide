using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.Threading;

public class ReadLife : MonoBehaviour
{
    MemoryMappedViewAccessor arrival;
    MemoryMappedFile arrivalfrombve;
    int arrivaltime;
    // Start is called before the first frame update
    void Start()
    {
        arrivalfrombve = MemoryMappedFile.OpenExisting("arrival");
        arrival = arrivalfrombve.CreateViewAccessor();
        arrivaltime = arrival.ReadInt32(0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
