using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;
using Microsoft.Windows.Forms.Layout;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// Χ��rect�����Ľ�����ϵ˳ʱ����תdegrees�Ƕ�,����������ϵ����
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">Ҫ��ת�ľ���</param>
        /// <param name="degrees">�Ƕ�</param>
        /// <param name="fit">������ת,��ͼ������ת</param>
        /// <returns>������ϵ����</returns>
        public static Rectangle RotateRect(Graphics g, Rectangle rect, float degrees, bool fit)
        {
            g.RotateTransform(degrees, MatrixOrder.Append);//Χ������ԭ����ת
            g.TranslateTransform(rect.X + rect.Width / 2, rect.Y + rect.Height / 2, MatrixOrder.Append);//ƽ��ԭ��
            if (fit)
            {
                decimal decLessStraigntAngle = Math.Abs((decimal)degrees) % 180m;//ȡ����ֵ�����180������,С��ƽ�ǵĽǶ�
                return ((decLessStraigntAngle >= 0 && decLessStraigntAngle <= 45) || (decLessStraigntAngle >= 135 && decLessStraigntAngle <= 180))
                    ? new Rectangle(-rect.Width / 2, -rect.Height / 2, rect.Width, rect.Height)
                    : new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);//������ϵ����
            }
            else
            {
                return new Rectangle(-rect.Width / 2, -rect.Height / 2, rect.Width, rect.Height);
            }
        }


        /// <summary>
        /// ��ʼ�����ַ���(����������),������·��������ַ�����С.ע�ⲻҪ�޸ķ��صľ��κ��ַ�����С,��EndDrawString����Ҫ����.������EndDrawString�ɶԳ���.
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="s">�ַ���</param>
        /// <param name="font">����</param>
        /// <param name="strSize">�ַ�����С</param>
        /// <returns>�ַ���·������</returns>
        public static Rectangle BeginDrawString(Graphics g, string s, Font font, out Size strSize)
        {
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                strSize = Size.Ceiling(g.MeasureString(s, font, PointF.Empty, sf));
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(s, font.FontFamily, (int)font.Style, g.DpiY * font.SizeInPoints / 72f, Point.Empty, sf);
                    return Rectangle.Round(path.GetBounds());
                }
            }
        }

        /// <summary>
        /// ��ʼ�����ַ���(����������),������·��������ַ�����С.ע�ⲻҪ�޸ķ��صľ��κ��ַ�����С,��EndDrawString����Ҫ����.������EndDrawString�ɶԳ���.
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="s">�ַ���</param>
        /// <param name="font">����</param>
        /// <param name="layoutRectangle">���ƾ���</param>
        /// <param name="strSize">�ַ�����С</param>
        /// <returns>�ַ���·������</returns>
        public static Rectangle BeginDrawString(Graphics g, string s, Font font, Rectangle layoutRectangle, out Size strSize)
        {
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                strSize = Size.Ceiling(g.MeasureString(s, font, layoutRectangle.Size, sf));
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(s, font.FontFamily, (int)font.Style, g.DpiY * font.SizeInPoints / 72f, layoutRectangle, sf);
                    return Rectangle.Round(path.GetBounds());
                }
            }
        }

        /// <summary>
        /// ��ʽ�����ַ���.��BeginDrawString�ɶԳ���
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="s">�ַ���</param>
        /// <param name="font">����</param>
        /// <param name="brush">��ˢ</param>
        /// <param name="layoutRectangle">��������</param>
        /// <param name="align">���뷽ʽ</param>
        /// <param name="pathBounds">�ַ���·������,BeginDrawString(...)����ֵ</param>
        /// <param name="strSize">�ַ�����С,BeginDrawString(...)����ֵ</param>
        public static void EndDrawString(Graphics g, string s, Font font, Brush brush, Rectangle layoutRectangle, ContentAlignment align, Rectangle pathBounds, Size strSize)
        {
            layoutRectangle = LayoutUtils.Align(pathBounds.Size, layoutRectangle, align);
#if DEBUG
            g.DrawRectangle(SystemPens.ControlDarkDark, layoutRectangle);
#endif
            layoutRectangle.Offset(-pathBounds.X, -pathBounds.Y);
            layoutRectangle.Size = strSize;
            using (StringFormat sf = DefaultTheme.StringFormat)
            {
                g.DrawString(s, font, brush, layoutRectangle, sf);
            }
        }

        /// <summary>
        /// ��ȷ�����ַ���
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="s">�ַ���</param>
        /// <param name="font">����</param>
        /// <param name="brush">��ˢ</param>
        /// <param name="layoutRectangle">��������</param>
        /// <param name="align">���뷽ʽ</param>
        public static void DrawString(Graphics g, string s, Font font, Brush brush, Rectangle layoutRectangle, ContentAlignment align)
        {
            Size strSize;
            Rectangle pathBounds = BeginDrawString(g, s, font, layoutRectangle, out strSize);
            EndDrawString(g, s, font, brush, layoutRectangle, align, pathBounds, strSize);
        }

        /// <summary>
        /// ���Ʊ���ͼ
        /// </summary>
        /// <param name="g">��ͼ������</param>
        /// <param name="image">����ͼ</param>
        /// <param name="rect">��������</param>
        /// <param name="layout">����ͼ���ַ�ʽ</param>
        public static void DrawBackgroundImage(Graphics g, Image image, Rectangle rect, ImageLayout layout)
        {
            if (image == null)
                return;

            switch (layout)
            {
                case ImageLayout.None:
                    g.DrawImageUnscaled(image, rect.Location);
                    break;

                case ImageLayout.Tile:
                    using (Brush brush = new TextureBrush(image, WrapMode.Tile))
                    {
                        g.FillRectangle(brush, rect);
                    }
                    break;

                case ImageLayout.Center:
                    int x = rect.Left + (rect.Width - image.Width) / 2;
                    int y = rect.Top + (rect.Height - image.Height) / 2;
                    g.DrawImageUnscaled(image, x, y);
                    break;

                case ImageLayout.Stretch:
                    g.DrawImage(image, rect);
                    break;

                case ImageLayout.Zoom:
                    float xscale = (float)rect.Width / (float)image.Width;
                    float yscale = (float)rect.Height / (float)image.Height;
                    float scale = Math.Min(xscale, yscale);
                    int width = (int)(((float)image.Width) * scale);
                    int height = (int)(((float)image.Height) * scale);
                    x = rect.Left + (rect.Width - width) / 2;
                    y = rect.Top + (rect.Height - height) / 2;
                    g.DrawImage(image, x, y, width, height);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// ���ƾŹ��񱳾�ͼ
        /// </summary>
        /// <param name="g">��ͼ������</param>
        /// <param name="image">����ͼ</param>
        /// <param name="rect">Ŀ������</param>
        /// <param name="left">�Ź��񻮷�,��</param>
        /// <param name="top">�Ź��񻮷�,��</param>
        /// <param name="right">�Ź��񻮷�,��</param>
        /// <param name="bottom">�Ź��񻮷�,��</param>
        /// <param name="layout">�Ź��񱳾�ͼ���ַ�ʽ</param>
        public static void DrawBackgroundImage9(Graphics g, Image image, Rectangle rect, int left, int top, int right, int bottom, ImageLayout9 layout)
        {
            if (image == null || !RectangleEx.IsVisible(rect))
                return;

            //����
            int nSrcWidth = image.Width;
            int nSrcHeight = image.Height;
            int nDestWidth = rect.Width;
            int nDestHeight = rect.Height;
            //����
            Rectangle rcSrcTopLeft = new Rectangle(0, 0, left, top);
            Rectangle rcDestTopLeft = new Rectangle(rect.X, rect.Y, left, top);
            //��
            Rectangle rcSrcTop = new Rectangle(rcSrcTopLeft.Right, rcSrcTopLeft.Y, nSrcWidth - left - right, top);
            Rectangle rcDestTop = new Rectangle(rcDestTopLeft.Right, rcDestTopLeft.Y, nDestWidth - left - right, top);
            //����
            Rectangle rcSrcTopRight = new Rectangle(rcSrcTop.Right, rcSrcTop.Y, right, top);
            Rectangle rcDestTopRight = new Rectangle(rcDestTop.Right, rcDestTop.Y, right, top);
            //��
            Rectangle rcSrcRight = new Rectangle(rcSrcTopRight.X, rcSrcTopRight.Bottom, right, nSrcHeight - top - bottom);
            Rectangle rcDestRight = new Rectangle(rcDestTopRight.X, rcDestTopRight.Bottom, right, nDestHeight - top - bottom);
            //����
            Rectangle rcSrcBottomRight = new Rectangle(rcSrcRight.X, rcSrcRight.Bottom, right, bottom);
            Rectangle rcDestBottomRight = new Rectangle(rcDestRight.X, rcDestRight.Bottom, right, bottom);
            //��
            Rectangle rcSrcBottom = new Rectangle(rcSrcTop.X, rcSrcBottomRight.Y, rcSrcTop.Width, bottom);
            Rectangle rcDestBottom = new Rectangle(rcDestTop.X, rcDestBottomRight.Y, rcDestTop.Width, bottom);
            //����
            Rectangle rcSrcBottomLeft = new Rectangle(rcSrcTopLeft.X, rcSrcBottom.Y, left, bottom);
            Rectangle rcDestBottomLeft = new Rectangle(rcDestTopLeft.X, rcDestBottom.Y, left, bottom);
            //��
            Rectangle rcSrcLeft = new Rectangle(rcSrcBottomLeft.X, rcSrcRight.Y, left, rcSrcRight.Height);
            Rectangle rcDestLeft = new Rectangle(rcDestBottomLeft.X, rcDestRight.Y, left, rcDestRight.Height);
            //��
            Rectangle rcSrcMiddle = new Rectangle(rcSrcTop.X, rcSrcLeft.Y, rcSrcTop.Width, rcSrcLeft.Height);
            Rectangle rcDestMiddle = new Rectangle(rcDestTop.X, rcDestLeft.Y, rcDestTop.Width, rcDestLeft.Height);

            //����
            if (RectangleEx.IsVisible(rcSrcTopLeft))
            {
                g.DrawImage(image, rcDestTopLeft, rcSrcTopLeft, GraphicsUnit.Pixel);
            }
            //��
            if (RectangleEx.IsVisible(rcSrcTop) && RectangleEx.IsVisible(rcDestTop))
            {
                if ((layout & ImageLayout9.TopTile) == 0)//����
                {
                    g.DrawImage(image, rcDestTop, rcSrcTop, GraphicsUnit.Pixel);
                }
                else//ƽ��
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcTop))
                    {
                        brush.TranslateTransform(rcDestTop.X, rcDestTop.Y);
                        g.FillRectangle(brush, rcDestTop);
                    }
                }
            }
            //����
            if (RectangleEx.IsVisible(rcSrcTopRight))
            {
                g.DrawImage(image, rcDestTopRight, rcSrcTopRight, GraphicsUnit.Pixel);
            }
            //��
            if (RectangleEx.IsVisible(rcSrcRight) && RectangleEx.IsVisible(rcDestRight))
            {
                if ((layout & ImageLayout9.RightTile) == 0)//����
                {
                    g.DrawImage(image, rcDestRight, rcSrcRight, GraphicsUnit.Pixel);
                }
                else//ƽ��
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcRight))
                    {
                        brush.TranslateTransform(rcDestRight.X, rcDestRight.Y);
                        g.FillRectangle(brush, rcDestRight);
                    }
                }
            }
            //����
            if (RectangleEx.IsVisible(rcSrcBottomRight))
            {
                g.DrawImage(image, rcDestBottomRight, rcSrcBottomRight, GraphicsUnit.Pixel);
            }
            //��
            if (RectangleEx.IsVisible(rcSrcBottom) && RectangleEx.IsVisible(rcDestBottom))
            {
                if ((layout & ImageLayout9.BottomTile) == 0)//����
                {
                    g.DrawImage(image, rcDestBottom, rcSrcBottom, GraphicsUnit.Pixel);
                }
                else//ƽ��
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcBottom))
                    {
                        brush.TranslateTransform(rcDestBottom.X, rcDestBottom.Y);
                        g.FillRectangle(brush, rcDestBottom);
                    }
                }
            }
            //����
            if (RectangleEx.IsVisible(rcSrcBottomLeft))
            {
                g.DrawImage(image, rcDestBottomLeft, rcSrcBottomLeft, GraphicsUnit.Pixel);
            }
            //��
            if (RectangleEx.IsVisible(rcSrcLeft) && RectangleEx.IsVisible(rcDestLeft))
            {
                if ((layout & ImageLayout9.LeftTile) == 0)//����
                {
                    g.DrawImage(image, rcDestLeft, rcSrcLeft, GraphicsUnit.Pixel);
                }
                else//ƽ��
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcLeft))
                    {
                        brush.TranslateTransform(rcDestLeft.X, rcDestLeft.Y);
                        g.FillRectangle(brush, rcDestLeft);
                    }
                }
            }
            //�м�
            if (RectangleEx.IsVisible(rcSrcMiddle) && RectangleEx.IsVisible(rcDestMiddle))
            {
                if ((layout & ImageLayout9.MiddleTile) == 0)//����
                {
                    g.DrawImage(image, rcDestMiddle, rcSrcMiddle, GraphicsUnit.Pixel);
                }
                else//ƽ��
                {
                    using (TextureBrush brush = new TextureBrush(image, WrapMode.Tile, rcSrcMiddle))
                    {
                        brush.TranslateTransform(rcDestMiddle.X, rcDestMiddle.Y);
                        g.FillRectangle(brush, rcDestMiddle);
                    }
                }
            }
        }

        /// <summary>
        /// ���Ʊ߿�
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="pen">����</param>
        /// <param name="rect">��������</param>
        /// <param name="borderStyle">�߿���ʽ</param>
        /// <param name="cornerStyle">Բ��������ʽ</param>
        /// <param name="roundStyle">Բ����ʽ</param>
        /// <param name="radius">Բ�ǰ뾶</param>
        /// <param name="correct">�Ƿ��Сһ������</param>
        public static void DrawBorder(Graphics g, Pen pen, Rectangle rect, BorderVisibleStyle borderStyle, CornerStyle cornerStyle, RoundStyle roundStyle, float radius, bool correct)
        {
            //-----------------������-----------------
            if (borderStyle == BorderVisibleStyle.None)
                return;
            //-----------------У׼-----------------
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }

            //-----------------�����������-----------------
            if (float.IsNaN(radius) || radius <= 0f)
            {
                //-----------------ȫ��-----------------
                if (borderStyle == BorderVisibleStyle.All)
                {
                    g.DrawRectangle(pen, rect);
                    return;
                }
                cornerStyle = CornerStyle.None;
                roundStyle = RoundStyle.None;
            }
            //-----------------��ʱ��������-----------------
            float diameter = radius * 2;//ֱ��
            float halfWidth = rect.Width / 2f;//���һ��
            float halfHeight = rect.Height / 2f;//�߶�һ��
            PointF ptMiddleCenter = new PointF(rect.X + halfWidth, rect.Y + halfHeight);//���ĵ�            
            float lrDegrees = 0f;//�뾶���ڰ��,Բ�Ľ�
            float lrOffset = 0f;//�뾶���ڰ��,Բ�����߾���
            if ((roundStyle & RoundStyle.All) != 0 && radius > halfHeight)
            {
                double lrRadian = Math.Acos((radius - halfHeight) / radius);//����
                lrDegrees = (float)MathEx.ToDegrees(lrRadian);//�Ƕ�
                lrOffset = (float)(radius * Math.Sin(lrRadian));
            }
            float tbDegrees = 0f;//�뾶���ڰ��,Բ�Ľ�
            float tbOffset = 0f;//�뾶���ڰ��,Բ�����߾���
            if ((roundStyle & RoundStyle.All) != 0 && radius > halfWidth)
            {
                double tbRadian = Math.Acos((radius - halfWidth) / radius);//����
                tbDegrees = (float)MathEx.ToDegrees(tbRadian);//�Ƕ�
                tbOffset = (float)(radius * Math.Sin(tbRadian));
            }
            //��ʱ����
            PointF ptBeginTopLeft;
            PointF ptEndTopLeft;
            PointF ptBeginTopRight;
            PointF ptEndTopRight;
            PointF ptBeginBottomRight;
            PointF ptEndBottomRight;
            PointF ptBeginBottomLeft;
            PointF ptEndBottomLeft;


            #region �������϶˵�
            if ((roundStyle & RoundStyle.TopLeft) == 0)//ֱ��
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    ptEndTopLeft = new PointF(rect.X, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, ptMiddleCenter.Y);
                    ptEndTopLeft = new PointF(rect.X + radius, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y);
                    ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y + radius);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);
                    ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y);
                }
                else
                {
                    ptBeginTopLeft = ptEndTopLeft = new PointF(rect.X, rect.Y);
                }
            }
            else//Բ��
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopLeft = new PointF(rect.X + lrOffset, ptMiddleCenter.Y);
                        ptEndTopLeft = new PointF(rect.X, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X + radius, rect.Y + radius);
                        ptEndTopLeft = new PointF(rect.X, rect.Y);
                    }
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopLeft = new PointF(rect.X, ptMiddleCenter.Y);
                        ptEndTopLeft = new PointF(rect.X + lrOffset, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y);
                        ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y + tbOffset);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y);
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y + radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + tbOffset);
                        ptEndTopLeft = new PointF(ptMiddleCenter.X, rect.Y);
                    }
                    else
                    {
                        ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                        ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                    }
                }
                else
                {
                    ptBeginTopLeft = new PointF(rect.X, rect.Y + radius);//same
                    ptEndTopLeft = new PointF(rect.X + radius, rect.Y);//same
                }
            }
            #endregion

            #region �������϶˵�
            if ((roundStyle & RoundStyle.TopRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBeginTopRight = new PointF(rect.Right, rect.Y);
                    ptEndTopRight = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);
                    ptEndTopRight = new PointF(rect.Right, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    ptEndTopRight = new PointF(rect.Right, rect.Y);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y);
                    ptEndTopRight = new PointF(rect.Right, rect.Y + radius);
                }
                else
                {
                    ptBeginTopRight = ptEndTopRight = new PointF(rect.Right, rect.Y);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopRight = new PointF(rect.Right, rect.Y);
                        ptEndTopRight = new PointF(rect.Right - lrOffset, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right, rect.Y);
                        ptEndTopRight = new PointF(rect.Right - radius, rect.Y + radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginTopRight = new PointF(rect.Right - lrOffset, rect.Y);
                        ptEndTopRight = new PointF(rect.Right, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                        ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y + tbOffset);
                        ptEndTopRight = new PointF(rect.Right, rect.Y);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y + radius);
                        ptEndTopRight = new PointF(rect.Right, rect.Y);
                    }
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginTopRight = new PointF(ptMiddleCenter.X, rect.Y);
                        ptEndTopRight = new PointF(rect.Right, rect.Y + tbOffset);
                    }
                    else
                    {
                        ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                        ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                    }
                }
                else
                {
                    ptBeginTopRight = new PointF(rect.Right - radius, rect.Y);//same
                    ptEndTopRight = new PointF(rect.Right, rect.Y + radius);//same
                }
            }
            #endregion

            #region �������¶˵�
            if ((roundStyle & RoundStyle.BottomRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, ptMiddleCenter.Y);
                    ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                    ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);
                    ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom);
                }
                else
                {
                    ptBeginBottomRight = ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomRight = new PointF(rect.Right - lrOffset, ptMiddleCenter.Y);
                        ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right - radius, rect.Bottom - radius);
                        ptEndBottomRight = new PointF(rect.Right, rect.Bottom);
                    }
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, ptMiddleCenter.Y);
                        ptEndBottomRight = new PointF(rect.Right - lrOffset, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                        ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom - tbOffset);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom);
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom - radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - tbOffset);
                        ptEndBottomRight = new PointF(ptMiddleCenter.X, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                        ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                    }
                }
                else
                {
                    ptBeginBottomRight = new PointF(rect.Right, rect.Bottom - radius);//same
                    ptEndBottomRight = new PointF(rect.Right - radius, rect.Bottom);//same
                }
            }
            #endregion

            #region �������¶˵�
            if ((roundStyle & RoundStyle.BottomLeft) == 0)
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBeginBottomLeft = new PointF(rect.X, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X + radius, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBeginBottomLeft = new PointF(rect.X + radius, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X, ptMiddleCenter.Y);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    ptEndBottomLeft = new PointF(rect.X, rect.Bottom);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom);
                    ptEndBottomLeft = new PointF(rect.X, rect.Bottom - radius);
                }
                else
                {
                    ptBeginBottomLeft = ptEndBottomLeft = new PointF(rect.X, rect.Bottom);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomLeft = new PointF(rect.Left, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left + lrOffset, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left + radius, rect.Bottom - radius);
                    }
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + lrOffset, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left, ptMiddleCenter.Y);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom - tbOffset);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom - radius);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom);
                    }
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                    {
                        ptBeginBottomLeft = new PointF(ptMiddleCenter.X, rect.Bottom);
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - tbOffset);
                    }
                    else
                    {
                        ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                        ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                    }
                }
                else
                {
                    ptBeginBottomLeft = new PointF(rect.Left + radius, rect.Bottom);//same
                    ptEndBottomLeft = new PointF(rect.Left, rect.Bottom - radius);//same
                }
            }
            #endregion


            #region �������
            if ((borderStyle & BorderVisibleStyle.Left) != 0)
            {
                g.DrawLine(pen, ptEndBottomLeft, ptBeginTopLeft);
            }
            #endregion

            #region �������Ͻ�
            if ((borderStyle & BorderVisibleStyle.Left) != 0 || (borderStyle & BorderVisibleStyle.Top) != 0)
            {
                if ((roundStyle & RoundStyle.TopLeft) == 0)
                {
                    g.DrawLine(pen, ptBeginTopLeft, ptEndTopLeft);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.LeftIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - radius, rect.Y, diameter, diameter, 270 + lrDegrees, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.X - radius, rect.Y, diameter, diameter, 0, -90);
                    }
                    else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - (radius - lrOffset), rect.Y, diameter, diameter, 270 - lrDegrees, lrDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.TopIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Y - radius, diameter, diameter, 180, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y - radius, diameter, diameter, 180, -90);
                    }
                    else if ((cornerStyle & CornerStyle.TopOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Y - (radius - tbOffset), diameter, diameter, 180, tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.X, rect.Y, diameter, diameter, 180, 90);//same
                    }
                }
            }
            #endregion

            #region �����ϱ�
            if ((borderStyle & BorderVisibleStyle.Top) != 0)
            {
                g.DrawLine(pen, ptEndTopLeft, ptBeginTopRight);
            }
            #endregion

            #region �������Ͻ�
            if ((borderStyle & BorderVisibleStyle.Top) != 0 || (borderStyle & BorderVisibleStyle.Right) != 0)
            {
                if ((roundStyle & RoundStyle.TopRight) == 0)
                {
                    g.DrawLine(pen, ptBeginTopRight, ptEndTopRight);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.RightIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius, rect.Y, diameter, diameter, 270, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - radius, rect.Y, diameter, diameter, 270, -90);
                    }
                    else if ((cornerStyle & CornerStyle.RightOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius - lrOffset, rect.Y, diameter, diameter, 270, lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.TopIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - radius, diameter, diameter, tbDegrees, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - radius, diameter, diameter, 90, -90);
                    }
                    else if ((cornerStyle & CornerStyle.TopOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Y - (radius - tbOffset), diameter, diameter, 360 - tbDegrees, tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);//same
                    }
                }
            }
            #endregion

            #region �����ұ�
            if ((borderStyle & BorderVisibleStyle.Right) != 0)
            {
                g.DrawLine(pen, ptEndTopRight, ptBeginBottomRight);
            }
            #endregion

            #region �������½�
            if ((borderStyle & BorderVisibleStyle.Right) != 0 || (borderStyle & BorderVisibleStyle.Bottom) != 0)
            {
                if ((roundStyle & RoundStyle.BottomRight) == 0)
                {
                    g.DrawLine(pen, ptBeginBottomRight, ptEndBottomRight);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.RightIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 90 + lrDegrees, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 180, -90);
                    }
                    else if ((cornerStyle & CornerStyle.RightOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.Right - radius - lrOffset, rect.Bottom - diameter, diameter, diameter, 90 - lrDegrees, lrDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -90);
                    }
                    else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - radius - tbOffset, diameter, diameter, 0, tbDegrees);
                        else
                            g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);//same
                    }
                }
            }
            #endregion

            #region �����±�
            if ((borderStyle & BorderVisibleStyle.Bottom) != 0)
            {
                g.DrawLine(pen, ptEndBottomRight, ptBeginBottomLeft);
            }
            #endregion

            #region �������½�
            if ((borderStyle & BorderVisibleStyle.Bottom) != 0 || (borderStyle & BorderVisibleStyle.Left) != 0)
            {
                if ((roundStyle & RoundStyle.BottomLeft) == 0)
                {
                    g.DrawLine(pen, ptBeginBottomLeft, ptEndBottomLeft);
                }
                else
                {
                    if ((cornerStyle & CornerStyle.LeftIn) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -lrDegrees);
                        else
                            g.DrawArc(pen, rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -90);
                    }
                    else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                    {
                        if (radius > halfHeight)
                            g.DrawArc(pen, rect.X - (radius - lrOffset), rect.Bottom - diameter, diameter, diameter, 90, lrDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                    else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Bottom - radius, diameter, diameter, 180 + tbDegrees, -tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - radius, diameter, diameter, 270, -90);
                    }
                    else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                    {
                        if (radius > halfWidth)
                            g.DrawArc(pen, rect.X, rect.Bottom - radius - tbOffset, diameter, diameter, 180 - tbDegrees, tbDegrees);
                        else
                            g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                    else
                    {
                        g.DrawArc(pen, rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);//same
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// ����ģ����Ч,��ɫ��Ҫ��alphaͨ��
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="color">��ɫ(��alphaͨ��)</param>
        public static void DrawAeroBlur(Graphics g, Rectangle rect, Color color)
        {
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rect);
            }
        }

        /// <summary>
        /// ���Ʋ���Ч��,��ɫ��Ҫ��alphaͨ��
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="centerColor">������ɫ(��alphaͨ��)</param>
        /// <param name="surroundColor">��Χ��ɫ(��alphaͨ��)</param>
        public static void DrawAeroGlass(Graphics g, Rectangle rect, Color centerColor, Color surroundColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = centerColor;
                    brush.SurroundColors = new Color[] { surroundColor };
                    brush.CenterPoint = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                    g.FillPath(brush, path);
                }
            }
        }

        /// <summary>
        /// ���ƶԺ�(������)
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="color">��ɫ</param>
        public static void DrawCheck(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;

            PointF[] points = new PointF[3];
            points[0] = new PointF(l + width * 0.2f, t + height * 0.522f);//��
            points[1] = new PointF(l + width * 0.422f, b - height * 0.251f);//��
            points[2] = new PointF(r - width * 0.204f, t + height * 0.208f);//��
            using (Pen pen = new Pen(color, Math.Max(2f, Math.Min(rect.Width, rect.Height) * 0.15f)))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.DrawLines(pen, points);
                }
            }
        }

        /// <summary>
        /// ���Ʋ��(������)
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="color">��ɫ</param>
        public static void DrawCross(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;
            float offset = 0.2f;

            PointF[] points = new PointF[2];
            points[0] = new PointF(l + offset * width, t + offset * height);
            points[1] = new PointF(r - offset * width, b - offset * height);

            PointF[] points1 = new PointF[2];
            points1[0] = new PointF(r - offset * width, t + offset * height);
            points1[1] = new PointF(l + offset * width, b - offset * height);

            using (Pen pen = new Pen(color, Math.Max(2f, Math.Min(rect.Width, rect.Height) / 6f)))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.DrawLines(pen, points);
                    g.DrawLines(pen, points1);
                }
            }
        }

        /// <summary>
        /// ����ʡ�Ժ�(������)
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="color">��ɫ</param>
        public static void DrawEllipsis(Graphics g, Rectangle rect, Color color)
        {
            rect.Width--;
            rect.Height--;

            float d = Math.Max(3f, rect.Width / 6f);
            float t = rect.Y + (rect.Height - d) / 2f;
            float leftl = rect.X + d;
            float midl = rect.X + (rect.Width - d) / 2f;
            float rightl = rect.Right - d - d;

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g))
                {
                    g.FillEllipse(brush, leftl, t, d, d);
                    g.FillEllipse(brush, midl, t, d, d);
                    g.FillEllipse(brush, rightl, t, d, d);
                }
            }
        }

        /// <summary>
        /// ���Ƽ�ͷ(������)
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="color">��ɫ</param>
        /// <param name="direction">����</param>
        public static void DrawArrow(Graphics g, Rectangle rect, Color color, ArrowDirection direction)
        {
            rect.Width--;
            rect.Height--;

            int width = rect.Width;
            int height = rect.Height;
            int l = rect.X;
            int t = rect.Y;
            int r = rect.Right;
            int b = rect.Bottom;
            //�Գ��µ�Ϊ׼�������±���
            float offsetL = 0.24f;
            float offsetT = 0.33f;
            float offsetB = 0.27f;

            PointF[] points = new PointF[3]; ;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points[0] = new PointF(l + width * offsetB, t + height * 0.5f);
                    points[1] = new PointF(r - width * offsetT, t + height * offsetL);
                    points[2] = new PointF(r - width * offsetT, b - height * offsetL);
                    break;

                case ArrowDirection.Up:
                    points[0] = new PointF(l + width * 0.5f, t + height * offsetB);
                    points[1] = new PointF(r - width * offsetL, b - height * offsetT);
                    points[2] = new PointF(l + width * offsetL, b - height * offsetT);
                    break;

                case ArrowDirection.Right:
                    points[0] = new PointF(l + width * offsetT, t + height * offsetL);
                    points[1] = new PointF(r - width * offsetB, t + height * 0.5f);
                    points[2] = new PointF(l + width * offsetT, b - height * offsetL);
                    break;

                default:
                    points[0] = new PointF(l + width * offsetL, t + height * offsetT);
                    points[1] = new PointF(r - width * offsetL, t + height * offsetT);
                    points[2] = new PointF(l + width * 0.5f, b - height * offsetB);
                    break;
            }

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g, SmoothingMode.AntiAlias))
                {
                    using (new PixelOffsetModeGraphics(g, PixelOffsetMode.Default))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }
        }

        /// <summary>
        /// ���Ƽ�ͷ(��ѡ��С)
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="color">��ɫ</param>
        /// <param name="direction">��ͷ����</param>
        /// <param name="style">��С��ʽ</param>
        public static void DrawArrow(Graphics g, Rectangle rect, Color color, ArrowDirection direction, SizeStyle style)
        {
            Point point = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2));
            Point[] points = null;

            switch (style)
            {
                case SizeStyle.Tiny:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 1, point.Y - 2), new Point(point.X + 1, point.Y + 2), new Point(point.X - 1, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 2, point.Y + 1), new Point(point.X + 2, point.Y + 1), new Point(point.X, point.Y - 2) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 1, point.Y - 2), new Point(point.X - 1, point.Y + 2), new Point(point.X + 1, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 1, point.Y - 1), new Point(point.X + 2, point.Y - 1), new Point(point.X, point.Y + 1) };
                            break;
                    }
                    break;

                case SizeStyle.Small:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 2, point.Y - 3), new Point(point.X + 2, point.Y + 3), new Point(point.X - 1, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 3, point.Y + 2), new Point(point.X + 3, point.Y + 2), new Point(point.X, point.Y - 2) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 1, point.Y - 3), new Point(point.X - 1, point.Y + 3), new Point(point.X + 2, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 2, point.Y - 1), new Point(point.X + 3, point.Y - 1), new Point(point.X, point.Y + 2) };
                            break;
                    }
                    break;

                case SizeStyle.Normal:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 2, point.Y - 4), new Point(point.X + 2, point.Y + 4), new Point(point.X - 2, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 4, point.Y + 2), new Point(point.X + 5, point.Y + 2), new Point(point.X, point.Y - 3) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 2, point.Y - 4), new Point(point.X - 2, point.Y + 4), new Point(point.X + 2, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 3, point.Y - 2), new Point(point.X + 4, point.Y - 2), new Point(point.X, point.Y + 2) };
                            break;
                    }
                    break;

                case SizeStyle.Large:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 3, point.Y - 5), new Point(point.X + 3, point.Y + 5), new Point(point.X - 2, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 5, point.Y + 3), new Point(point.X + 6, point.Y + 3), new Point(point.X, point.Y - 3) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 2, point.Y - 5), new Point(point.X - 2, point.Y + 5), new Point(point.X + 3, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 4, point.Y - 2), new Point(point.X + 5, point.Y - 2), new Point(point.X, point.Y + 3) };
                            break;
                    }
                    break;

                case SizeStyle.Huge:
                    switch (direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 3, point.Y - 6), new Point(point.X + 3, point.Y + 6), new Point(point.X - 3, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 6, point.Y + 3), new Point(point.X + 7, point.Y + 3), new Point(point.X, point.Y - 4) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 3, point.Y - 6), new Point(point.X - 3, point.Y + 6), new Point(point.X + 3, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 5, point.Y - 3), new Point(point.X + 6, point.Y - 3), new Point(point.X, point.Y + 3) };
                            break;
                    }
                    break;

                default:
                    break;
            }

            using (Brush brush = new SolidBrush(color))
            {
                using (new SmoothingModeGraphics(g, SmoothingMode.None))
                {
                    using (new PixelOffsetModeGraphics(g, PixelOffsetMode.Default))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }
        }
    }
}
