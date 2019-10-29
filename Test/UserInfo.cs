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
    public class UserInfo
    {
        public int id{ get;set;}
        public string username{get;set;}
        public string password{get;set;}

    }
}