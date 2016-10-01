using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// ��ɫc1,���c2�Ƿ�Ϊ��ɫ
        /// </summary>
        /// <param name="c1">��ɫc1</param>
        /// <param name="c2">��ɫc2</param>
        /// <returns>�Ƿ�Ϊ��</returns>
        private static bool IsDarker(Color c1, Color c2)
        {
            HLSColor color = new HLSColor(c1);
            HLSColor color2 = new HLSColor(c2);
            return (color.Luminosity < color2.Luminosity);
        }

        /// <summary>
        /// ��ȡ��Чʱ�ı���ɫ
        /// </summary>
        /// <param name="backColor">�ؼ�����ɫ</param>
        /// <returns>��Ч��ɫ</returns>
        public static Color GetGrayColor(Color backColor)
        {
            Color controlDark = SystemColors.ControlDark;
            if (RenderEngine.IsDarker(backColor, SystemColors.Control))
            {
                controlDark = ControlPaint.Dark(backColor);
            }
            return controlDark;
        }


        /// <summary>
        /// ��ȡ������ɫλ������
        /// </summary>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="pos1">λ��1</param>
        /// <param name="pos2">λ��2</param>
        /// <param name="reverse">�Ƿ�ת</param>
        /// <param name="avg">�Ƿ����λ��</param>
        /// <param name="colors">��ɫ����</param>
        /// <param name="positions">λ������</param>
        public static void GetColorPosGradient(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            ColorVector vector = ColorVector.FromArgb(8, 8, 8);
            Color outerColor = baseColor + vector;
            Color innerColor = baseColor - vector;
            if (reverse)
            {
                colors = new Color[] { outerColor, innerColor, innerColor, outerColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };//����ʱ.��ת�벻��ת��ͬ
                else
                    positions = new float[] { 0.0f, 1.0f - pos2, 1.0f - pos1, 1.0f };//�Ǿ���ʱ.1-����Ԫ��,�ٷ�ת˳��
            }
            else
            {
                colors = new Color[] { outerColor, innerColor, innerColor, outerColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, pos2, 1.0f };
            }
        }

        /// <summary>
        /// ��ȡ������ɫλ������
        /// </summary>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="pos1">λ��1</param>
        /// <param name="pos2">λ��2</param>
        /// <param name="reverse">�Ƿ�ת</param>
        /// <param name="avg">�Ƿ����λ��</param>
        /// <param name="colors">��ɫ����</param>
        /// <param name="positions">λ������</param>
        public static void GetColorPosFadeIn(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, 1.0f };
            }
        }

        /// <summary>
        /// ��ȡ������ɫλ������
        /// </summary>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="pos1">λ��1</param>
        /// <param name="pos2">λ��2</param>
        /// <param name="reverse">�Ƿ�ת</param>
        /// <param name="avg">�Ƿ����λ��</param>
        /// <param name="colors">��ɫ����</param>
        /// <param name="positions">λ������</param>
        public static void GetColorPosFadeOut(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.5f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, 1.0f };
            }
        }

        /// <summary>
        /// ��ȡ����������ɫλ������
        /// </summary>
        /// <param name="baseColor">��ɫ</param>
        /// <param name="pos1">λ��1</param>
        /// <param name="pos2">λ��2</param>
        /// <param name="reverse">�Ƿ�ת</param>
        /// <param name="avg">�Ƿ����λ��</param>
        /// <param name="colors">��ɫ����</param>
        /// <param name="positions">λ������</param>
        public static void GetColorPosFadeInFadeOut(Color baseColor, float pos1, float pos2, bool reverse, bool avg, out Color[] colors, out float[] positions)
        {
            if (reverse)
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, 1.0f - pos2, 1.0f - pos1, 1.0f };
            }
            else
            {
                colors = new Color[] { Color.Transparent, baseColor, baseColor, Color.Transparent };
                if (avg)
                    positions = new float[] { 0.0f, 0.333333f, 0.666667f, 1.0f };
                else
                    positions = new float[] { 0.0f, pos1, pos2, 1.0f };
            }
        }
    }
}
