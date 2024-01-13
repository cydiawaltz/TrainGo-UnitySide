using UnityEngine;
using System.IO.MemoryMappedFiles;

public class ReadLife : MonoBehaviour
{
    //持ち時間の設定
    int life = 30;//
    int overatc = 2;//atc超過（予告無視）
    int overtime = 5;//時間超過
    int teitsuu = 3;//定通ボーナス
    int grate = 5;//Grate停車
    int good = 3;//Good停
    int GoukakuHani = 4;//合格範囲(m)
    int saikasoku = 5;//駅構内再加速
    int HijouSeidouTeisya = 5;//非常制動停車
    int hijouseidou = 3;//非常制動
    MemoryMappedViewAccessor arrival;
    MemoryMappedViewAccessor beacon;
    int arrivaltime;
    int beacontype;
    int atc;
    // Start is called before the first frame update
    void Start()
    {
        MemoryMappedFile arrivalfrombve = MemoryMappedFile.OpenExisting("arrival");
        arrival = arrivalfrombve.CreateViewAccessor();
        arrivaltime = arrival.ReadInt32(0);
        //Beacon
        MemoryMappedFile beaconfrombve = MemoryMappedFile.OpenExisting("arrival");
        beacon = beaconfrombve.CreateViewAccessor();
        beacontype = beacon.ReadInt32(0);
        atc=80;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (beacontype)
            {
                //ATC信号0
                case 10:
                    atc = 0;
                    break;
                //ATC信号40
                case 18:
                    atc = 40;
                    break;
                //ATC45
                case 19:
                    atc = 45;
                    break;
                //ATC55
                case 21:
                    atc = 55;
                    break;
                //ATC65
                case 23:
                    atc = 65;
                    break;
                //ATC75
                case 25:
                    atc = 75;
                    break;
                case 26://そうでないときはクソめんどいのでATC80
                    atc = 80;
                    break;
            }
    }
}
