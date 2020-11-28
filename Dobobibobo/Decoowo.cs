using System;
using System.Collections.Generic;
using CommandSystem;
using CustomPlayerEffects;
using Exiled.API.Features;
using MEC;
using Mirror;
using UnityEngine;

namespace Dobobibobo.decowo
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class Decoowo : ParentCommand
	{
		public override string Command { get; } = "decowo";
		public override string[] Aliases { get; } = new string[0];
		public override string Description { get; } = "decowo";
		public override void LoadGeneratedCommands()
		{
		}
		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			Timing.RunCoroutine(this.timeowo());
			response = "Начинаю контейм";
			return true;
		}
		private IEnumerator<float> timeowo()
		{
			Cassie.DelayedMessage("pitch_0.98 Danger . Light Containment Zone overall decontamination in T minus 30 seconds . All checkpoint doors have been opened. Please evacuate immediately . . . . 20 .19 . 18 . 17 . 16 . 15 . 14 . 13 . 12 . 11 . 10 seconds 9 . 8 . 7 . 6 . 5 . 4 . 3 . 2 . 1 . . . . Light containment zone is lockdown and ready for decontamination the termination of all biological forms has now begun", 0f, false, true);
			yield return Timing.WaitForSeconds(40f);
			Map.StartDecontamination();
			using (Dictionary<GameObject, ReferenceHub>.Enumerator enumerator = ReferenceHub.GetAllHubs().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<GameObject, ReferenceHub> keyValuePair = enumerator.Current;
					ReferenceHub value = keyValuePair.Value;
					if (value.transform.position.y < 100f && value.transform.position.y > 100f)
					{
						value.playerEffectsController.EnableEffect<Decontaminating>(0f, false);
					}
				}
				yield break;
			}
		}
	}
}
