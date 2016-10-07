using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// ����λ�ýṹ����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// ����λ�ýṹ
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            /// <summary>
            /// A handle to the window.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The position of the window in Z order (front-to-back position). This member can be a handle to the window behind which this window is placed, or can be one of the special values listed with the SetWindowPos function.
            /// </summary>
            public IntPtr hwndInsertAfter;
            /// <summary>
            /// The position of the left edge of the window.
            /// </summary>
            public int x;
            /// <summary>
            /// The position of the top edge of the window.
            /// </summary>
            public int y;
            /// <summary>
            /// The window width, in pixels.
            /// </summary>
            public int cx;
            /// <summary>
            /// The window height, in pixels.
            /// </summary>
            public int cy;
            /// <summary>
            /// The window position. This member can be one or more of the following values. �μ� SWP
            /// </summary>
            public uint flags;
        }
    }
}
