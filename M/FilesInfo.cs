using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace PhotoBackUper.M
{
    class DateAndCount
    {
        public DateAndCount(DateTime date)
        {
            Date = date;
            Count = 1;
        }
        public DateTime Date { get; private set; }
        public int Count { get; private set; }
        public void Add() => Count++;
    }
    class FilesInfo
    {
        public FilesInfo(FileInfo[] fileinfos)
        {
            foreach (FileInfo File in fileinfos)
            {
                if(ContFromDates.Select(d => d.Date.Date).Contains(File.LastWriteTime.Date))
                {
                    ContFromDates.FirstOrDefault(d => d.Date.Date == File.LastWriteTime.Date).Add();
                }
                else
                {
                    List<DateAndCount> Temp = ContFromDates.ToList();
                    Temp.Add(new DateAndCount(File.LastWriteTime.Date));
                    ContFromDates = Temp.ToArray();
                }
            }
        }
        public DateAndCount[] ContFromDates = new DateAndCount[0];
    }
}
