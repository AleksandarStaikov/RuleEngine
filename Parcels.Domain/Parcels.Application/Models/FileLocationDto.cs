namespace Parcels.Application.Models
{
	using System.IO;

	public class FileLocationDto
	{
		public FileLocationDto(string directoryPath, string fileName)
		{
			this.DirectoryPath = directoryPath;
			this.FileName = fileName;
		}

		public string DirectoryPath { get; set; }
		public string FileName { get; set; }
		public string FullPath => Path.Combine(DirectoryPath, FileName);
	}
}
