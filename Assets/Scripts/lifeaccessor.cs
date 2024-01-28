using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.MemoryMappedFiles;

public class lifeaccessor : MonoBehaviour
{
    //public Syokyu life;
    //int lifetime;
    public MemoryMappedViewAccessor lifetobve;
    
    // Start is called before the first frame update
    void Start()
    {
        //lifetime = life.life;
        MemoryMappedFile l = MemoryMappedFile.CreateNew("life", 1000);
        lifetobve = l.CreateViewAccessor();
        lifetobve.Write(1,30);
    }

    // Update is called once per frame
    void Update()
    {
        //lifetobve.Write(0,lifetime);
        //DontDestroyOnLoad(this.gameObject);
        //↑死は救済だ
    }
}
