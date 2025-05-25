using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Exiled.API.Features.Core.Generic;
using UnityEngine;

namespace GOC
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Skay";
        public override string Name => "GOC for V.14.1";
        public override string Prefix => "GOC14.1";
        public List<Player> GOC = new List<Player>();
        public static Spawn spawn;
        public static Plugin meow;
        public static Plugin Instance { get; private set; }
        public static System.Random random = new System.Random();
        public override void OnEnabled()
        {
            spawn = new Spawn();
            Instance = this;
            meow = this;
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            spawn = null;
            meow = null;
            Instance = null;

            Exiled.Events.Handlers.Server.RespawningTeam -= OnRespawningTeam;
            base.OnDisabled();
        }
        private void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            int ran = random.Next(0, 100);
            if (ran > Config.Chance)
                return;
            ev.IsAllowed = false;
            spawn.SpawnGOC(ev.Players);
            if (!string.IsNullOrEmpty(Config.CassieRussian))
            {
                Cassie.MessageTranslated(
    Config.CassieEnglish,
    Config.CassieRussian,
    isHeld: false,
    isNoisy: true,
    isSubtitles: true);

            }

        }

    }
}
