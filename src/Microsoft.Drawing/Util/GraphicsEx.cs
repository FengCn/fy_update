using System;
using System.Drawing;
using Microsoft.Win32;

namespace Microsoft.Drawing
{
    /// <summary>
    /// Graphics������
    /// </summary>
    public static class GraphicsEx
    {
        /// <summary>
        /// �����豸����(��֧��Alphaͨ��)
        /// </summary>
        /// <param name="gSrc">ԭ�豸</param>
        /// <param name="gDest">Ŀ���豸</param>
        /// <param name="ptDest">Դ��ʼ����</param>
        /// <param name="ptSrc">Ŀ����ʼ����</param>
        /// <param name="szBlock">���ƴ�С</param>
        public static void Render(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.BitBlt(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, NativeMethods.SRCCOPY);
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }

        /// <summary>
        /// ����豸����(֧��Alphaͨ��)
        /// </summary>
        /// <param name="gSrc">ԭ�豸</param>
        /// <param name="gDest">Ŀ���豸</param>
        /// <param name="ptDest">Դ��ʼ����</param>
        /// <param name="ptSrc">Ŀ����ʼ����</param>
        /// <param name="szBlock">���ƴ�С</param>
        public static void BlendRender(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.GdiAlphaBlend(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, szBlock.Width, szBlock.Height, NativeMethods.BLENDFUNCTION.Default);
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }

        /// <summary>
        /// ����豸����(֧��Alphaͨ��)
        /// </summary>
        /// <param name="gSrc">ԭ�豸</param>
        /// <param name="gDest">Ŀ���豸</param>
        /// <param name="ptDest">Դ��ʼ����</param>
        /// <param name="ptSrc">Ŀ����ʼ����</param>
        /// <param name="szBlock">���ƴ�С</param>
        /// <param name="alpha">͸����[0-255]</param>
        public static void BlendRender(Graphics gSrc, Graphics gDest, Point ptDest, Point ptSrc, Size szBlock, byte alpha)
        {
            if (gSrc == null || gDest == null)
                return;

            IntPtr hdcDest = gDest.GetHdc();
            IntPtr hdcSrc = gSrc.GetHdc();
            try
            {
                UnsafeNativeMethods.GdiAlphaBlend(hdcDest, ptDest.X, ptDest.Y, szBlock.Width, szBlock.Height, hdcSrc, ptSrc.X, ptSrc.Y, szBlock.Width, szBlock.Height, new NativeMethods.BLENDFUNCTION(NativeMethods.AC_SRC_OVER, 0, alpha, NativeMethods.AC_SRC_ALPHA));
            }
            finally
            {
                gSrc.ReleaseHdcInternal(hdcSrc);
                gDest.ReleaseHdcInternal(hdcDest);
            }
        }
    }
}
