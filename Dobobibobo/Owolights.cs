using System;
using CommandSystem;
using UnityEngine;

namespace Dobobibobo.checkonline
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class Owolights : ParentCommand
	{
		public override string Command { get; } = "owolights";
		public override string[] Aliases { get; } = new string[0];
		public override string Description { get; } = "owolights 0/2";
		public override void LoadGeneratedCommands()
		{
		}
		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			foreach (FlickerableLightController flickerableLightController in UnityEngine.Object.FindObjectsOfType<FlickerableLightController>())
			{
				float num = float.Parse(CollectionExtensions.At(arguments, 0));
				flickerableLightController.ServerSetLightIntensity(num);
			}
			response = "Ну делаю";
			return true;
		}
	}
}
