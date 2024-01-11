using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Text;
using System.Threading;

public class ReadLife : MonoBehaviour
{
    MemoryMappedFile lifefrombve;
    MemoryMappedViewAccessor life;
    // Start is called before the first frame update
    void Start()
    {
        //BVE‘¤‚©‚ç
        MemoryMappedFile lifefrombve = MemoryMappedFile.OpenExisting("Life");
        life = lifefrombve.CreateViewAccessor();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
