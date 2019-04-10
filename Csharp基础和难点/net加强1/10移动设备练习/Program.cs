using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10移动设备练习
{
    class Program
    {
        static void Main(string[] args)
        {
            Udisk u = new Udisk();
            Mp3 mp3 = new Mp3();
            MobileDisk md = new MobileDisk();
            Telphone t = new Telphone();
            Computer cpu = new Computer();
            cpu.MS = t; //u;//mp3;//将MP3插到了电脑上

            cpu.CpuRead();
            cpu.CpuWrite();
           // mp3.PlayMusic();
            Console.ReadKey();
        }
    }

    abstract class MobileStorage
    {
        public abstract void Read();
        public abstract void Write();
    }

    class Mp3 : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("MP3在读数据");
        }
        public override void Write()
        {
            Console.WriteLine("MP3在取数据");
        }
        public void PlayMusic()
        {
            Console.WriteLine("mp3在播放音乐");
        }
    }
    class Udisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("u盘在读数据");
        }
        public override void Write()
        {
            Console.WriteLine("u盘在取数据");
        }
    }
    class MobileDisk : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("移动硬盘在读取数据");
        }

        public override void Write()
        {
            Console.WriteLine("移动硬盘在写入数据");
        }
    }
    class Telphone : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("shouji在读取数据");
        }
        public override void Write()
        {
            Console.WriteLine("shouji 在qu取数据");
        }

    }
    class Computer 
    {
        public MobileStorage MS
        {
            get;
            set;
        }
        public void CpuRead()
        {
            this.MS.Read();
        }
        public void CpuWrite()
        {
            this.MS.Write();

        }
    }
}
