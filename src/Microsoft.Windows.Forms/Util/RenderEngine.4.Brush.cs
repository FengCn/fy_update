using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// ��ȡ�߶���ˮƽX��н�(�Ƕȱ�ʾ)
        /// </summary>
        /// <param name="pt1">���</param>
        /// <param name="pt2">�յ�</param>
        /// <returns>�н�</returns>
        public static float GetLineDegrees(Point pt1, Point pt2)
        {
            return (float)MathEx.ToDegrees(Math.Atan(((double)pt2.Y - (double)pt1.Y) / ((double)pt2.X - (double)pt1.X)));
        }

        /// <summary>
        /// ��ȡ�����߶ε���С����(�ǿ�)
        /// </summary>
        /// <param name="pt1">���</param>
        /// <param name="pt2">�յ�</param>
        /// <returns>����</returns>
        public static Rectangle GetLineRect(Point pt1, Point pt2)
        {
            Rectangle rect = Rectangle.FromLTRB(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y), Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y));
            rect.Inflate(1, 1);
            return rect;
        }


        /// <summary>
        /// ������ˢ,��Ⱦ�����ͱ߿�ʹ��
        /// </summary>
        /// <param name="rect">��ˢ����</param>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="pos1">��ɫλ��1</param>
        /// <param name="pos2">��ɫλ��2</param>
        /// <param name="reverse">�Ƿ�ת</param>
        /// <param name="mode">����ģʽ</param>
        /// <param name="style">��ʽ</param>
        /// <returns>��ˢ</returns>
        public static Brush CreateBrush(Rectangle rect, Color baseColor, float pos1, float pos2, bool reverse, LinearGradientMode mode, BlendStyle style)
        {
            Brush brush = null;
            RectangleEx.MakeNotEmpty(ref rect);
            switch (style)
            {
                case BlendStyle.Solid:
                    {
                        SolidBrush brushTmp = new SolidBrush(baseColor);
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.Gradient:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosGradient(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeIn:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeIn(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeOut(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeInFadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(rect, Color.Empty, Color.Empty, mode);
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeInFadeOut(baseColor, pos1, pos2, reverse, false, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                default:
                    break;
            }
            return brush;
        }

        /// <summary>
        /// ������ˢ,��Ⱦ�߶�ʹ��
        /// </summary>
        /// <param name="pt1">���</param>
        /// <param name="pt2">�յ�</param>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="style">��ʽ</param>
        /// <returns>��ˢ</returns>
        public static Brush CreateBrush(Point pt1, Point pt2, Color baseColor, BlendStyle style)
        {
            Brush brush = null;
            switch (style)
            {
                case BlendStyle.Solid:
                    {
                        SolidBrush brushTmp = new SolidBrush(baseColor);
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.Gradient:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosGradient(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeIn:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeIn(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeOut(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                case BlendStyle.FadeInFadeOut:
                    {
                        LinearGradientBrush brushTmp = new LinearGradientBrush(GetLineRect(pt1, pt2), Color.Empty, Color.Empty, GetLineDegrees(pt1, pt2));
                        //��ˢ����
                        ColorBlend blendTmp = new ColorBlend();
                        Color[] colors;
                        float[] positions;
                        RenderEngine.GetColorPosFadeInFadeOut(baseColor, float.NaN, float.NaN, false, true, out colors, out positions);
                        blendTmp.Colors = colors;
                        blendTmp.Positions = positions;
                        //
                        brushTmp.InterpolationColors = blendTmp;
                        brush = brushTmp;
                        brushTmp = null;
                    }
                    break;

                default:
                    break;
            }
            return brush;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="brush">��ˢ</param>
        /// <param name="width">ֱ�߿��</param>
        /// <param name="style">������ʽ</param>
        /// <param name="pattern">���߳�������</param>
        /// <param name="cap">ÿ���߶μ�ñ��ʽ</param>
        /// <param name="offset">ֱ�ߵ���㵽�̻���ͼ����ʼ���ľ���</param>
        /// <returns>����</returns>
        public static Pen CreatePen(Brush brush, int width, DashStyle style, float[] pattern, DashCap cap, float offset)
        {
            Pen pen = new Pen(brush);
            pen.Width = width;
            pen.DashStyle = style;
            if (style == DashStyle.Custom && pattern != null && pattern.Length > 0)
                pen.DashPattern = pattern;
            pen.DashCap = cap;
            pen.DashOffset = offset;
            return pen;
        }
    }
}
