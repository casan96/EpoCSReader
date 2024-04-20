using EpoCSReader.Utils;
namespace EpoCSReader.Core
{
	public class Reader
	{
		private string? _Path;
		private bool IsRunning;
		public string? Path { get => _Path; }
        public Reader(string pathFile)
		{
			_Path = pathFile;
		}

		public void ShowContentInPath()
		{
			if (_Path == null) return;
			var folders = FileManagement.FolderListInPath(_Path);
			foreach(string folder in folders)
			{
				Console.WriteLine(folder);
			}
			var files = FileManagement.FilesInFolder(_Path);
			foreach (var file in files)
			{
				Console.WriteLine(file);
			}
		}

		public void Run()
		{
            
        }
		
		private void ChangePath(string removePath)
		{
			_Path  = _Path?.Replace(removePath, "");
		}

		private void ProcessKey(ConsoleKeyInfo key)
		{
			if (key.KeyChar == 'c')
			{
				IsRunning = false;
			}
		}
	}
}
