using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MES
{
    public struct CurFlowConfig
    {
        public int flowID;
        public string flowName;
    }

    public class Global
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        public SqlConnection oldSqlConnection;
        public SqlConnection newSqlConnection;
        public OracleConnection oracleConnection;
        private int connType = 0;

         public Global(SqlConnection mainConnection)
        {
            switch (connType)
            { 
                case 0:
                    oldSqlConnection = mainConnection;
                     break;
                case 1:
                     newSqlConnection = mainConnection;
                     break;
            }
             
        }

         public Global(OracleConnection mainConnection)
         { 
              oracleConnection = mainConnection;
          }

        public int GetUserID(string pBarCode)
        {
            int userID = 0;
            string sqlStr = "select UserID from UserInfo where BarCode = '" + pBarCode + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, oldSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            try
            {
                reader.Read();
                userID = Convert.ToInt16(reader.GetValue(0));
                reader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            return userID;
        }

        public int GetRoleID(string pBarCode)
        {
            int roleID = 0;
            string sqlStr = "select RoleID from UserLoginPopedomView where BarCode = '" + pBarCode + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, oldSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            try
            {
                reader.Read();
                roleID = Convert.ToInt16(reader.GetValue(0));
                reader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            return roleID;
        }

        /// <summary>
        /// 是否为当前工序的有效登录用户
        /// </summary>
        public bool IsFlowUser(string pUserBarCode, string pCurFlowName)
        {
            bool rc = true;

            string status = "";
            string sqlStr = "select status from UserLoginPopedomView where BarCode = '" + pUserBarCode + "'"
                + " and FlowName = '" + pCurFlowName + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, oldSqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            try
            {
                reader.Read();
                if (reader.HasRows)
                {
                    status = reader.GetValue(0).ToString();
                    if (status != "在职")
                    {
                        MessageBox.Show("登录用户不是在职员工，如有疑问请与管理员联系！");
                        rc = false;
                    }
                }
                else
                {
                    MessageBox.Show("登录用户没有当前工序操作权限，请使用具有工序操作权限用户登录！");
                    rc = false;
                }
                reader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
                rc = false;
            }

            return rc;
        }

        public bool InsertLoginRecord(int pUserID, string pOperateType, string pOperateTime, string pFlowName, string pDescription)
        {
            //操作数据库中FlowProjectDetailsView视图
            bool rc = true;
            string sqlStr = "INSERT INTO UserOperate "
                + "(UserID,OperateType,OperateTime,FlowName,Description) VALUES ( "
                + pUserID + ",'" + pOperateType + "','" + pOperateTime + "','" + pFlowName + "','" + pDescription + "')";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, oldSqlConnection);
            sqlCommand.CommandTimeout = 30;
            try
            {
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
                sqlCommand.Dispose();
                rc = false;
            }

            return rc;
        }

        /// <summary>
        /// 获取登录用户权限数据
        /// </summary>
        public void GetUserLoginPopedomViewData(DataSet ds, string pUserBarCode)
        {
            string sqlStr = "select RoleID,RoleName,FlowID,FlowName from UserLoginPopedomView"
                + " where BarCode = '" + pUserBarCode + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlStr, oldSqlConnection);
            sqlCommand.CommandTimeout = 30;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            sqlDataAdapter.Fill(ds, "UserLoginPopedom");
        }

        /// <summary>
        /// 得到工序ID
        /// </summary>
        /// <param name="PFlowName"></param>
        /// <returns></returns>
        public int GetFlowID(string PFlowName)
        {
            int intFlowID = -1;
            SqlCommand SelCommandText = oldSqlConnection.CreateCommand();
            SelCommandText.CommandText = "select flowid from flow where flowname='" + PFlowName + "'";
            SqlDataReader reader = SelCommandText.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    intFlowID = Convert.ToInt32(reader["flowid"]);
                }
                reader.Close();
            }
            catch
            {
                reader.Close();
            }
            return intFlowID;
        }

        public void InitFlowConfig(ref CurFlowConfig flowConfig)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("Config.xml");
            flowConfig.flowName = ds.Tables["FlowConfig"].Rows[0]["CurrentFlow"].ToString();
            flowConfig.flowID = GetFlowID(flowConfig.flowName);
        }

        public bool GetProductPlan(DateTime recieveTime, ref String orderCode, ref String productCode)
        {
            string sqlStr;
            sqlStr = "select t.ordercode,t.productcode,t.recievetime from info.productplan t where t.recievetime > to_date('" + recieveTime+ "','yyyy-mm-dd')";
            if (oldSqlConnection.State == System.Data.ConnectionState.Closed)
                oldSqlConnection.Open();
            SqlCommand sqlComm = new SqlCommand(sqlStr);
            SqlDataReader sqlReader = sqlComm.ExecuteReader();
            try
            {
                sqlReader.Read();
                orderCode = sqlReader.GetString(0);
                productCode = sqlReader.GetString(1);
                
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlReader.Close();
            }
            return true;
        }
    }
}
