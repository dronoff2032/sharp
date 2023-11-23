using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoropechatanie
{
    internal class Records
    {
        public static void records()
        {
            Dictionary<string, TableRecordType> all_records = read_all_records();

            foreach (var record in all_records)
            {
                Console.WriteLine(record);
            }
        }

        public static void new_result(string name, TableRecordType record)
        {
            Dictionary<string, TableRecordType> allRecords = read_all_records();
            allRecords.Add(name, record);

            string json = JsonConvert.SerializeObject(allRecords);
            File.WriteAllText("C:\\Users\\xelond\\Desktop\\практосыж\\sharp\\records.json", json);
        }

        private static Dictionary<string, TableRecordType> read_all_records()
        {
            string records = File.ReadAllText("C:\\Users\\xelond\\Desktop\\практосыж\\sharp\\records.json");
            Dictionary<string, TableRecordType> all_records = JsonConvert.DeserializeObject<Dictionary<string, TableRecordType>>(records);
            return all_records;
        }
    }
}
