using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API;
using Exiled;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using Handlers = Exiled.Events.Handlers;

namespace Dobobibobo
{
	public class Plugin : Plugin<Config>
	{
		public override string Author { get; } = "FluffyCuteOwO";
		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers(this);
            Handlers.Player.Joined += EventHandlers.OnJoined;
            Handlers.Player.IntercomSpeaking += EventHandlers.OnIntercomSpeaking;
			Handlers.Player.Left += EventHandlers.OnLeft;
		}
		public override void OnDisabled()
		{
			base.OnDisabled();
			EventHandlers = null;
			Handlers.Player.Joined -= EventHandlers.OnJoined;
			Handlers.Player.IntercomSpeaking -= EventHandlers.OnIntercomSpeaking;
			Handlers.Player.Left -= EventHandlers.OnLeft;
		}
		public override void OnReloaded()
		{
			base.OnReloaded();
		}
		public EventHandlers EventHandlers;
		public static List<string> pEditor;
	}
}
