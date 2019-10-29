using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WEBAPI.Test
{
    public class Util
    {
        private IConfiguration iconfig;
        public Util(IConfiguration icf)
        {
            this.iconfig = icf;
        }
        private string strconn = @"Data Source=.;Initial Catalog=TestData;Integrated Security=True";
        //Data Source=.;Initial Catalog=TestData;Integrated Security=True
        public SqlConnection Conn()
        {
            SqlConnection c  = new SqlConnection(strconn);
            //SqlConnection c  = new SqlConnection(this._Configuration["connectionStrings:newDB"]);
            return c;
        }
    }
}