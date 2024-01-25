using UnityEngine;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System;
using System.Collections;
using TMPro;


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
    int kakusikeiteki = 2;//各死刑的
    MemoryMappedViewAccessor beacon;
    MemoryMappedViewAccessor speedfrombve;
    MemoryMappedViewAccessor NowLoca;
    MemoryMappedViewAccessor next;
    MemoryMappedViewAccessor horn;
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
    public bool HideHorn;
    public int Onhorn;
    //他スクリプト
    public ReadNotch notch;
    public ReadArrival arriv;
    //ここから音声・画像など
    public GameObject yokokumusi;//予告無視時にオンに、「予告無視」ボイスと画像を入れる 
    public GameObject Grate;//Grate!時に表示
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        //arrival
        arrival = arriv.arrivaltime;
        //past
        past = arriv.past;
        //Beacon
        MemoryMappedFile beaconfrombve = MemoryMappedFile.OpenExisting("Horn");
        beacon = beaconfrombve.CreateViewAccessor();
        beacontype = beacon.ReadInt32(0);
        //Speed
        MemoryMappedFile speedfrombv = MemoryMappedFile.OpenExisting("speed");
        speedfrombve = speedfrombv.CreateViewAccessor();
        speed = speedfrombve.ReadSingle(0);
        //ノッチ
        Power = notch.Power;
        Brake = notch.Brake;
        //距離
        MemoryMappedFile a = MemoryMappedFile.OpenExisting("NowLocation");
        NowLoca = a.CreateViewAccessor();
        nowlocation = NowLoca.ReadSingle(0);
        //次駅
        MemoryMappedFile b = MemoryMappedFile.OpenExisting("NextLocation");
        next = b.CreateViewAccessor();
        NextLocation = next.ReadSingle(0);
        //現在
        now = arriv.now;
        //各死刑的
        HideHorn = false;
        MemoryMappedFile c = MemoryMappedFile.OpenExisting("arrival");
        horn = c.CreateViewAccessor();
        Onhorn = horn.ReadInt32(0);
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
                case 26:
                    atc = 80;
                    break;
                case 900://隠し警笛開始
                    HideHorn = true;
                    break;
                case 901://隠し警笛終了
                    HideHorn = false;
                    break;
            }
        textMeshProUGUI.text = life.ToString();
        //減点処理・加点処理
        //前方予告無視
        if(atc<speed && Brake == 0)
        {
            life -=overatc;
            yokokumusi.SetActive(true);
            Thread.Sleep(2000);
            yokokumusi.SetActive(false);
        }
        //遅れ・定通
        if(arriv.passhantei == true)//停車時
        {
            //遅れが５秒超え、１秒おき
            if(arrival - now >5000 )
            {
                //範囲外
                if(Math.Abs(nowlocation - NextLocation)>GoukakuHani )
                {
                    life -= overtime;//５秒以上遅れたら１秒ごとに減点
                    Thread.Sleep(1000);
                }
                //範囲内かつ停車していない
                if(Math.Abs(nowlocation - NextLocation)<GoukakuHani && speed>0)
                {
                    life-= overtime;
                    Thread.Sleep(1000);
                }
            }
            //Grate!
            if(Math.Abs(arrival - now) < 1000 && Math.Abs(nowlocation - NextLocation)<0.5)
            {
                
                life += grate;//Grate!
                Thread.Sleep(50000);
            }
            //Good!
            if(Math.Abs(nowlocation - NextLocation)<0.5)
            {
                life += good;//good!
                Thread.Sleep(50000);
            }
            //オーバーラン
            if (nowlocation > GoukakuHani + NextLocation)//過走時
            {
                if (speed == 0)
                {
                    int overrun = Convert.ToInt32(nowlocation - NextLocation);
                    life -= overrun;
                    Thread.Sleep(500000);
                }
            }

        }
        if(arriv.passhantei == false)//通過
        {
            if(arrival - now >5000 && NextLocation > nowlocation)//５秒過ぎたあと,次駅距離>現在距離
            {
                life -= overtime;
                Thread.Sleep(1000);
            }
            if(Math.Abs(arrival - now)<1000 &&NextLocation == nowlocation)
            {
                life += teitsuu;//定通
                Thread.Sleep(1000);
            }
        }
        if(Brake == 8)//ノッチが非常の時
        {
            life -= hijouseidou;
            Thread.Sleep(4000);
        }
        //隠し警笛
        if(HideHorn == true)//隠し警笛ゾーン
        {
            if(Onhorn == 1)
            {
                life += kakusikeiteki;
                Thread.Sleep(1000);
            }
        }
    }
}