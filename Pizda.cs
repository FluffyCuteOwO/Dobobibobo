using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using CustomPlayerEffects;
using Exiled.API.Features;
using MEC;
using Mirror;
using UnityEngine;

namespace Dobobibobo.pizda
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class Pizda : ParentCommand
	{
		public override string Command { get; } = "pizda";
		public override string[] Aliases { get; } = new string[0];
		public override string Description { get; } = "pizda room set x y z/pizda default";
		public override void LoadGeneratedCommands()
		{
		}
		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			GameObject Scp106Room = GameObject.FindObjectsOfType<NetworkIdentity>().Where(t => t.name == "All" && Vector3.Distance(t.transform.position, GameObject.Find("ContBox").transform.position) <= 50).FirstOrDefault().gameObject;
			GameObject Scp939Room = GameObject.FindObjectsOfType<NetworkIdentity>().Where(t => t.name == "All" && Vector3.Distance(t.transform.position, GameObject.FindGameObjectsWithTag("SCP_939").First().transform.position + new Vector3(0, 15, 0)) <= 10f).First().gameObject;
			Quaternion auf = Scp106Room.transform.rotation;
			Quaternion auf1 = Scp939Room.transform.rotation;
			if (arguments.At(0) == "set")
			{
				switch (arguments.At(1))
                {
					case ("106"):
						Scp106Room.transform.Rotate(float.Parse(arguments.At(2)), float.Parse(arguments.At(3)), float.Parse(arguments.At(4)));
						NetworkServer.UnSpawn(Scp106Room);
						NetworkServer.Spawn(Scp106Room);
						response = "Пизда комнате 106";
						return true;
					case ("939"):
						Scp939Room.transform.Rotate(float.Parse(arguments.At(2)), float.Parse(arguments.At(3)), float.Parse(arguments.At(4)));
						NetworkServer.UnSpawn(Scp939Room);
						NetworkServer.Spawn(Scp939Room);
						response = "Пизда комнате 939";
						return true;
				}
				
			}
			if (arguments.At(0) == "default")
            {
				auf = Scp106Room.transform.rotation;
				auf1 = Scp939Room.transform.rotation;
				NetworkServer.UnSpawn(Scp106Room);
				NetworkServer.Spawn(Scp106Room);
				NetworkServer.UnSpawn(Scp939Room);
				NetworkServer.Spawn(Scp939Room);
				response = "Вернул комнату";
				return true;
			}
			response = "ну пизд";
			return false;
		}
	}
}
