using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    static class SqlHelper
    {
        public static DataTable ExecuteQuery(this IDbConnection conn, FormattableString formattable)
        {
            using IDbCommand cmd = CreateCommand(conn, formattable);
            DataTable dt = new DataTable();
            using var reader = cmd.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public static object? ExecuteScalar(this IDbConnection conn, FormattableString formattable)
        {
            using IDbCommand cmd = CreateCommand(conn, formattable);
            return cmd.ExecuteScalar();
        }

        public static int ExecuteNonQuery(this IDbConnection conn, FormattableString formattable)
        {
            using IDbCommand cmd = CreateCommand(conn, formattable);
            return cmd.ExecuteNonQuery();
        }

        public static IDbCommand CreateCommand(this IDbConnection conn, FormattableString formattable)
        {
            var cmd = conn.CreateCommand();
            string sql = formattable.Format;
            for (int i = 0; i < formattable.ArgumentCount; i++)
            {
                sql = sql.Replace("{" + i + "}", $"@p{i}");
                var param = cmd.CreateParameter();
                param.ParameterName = $"@p{i}";
                param.Value = formattable.GetArgument(i);
                cmd.Parameters.Add(param);
            }
            cmd.CommandText = sql;
            return cmd;
        }
    }
}
