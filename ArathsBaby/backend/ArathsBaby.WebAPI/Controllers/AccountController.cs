using ArathsBaby.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArathsBaby.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ArathsBabyContext _context;

        public AccountController(ArathsBabyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int Login([FromBody] UserInfo userInfo)
        {
            int rpta = 0;
            try
            {
                    int nvces = _context.Users.Where(p => p.Email == userInfo.Email
                     && p.Password == userInfo.Password).Count();
                    if (nvces == 0)
                    {
                        rpta = 0;
                    }
                    else
                    {
                        rpta = _context.Users.Where(p => p.Email == userInfo.Email
                     && p.Password == userInfo.Password).First().Id;
                    }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }

            return rpta;
        }

        //[HttpPost]
        //public bool Login([FromBody] UserInfo userInfo)
        //{
        //    var user = (from u in _context.Users
        //                where u.Email == userInfo.Email && u.Password == userInfo.Password
        //                select u).FirstOrDefault<Users>();

        //    if (user != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //[HttpPost]
        //public bool Get(UserInfo userInfo)
        //{
        //    try
        //    {
        //        var result = (from u in _context.Users
        //                where u.Email == userInfo.Email && u.Password == userInfo.Password
        //                select u).FirstOrDefault();

        //        if (result.Email == userInfo.Email && result.Password == userInfo.Password)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}