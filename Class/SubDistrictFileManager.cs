using ExcelFormatTypeEditForGraphDisplay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFormatTypeEditForGraphDisplay.Class
{
    class SubDistrictFileManager
    {

        /// <summary>
        ///จัดการไฟล์ระดับตำบล
        /// </summary>
        public static void ManageFileDataInSubDistrictFile()
        {
            var filename = "AMPValue";
            var filepath = @$"C:\Users\Ar'leng Chalermchai\Documents\Programming\C#\ExcelFormatTypeEditForGraphDisplay\Import\AMP\{filename}.csv";
            var data = filepath.ReadData();
            var subDistrictDataList = GetSubDistrictDataList(data);
            subDistrictDataList.WriterCRVFile($"{filename}-export");
        }

        static List<SubDistrict> GetSubDistrictDataList(IEnumerable<string> data)
        {
            var subDistrictDataList = new List<SubDistrict>();
            var headerList = new List<string>();
            for (int i = 0; i < data.Count(); i++)
            {
                if (i == 0)
                {
                    headerList.AddRange(data.ElementAt(0).Split(","));
                }
                if (i > 0)
                {
                    var dataList = new List<string>();
                    dataList.AddRange(data.ElementAt(i).Split(","));
                    subDistrictDataList.AddRange(InputDataToSubDistrictFormat(headerList, dataList));
                }
            }
            return subDistrictDataList;
        }

        static List<SubDistrict> InputDataToSubDistrictFormat(List<string> headerList, List<string> dataList)
        {
            var subDistrictDataList = new List<SubDistrict>();
            for (var i = 5; i < headerList.Count(); i++)
            {
                subDistrictDataList.Add(
                   new SubDistrict
                   {
                       AMPCODE5 = dataList.ElementAt(0),
                       AMPCODE = dataList.ElementAt(1),
                       AMP = dataList.ElementAt(2),
                       CWT = dataList.ElementAt(3),
                       REG = dataList.ElementAt(4),
                       HeaderName = headerList.ElementAt(i),
                       Data = dataList.ElementAt(i),
                       //WMI = dataList.ElementAt(headerList.Count() - 1)

                   });
            }
            var X = subDistrictDataList.ToList();
            return subDistrictDataList.ToList();
        }

    }
}
