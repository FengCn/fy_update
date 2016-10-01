using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms.Layout
{
    /// <summary>
    /// ���ֲ�����
    /// </summary>
    public static class LayoutOptions
    {
        private static TextImageRelation[] m_ImageAlignToRelation;//ͼƬ���뷽ʽת��Ϊ�ı�ͼƬ���λ����������
        private static ContentAlignment[][] m_RtlTranslateAlignment;//���ҷ�ת��ʽ������뷽ʽ��������

        /// <summary>
        /// ��̬����,��ʼ���ֶ�
        /// </summary>
        static LayoutOptions()
        {
            TextImageRelation[] relationArray = new TextImageRelation[11];
            relationArray[0] = TextImageRelation.ImageBeforeText | TextImageRelation.ImageAboveText;
            relationArray[1] = TextImageRelation.ImageAboveText;
            relationArray[2] = TextImageRelation.TextBeforeImage | TextImageRelation.ImageAboveText;
            relationArray[4] = TextImageRelation.ImageBeforeText;
            relationArray[6] = TextImageRelation.TextBeforeImage;
            relationArray[8] = TextImageRelation.ImageBeforeText | TextImageRelation.TextAboveImage;
            relationArray[9] = TextImageRelation.TextAboveImage;
            relationArray[10] = TextImageRelation.TextBeforeImage | TextImageRelation.TextAboveImage;
            m_ImageAlignToRelation = relationArray;

            m_RtlTranslateAlignment = new ContentAlignment[][] 
            { 
                new ContentAlignment[] { ContentAlignment.TopLeft, ContentAlignment.TopRight },
                new ContentAlignment[] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight },
                new ContentAlignment[] { ContentAlignment.BottomLeft, ContentAlignment.BottomRight } 
            };
        }


        /// <summary>
        /// Rtl����Align
        /// </summary>
        /// <param name="align">Ҫ������Ķ��뷽ʽ</param>
        /// <param name="rtl">���ҷ�ת��ʽ</param>
        /// <returns>�����Ķ��뷽ʽ</returns>
        public static ContentAlignment RtlTranslateAlignment(ContentAlignment align, RightToLeft rtl)
        {
            if (rtl == RightToLeft.Yes)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (m_RtlTranslateAlignment[i][0] == align)
                        return m_RtlTranslateAlignment[i][1];

                    if (m_RtlTranslateAlignment[i][1] == align)
                        return m_RtlTranslateAlignment[i][0];
                }
            }
            return align;
        }
        /// <summary>
        /// Rtl����Relation
        /// </summary>
        /// <param name="relation">�ı�ͼƬ���λ��</param>
        /// <param name="rtl">���ҷ�ת��ʽ</param>
        /// <returns>�������ı�ͼƬ���λ��</returns>
        public static TextImageRelation RtlTranslateRelation(TextImageRelation relation, RightToLeft rtl)
        {
            if (rtl == RightToLeft.Yes)
            {
                if (relation == TextImageRelation.ImageBeforeText)
                    return TextImageRelation.TextBeforeImage;

                if (relation == TextImageRelation.TextBeforeImage)
                    return TextImageRelation.ImageBeforeText;
            }
            return relation;
        }


        /// <summary>
        /// ͼƬ���뷽ʽת��Ϊ�ı�ͼƬ���λ��
        /// </summary>
        /// <param name="align">ͼƬ���뷽ʽ</param>
        /// <returns>�ı�ͼƬ���λ��</returns>
        public static TextImageRelation ImageAlignToRelation(ContentAlignment align)
        {
            return m_ImageAlignToRelation[LayoutUtils.ContentAlignmentToIndex(align)];
        }
        /// <summary>
        /// �ı����뷽ʽת��Ϊ�ı�ͼƬ���λ��
        /// </summary>
        /// <param name="align">�ı����뷽ʽ</param>
        /// <returns>�ı�ͼƬ���λ��</returns>
        public static TextImageRelation TextAlignToRelation(ContentAlignment align)
        {
            return LayoutUtils.GetOppositeTextImageRelation(ImageAlignToRelation(align));
        }


        /// <summary>
        /// ��ȡ���Ƹ�ʽ
        /// </summary>
        /// <param name="align">���뷽ʽ</param>
        /// <param name="rtl">���ҷ�ת</param>
        /// <returns>���Ƹ�ʽ</returns>
        public static StringFormat GetStringFormat(ContentAlignment align, RightToLeft rtl)
        {
            StringFormat format = DefaultTheme.StringFormat;
            switch (align)
            {
                case ContentAlignment.TopLeft:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleLeft:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleCenter:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomCenter:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Far;
                    break;
                default:
                    break;
            }
            if (rtl == RightToLeft.Yes)
                format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            format.HotkeyPrefix = HotkeyPrefix.Show;
            return format;
        }
        /// <summary>
        /// ��ȡ���Ƹ�ʽ
        /// </summary>
        /// <param name="align">���뷽ʽ</param>
        /// <param name="rtl">���ҷ�ת</param>
        /// <returns>���Ƹ�ʽ</returns>
        public static TextFormatFlags GetTextFormatFlags(ContentAlignment align, RightToLeft rtl)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            switch (align)
            {
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                default:
                    break;
            }
            if (rtl == RightToLeft.Yes)
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            return flags;
        }
        /// <summary>
        /// �����ı���С
        /// </summary>
        /// <param name="layout">���ֶ���</param>
        /// <param name="proposedSize">���ṩ�Ĵ�С</param>
        /// <returns>�ı���С</returns>
        public static Size GetTextSize(LayoutData layout, Size proposedSize)
        {
            return Size.Ceiling(layout.Graphics.MeasureString(layout.Text, layout.Font, new SizeF((float)proposedSize.Width, (float)proposedSize.Height), layout.CurrentStringFormat));
        }


        /// <summary>
        /// �����ı���ͼƬ,ÿ����һ��,ִ��һ�β��ֲ���
        /// </summary>
        /// <param name="layout">���ֶ���</param>
        public static void LayoutTextAndImage(LayoutData layout)
        {
            if (((layout.ImageSize == Size.Empty) || (layout.Text == null)) || ((layout.Text.Length == 0) || (layout.CurrentTextImageRelation == TextImageRelation.Overlay)))
            {
                Size imageSize = layout.ImageSize;
                Size textSize = GetTextSize(layout, layout.CurrentClientRectangle.Size);

                layout.OutImageBounds = LayoutUtils.Align(imageSize, layout.CurrentClientRectangle, layout.CurrentImageAlign);
                layout.OutTextBounds = LayoutUtils.Align(textSize, layout.CurrentClientRectangle, layout.CurrentTextAlign);
            }
            else
            {
                Size proposedSize = LayoutUtils.SubAlignedRegion(layout.CurrentClientRectangle.Size, layout.ImageSize, layout.CurrentTextImageRelation);//��ȥͼƬ�ռ��Ĵ�С
                Size textSize = GetTextSize(layout, proposedSize);//�ı���С
                Size textImageSize = LayoutUtils.AddAlignedRegion(textSize, layout.ImageSize, layout.CurrentTextImageRelation);//������С���
                Rectangle containerRect = layout.CurrentClientRectangle;//�ܰ���layout.CurrentClientRectangle,textImageSize����С����
                containerRect.Size = LayoutUtils.UnionSizes(layout.CurrentClientRectangle.Size, textImageSize);//��ȡ����Size�е����ֵ(�ֱ�����͸�)
                Rectangle textImageRect = LayoutUtils.Align(textImageSize, containerRect, ContentAlignment.MiddleCenter);//����
                bool imageNoOverlay = (ImageAlignToRelation(layout.CurrentImageAlign) & layout.CurrentTextImageRelation) != TextImageRelation.Overlay;
                bool textNoOverlay = (TextAlignToRelation(layout.CurrentTextAlign) & layout.CurrentTextImageRelation) != TextImageRelation.Overlay;
                Rectangle imageBounds;
                Rectangle textBounds;
                if (imageNoOverlay)
                {
                    LayoutUtils.SplitRegion(containerRect, layout.ImageSize, (AnchorStyles)layout.CurrentTextImageRelation, out imageBounds, out textBounds);
                }
                else if (textNoOverlay)
                {
                    LayoutUtils.SplitRegion(containerRect, textSize, (AnchorStyles)LayoutUtils.GetOppositeTextImageRelation(layout.CurrentTextImageRelation), out textBounds, out imageBounds);
                }
                else
                {
                    LayoutUtils.SplitRegion(textImageRect, layout.ImageSize, (AnchorStyles)layout.CurrentTextImageRelation, out imageBounds, out textBounds);
                    LayoutUtils.ExpandRegionsToFillBounds(containerRect, (AnchorStyles)layout.CurrentTextImageRelation, ref imageBounds, ref textBounds);//��չ
                }
                layout.OutImageBounds = LayoutUtils.Align(layout.ImageSize, imageBounds, layout.CurrentImageAlign);
                layout.OutTextBounds = LayoutUtils.Align(textSize, textBounds, layout.CurrentTextAlign);
            }

            //����
            switch (layout.CurrentTextImageRelation)
            {
                case TextImageRelation.TextBeforeImage:
                case TextImageRelation.ImageBeforeText:
                    {
                        int num = Math.Min(layout.OutTextBounds.Bottom, layout.CurrentClientRectangle.Bottom);
                        layout.OutTextBounds.Y = Math.Max(Math.Min(layout.OutTextBounds.Y, layout.CurrentClientRectangle.Y + ((layout.CurrentClientRectangle.Height - layout.OutTextBounds.Height) / 2)), layout.CurrentClientRectangle.Y);
                        layout.OutTextBounds.Height = num - layout.OutTextBounds.Y;
                        break;
                    }

                case TextImageRelation.TextAboveImage:
                case TextImageRelation.ImageAboveText:
                    {
                        int num2 = Math.Min(layout.OutTextBounds.Right, layout.CurrentClientRectangle.Right);
                        layout.OutTextBounds.X = Math.Max(Math.Min(layout.OutTextBounds.X, layout.CurrentClientRectangle.X + ((layout.CurrentClientRectangle.Width - layout.OutTextBounds.Width) / 2)), layout.CurrentClientRectangle.X);
                        layout.OutTextBounds.Width = num2 - layout.OutTextBounds.X;
                        break;
                    }

                default:
                    break;
            }
            if ((layout.CurrentTextImageRelation == TextImageRelation.ImageBeforeText) && (layout.OutImageBounds.Size.Width != 0))
            {
                layout.OutImageBounds.Width = Math.Max(0, Math.Min(layout.CurrentClientRectangle.Width - layout.OutTextBounds.Width, layout.OutImageBounds.Width));
                layout.OutTextBounds.X = layout.OutImageBounds.X + layout.OutImageBounds.Width;
            }
            if ((layout.CurrentTextImageRelation == TextImageRelation.ImageAboveText) && (layout.OutImageBounds.Size.Height != 0))
            {
                layout.OutImageBounds.Height = Math.Max(0, Math.Min(layout.CurrentClientRectangle.Height - layout.OutTextBounds.Height, layout.OutImageBounds.Height));
                layout.OutTextBounds.Y = layout.OutImageBounds.Y + layout.OutImageBounds.Height;
            }
            layout.OutTextBounds = Rectangle.Intersect(layout.OutTextBounds, layout.CurrentClientRectangle);
            //
            int num3 = Math.Min(layout.OutTextBounds.Bottom, layout.CurrentClientRectangle.Bottom);
            layout.OutTextBounds.Y = Math.Max(layout.OutTextBounds.Y, layout.CurrentClientRectangle.Y);
            layout.OutTextBounds.Height = num3 - layout.OutTextBounds.Y;

            //ƫ��
            layout.OutImageBounds.Offset(layout.ImageOffset);
            layout.OutTextBounds.Offset(layout.TextOffset);
        }
    }
}
