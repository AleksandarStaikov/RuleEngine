namespace Parcels.Application
{
	using System.Collections.Generic;
	using Models;

	public interface IParcelEngine
	{
		List<ParcelProcessingResult> ProcessParcels(string fileName);
	}
}