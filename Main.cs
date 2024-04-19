using EpoCSReader.Core;
namespace EpoCSReader
{
	public static class MainEstar
	{
		public static void Main(string[] args)
		{
			
			var folders = FileSystem.FolderListInPath(Directory.GetCurrentDirectory());
			foreach(string folder in folders)
			{
				Console.WriteLine(folder);
			}
			var files = FileSystem.FilesInFolder(Directory.GetCurrentDirectory());
			foreach (string file in files)
			{
				Console.WriteLine(file);
			}
		}
	}
}
