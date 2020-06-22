using System;
using System.Collections.Generic;
using System.Text;

namespace infra.ViewModels
{
    public class ViewUndergraduateStudentsWork
    {
        public int Id { get; set; }
        public string updaterName { get; set; }
        public string teammate { get; set; }
        public string topic { get; set; }
        public string youtubeURL { get; set; }
        public string youtubeId { get; set; }
        public string googleDriveURL { get; set; }
        public DateTime dateTime { get; set; }
    }
}
