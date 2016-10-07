using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// ��ͼ�ṹ����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// ��ͼ�ṹ
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            /// <summary>
            /// �����ڻ��Ƶľ��
            /// </summary>
            public IntPtr hdc;
            /// <summary>
            /// ���Ϊ����ֵ��������������򲻲�������
            /// </summary>
            public bool fErase;
            /// <summary>
            /// ͨ���ƶ����ϽǺ����½ǵ�����ȷ��һ��Ҫ���Ƶľ��η�Χ���þ��ε�λ����ڿͻ������Ͻ�
            /// </summary>
            public RECT rcPaint;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            public bool fRestore;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            public bool fIncUpdate;
            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }
    }
}
