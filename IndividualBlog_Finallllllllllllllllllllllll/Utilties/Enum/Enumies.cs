using System.ComponentModel.DataAnnotations;

namespace IndividualBlog.Utilties.Enum
{
    public enum EPost
    {
        [Display(Name = "Hiển thị")]
        Approved =0,
        [Display(Name ="Ẩn bài")]
        Cancel =1,
    }
    public enum EUserRole
    {
        [Display(Name = "Quản trị hệ thống")]
        Admin =0,
        [Display(Name = "Quản trị nhỏ")]
        Mod =1,
        [Display(Name = "Thành viên")]
        Member =2,
    }
    public enum EUserStatus
    {
        [Display(Name = "Đang hoạt động")]
        Active =0,
        [Display(Name = "Khóa tài khoản")]
        Block = 1,
    }
}
