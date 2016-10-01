using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// POINT����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// POINT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// ˮƽ����
            /// </summary>
            public int x;
            /// <summary>
            /// ��ֱ����
            /// </summary>
            public int y;

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="x">ˮƽ����</param>
            /// <param name="y">��ֱ����</param>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
