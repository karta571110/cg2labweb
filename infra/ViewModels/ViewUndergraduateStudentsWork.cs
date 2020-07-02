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
        [RegularExpression("https\\:\\/\\/www.youtube.com\\/watch\\?v=\\w*&?t?\\=?[0-9]*s?", ErrorMessage ="這個網址不是youtube (或是你嘗試輸入youtube播放清單的影片)")]
        public string youtubeURL { get; set; }
        public string youtubeId { get; set; }
        [Required(ErrorMessage = "不可空白")]
        [Url]
        [RegularExpression("https:\\/\\/drive\\.google\\.com\\/file\\/d\\/[A-Za-z0-9-]*\\/view\\?usp=sharing", ErrorMessage ="這個網址不是google雲端")]
        public string googleDriveURL { get; set; }
        public DateTime dateTime { get; set; }
    }
}
