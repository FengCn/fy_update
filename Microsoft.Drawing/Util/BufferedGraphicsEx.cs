using System;
using System.Drawing;
using System.Reflection;

namespace Microsoft.Drawing
{
    /// <summary>
    /// BufferedGraphicsEx������
    /// </summary>
    public static class BufferedGraphicsEx
    {
        private static readonly FieldInfo FiTargetLoc;      //BufferedGraphics.targetLoc�ֶ���Ϣ
        private static readonly FieldInfo FiVirtulSize;     //BufferedGraphics.virtualSize�ֶ���Ϣ

        /// <summary>
        /// ��̬����
        /// </summary>
        static BufferedGraphicsEx()
        {
            Type type = typeof(BufferedGraphics);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FiTargetLoc = type.GetField("targetLoc", flags);
            FiVirtulSize = type.GetField("virtualSize", flags);
        }

        /// <summary>
        /// ��ȡ��������Ŀ�����ꡣ
        /// </summary>
        /// <param name="bg">��������</param>
        /// <returns>��������Ŀ������</returns>
        public static Point GetTargetLoc(BufferedGraphics bg)
        {
            if (bg == null)
                throw new ArgumentNullException("bg");

            return (Point)FiTargetLoc.GetValue(bg);
        }

        /// <summary>
        /// ��ȡ������������ߴ��С��
        /// </summary>
        /// <param name="bg">��������</param>
        /// <returns>������������ߴ��С��</returns>
        public static Size GetVirtualSize(BufferedGraphics bg)
        {
            if (bg == null)
                throw new ArgumentNullException("bg");

            return (Size)FiVirtulSize.GetValue(bg);
        }

        /// <summary>
        /// ��ͼ�λ�����������д��ָ���� System.Drawing.Graphics ����
        /// </summary>
        /// <param name="bgSrc">ͼ�λ�������Ҫ��ϵ�Դ��</param>
        /// <param name="gDest">һ�� System.Drawing.Graphics ����Ҫ������д��ͼ�λ����������ݡ�</param>
        /// <param name="rcDest">Ŀ����Ρ�</param>
        public static void Render(BufferedGraphics bgSrc, Graphics gDest, Rectangle rcDest)
        {
            //��֤
            if (bgSrc == null || gDest == null || !RectangleEx.IsVisible(rcDest))
                return;

            //�����ȡ˽���ֶ� 
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            targetLoc.Offset(rcDest.X, rcDest.Y);
            Size virtualSize = rcDest.Size;
            Point sourceLoc = rcDest.Location;

            //�����Ⱦ
            GraphicsEx.Render(bgSrc.Graphics, gDest, targetLoc, sourceLoc, virtualSize);
        }

        /// <summary>
        /// ��ͼ�λ�������������ָ���� System.Drawing.Graphics �����ϡ�(֧�ֻ�����Alphaͨ��)
        /// </summary>
        /// <param name="bgSrc"></param>
        /// <param name="gDest">һ�� System.Drawing.Graphics ����ͼ�λ�����Ҫ��ϵ�Ŀ�ꡣ</param>
        public static void BlendRender(BufferedGraphics bgSrc, Graphics gDest)
        {
            //��֤
            if (bgSrc == null || gDest == null)
                return;

            //�����ȡ˽���ֶ�
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            Size virtualSize = (Size)FiVirtulSize.GetValue(bgSrc);

            //�����Ⱦ
            GraphicsEx.BlendRender(bgSrc.Graphics, gDest, targetLoc, Point.Empty, virtualSize);
        }

        /// <summary>
        /// ��ͼ�λ�������������ָ���� System.Drawing.Graphics �����ϡ�(֧�ֻ�����Alphaͨ��)
        /// </summary>
        /// <param name="bgSrc">ͼ�λ�������Ҫ��ϵ�Դ��</param>
        /// <param name="gDest">һ�� System.Drawing.Graphics ����ͼ�λ�����Ҫ��ϵ�Ŀ�ꡣ</param>
        /// <param name="rcDest">Ŀ����Ρ�</param>
        public static void BlendRender(BufferedGraphics bgSrc, Graphics gDest, Rectangle rcDest)
        {
            //��֤
            if (bgSrc == null || gDest == null || !RectangleEx.IsVisible(rcDest))
                return;

            //�����ȡ˽���ֶ�
            Point targetLoc = (Point)FiTargetLoc.GetValue(bgSrc);
            targetLoc.Offset(rcDest.X, rcDest.Y);
            Size virtualSize = rcDest.Size;
            Point sourceLoc = rcDest.Location;

            //�����Ⱦ
            GraphicsEx.BlendRender(bgSrc.Graphics, gDest, targetLoc, sourceLoc, virtualSize);
        }
    }
}
