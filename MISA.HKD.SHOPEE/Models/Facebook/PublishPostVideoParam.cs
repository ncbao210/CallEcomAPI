using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookUploadVideoParam<T> : FBUploadFileParam<T> where T : FacebookUploadVideoBody
    {
    }
    public class FacebookUploadVideoBody
    {
        public string upload_session_id { get; set; }

        public string upload_phase { get; set; } = "finish";
    }

    public class FacebookInitUploadVideoRes : FacebookBaseResponse
    {
        public string upload_session_id { get; set; }

        public string video_id { get; set; }
        public string start_offset { get; set; }
        public string end_offset { get; set; }
    }

    public class FacebookUploadVideoRes : FacebookBaseResponse
    {
        public string start_offset { get; set; }
        public string end_offset { get; set; }
    }

    public class FacebookUploadVideoFinishRes
    {
        public string video_id { get; set; }

        public string upload_session_id { get; set; }

    }

    public class PublishPostVideoParam : FacebookUploadVideoParam<PublishPostVideoBody>
    {
    }

    public class PublishPostVideoBody : FacebookUploadVideoBody
    {
        public string title { get; set; }

        public string description { get; set; }

        public bool? published { get; set; }

        public List<AttachMedia> attached_media { get; set; }


    }
    public class FacebookPageParam<T> : FaceBookBaseParam<T>
    {
        public string PageID { get; set; }
    }

    public class FBUploadFileParam<T> : FacebookPageParam<T>
    {
        /// <summary>
        /// File cần đăng
        /// </summary>
        public Byte[] FileBytes { get; set; }
        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// file type
        /// </summary>
        public string FileType { get; set; }
    }
    public class FBUploadAttachmentRes : FacebookBaseResponse
    {
        public string id { get; set; }
    }

    public class CreatePostParam : FacebookPageParam<CreatePostBody>
    {
    }

    public class CreatePostBody
    {
        /// <summary>
        /// Required
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Tài liệu đính kèm
        /// </summary>
        public List<AttachMedia> attached_media { get; set; }

        /// <summary>
        /// Mô tả video của bài đăng
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Thời gian đặt lịch đăng
        /// An integer UNIX timestamp [in seconds] (e.g. 1530432000)
        /// </summary>
        public int? scheduled_publish_time { get; set; }

        /// <summary>
        /// Bài post có được publish luôn hay không
        /// Mặc định là Publish luôn
        /// Nếu false thì cần có scheduled_publish_time
        /// </summary>
        public bool? published { get; set; } = true;

        /// <summary>
        /// Có ghim bài viết hay không (nếu ghim sẽ vào phần "Đáng chú ý")
        /// </summary>
        public bool? is_pinned { get; set; }

    }

    public class FBPostProductParam : FacebookPageParam<FBPostProductBody>
    {
    }
    public class FBPostProductBody
    {
        /// <summary>
        /// Link ảnh
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Caption của bài viết
        /// </summary>
        public string caption { get; set; }

        /// <summary>
        /// Bài post có được publish luôn hay không
        /// Mặc định là Publish luôn
        /// Nếu false thì cần có scheduled_publish_time
        /// </summary>
        public bool? published { get; set; }

        /// <summary>
        /// Thời gian đặt lịch đăng
        /// An integer UNIX timestamp [in seconds] (e.g. 1530432000)
        /// </summary>
        public int? scheduled_publish_time { get; set; }
    }

    public class FBPostProductResponse : FacebookBaseResponse
    {
        /// <summary>
        /// photo ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// ID của bài viết
        /// </summary>
        public string post_id { get; set; }
    }

}