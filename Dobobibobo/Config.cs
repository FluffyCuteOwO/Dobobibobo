using System;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Dobobibobo
{
	public class Config : IConfig
	{
		[Description("Enable or disable ploogin")]
		public bool IsEnabled { get; set; } = true;
	}
}
