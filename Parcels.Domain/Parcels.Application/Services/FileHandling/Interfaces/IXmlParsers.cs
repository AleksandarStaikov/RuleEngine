namespace Parcels.Application.Services.FileHandling.Interfaces
{
	public interface IXmlParsers
	{
		T DeserializeToObject<T>(string filepath) where T : class;
	}
}