using EpoCSReader.Utils;
namespace EpoCSReader.Core
{
	public class Reader
	{
		private string? _Path;
		private bool IsRunning;
		public string? Path { get => _Path; }
		public FileManagement.EpubFile epub;
        public Reader(string pathFile)
		{
			_Path = pathFile;
			IsRunning = true;
			epub = FileManagement.OpenEpub(_Path);
		}

		public void ShowContentInPath()
		{
			
		}

		public void Run()
		{
			while (IsRunning)
			{
                ProcessKey(Console.ReadKey());
				//Console.Clear();
			}
            
        }

		private void ProcessKey(ConsoleKeyInfo key)
		{
			if (key.Key == ConsoleKey.RightArrow)
			{
				IsRunning = false;
			}
		}
	}
}
