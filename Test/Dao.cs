using System.Reflection.Metadata;
using System.Collections;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;

namespace WEBAPI.Test
{
    public class Dao
    {
        private Util util;
        private Logger logger;
        public Dao(Util u , Logger log)
        {
            this.util = u;
            this.logger = log;
        }
        public Hashtable ByIdGetInfo(int id) //查询
        {
            Hashtable rusult = new Hashtable();
            string strSql = @"select id,username,password from[T_UserInfo] where id = @id";
            SqlConnection conn = util.Conn();
            SqlCommand comm = new SqlCommand(strSql,conn);
            comm.Parameters.AddWithValue("@id",id);
            SqlDataReader dr = null;
            try{
                conn.Open();
                dr = comm.ExecuteReader();
                if(dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        rusult.Add(dr.GetName(i),dr.GetValue(i));
                    }
                }
                dr.Close();
            }
            catch(Exception e)
            {
                rusult = null;
                this.logger.Properties.Clear();
                this.logger.Properties.Add("sql语句：",strSql);
                logger.Error("信息错误："+e.Message);
            }
            finally
            {
                if(dr != null) dr.Dispose();
                if(comm != null) comm.Dispose();
                if(conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
            return rusult;
        }
        //追加数据
        public int AddUserInfo(UserInfo UserInfo)   // 追加
        {
            int result = 0;
            string strsql = @"insert into [dbo].[T_UserInfo] (username, password)  values(@u,@p)";
            SqlConnection conn = util.Conn();
            SqlCommand comm = new SqlCommand(strsql,conn);
            comm.Parameters.AddWithValue("@u",UserInfo.username);
            comm.Parameters.AddWithValue("@p",UserInfo.password);
            try{
                conn.Open();
                result = comm.ExecuteNonQuery();
            }
            catch(Exception e){
                result = 0;
                this.logger.Properties.Clear();
                this.logger.Properties.Add("sql语句",strsql);
                this.logger.Error("错误信息"+e.Message);
            }
            finally{
                if(comm != null) comm.Dispose();
                if(conn.State == ConnectionState.Open) conn .Close();
                conn.Dispose();
            }
            return result;
        }
        public int UpdataUserInfo(UserInfo UserInfo)    //更新数据
        {
            int result = 0;
            string strsql = @"update [T_UserInfo] set [username]=@u,[password]=@p where [id]=@id";
            SqlConnection conn = util.Conn();
            SqlCommand comm = new SqlCommand(strsql,conn);
            comm.Parameters.AddWithValue("@id",UserInfo.id);
            comm.Parameters.AddWithValue("@u",UserInfo.username);
            comm.Parameters.AddWithValue("@p",UserInfo.password);

            try{
                conn.Open();
                result = comm.ExecuteNonQuery();
            }
            catch(Exception e){
                result = 0;
                this.logger.Properties.Clear();
                this.logger.Properties.Add("sql语句",strsql);
                this.logger.Error("错误信息"+e.Message);
            }
            finally{
                if(comm != null) comm.Dispose();
                if(conn.State == ConnectionState.Open) conn .Close();
                conn.Dispose();
            }
            return result;
        }

        public int DeldataUserInfo(UserInfo UserInfo)    //删除数据
        {
            int result = 0;
            string strsql = @"DELETE FROM [T_UserInfo] WHERE [id]=@id";
            SqlConnection conn = util.Conn();
            SqlCommand comm = new SqlCommand(strsql,conn);
            comm.Parameters.AddWithValue("@id",UserInfo.id);
            try{
                conn.Open();
                result = comm.ExecuteNonQuery();
            }
            catch(Exception e){
                result = 0;
                this.logger.Properties.Clear();
                this.logger.Properties.Add("sql语句",strsql);
                this.logger.Error("错误信息"+e.Message);
            }
            finally{
                if(comm != null) comm.Dispose();
                if(conn.State == ConnectionState.Open) conn .Close();
                conn.Dispose();
            }
            return result;
        }

    }
}