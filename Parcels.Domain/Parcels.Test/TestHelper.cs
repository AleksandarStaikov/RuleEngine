namespace Parcels.Test
{
	using Application;
	using Microsoft.Extensions.DependencyInjection;
	using System;

	public class TestHelper
	{
		public static IServiceProvider GetServiceProvider()
			=> new ServiceCollection()
				.AddApplication()
				.BuildServiceProvider();

	}
}
