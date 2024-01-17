using UnityEngine;
using System.IO.MemoryMappedFiles;

public class Syokyu : MonoBehaviour
{
    //持ち時間の設定
    public int life = 30;//
    int overatc = 2;//atc超過（予告無視）
    int overtime = 1;//時間超過(１秒毎)
    int teitsuu = 3;//定通ボーナス
    int grate = 5;//Grate停車
    int good = 3;//Good停
    int GoukakuHani = 4;//合格範囲(m)
    int saikasoku = 5;//駅構内再加速
    int HijouSeidouTeisya = 5;//非常制動停車
    int hijouseidou = 3;//非常制動
    MemoryMappedViewAccessor beacon;
    MemoryMappedViewAccessor speedfrombve;
    MemoryMappedViewAccessor NowLoca;
    MemoryMappedViewAccessor next;
    public int arrivaltime;
    public int beacontype;
    public int atc;
    public float speed;
    int Power;
    int Brake;
    int arrival;
    int past;
    int now;
    public double nowlocation;
    public double NextLocation;
    //他スクリプト
    public Notch notch;
    public Arrival arriv; 
    // Start is called before the first frame update
    void Start()
    {
        //arrival
        arrival = arriv.arrivaltime;
        //past
        past = arriv.past;
        //Beacon
        MemoryMappedFile beaconfrombve = MemoryMappedFile.OpenExisting("arrival");
        beacon = beaconfrombve.CreateViewAccessor();
        beacontype = beacon.ReadInt32(0);
        //Speed
        MemoryMappedFile speedfrombv = MemoryMappedFile.OpenExisting("speed")
        speedfrombve = speedfrombv.CreateViewAccessor();
        speed = speedfrombve.ReadSingle(0);
        //ノッチ
        Power = notch.Power;
        Brake = notch.Brake;
        //距離
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("speed")
        NowLoca = a.CreateViewAccessor();
        nowlocation = NowLoca.ReadSingle(0);
        //次駅
        MemoryMappedFile b = MemoryMappedFile.OpenExisting("speed")
        next = b.CreateViewAccessor();
        NextLocation = next.ReadSingle(0);
        //現在
        now = arriv.now;
        //
        wait = false;
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
        //減点処理・加点処理
        if(atc<speed && Brake == 0)
        {
            life -=overatc;//予告無
        }
        //遅れ・定通
        if(arriv.passhantei = true)//停車時
        {
            //遅れが５秒超え、１秒おき、合格範囲外
            if(arrival - now >5000 && (arrival - now)% 1000 == 0 && Math.Abs(nowlocation - NextLocation)>GoukakuHani)
            {
                life -=overtime;//５秒以上遅れたら１秒ごとに減点
            }
            if(Math.Abs(milliarrival - millinow) < 1000 && Math.Abs(nowlocation - NextLocation)<0.5)
            {
                life += grate;//Grate!
            }
            if(Math.Abs(nowlocation - NextLocation)<0.5)
            {
                life -= good;
            }
        }

    }