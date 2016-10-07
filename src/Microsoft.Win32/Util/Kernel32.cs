using System;
using System.Text;

namespace Microsoft.Win32
{
    /// <summary>
    /// Kernel32��չ
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// ��ȡ��ָ���� Win32 ��������������ϸ˵����
        /// </summary>
        /// <param name="nErrorCode">Win32 ������롣</param>
        /// <returns>�������ϸ˵����</returns>
        public static string GetErrorMessage(int nErrorCode)
        {
            StringBuilder lpBuffer = new StringBuilder(0x100);
            if (UnsafeNativeMethods.FormatMessage(NativeMethods.FORMAT_MESSAGE_IGNORE_INSERTS | NativeMethods.FORMAT_MESSAGE_FROM_SYSTEM | NativeMethods.FORMAT_MESSAGE_ARGUMENT_ARRAY, IntPtr.Zero, nErrorCode, 0, lpBuffer, lpBuffer.Capacity + 1, IntPtr.Zero) == 0)
                return ("Unknown error (0x" + Convert.ToString(nErrorCode, 0x10) + ")");

            int length = lpBuffer.Length;
            while (length > 0)
            {
                char ch = lpBuffer[length - 1];
                if ((ch > ' ') && (ch != '.'))
                    break;
                length--;
            }
            return lpBuffer.ToString(0, length);
        }
    }
}
