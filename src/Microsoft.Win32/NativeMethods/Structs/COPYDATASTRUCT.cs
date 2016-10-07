using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// COPYDATASTRUCT����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// ���̼䴫�����ݽṹ
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            /// <summary>
            /// flag
            /// </summary>
            public int dwData;//flag
            /// <summary>
            /// ��С
            /// </summary>
            public int cbData;//size
            /// <summary>
            /// ����
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
    }
}
