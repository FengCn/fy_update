using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// TRIVERTEX����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// <para>ʵ�ֹ���:The TRIVERTEX structure contains color information and position information.</para>
        /// <para>���÷���:Win32�ṹ��</para>
        /// <para>.</para>
        /// <para>������Ա:�����</para>
        /// <para>��������:2013-11-25</para>
        /// <para>������ע:</para>
        /// <para>.</para>
        /// <para>�޸���Ա:</para>
        /// <para>�޸�����:</para>
        /// <para>�޸ı�ע:</para>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TRIVERTEX
        {
            /// <summary>
            /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
            /// </summary>
            int x;
            /// <summary>
            /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
            /// </summary>
            int y;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Red;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Green;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Blue;
            /// <summary>
            /// The color information at the point of x, y.
            /// </summary>
            ushort Alpha;

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="x">������</param>
            /// <param name="y">������</param>
            /// <param name="red">R</param>
            /// <param name="green">G</param>
            /// <param name="blue">B</param>
            /// <param name="alpha">A</param>
            public TRIVERTEX(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha = alpha;
            }
            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="x">������</param>
            /// <param name="y">������</param>
            /// <param name="color">��ɫ</param>
            public TRIVERTEX(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.Red = color.R;
                this.Green = color.G;
                this.Blue = color.B;
                this.Alpha = color.A;
            }
            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="pt">����</param>
            /// <param name="color">��ɫ</param>
            public TRIVERTEX(Point pt, Color color)
            {
                this.x = pt.X;
                this.y = pt.Y;
                this.Red = color.R;
                this.Green = color.G;
                this.Blue = color.B;
                this.Alpha = color.A;
            }
        }
    }
}
