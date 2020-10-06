using System;
using System.Data;
using System.Data.SqlClient;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            Student.SaveMany(
                new Student { NAME = "赵云", AGE = 18 },
                new Student { NAME = "马超", AGE = 21 },
                new Student { NAME = "关羽", AGE = 22 }
                );

            //new Student().Delete();
        }
    }
    class Student : Entity
    {
        private DBhelper _dBhelper;
        public Student()
        {
            if (_dBhelper == null)
            {
                _dBhelper = new DBhelper();
            }
        }
        public string NAME { get; set; }
        public int AGE { get; set; }
        public static void SaveMany(params Student[] students)
        {
            DBhelper dBhelper = new DBhelper();
            //批量save（）方法
            using (dBhelper.LongConnection)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    students[i].Save(dBhelper.LongConnection);
                }
                //new Student { NAME = "张飞", AGE = 24 }.Save(dBhelper.Connection);
                //new Student { NAME = "赵云", AGE = 22 }.Save(dBhelper.Connection);
                //new Student { NAME = "马超", AGE = 22 }.Save(dBhelper.Connection);
            }
        }
        public void Save(SqlConnection connection)
        {
            _dBhelper.ExecuteNonQuery($"INSERT Student VALUES(N'{NAME}',{AGE}", _dBhelper.LongConnection);

        }
        public void Delete()
        {
            _dBhelper.ExecuteNonQuery($"DELETE Student", _dBhelper.LongConnection);

        }

    }
    class Entity
    {
        public int Id { get; set; }
    }
    class DBhelper
    {
        static string connectionString = @" Data Source = (localdb)\ProjectsV13; Initial Catalog = _17bang; Integrated Security = True;";
        private SqlConnection _longConnection;
        public SqlConnection LongConnection
        {
            get
            {
                _longConnection = _longConnection ?? new SqlConnection(connectionString);
                return _longConnection;
            }
        }
        public int ExecuteNonQuery(string CmdText, SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();//显示打开连接
            }
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = CmdText;
            return command.ExecuteNonQuery();

        }
    }
}
