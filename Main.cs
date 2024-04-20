using EpoCSReader.Core;
using System.ComponentModel.Design;
namespace EpoCSReader
{
	public static class MainEstar
	{
		public static void Main(string[] args)
		{
			if (args.Length != 1) 
			{
				Console.WriteLine("Pass the path of the file like argument");
				return;
			}
			Reader reader = new Reader(args[0]);
			//reader.Run();
			
		}
	}
}
