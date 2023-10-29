using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace B10_HTMLHelpers.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên nhân viên")]
        // [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name chỉ được chứa chữ cái và khoảng trắng.")]
        [RegularExpression("^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "Name chỉ được chứa chữ cái và khoảng trắng.")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Range(19, 50, ErrorMessage = "Tuổi phải nằm trong khoảng từ 19 đến 50.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age phải là số nguyên.")]
        public int Age { get; set; }
        [Required]
        public int DepID { get; set; }
        public virtual Department Department { get; set; }
    }
}