using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuthenticationDemo
{
    using System.Web.Security;

    using NLog;

    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// 建立Logger
        /// </summary>
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 按下登入按鈕後的動作
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void LinkButton_Submit_OnClick(object sender, EventArgs e)
        {
            // 先把Session全部清空
            Session.Clear();
            Session.Abandon();

            try
            {
                // 完成帳號密碼的驗證
                var userName = this.TextBox_UserName.Text.Trim();

                // 使用SHA1,密碼做HASH(雖然函式已標註過期,但至少在.NET Framework 4.5.2還是可以用的
                var encPassword =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(
                        this.TextBox_Password.Text.Trim(), 
                        "SHA1");
                var roles = AccountLogin.VerifyAndReturnRoles(userName, encPassword);

                // 將登入的 Cookie 設定成 Session Cookie
                var isPersistent = false;

                // 建立一張ticket
                var ticket = new FormsAuthenticationTicket(
                    1,
                    userName,
                    DateTime.Now, 
                    DateTime.Now.AddMinutes(30), // 30分後過期
                    isPersistent,
                    roles,
                    FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);

                // 將ticket放在cookie中
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                try
                {
                    Response.Redirect(Page.ResolveUrl("~/Default.aspx"), true);
                }
                catch 
                {
                   // 使用Response.Redirect,asp.net 一定會抛出轉址的Exception,因此用Try catch忽略Exception
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception);

                // 所有的錯誤,丟到ModelState去顯示,前端要加一個ValidationSummary 控制項
                this.Page.ModelState.AddModelError("error", "登入失敗,請檢查帳號密碼");
            }
        }

        // 驗證用Class
        private  class AccountLogin
        {
            public static string VerifyAndReturnRoles(string userName, string encPassword)
            {
                // 如果成功,回傳角色清單,否則丟出Exception
                // 必須實作

                if ("asdf".Equals(userName))
                {
                    throw new ArgumentNullException(nameof(userName),"不允許的使用者");
                }

                return string.Join(",",new[] { "Admin", "Group1" }) ;
            }
        }
    }
}