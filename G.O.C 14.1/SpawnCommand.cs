using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using PlayerRoles;
using RemoteAdmin;

namespace GOC
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnCommand : ICommand
    {
        public string Command => "sgoc";
        public string[] Aliases => new[] { "sg" };
        public string Description => "Spawn custom sqad callsed G.O.C. ";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "The command can only be executed by the player.";
                return false;
            }
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "Failed to get player data";
                return false;
            }
            if (player.CheckPermission("spawn.goc"))
            {
                response = "No rights";
                return false;
            }

            List<Player> spectators = Player.List.Where(p => p.Role.Type == RoleTypeId.Spectator).ToList();

            if (spectators.Count == 0)
            {
                response = "There are no players in the spectators!";
                return false;
            }

            try
            {
                Plugin.spawn.SpawnGOC(spectators);

                if (!string.IsNullOrWhiteSpace(Plugin.Instance.Config.CassieEnglish))
                {
                    if (!string.IsNullOrWhiteSpace(Plugin.Instance.Config.CassieRussian))
                    {
                        Cassie.MessageTranslated(
                            Plugin.Instance.Config.CassieEnglish,
                            Plugin.Instance.Config.CassieRussian,
                            isHeld: false,
                            isNoisy: true);
                    }
                    else
                    {
                        Cassie.Message(
                            Plugin.Instance.Config.CassieEnglish,
                            isHeld: false,
                            isNoisy: true);
                    }
                }

                response = $"Success!";
                return true;
            }
            catch (Exception)
            {
                response = "Error executing command!";
                return false;
            }
        }
    }
}