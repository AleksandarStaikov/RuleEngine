namespace Parcels.Application.Services.FileHandling
{
	using Interfaces;
	using Models;
	using System.IO;

	public class FileHandler : IFileHandler
	{
		public void ValidateDirectoryExists(FileLocationDto fileLocation)
		{
			var directoryExists = Directory.Exists(fileLocation.DirectoryPath);

			if (!directoryExists)
			{
				throw new FeedbackException(
					$"The provided directory does not exists: '{fileLocation.DirectoryPath}'");
			}
		}

		public void ValidateFileExists(FileLocationDto fileLocation)
		{
			var fileExists = File.Exists(fileLocation.FullPath);
			
			if (!fileExists)
			{
				throw new FeedbackException(
					$"The file '{fileLocation.FileName}' could not be found in '{fileLocation.DirectoryPath}'");
			}
		}

		public FileLocationDto SplitFilePath(string filePath)
		{
			var fileInfo = new FileInfo(filePath);

			var fileLocation = new FileLocationDto(fileInfo.DirectoryName, fileInfo.Name);

			return fileLocation;
		}
	}
}
