using System;
using System.IO;
using CommandSystem;
using Mirror.LiteNetLib4Mirror;

namespace Dobobibobo.checkonline
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class Checkonline : ParentCommand
	{
		public override string Command { get; } = "checkonline";
		public override string[] Aliases { get; } = new string[0];
		public override string Description { get; } = "checkonline admin";
		public override void LoadGeneratedCommands()
		{
		}
		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			int port = (int)LiteNetLib4MirrorTransport.Singleton.port;
			if (File.Exists(string.Format("/home/owo/admin/{0}{1}.txt", CollectionExtensions.At(arguments, 0), port)))
			{
				string[] value = File.ReadAllLines(string.Format("/home/owo/admin/{0}{1}.txt", CollectionExtensions.At(arguments, 0), port));
				response = (string.Join(" ", value) ?? "");
				return true;
			}
			response = "уаф";
			return false;
		}
	}
}
