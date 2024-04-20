
using System.Collections;
using System.Globalization;
using System.IO.Compression;
using System.Numerics;
using System.Xml;

namespace EpoCSReader.Utils
{
	public static class FileManagement
	{
		public struct Items
		{
            public string Type;
		}
		public struct EpubFile
		{
			public string Name;
			public ZipArchive? Archive;
			private XmlNode? Metadata ;
			public Vector<Items> Items;

            public EpubFile()
			{
				Name = "";
				Archive = null;
                Metadata = null;
                Items = new Vector<Items>();
			}
		}
		public static EpubFile OpenEpub(string path)
		{
            EpubFile epub = new EpubFile();
			epub.Archive = ZipFile.OpenRead(path);
			return epub;
		}

		public static 

	}
}
