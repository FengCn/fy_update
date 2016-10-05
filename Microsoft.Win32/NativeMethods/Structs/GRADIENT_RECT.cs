using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// GRADIENT_RECT����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// The GRADIENT_RECT structure specifies the index of two vertices in the pVertex array in the GradientFill function. These two vertices form the upper-left and lower-right boundaries of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_RECT
        {
            /// <summary>
            /// The upper-left corner of a rectangle.
            /// </summary>
            public uint UpperLeft;
            /// <summary>
            /// The lower-right corner of a rectangle.
            /// </summary>
            public uint LowerRight;

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="upperLeft">���Ͻ�</param>
            /// <param name="lowerRight">���Ͻ�</param>
            public GRADIENT_RECT(uint upperLeft, uint lowerRight)
            {
                this.UpperLeft = upperLeft;
                this.LowerRight = lowerRight;
            }
        }
    }
}