namespace Parcels.Application.Services.FileHandling
{
	using Interfaces;
	using System.IO;
	using System.Xml.Serialization;

	public class XmlParsers : IXmlParsers
	{
		public T DeserializeToObject<T>(string filepath) where T : class
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			using (StreamReader streamReader = new StreamReader(filepath))
			{
				return (T)serializer.Deserialize(streamReader);
			}
		}
	}
}
