
namespace EpoCSReader.Utils
{
		public static class FileSystem
		{
				public static List<string> FilesInFolder(string path)
				{
						List<string> filesList = new();
						var files = Directory.EnumerateFiles(path);
						foreach (string file in files)
						{
								string fileName = file.Substring(path.Length + 1);
								filesList.Add(fileName);
						}
						return filesList;
				}
				public static List<string> FolderListInPath(string path)
				{
						List<string> foldersList = new();
						var folders = Directory.EnumerateDirectories(path);
						foreach (string folder in folders)
						{
								string folderName = folder.Substring(path.Length + 1);
								foldersList.Add(folderName);
						}
						return foldersList;
				}
		}
}
