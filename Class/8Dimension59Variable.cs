using ExcelFormatTypeEditForGraphDisplay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFormatTypeEditForGraphDisplay
{
    public class _8Dimension59Variable
    {

        /// <summary>
        /// รวม 59 ตัวแปร และ 8มิติ
        /// </summary>
        public static void ManageFileDataIn8DimensionAnd59VariableFile()
        {
            var filename = "AMP59+8";
            var filepath = @$"C:\Users\Ar'leng Chalermchai\Documents\Programming\C#\ExcelFormatTypeEditForGraphDisplay\Import\AMP\{filename}.csv";
            var data = filepath.ReadData();
            SubData(data).WriterCRVFile($"{filename}-export");
        }

        static List<_8Dimension59VariableAdressConcatExportModel> SubData(IEnumerable<string> data)
        {
            var rawDataList = new List<_8Dimension59VariableAdressConcatExportModel>();
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
                    var _59VariableDatalist = Get59VariablesDataList(headerList, dataList);
                    var _8DimensionDataList = Get8DimensionDataList(headerList, dataList);
                    rawDataList.AddRange(InputdataToFormat(_59VariableDatalist, _8DimensionDataList, dataList));
                }
            }
            return rawDataList;
        }

        static List<_8Dimension59VariableAdressConcatExportModel> InputdataToFormat(List<DataList> _59VariableDatalist, List<DataList> _8DimensionDataList, List<string> dataList)
        {
            var data = new List<_8Dimension59VariableAdressConcatExportModel>();
            for (int i = 0; i < _59VariableDatalist.Count; i++)
            {
                var dimensionHeader = "";
                var dimenstionData = "";
                if (i < 8) { dimensionHeader = _8DimensionDataList.ElementAt(0).Header; dimenstionData = _8DimensionDataList.ElementAt(0).Data; }
                else if (i < 13) { dimensionHeader = _8DimensionDataList.ElementAt(1).Header; dimenstionData = _8DimensionDataList.ElementAt(1).Data; }
                else if (i < 24) { dimensionHeader = _8DimensionDataList.ElementAt(2).Header; dimenstionData = _8DimensionDataList.ElementAt(2).Data; }
                else if (i < 25) { dimensionHeader = _8DimensionDataList.ElementAt(3).Header; dimenstionData = _8DimensionDataList.ElementAt(3).Data; }
                else if (i < 33) { dimensionHeader = _8DimensionDataList.ElementAt(4).Header; dimenstionData = _8DimensionDataList.ElementAt(4).Data; }
                else if (i < 45) { dimensionHeader = _8DimensionDataList.ElementAt(5).Header; dimenstionData = _8DimensionDataList.ElementAt(5).Data; }
                else if (i < 48) { dimensionHeader = _8DimensionDataList.ElementAt(6).Header; dimenstionData = _8DimensionDataList.ElementAt(6).Data; }
                else if (i < 59) { dimensionHeader = _8DimensionDataList.ElementAt(7).Header; dimenstionData = _8DimensionDataList.ElementAt(7).Data; }
                else if (i < 62) { dimensionHeader = _8DimensionDataList.ElementAt(2).Header; dimenstionData = _8DimensionDataList.ElementAt(2).Data; }
                else if (i < 64) { dimensionHeader = _8DimensionDataList.ElementAt(5).Header; dimenstionData = _8DimensionDataList.ElementAt(5).Data; }
                else if (i < 71) { dimensionHeader = _8DimensionDataList.ElementAt(7).Header; dimenstionData = _8DimensionDataList.ElementAt(7).Data; }
               // else { dimensionHeader = _8DimensionDataList.ElementAt(7).Header; dimenstionData = _8DimensionDataList.ElementAt(7).Data; }
                data.Add(new _8Dimension59VariableAdressConcatExportModel
                {
                    Address = $"{dataList.ElementAt(0)},{dataList.ElementAt(1)},{dataList.ElementAt(2)},{dataList.ElementAt(3)},{dataList.ElementAt(4)}",
                    Header8 = dimensionHeader,
                    Value8 = dimenstionData,
                    Header59 = _59VariableDatalist.ElementAt(i).Header,
                   Value59 = _59VariableDatalist.ElementAt(i).Data,
                   WBI = _8DimensionDataList.ElementAt(8).Data
                }) ;
            }
            return data;
        }

        static List<DataList> Get8DimensionDataList(List<string> headerList, List<string> dataList)
        {
            var rawData = new List<DataList>();
            for (var i = 0; i < headerList.Count(); i++)
            {
                rawData.Add(
                    new DataList
                    {
                        Header = headerList.ElementAt(i),
                        Data = dataList.ElementAt(i)
                    });
            }
            var data = rawData.Skip(78).SkipLast(0).ToList();
            return data;
        }

        static List<DataList> Get59VariablesDataList(List<string> headerList, List<string> dataList)
        {
            var rawData = new List<DataList>();
            for (var i = 0; i < headerList.Count(); i++)
            {
                rawData.Add(
                    new DataList
                    {
                        Header = headerList.ElementAt(i),
                        Data = dataList.ElementAt(i)
                    });
            }
            var data = rawData.Skip(5).SkipLast(11).ToList();
            return data;
        }


    }
}
