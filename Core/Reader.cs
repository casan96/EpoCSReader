using EpoCSReader.Utils;
namespace EpoCSReader.Core
{
	public class Reader
	{
		private string? _Path;

		public string? Path { get => _Path; }
        public Reader()
		{
			_Path = Directory.GetCurrentDirectory();
		}

		public void ShowContentInPath()
		{
			if (_Path == null) return;
			var folders = FileSystem.FolderListInPath(_Path);
			foreach(string folder in folders)
			{
				Console.WriteLine(folder);
			}
			var files = FileSystem.FilesInFolder(_Path);
			foreach (var file in files)
			{
				Console.WriteLine(file);
			}
		}

		public bool IsRunning()
		{
			return true;
		}
	}
}
