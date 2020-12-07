using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace xzc_serv
{
    class DCon
    {
        #region  建立数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        public SqlConnection getcon()
        {
            string M_str_sqlcon = ConfigurationManager.ConnectionStrings["xzcserv"].ToString();        //"Data Source=(local);Database=xzc;User id=sa;PWD=sa123";
            SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            myCon.Open();
            return myCon;
        }
        #endregion

        #region  关闭连接

        /// <summary>

        /// 关闭数据库连接

        /// </summary>

        public void closedb()

        {
            SqlConnection sqlcon = this.getcon();

            if (sqlcon != null)
            {
                sqlcon.Close();
                sqlcon.Dispose();
                sqlcon = null;
            }


        }

        #endregion



        #region  执行SqlCommand命令
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getcom(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);

            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();

        }
        #endregion

        #region  创建DataSet对象
        /// <summary>
        /// 创建一个DataSet对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <param name="M_str_table">表名</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getds(string M_str_sqlstr, string M_str_table)
        {
            SqlConnection sqlcon = this.getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter(M_str_sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, M_str_table);
            return myds;
        }
        #endregion

        #region  创建SqlDataReader对象
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public SqlDataReader getread(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            SqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }
        #endregion


        #region 
        /// <summary>
        /// 查询职工信息
        /// </summary>
        /// <param name="str">查询条件</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataSet数据集对象</returns>
        public DataSet SelectEInfo(string str, int strKeyWord)
        {
            SqlConnection sqlcon = this.getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            SqlCommand sqlcmd = new SqlCommand("proc_SelectEInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            switch (str)
            {
                case "工号":
                    sqlcmd.Parameters.Add("@id", SqlDbType.Int, 10).Value = strKeyWord;
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";

                    break;
                case "姓名":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = strKeyWord;

                    break;

                default:
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";

                    break;
            }
            sqlda.SelectCommand = sqlcmd;
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            sqlcon.Close();
            return myds;
        }
        #endregion
    }
}

