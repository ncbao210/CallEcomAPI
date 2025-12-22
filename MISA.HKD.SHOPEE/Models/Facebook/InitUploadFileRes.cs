using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class InitUploadFileRes : FacebookBaseResponse
    {
        public string id { get; set; }
    }

    public class HandleUploadFile : FacebookBaseResponse
    {
        public string h { get; set; }
    }

    public class InitVideoRes : FacebookBaseResponse
    {
        public string upload_session_id { get; set; }

        public string video_id { get; set; }
        public string start_offset { get; set; }
        public string end_offset { get; set; }
    }

    public class VideoUploadResponse : FacebookBaseResponse
    {
        public string start_offset { get; set; }
        public string end_offset { get; set; }
    }
}