using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Layout;

namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        //��Ⱦʱ���ݽ�������ʱ����
        private Rectangle m_BackColorRect;
        private Rectangle m_BackgroundImageRect;
        private Rectangle m_BackgroundImage9Rect;
        private Rectangle m_TextImageRect;
        private Rectangle m_StringRect;
        private Rectangle m_BorderColorRect;

        //��Ⱦ�ı����ķ���
        private void RenderTextCore(LayoutData layout)
        {
            layout.DoLayout();//ִ�в���
            this.CurrentTextPreferredRect = layout.OutTextBounds;//�����ı��������
            bool needRotate = !(Single.IsNaN(this.m_TextRotateAngle) || this.m_TextRotateAngle % 360f == 0f);//�Ƿ���Ҫ��ת
            Rectangle textRect = needRotate ? RenderEngine.RotateRect(this.m_Graphics, this.CurrentTextPreferredRect, this.m_TextRotateAngle, false) : this.CurrentTextPreferredRect; //�»�ͼ����(�����ת��Ϊ��ת�������)

            //������Ӱ�����
            if (this.m_TextShadowShapeStyle != 0)
            {
                using (new SmoothingModeGraphics(this.m_Graphics, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath textPath = new GraphicsPath())
                    {
                        //����ı�
                        textPath.AddString(this.m_Text, this.m_Font.FontFamily, (int)this.m_Font.Style, this.m_Graphics.DpiY * this.m_Font.SizeInPoints / 72f, textRect, layout.CurrentStringFormat);

                        //������Ӱ����Ӱ���
                        if (((this.m_TextShadowShapeStyle & ShadowShapeStyle.Shadow) != 0) || ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfShadow) != 0 && this.m_TextShapeOfShadowWidth > 0f))
                        {
                            using (GraphicsPath shadowPath = textPath.Clone() as GraphicsPath)
                            {
                                using (Matrix shadowMatrix = new Matrix(1, 0, 0, 1, this.m_TextShadowMatrixOffset.X, this.m_TextShadowMatrixOffset.Y))
                                {
                                    shadowPath.Transform(shadowMatrix);
                                }

                                //������Ӱ
                                if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.Shadow) != 0)
                                {
                                    using (Brush shadowBrush = new SolidBrush(this.m_TextShadowColor))
                                    {
                                        this.m_Graphics.FillPath(shadowBrush, shadowPath);
                                    }
                                }
                                //��Ӱ���
                                if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfShadow) != 0 && this.m_TextShapeOfShadowWidth > 0f)
                                {
                                    using (Pen shapeOfShadowPen = new Pen(this.m_TextShapeOfShadowColor, this.m_TextShapeOfShadowWidth))
                                    {
                                        this.m_Graphics.DrawPath(shapeOfShadowPen, shadowPath);
                                    }
                                }
                            }
                        }

                        //�����ı�
                        using (Brush textBrush = new SolidBrush(this.CurrentForeColor))
                        {
                            this.m_Graphics.FillPath(textBrush, textPath);
                        }

                        //�ı����
                        if ((this.m_TextShadowShapeStyle & ShadowShapeStyle.ShapeOfText) != 0 && this.m_TextShapeOfTextWidth > 0f)
                        {
                            using (Pen shapeOfTextPen = new Pen(this.m_TextShapeOfTextColor, this.m_TextShapeOfTextWidth))
                            {
                                this.m_Graphics.DrawPath(shapeOfTextPen, textPath);
                            }
                        }
                    }
                }
            }
            else
            {
                using (new TextRenderingHintGraphics(this.m_Graphics, this.m_TextRenderingHint))
                {
                    using (Brush textBrush = new SolidBrush(this.CurrentForeColor))
                    {
                        this.m_Graphics.DrawString(this.m_Text, this.m_Font, textBrush, textRect, layout.CurrentStringFormat);
                    }
                }
            }

            //�ָ���ת
            if (needRotate)
                this.m_Graphics.ResetTransform();
        }
        //��ȾͼƬ���ķ���
        private void RenderImageCore(LayoutData layout)
        {
            layout.DoLayout();//ִ�в���
            this.CurrentImagePreferredRect = layout.OutImageBounds;//����ͼƬ�������
            bool needRotate = !(float.IsNaN(this.m_ImageRotateAngle) || this.m_ImageRotateAngle % 360f == 0f);//�Ƿ���Ҫ��ת
            Rectangle imageBounds = needRotate ? RenderEngine.RotateRect(this.m_Graphics, this.CurrentImagePreferredRect, this.m_ImageRotateAngle, false) : this.CurrentImagePreferredRect;//�»�ͼ����(�����ת��Ϊ��ת�������)

            //��ʼ����
            if (this.m_State == State.Disabled && this.m_ImageGrayOnDisabled)
            {
                using (Image grayImg = RenderEngine.GetGrayImage(this.CurrentImage))
                {
                    this.m_Graphics.DrawImage(grayImg, imageBounds);
                }
            }
            else
            {
                this.m_Graphics.DrawImage(this.CurrentImage, imageBounds);
            }

            //�ָ���ת
            if (needRotate)
                this.m_Graphics.ResetTransform();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="rect">����λ�úʹ�С</param>
        /// <returns>����</returns>
        public Region CreateRegion(Rectangle rect)
        {
            if (this.m_RoundStyle == RoundStyle.None)//ֱ��
            {
                if ((this.m_RoundCornerStyle & CornerStyle.Horizontal) != 0)
                    rect.Inflate(2, 0);
                else if ((this.m_RoundCornerStyle & CornerStyle.Vertical) != 0)
                    rect.Inflate(0, 2);
                else
                    return null;
            }
            else//��Բ��
            {
                if ((this.m_RoundCornerStyle & CornerStyle.Horizontal) != 0)
                    rect.Inflate(5, 1);
                else if ((this.m_RoundCornerStyle & CornerStyle.Vertical) != 0)
                    rect.Inflate(1, 5);
                else
                    return null;
            }

            using (GraphicsPath path = RenderEngine.CreateGraphicsPath(rect, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false))
            {
                return new Region(path);
            }
        }

        /// <summary>
        /// ��Ⱦ����ɫ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderBackColor(Rectangle rect)
        {
            this.m_BackColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            using (Brush brush = RenderEngine.CreateBrush(this.CurrentBackColorBrushRect, this.CurrentBackColor, this.m_BackColorPos1, this.m_BackColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BackColorBlendStyle))
            {
                if (float.IsNaN(this.m_RoundRadius) || this.m_RoundRadius <= 0f)
                    this.m_Graphics.FillRectangle(brush, this.CurrentBackColorPathRect);
                else
                    this.m_Graphics.FillPath(brush, this.CurrentBackColorPath);
            }
        }
        /// <summary>
        /// ��Ⱦ����ɫ��Ч
        /// </summary>
        public void RenderBackColorAero()
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            //����ģ��Ч��
            if ((this.m_BackColorAeroStyle & AeroStyle.Blur) != 0)
            {
                Rectangle blurRect = this.CurrentBackColorPathRect;
                int blurWidth = 0;
                int blurHeight = 0;
                switch (this.m_BackColorAlign)
                {
                    case TabAlignment.Top:
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Height = blurHeight;
                        break;

                    case TabAlignment.Bottom:
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Y = blurRect.Bottom - blurHeight;
                        blurRect.Height = blurHeight;
                        break;

                    case TabAlignment.Left:
                        blurWidth = (int)(this.CurrentBackColorPathRect.Width * this.m_BackColorAeroPos);
                        blurRect.Width = blurWidth;
                        break;

                    case TabAlignment.Right:
                        blurWidth = (int)(this.CurrentBackColorPathRect.Width * this.m_BackColorAeroPos);
                        blurRect.X = blurRect.Right - blurWidth;
                        blurRect.Width = blurWidth;
                        break;

                    default://ͬTop
                        blurHeight = (int)(this.CurrentBackColorPathRect.Height * this.m_BackColorAeroPos);
                        blurRect.Height = blurHeight;
                        break;
                }

                //����
                RenderEngine.DrawAeroBlur(this.m_Graphics, blurRect, this.m_BackColorAeroBlurColor);
            }

            //���Ʋ���Ч��
            if ((this.m_BackColorAeroStyle & AeroStyle.Glass) != 0)
            {
                Rectangle glassRect = this.CurrentBackColorPathRect;
                int blurWidth = 0;
                int blurHeight = 0;
                switch (this.m_BackColorAlign)
                {
                    case TabAlignment.Top:
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y += blurHeight;//�ײ�
                        glassRect.Height = (glassRect.Height - blurHeight) * 2;//Բ��һ��
                        break;

                    case TabAlignment.Bottom:
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y -= (glassRect.Height - blurHeight);//����
                        glassRect.Height = (this.CurrentBackColorPathRect.Height - blurHeight) * 2;//Բ��һ��
                        break;


                    case TabAlignment.Left:
                        blurWidth = (int)(glassRect.Width * this.BackColorAeroPos);
                        glassRect.X += blurWidth;//�Ҳ�
                        glassRect.Width = (glassRect.Width - blurWidth) * 2;//Բ��һ��
                        break;


                    case TabAlignment.Right:
                        blurWidth = (int)(glassRect.Width * this.BackColorAeroPos);
                        glassRect.X -= (glassRect.Width - blurWidth);//���
                        glassRect.Width = (glassRect.Width - blurWidth) * 2;//Բ��һ��
                        break;

                    default://ͬTop
                        blurHeight = (int)(glassRect.Height * this.BackColorAeroPos);
                        glassRect.Y += blurHeight;//�ײ�
                        glassRect.Height = (glassRect.Height - blurHeight) * 2;//Բ��һ��
                        break;
                }

                //����
                RenderEngine.DrawAeroGlass(this.m_Graphics, glassRect, this.BackColorAeroGlassCenterColor, this.BackColorAeroGlassSurroundColor);
            }
        }
        /// <summary>
        /// ��Ⱦ����ͼ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderBackgroundImage(Rectangle rect)
        {
            this.m_BackgroundImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackgroundImageRect) || this.CurrentBackgroundImage == null)
                return;

            if (this.m_State == State.Disabled && this.m_BackgroundImageGrayOnDisabled)//��ɫͼƬ
            {
                using (Image img = RenderEngine.GetGrayImage(this.CurrentBackgroundImage))
                {
                    RenderEngine.DrawBackgroundImage(this.m_Graphics, img, this.CurrentBackgroundImageRect, this.m_BackgroundImageLayout);
                }
            }
            else//ԭͼ
            {
                RenderEngine.DrawBackgroundImage(this.m_Graphics, this.CurrentBackgroundImage, this.CurrentBackgroundImageRect, this.m_BackgroundImageLayout);
            }
        }
        /// <summary>
        /// ��Ⱦ�Ź��񱳾�ͼ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderBackgroundImage9(Rectangle rect)
        {
            this.m_BackgroundImage9Rect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackgroundImage9Rect) || this.CurrentBackgroundImage9 == null)
                return;

            if (this.m_State == State.Disabled && this.m_BackgroundImage9GrayOnDisabled)//��ɫͼƬ
            {
                using (Image img = RenderEngine.GetGrayImage(this.CurrentBackgroundImage9))
                {
                    RenderEngine.DrawBackgroundImage9(this.m_Graphics, img, this.CurrentBackgroundImage9Rect, this.m_BackgroundImage9Padding.Left, this.m_BackgroundImage9Padding.Top, this.m_BackgroundImage9Padding.Right, this.m_BackgroundImage9Padding.Bottom, this.m_BackgroundImage9Layout);
                }
            }
            else//ԭͼ
            {
                RenderEngine.DrawBackgroundImage9(this.m_Graphics, this.CurrentBackgroundImage9, this.CurrentBackgroundImage9Rect, this.m_BackgroundImage9Padding.Left, this.m_BackgroundImage9Padding.Top, this.m_BackgroundImage9Padding.Right, this.m_BackgroundImage9Padding.Bottom, this.m_BackgroundImage9Layout);
            }
        }
        /// <summary>
        /// ��Ⱦ�ı���ͼƬ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderTextAndImage(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || ((this.m_Text == null || this.m_Text.Length <= 0) && this.m_Image == null))
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.ImageSize = (this.CurrentImage == null ? Size.Empty : this.m_ImageSize);
                layout.ImageAlign = this.m_ImageAlign;
                layout.ImageOffset = this.m_ImageOffset;

                layout.Text = this.m_Text;
                layout.Font = this.m_Font;
                layout.TextAlign = this.m_TextAlign;
                layout.TextOffset = this.m_TextOffset;

                if (this.CurrentImage != null)
                    this.RenderImageCore(layout);

                if (this.Text != null && this.Text.Length > 0)
                    this.RenderTextCore(layout);
            }
        }
        /// <summary>
        /// ��Ⱦ�ı�
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderText(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || this.Text == null || this.Text.Length <= 0)
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.Text = this.m_Text;
                layout.Font = this.m_Font;
                layout.TextAlign = this.m_TextAlign;
                layout.TextOffset = this.m_TextOffset;

                this.RenderTextCore(layout);
            }
        }
        /// <summary>
        /// ��ȾͼƬ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderImage(Rectangle rect)
        {
            this.m_TextImageRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_TextImageRect) || this.CurrentImage == null)
                return;

            using (LayoutData layout = new LayoutData())
            {
                layout.Graphics = this.m_Graphics;

                layout.ClientRectangle = this.CurrentTextImageClientRect;
                layout.Padding = this.m_Padding;
                layout.TextImageRelation = this.m_TextImageRelation;
                layout.RightToLeft = this.m_RightToLeft;

                layout.ImageSize = (this.CurrentImage == null ? Size.Empty : this.m_ImageSize);
                layout.ImageAlign = this.m_ImageAlign;
                layout.ImageOffset = this.m_ImageOffset;

                this.RenderImageCore(layout);
            }
        }
        /// <summary>
        /// ׼����Ⱦ�ַ���·��,�����ַ���·���Ĵ�С(�����ַ���·����С,����������)
        /// </summary>
        /// <returns>�ַ���·����С</returns>
        public Size BeginRenderString()
        {
            if (this.m_State == State.Hidden || this.Text == null || this.Text.Length <= 0)
                return Size.Empty;

            Size strSize;
            this.m_CurrentStringPathRect = RenderEngine.BeginDrawString(this.m_Graphics, this.Text, this.Font, out strSize);
            this.m_CurrentStringSize = strSize;
            return this.CurrentStringPathRect.Size;
        }
        /// <summary>
        /// ׼����Ⱦ�ַ���·��,�����ַ���·���Ĵ�С(�����ַ���·����С,����������)
        /// </summary>
        /// <param name="rect">����ʱ,��������.����������޹�</param>
        /// <returns>�ַ���·����С</returns>
        public Size BeginRenderString(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect) || this.Text == null || this.Text.Length <= 0)
                return Size.Empty;

            Size strSize;
            this.m_CurrentStringPathRect = RenderEngine.BeginDrawString(this.m_Graphics, this.Text, this.Font, rect, out strSize);
            this.m_CurrentStringSize = strSize;
            return this.CurrentStringPathRect.Size;
        }
        /// <summary>
        /// ��ʽ��Ⱦ�ַ���·��
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void EndRenderString(Rectangle rect)
        {
            this.m_StringRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_StringRect) || this.Text == null || this.Text.Length <= 0)
                return;

            using (Brush brush = new SolidBrush(this.CurrentForeColor))
            {
                RenderEngine.EndDrawString(this.m_Graphics, this.m_Text, this.m_Font, brush, this.CurrentStringRect, this.m_TextAlign, this.CurrentStringPathRect, this.CurrentStringSize);
            }
        }
        /// <summary>
        /// ��Ⱦ�ַ���·��
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderString(Rectangle rect)
        {
            this.BeginRenderString(rect);
            this.EndRenderString(rect);
        }
        /// <summary>
        /// ��Ⱦ�߿���ɫ(RoundStyleԲ����ʽ,BorderStyleȷ�������ĸ���,BlendStyle��Ϸ�ʽ)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderBorder(Rectangle rect)
        {
            this.m_BorderColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BorderColorRect))
                return;

            //���ü�����
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);

            //�����ڱ߿�
            if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentInnerBorderBrushRect, this.CurrentInnerBorderColor, this.m_InnerBorderColorPos1, this.m_InnerBorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_InnerBorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_InnerBorderDashStyle, this.m_InnerBorderDashPattern, this.m_InnerBorderDashCap, this.m_InnerBorderDashOffset))
                    {
                        RenderEngine.DrawBorder(this.m_Graphics, pen, this.CurrentInnerBorderPathRect, this.m_InnerBorderVisibleStyle, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false);
                    }
                }
            }

            //���Ʊ߿�
            if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentBorderBrushRect, this.CurrentBorderColor, this.m_BorderColorPos1, this.m_BorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_BorderDashStyle, this.m_BorderDashPattern, this.m_BorderDashCap, this.m_BorderDashOffset))
                    {
                        RenderEngine.DrawBorder(this.m_Graphics, pen, this.CurrentBorderPathRect, this.m_BorderVisibleStyle, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false);
                    }
                }
            }
        }
        /// <summary>
        /// ��Ⱦ�߶�
        /// </summary>
        /// <param name="pt1">���</param>
        /// <param name="pt2">�յ�</param>
        public void RenderLine(Point pt1, Point pt2)
        {
            if (this.m_State == State.Hidden || pt1 == pt2)
                return;

            //ʹ�ñ߿���ɫ
            using (Brush brush = RenderEngine.CreateBrush(pt1, pt2, this.CurrentLineColor, this.m_LineBlendStyle))
            {
                using (Pen pen = RenderEngine.CreatePen(brush, this.m_LineWidth, this.m_LineDashStyle, this.m_LineDashPattern, this.m_LineDashCap, this.m_LineDashOffset))
                {
                    this.m_Graphics.DrawLine(pen, pt1, pt2);
                }
            }
        }

        /// <summary>
        /// ��Ⱦ�Ժ�(��������Ⱦ)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderCheck(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawCheck(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// ��Ⱦ���(��������Ⱦ)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderCross(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawCross(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// ��Ⱦʡ�Ժ�(��������Ⱦ)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderEllipsis(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawEllipsis(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor);
        }
        /// <summary>
        /// ��Ⱦ��ͷ(��������Ⱦ)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        /// <param name="direction">��ͷ����</param>
        public void RenderArrow(Rectangle rect, ArrowDirection direction)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawArrow(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor, direction);
        }
        /// <summary>
        /// ��Ⱦ��ͷ(�̶���С)
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        /// <param name="direction">��ͷ����</param>
        /// <param name="style">��С��ʽ</param>
        public void RenderArrow(Rectangle rect, ArrowDirection direction, SizeStyle style)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            this.CurrentTextPreferredRect = rect;
            RenderEngine.DrawArrow(this.m_Graphics, this.CurrentTextPreferredRect, this.CurrentForeColor, direction, style);
        }
        /// <summary>
        /// ��ȾMetrol���±߿�
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderMetroPress(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            //���
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 2;
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 1;
                rect.Width -= 1;
            }

            //�ϱ�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 2;
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 1;
                rect.Height -= 1;
            }

            //�ұ�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 1;
            }

            //�±�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 1;
            }

            //���ü�����
            this.m_Graphics.SetClip(rect);

            //���ƿ�߿�
            using (GraphicsPath pathBorder = RenderEngine.CreateGraphicsPath(rect),
                pathBorderIn = RenderEngine.CreateGraphicsPath(Rectangle.Inflate(rect, -3, -3)))
            {
                //�߿�����
                pathBorder.AddPath(pathBorderIn, true);

                //����
                using (Brush brush = new SolidBrush(this.CurrentBorderColor))
                {
                    this.m_Graphics.FillPath(brush, pathBorder);
                }
            }
        }
        /// <summary>
        /// ����Metrolѡ�б߿�
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        public void RenderMetroCheck(Rectangle rect)
        {
            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(rect))
                return;

            //���
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 2;
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
            {
                rect.X += 1;
                rect.Width -= 1;
            }

            //�ϱ�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 2;
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
            {
                rect.Y += 1;
                rect.Height -= 1;
            }

            //�ұ�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
            {
                rect.Width -= 1;
            }

            //�±�
            if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 2;
            }
            else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
            {
                rect.Height -= 1;
            }

            //���ü�����
            this.m_Graphics.SetClip(rect);

            //���ƿ�߿�
            using (GraphicsPath pathBorder = RenderEngine.CreateGraphicsPath(rect),
                pathBorderIn = RenderEngine.CreateGraphicsPath(Rectangle.Inflate(rect, -3, -3)),
                pathTriangle = new GraphicsPath())
            {
                //�߿�����
                pathBorder.AddPath(pathBorderIn, true);

                //���Ͻ���������
                Point[] points = new Point[] {
                    new Point(rect.X + rect.Width - 40, rect.Y),
                    new Point(rect.X + rect.Width, rect.Y),
                    new Point(rect.X + rect.Width, rect.Y + 40) 
                };
                pathTriangle.AddPolygon(points);

                //����
                using (Brush brush = new SolidBrush(this.CurrentBackColor))
                {
                    this.m_Graphics.FillPath(brush, pathBorder);
                    this.m_Graphics.FillPath(brush, pathTriangle);
                }
            }

            //���ƶԺ�
            RenderEngine.DrawCheck(this.m_Graphics, new Rectangle(rect.Right - 22, rect.Y + 2, 20, 20), this.CurrentForeColor);
        }
        /// <summary>
        /// ��Ⱦ��ǩ��ʽ����ؼ�����ɫ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        /// <param name="tabSize">���ϽǱ�ǩ��С</param>
        /// <param name="tabRound">��ǩ���Ͻ��Ƿ�Բ��</param>
        /// <param name="tabRadius">��ǩ���Ͻ�Բ�ǰ뾶</param>
        public void RenderBackColorGroupBoxTab(Rectangle rect, Size tabSize, bool tabRound, float tabRadius)
        {
            this.m_BackColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BackColorRect))
                return;

            using (Brush brush = RenderEngine.CreateBrush(this.CurrentBackColorBrushRect, this.CurrentBackColor, this.m_BackColorPos1, this.m_BackColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BackColorBlendStyle))
            {
                //У����������
                if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
                    tabSize.Width -= 4;
                else if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
                    tabSize.Width -= 2;
                using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentBackColorPathRect, this.m_RoundStyle, this.m_RoundRadius, tabSize, tabRound, tabRadius, false))
                {
                    this.m_Graphics.SetClip(path, CombineMode.Intersect);
                    this.m_Graphics.FillPath(brush, path);
                }
            }
        }
        /// <summary>
        /// ��Ⱦ��ǩ��ʽ����ؼ��߿�ɫ
        /// </summary>
        /// <param name="rect">��Ⱦ����</param>
        /// <param name="tabSize">���ϽǱ�ǩ��С</param>
        /// <param name="tabRound">��ǩ���Ͻ��Ƿ�Բ��</param>
        /// <param name="tabRadius">��ǩ���Ͻ�Բ�ǰ뾶</param>
        public void RenderBorderColorGroupBoxTab(Rectangle rect, Size tabSize, bool tabRound, float tabRadius)
        {
            this.m_BorderColorRect = rect;

            if (this.m_State == State.Hidden || !RectangleEx.IsVisible(this.m_BorderColorRect))
                return;

            //���ü�����
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);

            //�����ڱ߿�
            if (this.m_InnerBorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentInnerBorderBrushRect, this.CurrentInnerBorderColor, this.m_InnerBorderColorPos1, this.m_InnerBorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_InnerBorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_InnerBorderDashStyle, this.m_InnerBorderDashPattern, this.m_InnerBorderDashCap, this.m_InnerBorderDashOffset))
                    {
                        Size innerBorderTabSize = new Size(tabSize.Width - 3, tabSize.Height);
                        using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentInnerBorderPathRect, this.m_RoundStyle, this.m_RoundRadius, innerBorderTabSize, tabRound, tabRadius, false))
                        {
                            this.m_Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }

            //���Ʊ߿�
            if (this.m_BorderVisibleStyle != BorderVisibleStyle.None)
            {
                using (Brush brush = RenderEngine.CreateBrush(this.CurrentBorderBrushRect, this.CurrentBorderColor, this.m_BorderColorPos1, this.m_BorderColorPos2, this.CurrentBackColorReverse, this.CurrentBackColorMode, this.m_BorderBlendStyle))
                {
                    using (Pen pen = RenderEngine.CreatePen(brush, 1, this.m_BorderDashStyle, this.m_BorderDashPattern, this.m_BorderDashCap, this.m_BorderDashOffset))
                    {
                        Size borderTabSize = new Size(tabSize.Width - 1, tabSize.Height);
                        using (GraphicsPath path = RenderEngine.CreateGroupBoxTabGraphicsPath(this.CurrentBorderPathRect, this.m_RoundStyle, this.m_RoundRadius, borderTabSize, tabRound, tabRadius, false))
                        {
                            this.m_Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
        }
    }
}
