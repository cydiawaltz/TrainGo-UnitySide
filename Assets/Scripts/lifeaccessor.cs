using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.MemoryMappedFiles;

public class lifeaccessor : MonoBehaviour
{
    //public Syokyu life;
    //int lifetime;
    MemoryMappedViewAccessor lifetobve;
    
    // Start is called before the first frame update
    void Start()
    {
        //lifetime = life.life;
        MemoryMappedFile l = MemoryMappedFile.CreateNew("life", 1000);
        lifetobve = l.CreateViewAccessor();
        lifetobve.Write(0,30);
    }

    // Update is called once per frame
    void Update()
    {
        //lifetobve.Write(0,lifetime);
        DontDestroyOnLoad(this.gameObject);
    }
}
