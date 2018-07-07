using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentEncryption
{
    /// <summary>
    /// メールアイテムの検証エラー
    /// </summary>
    class MailItemValidationException : Exception
    {
        public MailItemValidationException() : base()
        {

        }

        public MailItemValidationException(string message) : base(message)
        {

        }

        public MailItemValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
