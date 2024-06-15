using System.Text;
using System.Security.Cryptography;
namespace Doan1.Ulitities
{
	public class Functions
	{
		public static int _AccountIDA = 0;
		public static string _FullNameA=string.Empty;
		public static string _EmailA=string.Empty;
		public static string _AvatarA=string.Empty;
		public static string _UserNameA=string.Empty;
		public static string _PasswordA=string.Empty;
		public static string _PhoneA=string.Empty;

        public static int _AccountID = 0;
        public static string _FullName = string.Empty;
        public static string _Email = string.Empty;
        public static string _Avatar = string.Empty;
        public static string _UserName = string.Empty;
        public static string _Password = string.Empty;
        public static string _Phone = string.Empty;

        public static string _Message=string.Empty;
		public static string _MessageEmail=string.Empty;

		public static int Cmt;
		public static string TitleSlugGeneration(string type, string title, long id)
		{
			string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
			return sTitle;
		}
		public static string getCurrentDate()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string MD5Hash(string text) 
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
			byte[] result = md5.Hash;
			StringBuilder strBuilder = new StringBuilder();
			for (int i=0;i<result.Length;i++)
			{
				strBuilder.Append(result[i].ToString("x2"));
			}
			return strBuilder.ToString();
		}
		public static string MD5PassWord(string? text)
		{
			string str=MD5Hash(text);
			for (int i = 0; i <= 5; i++)
				str = MD5Hash(str + "_" + str);
			return str;
		}
		public static bool IsLoginAdmin()
		{
			if( string.IsNullOrEmpty(Functions._EmailA)|| (Functions._AccountIDA<=0))
				return false;
			return true;
		}
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._Email) || (Functions._AccountID <= 0))
                return false;
            return true;
        }
    }
}
