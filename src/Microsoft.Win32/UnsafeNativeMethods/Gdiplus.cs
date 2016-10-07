using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Gdiplus.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// �����ַ�����С
        /// </summary>
        /// <param name="hGraphics">��ͼ������</param>
        /// <param name="szText">Ҫ���Ե��ַ���</param>
        /// <param name="nLength">�ַ�������</param>
        /// <param name="hFont">������</param>
        /// <param name="aPositions">��������</param>
        /// <param name="nFlags">���</param>
        /// <param name="hMatrix"></param>
        /// <param name="tBounds">����</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public extern static int GdipMeasureDriverString(IntPtr hGraphics, string szText, int nLength, IntPtr hFont, PointF[] aPositions, int nFlags, IntPtr hMatrix, ref RectangleF tBounds);
        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="hGraphics">��ͼ����</param>
        /// <param name="szText">Ҫ���Ƶ��ı�</param>
        /// <param name="nLength">�ַ�������</param>
        /// <param name="hFont">������</param>
        /// <param name="hBrush">��ˢ���</param>
        /// <param name="aPositions">��������</param>
        /// <param name="nFlags">���</param>
        /// <param name="hMatrix">��������</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public extern static int GdipDrawDriverString(IntPtr hGraphics, string szText, int nLength, IntPtr hFont, IntPtr hBrush, PointF[] aPositions, int nFlags, IntPtr hMatrix);
    }
}
