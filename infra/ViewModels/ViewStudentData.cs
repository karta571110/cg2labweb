using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace infra.ViewModels
{
    public class ViewStudentData
    {
        public int id { get; set; }
        [Required(ErrorMessage = "請輸入姓名")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="請輸入密碼")]
        [RegularExpression("\\w{8}\\w*",ErrorMessage ="密碼長度過短")]
        public string Password { get; set; }
        [Required(ErrorMessage ="請輸入信箱")]
        [RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4})*$",ErrorMessage ="信箱規格錯誤")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入學號")]
        [RegularExpression("^\\d[A]\\d{6}", ErrorMessage = "學號規格錯誤")]
        public string Studentid { get; set; }
    }
}
