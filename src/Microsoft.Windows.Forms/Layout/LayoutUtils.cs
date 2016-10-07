using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms.Layout
{
    /// <summary>
    /// ���ֹ�����
    /// </summary>
    public static class LayoutUtils
    {
        /// <summary>
        /// <para>0*****1*****2</para>
        /// <para>*           *</para>
        /// <para>*           *</para>
        /// <para>4     5     6</para>
        /// <para>*           *</para>
        /// <para>*           *</para>
        /// <para>8*****9*****10</para>
        /// <para>��ȡ���뷽ʽ������,����ͼ</para>
        /// </summary>
        /// <param name="alignment">���뷽ʽ</param>
        /// <returns>����</returns>
        public static int ContentAlignmentToIndex(ContentAlignment alignment)
        {
            int num = xContentAlignmentToIndex(((int)alignment) & 15);//ȡ0-3λ,�������4����3,���಻��
            int num2 = xContentAlignmentToIndex((((int)alignment) >> 4) & 15);//4-7,�������4����3,���಻��
            int num3 = xContentAlignmentToIndex((((int)alignment) >> 8) & 15);//8-11,�������4����3,���಻��
            int num4 = (((((num2 != 0) ? 4 : 0) | ((num3 != 0) ? 8 : 0)) | num) | num2) | num3;
            num4--;
            return num4;
        }
        /// <summary>
        /// ���淽���ĸ���
        /// </summary>
        /// <param name="threeBitFlag">4bit����</param>
        /// <returns>�������4����3,���಻��</returns>
        private static byte xContentAlignmentToIndex(int threeBitFlag)
        {
            return ((threeBitFlag == 4) ? ((byte)3) : ((byte)threeBitFlag));
        }


        /// <summary>
        /// ��ȡ������ı�ͼƬ���λ��
        /// </summary>
        /// <param name="relation">�ı�ͼƬ���λ��</param>
        /// <returns>������ı�ͼƬ���λ��</returns>
        public static TextImageRelation GetOppositeTextImageRelation(TextImageRelation relation)
        {
            return (TextImageRelation)GetOppositeAnchor((AnchorStyles)relation);
        }
        /// <summary>
        /// ��ȡ�����ê����ʽ
        /// </summary>
        /// <param name="anchor">ê����ʽ</param>
        /// <returns>�����ê����ʽ</returns>
        private static AnchorStyles GetOppositeAnchor(AnchorStyles anchor)
        {
            AnchorStyles none = AnchorStyles.None;
            if (anchor != AnchorStyles.None)
            {
                for (int i = 1; i <= 8; i = i << 1)
                {
                    switch ((anchor & (AnchorStyles)i))
                    {
                        case AnchorStyles.Top:
                            none |= AnchorStyles.Bottom;
                            break;

                        case AnchorStyles.Bottom:
                            none |= AnchorStyles.Top;
                            break;

                        case AnchorStyles.Left:
                            none |= AnchorStyles.Right;
                            break;

                        case AnchorStyles.Right:
                            none |= AnchorStyles.Left;
                            break;
                    }
                }
            }
            return none;
        }


        /// <summary>
        /// �ھ���ָ��λ�û���ָ����С������
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">���뷽ʽ</param>
        /// <returns>��������</returns>
        public static Rectangle Align(Size size, Rectangle rect, ContentAlignment align)
        {
            return VAlign(size, HAlign(size, rect, align), align);
        }
        /// <summary>
        /// ����X����Ϳ��,ʹ���Ϊsize�Ŀ��,��ˮƽ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">ˮƽ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static Rectangle HAlign(Size size, Rectangle rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != ((ContentAlignment)0))
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0))
            {
                rect.X += (rect.Width - size.Width) / 2;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// ����Y����͸߶�,ʹ�߶�Ϊsize�ĸ߶�,�ڴ�ֱ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">��ֱ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static Rectangle VAlign(Size size, Rectangle rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft)) != ((ContentAlignment)0))
            {
                rect.Y += rect.Height - size.Height;
            }
            else if ((align & (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft)) != ((ContentAlignment)0))
            {
                rect.Y += (rect.Height - size.Height) / 2;
            }
            rect.Height = size.Height;
            return rect;
        }
        /// <summary>
        /// �ھ���ָ��λ�û���ָ����С������
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">���뷽ʽ</param>
        /// <returns>��������</returns>
        public static RectangleF Align(SizeF size, RectangleF rect, ContentAlignment align)
        {
            return VAlign(size, HAlign(size, rect, align), align);
        }
        /// <summary>
        /// ����X����Ϳ��,ʹ���Ϊsize�Ŀ��,��ˮƽ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">ˮƽ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static RectangleF HAlign(SizeF size, RectangleF rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != ((ContentAlignment)0))
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0))
            {
                rect.X += (rect.Width - size.Width) / 2f;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// ����Y����͸߶�,ʹ�߶�Ϊsize�ĸ߶�,�ڴ�ֱ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">��ֱ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static RectangleF VAlign(SizeF size, RectangleF rect, ContentAlignment align)
        {
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft)) != ((ContentAlignment)0))
            {
                rect.Y += rect.Height - size.Height;
            }
            else if ((align & (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft)) != ((ContentAlignment)0))
            {
                rect.Y += (rect.Height - size.Height) / 2f;
            }
            rect.Height = size.Height;
            return rect;
        }

        /// <summary>
        /// ����X����Ϳ��,ʹ���Ϊsize�Ŀ��,��ˮƽ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">ˮƽ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static Rectangle HAlign(Size size, Rectangle rect, HorizontalAlignment align)
        {
            if ((align & HorizontalAlignment.Right) != 0)
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & HorizontalAlignment.Center) != 0)
            {
                rect.X += (rect.Width - size.Width) / 2;
            }
            rect.Width = size.Width;
            return rect;
        }
        /// <summary>
        /// ����X����Ϳ��,ʹ���Ϊsize�Ŀ��,��ˮƽ�������ƶ����뵽����
        /// </summary>
        /// <param name="size">��С</param>
        /// <param name="rect">����</param>
        /// <param name="align">ˮƽ���뷽ʽ</param>
        /// <returns>�¾���</returns>
        public static RectangleF HAlign(SizeF size, RectangleF rect, HorizontalAlignment align)
        {
            if ((align & HorizontalAlignment.Right) != 0)
            {
                rect.X += rect.Width - size.Width;
            }
            else if ((align & HorizontalAlignment.Center) != 0)
            {
                rect.X += (rect.Width - size.Width) / 2f;
            }
            rect.Width = size.Width;
            return rect;
        }


        /// <summary>
        /// ��������С�м�ȥָ����Сby��ϵ.�ص���ϵ(��ҪԤ���ֶ��ų�)
        /// </summary>
        /// <param name="containerSize">������С</param>
        /// <param name="contentSize">���ݴ�С</param>
        /// <param name="relation">�������ݹ�ϵ</param>
        /// <returns>�´�С</returns>
        public static Size SubAlignedRegion(Size containerSize, Size contentSize, TextImageRelation relation)
        {
            return SubAlignedRegionCore(containerSize, contentSize, IsVerticalRelation(relation));
        }
        /// <summary>
        /// ��������С�м�ȥָ����Сby�Ƿ����¹�ϵ.�ص���ϵ(��ҪԤ���ֶ��ų�)
        /// </summary>
        /// <param name="containerSize">������С</param>
        /// <param name="contentSize">���ݴ�С</param>
        /// <param name="vertical">�Ƿ�ֱ��ϵ</param>
        /// <returns>�´�С</returns>
        public static Size SubAlignedRegionCore(Size containerSize, Size contentSize, bool vertical)
        {
            if (vertical)
            {
                containerSize.Height -= contentSize.Height;
            }
            else
            {
                containerSize.Width -= contentSize.Width;
            }
            return containerSize;
        }
        /// <summary>
        /// �Ƿ�ֱ��ϵ
        /// </summary>
        /// <param name="relation">�ı�ͼƬ���λ��</param>
        /// <returns>�Ǵ�ֱ��ϵ����true,���򷵻�false</returns>
        public static bool IsVerticalRelation(TextImageRelation relation)
        {
            return ((relation & (TextImageRelation.TextAboveImage | TextImageRelation.ImageAboveText)) != TextImageRelation.Overlay);
        }


        /// <summary>
        /// ������С���,by��ϵ.�ص���ϵ(��ҪԤ���ֶ��ų�)
        /// </summary>
        /// <param name="contentSize1">���ݴ�С1</param>
        /// <param name="contentSize2">���ݴ�С2</param>
        /// <param name="relation">�������ݹ�ϵ</param>
        /// <returns>�´�С</returns>
        public static Size AddAlignedRegion(Size contentSize1, Size contentSize2, TextImageRelation relation)
        {
            return AddAlignedRegionCore(contentSize1, contentSize2, IsVerticalRelation(relation));
        }
        /// <summary>
        /// ������С���,by�Ƿ����¹�ϵ.�ص���ϵ(��ҪԤ���ֶ��ų�)
        /// </summary>
        /// <param name="contentSize1">���ݴ�С1</param>
        /// <param name="contentSize2">���ݴ�С2</param>
        /// <param name="vertical">�Ƿ񴵹�ϵ</param>
        /// <returns>�´�С</returns>
        public static Size AddAlignedRegionCore(Size contentSize1, Size contentSize2, bool vertical)
        {
            if (vertical)
            {
                contentSize1.Width = Math.Max(contentSize1.Width, contentSize2.Width);
                contentSize1.Height += contentSize2.Height;
            }
            else
            {
                contentSize1.Width += contentSize2.Width;
                contentSize1.Height = Math.Max(contentSize1.Height, contentSize2.Height);
            }
            return contentSize1;
        }


        /// <summary>
        /// ��ȡ�����ص���Size����С�����Ĵ�С
        /// </summary>
        /// <param name="a">��С1</param>
        /// <param name="b">��С2</param>
        /// <returns>������С</returns>
        public static Size UnionSizes(Size a, Size b)
        {
            return new Size(Math.Max(a.Width, b.Width), Math.Max(a.Height, b.Height));
        }
        /// <summary>
        /// ��ê����ʽ�ָ����
        /// </summary>
        /// <param name="bounds">Ҫ���ָ�ľ���</param>
        /// <param name="contentSize">���ݴ�С</param>
        /// <param name="anchor">ê����ʽ</param>
        /// <param name="region1">��һ������</param>
        /// <param name="region2">�ڶ�������</param>
        public static void SplitRegion(Rectangle bounds, Size contentSize, AnchorStyles anchor, out Rectangle region1, out Rectangle region2)
        {
            region1 = region2 = bounds;
            switch (anchor)
            {
                case AnchorStyles.Top:
                    region1.Height = contentSize.Height;
                    region2.Y += contentSize.Height;
                    region2.Height -= contentSize.Height;
                    return;

                case AnchorStyles.Bottom:
                    region1.Y += bounds.Height - contentSize.Height;
                    region1.Height = contentSize.Height;
                    region2.Height -= contentSize.Height;
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    region1.Width = contentSize.Width;
                    region2.X += contentSize.Width;
                    region2.Width -= contentSize.Width;
                    return;

                case AnchorStyles.Right:
                    region1.X += bounds.Width - contentSize.Width;
                    region1.Width = contentSize.Width;
                    region2.Width -= contentSize.Width;
                    return;

                default:
                    return;
            }
        }


        /// <summary>
        /// ��region2��anchorê����bounds,��region1����ת��anchorê����bounds
        /// </summary>
        /// <param name="bounds">��������</param>
        /// <param name="anchor">ê����ʽ</param>
        /// <param name="region1">����1</param>
        /// <param name="region2">����2</param>
        public static void ExpandRegionsToFillBounds(Rectangle bounds, AnchorStyles anchor, ref Rectangle region1, ref Rectangle region2)
        {
            switch (anchor)
            {
                case AnchorStyles.Top:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Bottom);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Top);
                    return;

                case AnchorStyles.Bottom:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Top);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Bottom);
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Right);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Left);
                    return;

                case AnchorStyles.Right:
                    region1 = SubstituteSpecifiedBounds(bounds, region1, AnchorStyles.Left);
                    region2 = SubstituteSpecifiedBounds(bounds, region2, AnchorStyles.Right);
                    return;

                default:
                    return;
            }
        }
        /// <summary>
        /// ê�����ݾ��ε���������
        /// </summary>
        /// <param name="containerBounds">��������</param>
        /// <param name="contentBounds">���ݾ���</param>
        /// <param name="anchor">ê����ʽ</param>
        /// <returns>�¾���</returns>
        private static Rectangle SubstituteSpecifiedBounds(Rectangle containerBounds, Rectangle contentBounds, AnchorStyles anchor)
        {
            int left = ((anchor & AnchorStyles.Left) != AnchorStyles.None) ? contentBounds.Left : containerBounds.Left;
            int top = ((anchor & AnchorStyles.Top) != AnchorStyles.None) ? contentBounds.Top : containerBounds.Top;
            int right = ((anchor & AnchorStyles.Right) != AnchorStyles.None) ? contentBounds.Right : containerBounds.Right;
            int bottom = ((anchor & AnchorStyles.Bottom) != AnchorStyles.None) ? contentBounds.Bottom : containerBounds.Bottom;
            return Rectangle.FromLTRB(left, top, right, bottom);
        }
    }
}
