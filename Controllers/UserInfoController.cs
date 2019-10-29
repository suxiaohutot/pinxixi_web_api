using System.Collections;
using System.Resources;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Extensions.Logging;
using WEBAPI.Test;
using Microsoft.AspNetCore.Cors;//可以使用指定的控制器


namespace WEBAPI.Controllers
{
    //启用控制器
    [EnableCors("Domain")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private Dao daotest;
        public UserInfoController(Dao d)
        {
            this.daotest = d;
        }
        [HttpGet("{id}")]
        public ActionResult<object> GetUserByid(int id) //查询数据的get
        {
            var rusult  = new{
                Status = 0,
                data = daotest.ByIdGetInfo(id)
            };
            return rusult;
        }

        [HttpPost("PostAddUserInfo")]
        public ActionResult<object> PostAddUserInfo([FromForm]UserInfo userinfo)  //追加数据的post
        {
            var result = new {
                status = 0,
                data = "添加成功"
            };
            int temp = daotest.AddUserInfo(userinfo);
            if(temp <= 0)
            {
                result = new{
                    status = 1,
                    data = "添加失败"
                };
            }
            return result;
        }

        [HttpPut("PutUpdataUserInfo")]
        public ActionResult<object> PutUpdataUserInfo([FromForm]UserInfo userInfo) //修改数据的post
        {
            var result = new {
                status = 0,
                data = "修改成功"
            };
            int temp = daotest.UpdataUserInfo(userInfo);
            if(temp <= 0)
            {
                result = new {
                    status = 1,
                    data = "修改失败"
                };
            }
            return result;
        }

        [HttpDelete("DeletedataUserInfo")]
        public ActionResult<object> DeletedataUserInfo([FromForm]UserInfo userInfo)//删除数据
        {
            var result = new {
                status = 0,
                data = "删除成功"
            };
            int temp = daotest.UpdataUserInfo(userInfo);
            if(temp <= 0)
            {
                result = new {
                    status = 1,
                    data = "删除失败"
                };
            }
            return result;
        }
    }
}