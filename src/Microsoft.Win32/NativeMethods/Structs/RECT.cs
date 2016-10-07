using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// ���νṹ����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// ���νṹ
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// ���Ͻ�ˮƽ����
            /// </summary>
            public int left;
            /// <summary>
            /// ���ϽǴ�ֱ����
            /// </summary>
            public int top;
            /// <summary>
            /// ���½�ˮƽ����
            /// </summary>
            public int right;
            /// <summary>
            /// ���½Ǵ�ֱ����
            /// </summary>
            public int bottom;

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="left">���Ͻ�ˮƽ����</param>
            /// <param name="top">���ϽǴ�ֱ����</param>
            /// <param name="right">���½�ˮƽ����</param>
            /// <param name="bottom">���½Ǵ�ֱ����</param>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="r">Rectangle�ṹ</param>
            public RECT(Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="x">���Ͻ�ˮƽ����</param>
            /// <param name="y">���ϽǴ�ֱ����</param>
            /// <param name="width">���</param>
            /// <param name="height">�߶�</param>
            /// <returns>���νṹ</returns>
            public static NativeMethods.RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.RECT(x, y, x + width, y + height);
            }

            /// <summary>
            /// ���
            /// </summary>
            public int Width
            {
                get
                {
                    return this.right - this.left;
                }
            }

            /// <summary>
            /// �߶�
            /// </summary>
            public int Height
            {
                get
                {
                    return this.bottom - this.top;
                }
            }

            /// <summary>
            /// ���Ͻ�
            /// </summary>
            public Point Location
            {
                get
                {
                    return new Point(this.left, this.top);
                }
            }

            /// <summary>
            /// ���½�
            /// </summary>
            public Point BottomRight
            {
                get
                {
                    return new Point(this.right, this.bottom);
                }
            }

            /// <summary>
            /// ��С
            /// </summary>
            public Size Size
            {
                get
                {
                    return new Size(this.right - this.left, this.bottom - this.top);
                }
            }

            /// <summary>
            /// ת��Ϊ System.Drawing.Rectangle.
            /// </summary>
            /// <returns>System.Drawing.Rectangle</returns>
            public Rectangle ToRectangle()
            {
                return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
            }

            /// <summary>
            /// �Ƿ����ָ����
            /// </summary>
            /// <param name="pt">��</param>
            /// <returns>��������true,���򷵻�false</returns>
            public bool Contains(NativeMethods.POINT pt)
            {
                return this.Contains(pt.x, pt.y);
            }

            /// <summary>
            /// �Ƿ����ָ����
            /// </summary>
            /// <param name="pt">��</param>
            /// <returns>��������true,���򷵻�false</returns>
            public bool Contains(Point pt)
            {
                return this.Contains(pt.X, pt.Y);
            }

            /// <summary>
            /// �Ƿ����ָ������
            /// </summary>
            /// <param name="x">ˮƽ����</param>
            /// <param name="y">��ֱ����</param>
            /// <returns>��������true,���򷵻�false</returns>
            public bool Contains(int x, int y)
            {
                return ((this.left <= x) && (x < this.right) && (this.top <= y) && (y < this.bottom));
            }
        }
    }
}
