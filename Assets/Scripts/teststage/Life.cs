using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.MemoryMappedFiles;
using System.Threading;

public class ReadLife : MonoBehaviour
{
    //���L�������̓ǂݍ���
    MemoryMappedFile lifefrombve;
    MemoryMappedViewAccessor life;
    public int lifetime;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        //BVE������
        MemoryMappedFile lifefrombve = MemoryMappedFile.OpenExisting("Life");
        life = lifefrombve.CreateViewAccessor();
        lifetime = life.ReadInt32(0);
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text= lifetime.ToString();//�������Ԃ̒l���e�L�X�g�ɑ��
    }
}
