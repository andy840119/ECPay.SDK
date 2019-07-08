using System.Text;
using ECPay.SDK.Payment.Enumeration;

namespace ECPay.SDK.Payment.Helpers
{
    public class CharSetHelper
    {
        public static Encoding GetCharSet(CharSetState CharSet)
        {
            Encoding type = null;

            switch (CharSet)
            {
                case CharSetState.Big5:
                    type = Encoding.GetEncoding("Big5");
                    break;
                case CharSetState.UTF8:
                    type = Encoding.UTF8;
                    break;
                case CharSetState.Default:
                default:
                    type = Encoding.Default;
                    break;
            }

            return type;
        }
    }
}
