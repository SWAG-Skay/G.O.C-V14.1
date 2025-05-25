using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using UnityEngine;

namespace GOC
{
    public class Config : IConfig
    {
        [Description("Is it included Plugin?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Is it included Debug?")]
        public bool Debug { get; set; } = false;
        [Description("Exiled Verson")]
        public override Version RequiredExiledVersion => new Version(9, 6, 0);
         [Description("Plugin Version")]
         public override Version Version => new Version(1, 0, 0);
        [Description("Chance for spawn in %")]
        public int Chance { get; set; } = 15;
        [Description("Items for squad")]
        public List<ItemType> ItemTypes { get; set; } = new List<ItemType>() { ItemType.SCP500, ItemType.Adrenaline, ItemType.ArmorHeavy, ItemType.GunCrossvec, ItemType.KeycardMTFOperative, ItemType.Medkit };
        [Description("Spawn Position for spawn. X.Y.Z")]
        public Vector3 SpawnPos { get; set; } = new Vector3(137.069f, 295.453f, -60.365f);
        [Description("Custom Info")]
        public string CustomInfo { get; set; } = "Global Occult Coalition";

        [Description("CASSIE in English or other language")]
        public string CassieEnglish { get; set; } = "Attention. facility personnel. .g2 Global Occult Coalition task force. .g1 Designated. unit G.O.C. .g3 Has entered the containment. zone .g4  All personnel maintain current positions. await further instructions .g6";
        [Description("CSSIE in Russian or other language")]
        public string CassieRussian { get; set; } = "Внимание. персоналу объекта. .g2 Оперативная группа Глобальной Оккультной Коалиции. .g1 Под кодовым названием Г.О.К. .g3 Вошла в зону заражения .g4 Весь персонал остаётся на местах. Ожидайте дальнейших указаний .g6";
    }
}
