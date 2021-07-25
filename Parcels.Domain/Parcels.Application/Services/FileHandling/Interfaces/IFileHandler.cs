namespace Parcels.Application.Services.FileHandling.Interfaces
{
	using Models;

	public interface IFileHandler
	{
		void ValidateDirectoryExists(FileLocationDto fileLocation);
		void ValidateFileExists(FileLocationDto fileLocation);
		FileLocationDto SplitFilePath(string filePath);
	}
}