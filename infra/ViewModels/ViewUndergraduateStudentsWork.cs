using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace infra.ViewModels
{
    public class ViewUndergraduateStudentsWork
    {
        public int Id { get; set; }
        public string updaterName { get; set; }
        [Required(ErrorMessage = "不可空白")]
        //[StringLength(7, ErrorMessage = "學號必須是2-7個字元", MinimumLength = 2)]
        public string teammate { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string topic { get; set; }
        [Required(ErrorMessage = "不可空白")]
        [Url]
        [RegularExpression("\\w{5}\\:\\/\\/\\w{3}\\.\\w{7}\\.\\w{3}\\/?\\w{5}\\?v\\=[a-zA-Z0-9_-]{11}\\&?t?\\=?[0-9]*s?", ErrorMessage ="這個網址不是youtube格式")]
        public string youtubeURL { get; set; }
        public string youtubeId { get; set; }
        [Required(ErrorMessage = "不可空白")]
        [Url]
        public string googleDriveURL { get; set; }
        public DateTime dateTime { get; set; }
    }
}
