using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    /// <summary>
    /// Các khai báo constant endpoint Facebook Graph API
    /// </summary>
    public class FacebookEndpoint
    {
        /// <summary>
        /// Lấy token có thời gian Expired dài hơn (60 ngày, mỗi ngày đăng nhập request sẽ tự refresh lại số ngày)
        /// </summary>
        public const string GetLongLivedAccessToken = "/oauth/access_token?grant_type=fb_exchange_token&client_id={0}&client_secret={1}&fb_exchange_token={2}";

        /// <summary>
        /// Lấy thông tin user cung cấp access_token
        /// </summary>
        public const string GetCurrentUserInfoAdmin = "/me?access_token={0}&fields=id,first_name,last_name,name,picture"; //,gender,picture.width(500).height(500),cover.width(1024).height(1024)

        /// <summary>
        /// Lấy danh sách trang của user cung cấp access_token
        /// </summary>
        /// Modified by nmsinh - 14/02/2019 : lỗi ko load danh sách fanpage
        public const string GetListPage = "/me?access_token={0}&fields=accounts.limit(200){{access_token,category,category_list,name,id,picture.width(500).height(500)}}"; //access_token,category,category_list,name,id,perms

        /// <summary>
        /// Lấy thông tin user theo id
        /// </summary>
        public const string GetUserInfoById = "/{1}?access_token={0}&fields=id,first_name,last_name,name,picture.width(100).height(100)"; //,profile_pic,picture.width(500).height(500),cover.width(1024).height(1024)

        /// <summary>
        /// Lấy danh sách hội thoại của page
        /// </summary>
        ///Khi lấy danh sách Conversation không cần lấy luôn danh sách message của từng conversation
        //public const string GetPageConversations = "/{1}/conversations?access_token={0}&fields=senders,can_reply,message_count,unread_count,snippet,updated_time,link,messages.limit(1){{from}}&limit={3}&after={2}";
        public const string GetPageConversations = "/{1}/conversations?access_token={0}&fields=senders,can_reply,message_count,unread_count,snippet,updated_time,link&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách hội thoại của page
        /// </summary>
        public const string GetPageConversationsMigrate = "/{1}/conversations?access_token={0}&fields=senders,can_reply,message_count,unread_count,snippet,updated_time,link,messages.limit(1){{from,message}}&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách tin nhắn theo hội thoại
        /// </summary>
        public const string GetListMessageByConversationId = "/{1}/messages?access_token={0}&fields=created_time,id,message,from,to,tags,attachments,shares{{id,link,description,name}},sticker&limit={2}";

        /// <summary>
        /// Lấy danh sách bài viết của page
        /// </summary>
        public const string GetPagePosts = "/{1}/posts?access_token={0}&fields=attachments,message,story,created_time,updated_time,is_hidden,full_picture,picture,icon,status_type,permalink_url&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách bài viết của page kèm theo comments
        /// </summary>
        public const string GetPagePostsWithComments = "/{1}/posts?access_token={0}&fields=attachments,message,story,created_time,updated_time,is_hidden,full_picture,picture,icon,status_type,permalink_url,comments.limit({5}){{{4}}}&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách bài viết của page để thực hiện tìm kiếm
        /// </summary>
        public const string GetPagePostsShort = "/{1}/posts?access_token={0}&fields=id,message,created_time,updated_time,permalink_url,picture&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách bài viết dùng cho gửi tin nhắn hàng loạt. Note: /posts luôn trả về order theo created_time desc
        /// </summary>
        public const string GetPagePostsForAutoMessage = "/{1}/posts?access_token={0}&fields=created_time,id,message&since={2}&until={3}&limit={4}&after={5}";

        /// <summary>
        /// Lấy danh sách live stream video của 1 page
        /// </summary>
        public const string GetVideoStreamFB = "/{1}/live_videos?access_token={0}&fields=id,status,stream_url,description,title,creation_time,live_views,permalink_url,embed_html,video{{id,length,updated_time,picture}}&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách live stream video của 1 page
        /// </summary>
        public const string GetVideoStreamFB2 = "/{1}?access_token={0}&fields=live_videos.limit({2}){{id,status,stream_url,description,title,creation_time,live_views,permalink_url,embed_html,video{{id,length,updated_time,picture}}}}";


        /// <summary>
        /// lấy danh sách bài post video
        /// </summary>
        public const string GetPostVideoStream = "/{1}/posts?access_token={0}&fields=message,id,created_time,attachments{{url,media,media_type,description,target}}&limit=100&after={2}";

        /// <summary>
        /// lấy danh sách bài post video
        /// </summary>
        public const string GetVideoDetail = "/{1}?access_token={0}&fields=id,title,permalink_url,description,source,embed_html,length,live_status,picture";


        /// <summary>
        /// Lấy thông tin chi tiết của 1 live stream video
        /// </summary>
        public const string GetVideoStreamFBDetail = "/{1}?access_token={0}&fields=id,status,stream_url,description,title,creation_time,live_views,permalink_url,embed_html,video{{id,length,updated_time,picture}}";


        /// <summary>
        /// Lấy danh sách comments vào 1 object
        /// </summary>
        public const string GetComments = "/{1}/comments?access_token={0}&fields={2}&order=reverse_chronological&limit={3}&after={4}";

        /// <summary>
        /// Lấy thông tin attachment (ảnh) kèm theo các comment trên attachment đó
        /// </summary>
        public const string GetCommentFromTaget = "/{1}?access_token={0}&fields=id,link,name,picture,comments.limit({2}){3}{{{4}}}";

        /// <summary>
        /// Lấy thông tin comment
        /// </summary>
        public const string GetFullCommentFromPost = "/{1}/comments?access_token={0}&fields=id,message,created_time,from,comments.limit({2}){{id,from,parent,message}}&after={3}&limit={4}";

        /// <summary>
        /// Danh sách các field cần lấy trên comment
        /// </summary>
        public const string CommentFields = "id,from,parent,message,attachment,can_hide,can_like,can_comment,can_remove,can_reply_privately,comment_count,is_hidden,is_private,user_likes,like_count,permalink_url,message_tags,created_time,object";
        public const string MessageCommentFields = "id,from,parent,message";

        /// <summary>
        /// Lấy đầy đủ thông tin bài viết
        /// </summary>
        public const string GetFullPostInfo = "/{1}?access_token={0}&fields=message,story,picture,full_picture,link,created_time,updated_time,can_reply_privately,comments{created_time,from,message,id,attachment}";

        /// <summary>
        /// Lấy 1 comment theo id
        /// </summary>
        public const string GetSingleComment = "/{1}?fields=attachment,can_comment,can_hide,can_like,can_remove,comment_count,created_time,id,is_hidden,is_private,like_count,message,permalink_url,from,message_tags,can_reply_privately,user_likes,object&access_token={0}";

        /// <summary>
        /// Chỉnh sửa một bình luận
        /// </summary>
        public const string UpdateComment = "/{1}?message={2}&access_token={0}";

        /// <summary>
        /// Xóa một đối tượng theo ID
        /// </summary>
        public const string DeleteObject = "/{1}?access_token={0}";

        /// <summary>
        /// Ẩn/bỏ ẩn một đối tượng (Comment, bài viết)
        /// </summary>
        public const string HideObject = "/{1}?access_token={0}&is_hidden={2}";

        /// <summary>
        /// Ẩn một đối tượng
        /// </summary>
        public const string HideObjectInBatch = "{0}?is_hidden=true";

        /// <summary>
        /// Like đối tượng
        /// </summary>
        public const string LikeObject = "/{1}/likes?access_token={0}";

        /// <summary>
        /// Trả lời kín dựa trên một object Coment/Post
        /// </summary>
        public const string PrivateReply = "/{1}/private_replies?access_token={0}&message={2}";

        /// <summary>
        /// Trả lời tin nhắn
        /// Có thể dùng cho trả lời một object comment/post
        /// </summary>
        public const string ReplyMessage = "/{1}/messages?access_token={0}";

        /// <summary>
        /// Trả lời tin nhắn
        /// </summary>
        public const string ReplyConversation = "/{1}/messages?access_token={0}&messaging_type={2}";

        /// <summary>
        /// Trả lời tin nhắn dạng biên lai
        /// </summary>

        public const string ReplyMessageByTemplate = "/{1}/messages?access_token={0}&messaging_type={2}";

        /// <summary>
        /// Trả lời tin nhắn có tag
        /// </summary>

        public const string ReplyConversationMessageTag = "/{1}/messages?access_token={0}&messaging_type={2}&tag={3}";

        /// <summary>
        /// Trả lời bình luận
        /// </summary>

        public const string ReplyComment = "/{1}/comments?access_token={0}";

        /// <summary>
        /// Trả lời bình luận với hình ảnh
        /// </summary>
        public const string ReplyCommentWithImage = "/{1}/comments?access_token={0}&attachment_url={2}";

        /// <summary>
        /// Đăng ký Webhook cho 1 page
        /// </summary>

        public const string SubscribedApps = "/{1}/subscribed_apps?access_token={0}";

        /// <summary>
        /// Đánh dấu hội thoại là đã đọc
        /// </summary>

        public const string MarkConversationAsRead = "/me/messages?access_token={0}";

        /// <summary>
        /// Cập nhật hàng loạt sản phẩm
        /// </summary>

        public const string ProductCatalogUpdateBatch = "{0}/batch";

        /// <summary>
        /// Đăng bài viết lên tường của Page
        /// </summary>
        //public const string PublishToPageWall = "{1}/feed?access_token={0}&message={1}";
        public const string PublishToPageWall = "{0}/feed";

        /// <summary>
        /// Lấy tất cả album của fanpage
        /// </summary>
        public const string GetPageAlbum = "me/albums?access_token={0}&fields=count,can_upload,cover_photo{{source,id}},description,id,link,name,picture{{height,width,url}},type";

        /// <summary>
        /// Lấy thông tin chi tiết của album
        /// </summary>photos?fields=name,picture,width,id,images&after=&limit=25
        public const string GetPageAlbumDetail = "/{1}/photos?access_token={0}&fields=images,name,picture,width,id";

        /// <summary>
        /// Trả lời tin nhắn với hình ảnh
        /// </summary>
        public const string ReplyConversationWithImage = "/me/messages?access_token={0}";

        /// <summary>
        /// đăng hàng hóa lên tường fanpage
        /// </summary>
        public const string PostProduct = "/{0}/photos";

        /// <summary>
        /// upload ảnh lên facebook ở trạng thái không publish
        /// </summary>
        public const string UploadImageFB = "/{1}/photos?access_token={0}&caption={2}&url={3}&published={4}";

        /// <summary>
        /// chuyển bài đăng từ đặt lịch sang đăng ngay trên fb
        /// </summary>
        public const string PostFbNowFromSchedule = "/{1}?access_token={0}&is_published=true";
        /// <summary>
        /// chuyển bài đăng từ đặt lịch sang đăng ngay trên fb
        /// </summary>
        public const string PostFbNowFromScheduleVideo = "/{1}?access_token={0}&published=true";
        /// <summary>
        /// upload video lên facebook
        /// </summary>
        public const string UploadVideoFB = "/{1}/videos?access_token={0}&description={2}&source={3}";

        /// <summary>
        /// update post video lên facebook
        /// </summary>
        public const string UpdateVideoFB = "/{1}/?access_token={0}";

        ////lấy thông tin bài post
        //public const string GetPostInfomation = "/{1}?fields=id,message,created_time,attachments";

        /// đặt lịch đăng bài lên facebook
        /// </summary>
        public const string CreatePostSchedule = "/{1}/feed?access_token={0}&scheduled_publish_time={2}&published=false";

        /// đặt lịch đăng bài lên facebook
        /// </summary>
        public const string CreatePostScheduleHasImage = "/{1}/feed?access_token={0}&scheduled_publish_time={2}&published=false";

        /// sửa thông tin bài post đã đặt lịch
        /// </summary>
        public const string EditSchedulePost = "/{1}/?access_token={0}&scheduled_publish_time={2}&published=false";

        /// sửa text bài post đã đặt lịch
        /// </summary>
        public const string EditTextSchedulePost = "/{1}/?access_token={0}scheduled_publish_time={2}&published=false";

        /// sửa thông tin bài post đã đăng
        /// </summary>
        public const string EditPublishedPost = "/{1}/?access_token={0}";

        /// sửa thông tin bài post video đã đăng
        /// </summary>
        public const string EditPublishedPostVideo = "/{1}/?access_token={0}";

        /// sửa thông tin bài post video đặt lịch
        /// </summary>
        public const string EditSchedulePostVideo = "/{1}/?access_token={0}&scheduled_publish_time={2}&published=false";

        /// <summary>
        /// đăng nhiều hàng hóa lên tường fanpage
        /// </summary>
        public const string PostProducts = "/{1}/feed?access_token={0}&message={2}";

        /// <summary>
        /// Cài đặt lời chào
        /// </summary>
        public const string SetMessengerGreeting = "/{1}/messenger_profile?access_token={0}&greeting={2}";
        /// <summary>
        /// Cài đặt menu cố định
        /// </summary>
        public const string SetPersistentMenu = "/{1}/messenger_profile?access_token={0}&persistent_menu={2}";
        /// <summary>
        /// Cài đặt menu cố định
        /// </summary>
        public const string GetGetStarted = "/{1}/messenger_profile?access_token={0}&fields={2}";
        /// <summary>
        /// Cài đặt menu geting started
        /// </summary>
        public const string SetGetStarted = "/{1}/messenger_profile?access_token={0}&get_started={2}";

        /// <summary>
        /// Cài đặt menu geting started
        /// </summary>
        public const string SetMessageProfile = "/{1}/messenger_profile?access_token={0}";

        /// <summary>
        /// Cài đặt menu geting started vaf persistenMenu
        /// </summary>
        public const string SetGetStartedPersistentMenu = "/{1}/messenger_profile?access_token={0}&get_started={2}&persistent_menu={3}";

        /// <summary>
        /// Cài đặt tin nhắn chào mừng
        /// </summary>
        public const string SetMessengerProfile = "/{1}/messenger_profile?access_token={0}&greeting={2}&get_started={3}&persistent_menu={4}";

        /// <summary>
        /// Xóa tin nhắn chào mừng
        /// </summary>
        public const string DeleteMessengerProfile = "/{1}/messenger_profile?access_token={0}&fields={2}";

        /// <summary>
        /// đăng bài post chỉ text
        /// </summary>
        public const string PostTextPublish = "/{0}/feed";

        /// <summary>
        /// đăng ảnh để lấy id (không publish)
        /// </summary>
        public const string UploadPhotoUnPublish = "/me/photos?published={0}";

        /// <summary>
        /// lấy link bài post
        /// </summary>
        public const string GetPostLink = "/{1}?access_token={0}&fields=permalink_url";

        /// <summary>
        /// Lấy thông tin bài post gồm ảnh và content
        /// </summary>
        public const string GetPostInfo = "/{1}?access_token={0}&fields=picture,message,attachments,created_time";

        /// <summary>
        /// Lấy thông tin bài post gồm ảnh và content
        /// </summary>
        public const string GetPostVideoInfo = "/{1}?access_token={0}&fields=source,description";

        /// <summary>
        /// Cập nhật thông tin bài post
        /// </summary>
        public const string UpdatePostInfo = "/{1}?access_token={0}";

        /// <summary>
        /// Cập nhật thông tin bài post
        /// </summary>
        public const string UpdateTextPostInfo = "/{1}?access_token={0}&message={2}";

        /// <summary>
        /// Cập nhật thông tin bài đăng video
        /// </summary>
        public const string UpdatePostVideoInfo = "/{1}?access_token={0}&description={2}";
        /// <summary>
        /// Lấy thông tin bài post gồm ảnh và content đối với chi tiết từng ảnh
        /// </summary>
        public const string GetImagePostInfo = "/{1}?access_token={0}&fields=id,name,picture,created_time,link";

        /// <summary>
        /// Lấy danh sách sản phẩm có trong Product Catalog
        /// </summary>
        public const string GetProductsInCatalog = "/{1}/products?access_token={0}&fields=id,name,retailer_id,image_url,url&limit={3}&after={2}";

        /// <summary>
        /// Lấy danh sách sản phẩm có trong Product Catalog
        /// </summary>
        public const string GetProductsInCatalogProduct = "/{1}/products?access_token={0}&fields=id,name,retailer_id&limit={2}";

        /// <summary>
        /// set tin nhắn mặc định tự động trả lời khách
        /// </summary>
        public const string MessageDefault = "me/saved_message_responses?access_token={0}&category=INSTANT_REPLY&message={1}";

        /// <summary>
        /// Lấy thông tin Product_catologId của page
        /// </summary>
        public const string GetProductCatalogId = "{1}?access_token={0}&fields=product_catalogs";

        /// <summary>
        /// Chặn KH với Fanpage
        /// </summary>

        public const string BlockCustomer = "/{1}/blocked?access_token={0}";

        /// <summary>
        /// Bỏ chặn KH với Fanpage
        /// </summary>

        public const string UnBlockCustomer = "/{1}/blocked?psid={2}&access_token={0}";

        /// <summary>
        /// Lấy danh sách user đã cmt post
        /// </summary>

        public const string GetUserCmtPost = "/{1}_{2}/comments?fields=from&access_token={0}";

        /// <summary>
        /// Lấy quyền kiểm soát tin nhắn
        /// </summary>

        public const string TakeThreadControl = "/{1}/take_thread_control?access_token={0}&recipient={2}";

        /// <summary>
        /// Chuyển quyền kiểm soát tin nhắn
        /// </summary>

        public const string PassThreadControl = "/{1}/pass_thread_control?access_token={0}&recipient={2}&target_app_id={3}";

        /// <summary>
        /// Yêu cầu quyền kiểm soát tin nhắn
        /// </summary>

        public const string RequestThreadControl = "/{1}/request_thread_control?access_token={0}&recipient={2}";

        /// <summary>
        /// Lấy block rate của page
        /// </summary>

        public const string GetBlockRate = "/{1}/insights/?access_token={0}&metric={2}&since={3}&until={4}";

        /// <summary>
        /// Trả lời tin nhắn có tag
        /// </summary>

        public const string ReplyConversationWithMessageTag = "/me/messages?access_token={0}";
    }
}