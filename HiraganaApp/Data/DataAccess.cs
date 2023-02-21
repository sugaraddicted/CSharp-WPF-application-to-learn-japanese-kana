using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;
using HiraganaApp.MVVM.Model;
using HiraganaApp.Help;

namespace HiraganaApp.Data
{
    class DataAccess
    {
        public static List<Letter> GetLetterList()
        {
            using (IDbConnection connection = new SQLiteConnection(Helper.ConnectionStringValue("D")))
            {
                var output = connection.Query<Letter>("select * from Letters", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
