using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Common
{
    public static class AppConstants
    {
        public const string APP_NAME = "Gara Oto Management System";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string CURRENCY_FORMAT = "#,##0";
        public const string DEFAULT_PASSWORD = "123456";

        public const string DateFormat = "dd/MM/yyyy";
    }

    public static class MessageConstants
    {
        public const string SAVE_SUCCESS = "Lưu dữ liệu thành công!";
        public const string SAVE_ERROR = "Lỗi khi lưu dữ liệu!";
        public const string DELETE_CONFIRM = "Bạn có chắc chắn muốn xóa?";
        public const string DELETE_SUCCESS = "Xóa dữ liệu thành công!";
        public const string DELETE_ERROR = "Lỗi khi xóa dữ liệu!";
        public const string VERIFY_LOGIN_ACCOUNT = "Tài khoản không tồn tại";
        public const string VERIFY_LOGIN_PASS = "Mật khẩu không chính xác.";
        public const string VERIFY_EMPTY = "Username và Password không được để trống.";
    }

    public static class ValidationConstants
    {
        public const string REQUIRED_FIELD = "{0} không được để trống";
        public const string INVALID_EMAIL = "Email không hợp lệ";
        public const string INVALID_PHONE = "Số điện thoại không hợp lệ";
        public const int PASS_LENGTH_MIN = 6;
    }
}
