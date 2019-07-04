using System;

namespace ECPay.SDK.Einvoice.Attributes
{
    internal class TextAttribute : Attribute
    {
        public string Text;

        public TextAttribute(string text)
        {
            Text = text;
        }
    }
}