using System;
using System.IO;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Mirror.LiteNetLib4Mirror;
using System.Collections.Generic;
using CommandSystem;
using CustomPlayerEffects;
using MEC;
using UnityEngine;
using Exiled;
using System.Linq;
using System.Text;
using Exiled.Permissions.Extensions;
using Mirror;
using System.Threading.Tasks;
using Grenades;

namespace Dobobibobo
{
	public class EventHandlers
	{
		asd
		public EventHandlers(Plugin plugin)
		{
			this.plugin = plugin;
		}
        public void OnJoined(JoinedEventArgs ev)
		{
			if (ev.Player.RemoteAdminAccess)
			{
				DateTime now = DateTime.Now;
				int port = (int)LiteNetLib4MirrorTransport.Singleton.port;
				if (!File.Exists(string.Format("/home/owo/admin/{0}{1}.txt", ev.Player.UserId, port)))
				{
					File.WriteAllText(string.Format("/home/owo/admin/{0}{1}.txt", ev.Player.UserId, port), string.Format(" Подключение в: {0}", now));
					return;
				}
				File.AppendAllText(string.Format("/home/owo/admin/{0}{1}.txt", ev.Player.UserId, port), string.Format(" Подключение в: {0}", now));
			}
		}
        public void OnLeft(LeftEventArgs ev)
        {
            if (ev.Player.RemoteAdminAccess)
            {
                int port = (int)LiteNetLib4MirrorTransport.Singleton.port;
                DateTime now = DateTime.Now;
                File.AppendAllText(string.Format("/home/owo/admin/{0}{1}.txt", ev.Player.UserId, port), string.Format(" Отключение в: {0}", now));
            }
        }
		public void OnIntercomSpeaking(IntercomSpeakingEventArgs ev)
		{
			if (ev.Player.Role == RoleType.Scp049) { 
				ev.IsAllowed = true;
			}
		}
        private readonly Plugin plugin;
	}
}
