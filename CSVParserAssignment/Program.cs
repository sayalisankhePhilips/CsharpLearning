using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DynamicCSVParser
{
	public class CsvLineInfo : DynamicObject
	{
		public string header, lineContent;

		public override string ToString()
		{

			//string objectString=string.Format("{0},{1},{2},{3},{4}",null,null,null,null,null);
			return lineContent;
		}

		public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
		{

			result = null;
			string propertyName = binder.Name;
			int indexOfProperty = header.Split(',').ToList().IndexOf(propertyName);
			if (indexOfProperty < 0)
			{
				return false;
			}
			result = lineContent.Split(',')[indexOfProperty];

			return true;
		}
	}

	public class CSVDataProvider
	{
		string filePath;
		public string FilePath { set { this.filePath = value; } }
		public IEnumerable<CsvLineInfo> GetAllRecords()
		{
			//Approach 1
			List<CsvLineInfo> _objectList = new List<CsvLineInfo>();
			using (TextFieldParser textFieldParser = new TextFieldParser(filePath))
			{
				textFieldParser.TextFieldType = FieldType.Delimited;
				textFieldParser.SetDelimiters(",");
				string header = textFieldParser.ReadLine();
				//Console.WriteLine("headerrrrr" + header);
				while (!textFieldParser.EndOfData)
				{					
					string[] allData = textFieldParser.ReadFields();					
					string lineContent = string.Join(',', allData); 
					//Console.WriteLine(lineContent);
					CsvLineInfo _line = new CsvLineInfo()
					{
						header = header,
						lineContent = lineContent
					};
					_objectList.Add(_line);
				}
				//Console.WriteLine(_objectList);
				//Console.WriteLine();
			}
			return _objectList;

			//Approach 2
			//CsvLineInfo _line1 = new CsvLineInfo() { header = "ID,Type,Attende,Duration", lineContent = "M100,Checkup,Tom,50" };
			//CsvLineInfo _line2 = new CsvLineInfo() { header = "ID,Type,Attende,Duration", lineContent = "M101,FollowUp,Hary,30" };
			//CsvLineInfo _line3 = new CsvLineInfo() { header = "ID,Type,Attende,Duration", lineContent = "M102,FollowUp,Mary,15" };
			//CsvLineInfo _line4 = new CsvLineInfo() { header = "ID,Type,Attende,Duration", lineContent = "M103,VideoCall,James,40" };
			//List<CsvLineInfo> _objectList = new List<CsvLineInfo>();
			//_objectList.AddRange(new CsvLineInfo[] { _line1, _line2, _line3, _line4 });
			//return _objectList;
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			CSVDataProvider _provider = new CSVDataProvider();
			_provider.FilePath = @"C:\Practice_dotnet_demo\DynamicCSVParser\Sheet1.csv";
			IEnumerable<CsvLineInfo> appointments = _provider.GetAllRecords();

			IEnumerable<dynamic> result = Query(appointments, (dynamic appointment) => { return appointment.Type == "FollowUp"; });
			foreach (dynamic appt in result)
			{
				Console.WriteLine(appt.ToString());
			}
		}

		public static IEnumerable<TSource> Query<TSource>(IEnumerable<TSource> source, Func<TSource, bool> filterFunction)
		{
			List<TSource> tempResult = new List<TSource>();

			foreach (TSource item in source)
			{
				if (filterFunction.Invoke(item))
				{
					tempResult.Add(item);
				}
			}
			return tempResult;

		}
	}
}
