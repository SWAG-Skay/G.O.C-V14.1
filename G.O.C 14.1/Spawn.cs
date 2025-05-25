using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Permissions.Commands.Permissions;
using MEC;
using PlayerRoles;

namespace GOC
{
    public class Spawn
    {
        public void SpawnGOC(List<Player> players)
        {
            foreach (Player wouf in players)
            {
                wouf.Role.Set(RoleTypeId.Tutorial);

                Timing.CallDelayed(0.1f, () =>
                {
                    wouf.CustomInfo = Plugin.meow.Config.CustomInfo;
                    wouf.InfoArea = PlayerInfoArea.CustomInfo;
                    wouf.Position = Plugin.meow.Config.SpawnPos;
                    Plugin.meow.GOC.Add(wouf);
                    foreach (ItemType item in Plugin.meow.Config.ItemTypes)
                    {
                        wouf.AddItem(item);
                    }

                });
            }
        }
    }
}
