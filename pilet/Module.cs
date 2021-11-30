using System;
using Microsoft.Extensions.DependencyInjection;

namespace pilet
{
	public class Module
	{
		public static void Main()
		{
			// this entrypoint should remain empty
		}

		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IClockService, ClockService>();
		}
	}

	public class ClockService : IClockService
	{
		public string Now() => DateTime.Now.ToString("o");
	}

	public interface IClockService
	{
		string Now();
	}
}
