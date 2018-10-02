﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;

namespace ClassicUO.Game.GameObjects
{
    public static class ContainerManager
    {
        //private static readonly ContainerData _default = new ContainerData(0x3C, 44, 65, 142, 94, 0x48);

        //static ContainerManager()
        //{
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(File.OpenRead(@"D:\Giochi\Ultima Online Classic ORION\OrionData\containers.txt")))
        //        {
        //            string line;
        //            StringBuilder sb = new StringBuilder();

        //            while (!reader.EndOfStream)
        //            {
        //                line = reader.ReadLine();
        //                if (line.StartsWith("#"))
        //                    continue;

        //                ushort id = ushort.Parse(line.Substring(2, line.IndexOf(" ") - 1), NumberStyles.HexNumber);

        //                line = line.Replace(" ", ",").Remove(line.Length - 1);
        //                line = $"new ContainerData({line})";

        //                sb.Append("{ 0x");
        //                sb.Append(id.ToString("X"));
        //                sb.Append(", ");
        //                sb.Append(line);
        //                sb.AppendLine("}, ");
        //            }

        //            string aaa =
        //                sb.ToString();

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //}

        private static readonly Dictionary<Graphic, ContainerData> _data = new Dictionary<Graphic, ContainerData>
        {
            { 0x9, new ContainerData(0x0009,0x0000,0x0000,20,85,124,19)},
            { 0x3C, new ContainerData(0x003C,0x0048,0x0058,44,65,186,15)},
            { 0x3D, new ContainerData(0x003D,0x0048,0x0058,29,34,137,12)},
            { 0x3E, new ContainerData(0x003E,0x002F,0x002E,33,36,142,14)},
            { 0x3F, new ContainerData(0x003F,0x004F,0x0058,19,47,182,12)},
            { 0x40, new ContainerData(0x0040,0x002D,0x002C,16,51,150,14)},
            { 0x41, new ContainerData(0x0041,0x004F,0x0058,35,38,145,11)},
            { 0x42, new ContainerData(0x0042,0x002D,0x002C,18,105,162,17)},
            { 0x43, new ContainerData(0x0043,0x002D,0x002C,16,51,181,12)},
            { 0x44, new ContainerData(0x0044,0x002D,0x002C,20,10,170,10)},
            { 0x48, new ContainerData(0x0048,0x002F,0x002E,16,10,154,9)},
            { 0x49, new ContainerData(0x0049,0x002D,0x002C,18,105,162,17)},
            { 0x4A, new ContainerData(0x004A,0x002D,0x002C,18,105,162,17)},
            { 0x4B, new ContainerData(0x004B,0x002D,0x002C,16,51,184,12)},
            { 0x4C, new ContainerData(0x004C,0x002D,0x002C,46,74,196,18)},
            { 0x4D, new ContainerData(0x004D,0x002F,0x002E,76,12,140,6)},
            { 0x4E, new ContainerData(0x004E,0x002D,0x002C,24,96,140,15)},
            { 0x4F, new ContainerData(0x004F,0x002D,0x002C,24,96,140,15)},
            { 0x51, new ContainerData(0x0051,0x002F,0x002E,16,10,154,9)},
            { 0x91A, new ContainerData(0x091A,0x0000,0x0000,1,13,260,19)},
            { 0x92E, new ContainerData(0x092E,0x0000,0x0000,1,13,260,19)},
            { 0x104, new ContainerData(0x0104,0x002F,0x002E,0,20,168,11)},
            { 0x105, new ContainerData(0x0105,0x002F,0x002E,0,20,168,11)},
            { 0x106, new ContainerData(0x0106,0x002F,0x002E,0,20,168,11)},
            { 0x107, new ContainerData(0x0107,0x002F,0x002E,0,20,168,11)},
            { 0x108, new ContainerData(0x0108,0x004F,0x0058,0,35,150,10)},
            { 0x109, new ContainerData(0x0109,0x002F,0x002E,0,20,175,10)},
            { 0x10A, new ContainerData(0x010A,0x002F,0x002E,0,20,175,10)},
            { 0x10B, new ContainerData(0x010B,0x002F,0x002E,0,20,175,10)},
            { 0x10C, new ContainerData(0x010C,0x002F,0x002E,0,20,168,11)},
            { 0x10D, new ContainerData(0x010D,0x002F,0x002E,0,20,168,11)},
            { 0x10E, new ContainerData(0x010E,0x002F,0x002E,0,20,168,11)},
            { 0x102, new ContainerData(0x0102,0x004F,0x0058,15,10,245,12)},
            { 0x11B, new ContainerData(0x011B,0x004F,0x0058,15,10,220,12)},
            { 0x11C, new ContainerData(0x011C,0x004F,0x0058,10,10,220,14)},
            { 0x11D, new ContainerData(0x011D,0x004F,0x0058,10,10,220,13)},
            { 0x11E, new ContainerData(0x011E,0x004F,0x0058,15,10,290,13)},
            { 0x11F, new ContainerData(0x011F,0x004F,0x0058,15,10,220,12)},
            { 0x58E, new ContainerData(0x058E,0x002D,0x002C,16,51,184,12)},
            { 0x484, new ContainerData(0x0484,0x064F,0x0000,5,43,160,10)}, 
        };


        public static ContainerData Get(Graphic graphic) => !_data.TryGetValue(graphic, out ContainerData value) ? _data[0x9] : value;
    }

    public class ContainerData
    {
        public ContainerData(Graphic graphic, ushort sound, ushort closed, int x, int y, int w, int h)
        {
            Graphic = graphic;
            Bounds = new Rectangle(x, y, w, h);
            OpenSound = sound;
            ClosedSound = closed;
        }

        public Graphic Graphic { get; }
        public Rectangle Bounds { get; }
        public ushort OpenSound { get; }
        public ushort ClosedSound { get; }
    }
}