using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// ����·����
        /// </summary>
        /// <param name="rect">���Ρ�</param>
        /// <returns>������·����</returns>
        public static GraphicsPath CreateGraphicsPath(Rectangle rect)
        {
            return CreateGraphicsPath(rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <summary>
        /// ����·����
        /// </summary>
        /// <param name="pt">���Ͻǡ�</param>
        /// <param name="sz">��С</param>
        /// <returns>������·����</returns>
        public static GraphicsPath CreateGraphicsPath(Point pt, Size sz)
        {
            return CreateGraphicsPath(pt.X, pt.Y, sz.Width, sz.Height);
        }

        /// <summary>
        /// ����·����
        /// </summary>
        /// <param name="x">���Ͻ�ˮƽ���ꡣ</param>
        /// <param name="y">���ϽǴ�ֱ����</param>
        /// <param name="width">��ȡ�</param>
        /// <param name="height">�߶ȡ�</param>
        /// <returns>������·����</returns>
        public static GraphicsPath CreateGraphicsPath(int x, int y, int width, int height)
        {
            Point[] points = new Point[4];
            points[0] = new Point(x, y);
            points[1] = new Point(x + width, y);
            points[2] = new Point(x + width, y + height);
            points[3] = new Point(x, y + height);
            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);
            return shape;
        }

        /// <summary>
        /// ����·����
        /// </summary>
        /// <param name="rect">��������·���ľ��Ρ�</param>
        /// <param name="cornerStyle">Բ��������ʽ��</param>
        /// <param name="roundStyle">Բ�ǵ���ʽ��</param>
        /// <param name="radius">Բ�ǰ뾶��</param>
        /// <param name="correct">�Ƿ�Ѿ��γ���� 1,�Ա㻭���߿�</param>
        /// <returns>������·����</returns>
        public static GraphicsPath CreateGraphicsPath(Rectangle rect, CornerStyle cornerStyle, RoundStyle roundStyle, float radius, bool correct)
        {
            //-----------------У׼-----------------
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }

            //-----------------���巵��ֵ-----------------
            GraphicsPath path = new GraphicsPath();
            //-----------------�����������-----------------
            if (float.IsNaN(radius) || radius <= 0f)
            {
                path.AddRectangle(rect);
                return path;
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
            PointF ptBegin;
            PointF ptEnd;


            #region ����
            if ((roundStyle & RoundStyle.TopLeft) == 0)//ֱ��
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBegin = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBegin = new PointF(rect.X, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.X + radius, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Y);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Y + radius);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else
                {
                    ptBegin = ptEnd = new PointF(rect.X, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else//Բ��
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - radius, rect.Y, diameter, diameter, 270 + lrDegrees, -lrDegrees);
                    else
                        path.AddArc(rect.X - radius, rect.Y, diameter, diameter, 0, -90);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - (radius - lrOffset), rect.Y, diameter, diameter, 270 - lrDegrees, lrDegrees);
                    else
                        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Y - radius, diameter, diameter, 180, -tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Y - radius, diameter, diameter, 180, -90);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Y - (radius - tbOffset), diameter, diameter, 180, tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
                else
                {
                    path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                }
            }
            #endregion


            #region ����
            if ((roundStyle & RoundStyle.TopRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Y);
                    ptEnd = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBegin = new PointF(rect.Right - radius, rect.Y);
                    ptEnd = new PointF(rect.Right, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Y + radius);
                    ptEnd = new PointF(rect.Right, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Y);
                    ptEnd = new PointF(rect.Right, rect.Y + radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else//����
                {
                    ptBegin = ptEnd = new PointF(rect.Right, rect.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius, rect.Y, diameter, diameter, 270, -lrDegrees);
                    else
                        path.AddArc(rect.Right - radius, rect.Y, diameter, diameter, 270, -90);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius - lrOffset, rect.Y, diameter, diameter, 270, lrDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
                else if ((cornerStyle & CornerStyle.TopIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Y - radius, diameter, diameter, tbDegrees, -tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y - radius, diameter, diameter, 90, -90);
                }
                else if ((cornerStyle & CornerStyle.TopOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Y - (radius - tbOffset), diameter, diameter, 360 - tbDegrees, tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
                else
                {
                    path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                }
            }
            #endregion


            #region ����
            if ((roundStyle & RoundStyle.BottomRight) == 0)
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    ptBegin = new PointF(rect.Right - radius, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.Right, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    ptBegin = new PointF(rect.Right, ptMiddleCenter.Y);
                    ptEnd = new PointF(rect.Right - radius, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Bottom);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBegin = new PointF(rect.Right, rect.Bottom - radius);
                    ptEnd = new PointF(ptMiddleCenter.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else//����
                {
                    ptBegin = ptEnd = new PointF(rect.Right, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.RightIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 90 + lrDegrees, -lrDegrees);
                    else
                        path.AddArc(rect.Right - radius, rect.Bottom - diameter, diameter, diameter, 180, -90);
                }
                else if ((cornerStyle & CornerStyle.RightOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.Right - radius - lrOffset, rect.Bottom - diameter, diameter, diameter, 90 - lrDegrees, lrDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius, diameter, diameter, 0, -90);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.Right - diameter, rect.Bottom - radius - tbOffset, diameter, diameter, 0, tbDegrees);
                    else
                        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
                else
                {
                    path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                }
            }
            #endregion


            #region ����
            if ((roundStyle & RoundStyle.BottomLeft) == 0)
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    ptBegin = new PointF(rect.X, rect.Bottom);
                    ptEnd = new PointF(rect.X + radius, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    ptBegin = new PointF(rect.X + radius, rect.Bottom);
                    ptEnd = new PointF(rect.X, ptMiddleCenter.Y);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Bottom - radius);
                    ptEnd = new PointF(rect.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    ptBegin = new PointF(ptMiddleCenter.X, rect.Bottom);
                    ptEnd = new PointF(rect.X, rect.Bottom - radius);
                    path.AddLine(ptBegin, ptEnd);
                }
                else
                {
                    ptBegin = ptEnd = new PointF(rect.X, rect.Bottom);
                    path.AddLine(ptBegin, ptEnd);
                }
            }
            else
            {
                if ((cornerStyle & CornerStyle.LeftIn) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -lrDegrees);
                    else
                        path.AddArc(rect.X - radius, rect.Bottom - diameter, diameter, diameter, 90, -90);
                }
                else if ((cornerStyle & CornerStyle.LeftOut) != 0)
                {
                    if (radius > halfHeight)
                        path.AddArc(rect.X - (radius - lrOffset), rect.Bottom - diameter, diameter, diameter, 90, lrDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
                else if ((cornerStyle & CornerStyle.BottomIn) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Bottom - radius, diameter, diameter, 180 + tbDegrees, -tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - radius, diameter, diameter, 270, -90);
                }
                else if ((cornerStyle & CornerStyle.BottomOut) != 0)
                {
                    if (radius > halfWidth)
                        path.AddArc(rect.X, rect.Bottom - radius - tbOffset, diameter, diameter, 180 - tbDegrees, tbDegrees);
                    else
                        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
                else
                {
                    path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                }
            }
            #endregion


            //�պϷ���
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// ��������Բ����ʽ�ͱ����·����
        /// </summary>
        /// <param name="rect">��������·���ľ��Ρ�</param>
        /// <param name="style">Բ����ʽ��</param>
        /// <param name="radius">Բ�Ǵ�С��</param>
        /// <param name="tabSize">�����С��</param>
        /// <param name="tabRound">�����Ƿ�Բ�ǡ�</param>
        /// <param name="tabRadius">����Բ�Ǵ�С��</param>
        /// <param name="correct">�Ƿ�Ѿ��γ���� 1,�Ա㻭���߿�</param>
        /// <returns>������·����</returns>
        public static GraphicsPath CreateGroupBoxTabGraphicsPath(Rectangle rect, RoundStyle style, float radius, Size tabSize, bool tabRound, float tabRadius, bool correct)
        {
            //У��
            if (correct)
            {
                rect.Width--;
                rect.Height--;
            }
            style = (float.IsNaN(radius) || radius <= 0f) ? RoundStyle.None : style;
            tabRound = (float.IsNaN(tabRadius) || tabRadius <= 0f) ? false : tabRound;

            //����
            GraphicsPath path = new GraphicsPath();
            Rectangle tabRect = new Rectangle(rect.Location, tabSize);
            float diameter = radius * 2;
            float tabDiameter = tabRadius * 2;
            Point pt;

            //����
            if ((style & RoundStyle.TopLeft) == 0)
            {
                pt = new Point(rect.X, rect.Y);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            }

            //Tab����
            if (tabRound)
            {
                if (tabRadius > tabRect.Height)//����90��
                {
                    double radians = Math.Acos((tabRadius - tabRect.Height) / tabRadius);
                    path.AddArc((float)(tabRect.Right - tabRadius * Math.Sin(radians) - tabRadius),
                        tabRect.Y, tabDiameter, tabDiameter, 270, (float)MathEx.ToDegrees(radians));
                }
                else//��90��
                {
                    path.AddArc(tabRect.Right - tabDiameter, tabRect.Y, tabDiameter, tabDiameter, 270, 90);

                    //Tab����
                    pt = new Point(tabRect.Right, tabRect.Bottom);
                    path.AddLine(pt, pt);
                }
            }
            else
            {
                pt = new Point(tabRect.Right, tabRect.Y);
                path.AddLine(pt, pt);

                //Tab����
                pt = new Point(tabRect.Right, tabRect.Bottom);
                path.AddLine(pt, pt);
            }

            //����
            if ((style & RoundStyle.TopRight) == 0)
            {
                pt = new Point(rect.Right, tabRect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.Right - diameter, tabRect.Bottom, diameter, diameter, 270, 90);
            }

            //����
            if ((style & RoundStyle.BottomRight) == 0)
            {
                pt = new Point(rect.Right, rect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            }

            //����
            if ((style & RoundStyle.BottomLeft) == 0)
            {
                pt = new Point(rect.X, rect.Bottom);
                path.AddLine(pt, pt);
            }
            else
            {
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            }

            //�պϷ���
            path.CloseFigure();
            return path;
        }
    }
}
