using System.IO.Compression;
using System.Numerics;
using System.Xml;

namespace EpoCSReader.Utils
{
	public static class FileManagement
	{
		public struct Item
		{
            public string Name;
			public string PathInFile;
			public XmlDocument content;
			public Item(string path, string contentText)
			{
				Name = "";
                PathInFile = path;
				content = new XmlDocument();
				content.LoadXml(contentText);
				SetTitleItem(ref this);
			}
		}
		public struct EpubFile
		{
			public string? Name;
			public string? EntryPoint;
			public string? Summary;
			public ZipArchive Archive;
			public XmlNodeList Metadata;
			public string? ContentPath;
			public XmlDocument Content;
			public List<Item> Items;

            public EpubFile(string path)
            {
                Archive = ZipFile.OpenRead(path);
                FindEntryPointEpub(ref this);
				ContentPath = EntryPoint?.Substring(0, EntryPoint.LastIndexOf("/") + 1);
                GetMetadataEpub(ref this);
				GetItemList(ref this);
            }
		}
		public static EpubFile OpenEpub(string path)
		{
            EpubFile epub = new EpubFile(path);
			return epub;
		}
		private static void FindEntryPointEpub(ref EpubFile epub)
		{
			if (epub.Archive == null) { return; }

			foreach	(var Entrie in epub.Archive.Entries) 
			{ 
				if (Entrie.FullName.Contains("container.xml"))
				{
					List<char> chars = new List<char>();
					using (StreamReader sr = new StreamReader(Entrie.Open())) { chars.AddRange(sr.ReadToEnd()); }
					string container = new string(chars.ToArray());

					XmlDocument doc = new XmlDocument();
                    doc.LoadXml(container);

					var root = doc.GetElementsByTagName("rootfile");
					epub.EntryPoint = root[0]?.Attributes?["full-path"]?.Value;
                }
			}
		}
		private static void GetMetadataEpub(ref EpubFile epub)
		{
			if (epub.EntryPoint == null) { return; }

			Stream? stream = epub.Archive?.GetEntry(epub.EntryPoint)?.Open();

            if (stream == null) { return; }
            string content = "";
            using (StreamReader sr = new StreamReader(stream)) { content = sr.ReadToEnd(); }

            epub.Content = new XmlDocument();
            epub.Content.LoadXml(content);

            epub.Metadata = epub.Content.GetElementsByTagName("metadata");
			epub.Name = epub.Content.GetElementsByTagName("dc:title")[0]?.InnerText;

        }
		private static void GetItemList(ref EpubFile epub)
		{
			epub.Items = new List<Item>();
			foreach (XmlNode item in epub.Content.GetElementsByTagName("item"))
			{
				var media = item.Attributes?["media-type"];
				var href = item.Attributes?["href"];
				if (media != null && href != null && media.Value.Contains("html"))
				{
					Stream? stream = epub.Archive?.GetEntry(epub.ContentPath + href.Value)?.Open();
                    if (stream == null) { Console.WriteLine(epub.ContentPath); continue; }
					string content = "";
                    using (StreamReader sr = new StreamReader(stream)) { content = sr.ReadToEnd(); }
                    epub.Items.Add(new Item(href.Value, content));
				}
			}
		}
		private static void SetTitleItem(ref Item item)
		{
			var title = item.content.GetElementsByTagName("title");
			if (title[0]?.InnerText == "") { return; }
			Console.WriteLine(item.content.GetElementsByTagName("title")[0]?.InnerText);
		}
	}
}
