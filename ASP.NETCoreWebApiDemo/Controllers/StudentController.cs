using ASP.NETCoreWebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            List<Student> list = new List<Student>();
            list = await Task.Run(() =>
            {
                return Data.GetList();
            });
            return list;
        }

        [HttpGet("GetDTO")]
        public async Task<List<StudentDTO>> GetDto()
        {
            List<StudentDTO> list = new List<StudentDTO>();
            List<Student> listStudent = await Task.Run(() =>
            {
                return Data.GetList();
            });
            // 循环给属性赋值
            foreach (var item in listStudent)
            {
                StudentDTO dto = new StudentDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Age = item.Age;
                dto.Gender = item.Gender;
                // 加入到集合中
                list.Add(dto);
            }

            return list;
        }
    }
}
