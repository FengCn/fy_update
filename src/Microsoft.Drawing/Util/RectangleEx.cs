using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ���ΰ�����
    /// </summary>
    public static class RectangleEx
    {
        /// <summary>
        /// �������ηǿ�,Ӱ��ԭ������
        /// </summary>
        /// <param name="rect">Ҫ�����ľ���</param>
        public static void MakeNotEmpty(ref Rectangle rect)
        {
            if (rect.Width < 1)
                rect.Width = 1;
            if (rect.Height < 1)
                rect.Height = 1;
        }

        /// <summary>
        /// ��ȡ�����Ƿ�ɼ�
        /// </summary>
        /// <param name="rect">����</param>
        /// <returns>��ȴ���0���Ҹ߶ȴ���0����true,���򷵻�false</returns>
        public static bool IsVisible(Rectangle rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        /// <summary>
        /// ��ָ���ķ���Ŵ����,��Ӱ��ԭ���ľ���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="align">����</param>
        /// <param name="value">�Ŵ���</param>
        /// <returns>�Ŵ��ľ���</returns>
        public static Rectangle Inflate(Rectangle rect, TabAlignment align, int value)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y -= value;
                    rect.Height += value;
                    break;

                case TabAlignment.Bottom:
                    rect.Height += value;
                    break;

                case TabAlignment.Left:
                    rect.X -= value;
                    rect.Width += value;
                    break;

                case TabAlignment.Right:
                    rect.Width += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// ��ָ���ķ���ͷ���Ŵ����,��Ӱ��ԭ���ľ���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="align">����</param>
        /// <param name="value">�Ŵ���</param>
        /// <param name="revalue">����Ŵ���</param>
        /// <returns>�Ŵ�����</returns>
        public static Rectangle Inflate(Rectangle rect, TabAlignment align, int value, int revalue)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y -= value;
                    rect.Height += value + revalue;
                    break;

                case TabAlignment.Bottom:
                    rect.Y -= revalue;
                    rect.Height += revalue + value;
                    break;

                case TabAlignment.Left:
                    rect.X -= value;
                    rect.Width += value + revalue;
                    break;

                case TabAlignment.Right:
                    rect.X -= revalue;
                    rect.Width += revalue + value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// ��ָ���ķ��������Ŵ����,��Ӱ��ԭ���ľ���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="align">����</param>
        /// <param name="value">�Ŵ���</param>
        /// <returns>�Ŵ�����</returns>
        public static Rectangle InflateSide(Rectangle rect, TabAlignment align, int value)
        {
            int half = value / 2;
            switch (align)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    rect.X -= half;
                    rect.Width += value;
                    break;

                case TabAlignment.Left:
                case TabAlignment.Right:
                    rect.Y -= half;
                    rect.Height += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// ��ָ���ߵ�������,ʹ�ڸ÷����ϵĴ�СΪָ��ֵ
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="align">����</param>
        /// <param name="value">��С</param>
        /// <returns>���������</returns>
        public static Rectangle Adjust(Rectangle rect, TabAlignment align, int value)
        {
            switch (align)
            {
                case TabAlignment.Top:
                    rect.Y += (rect.Height - value);
                    rect.Height = value;
                    break;

                case TabAlignment.Bottom:
                    rect.Height = value;
                    break;

                case TabAlignment.Left:
                    rect.X += (rect.Width - value);
                    rect.Width = value;
                    break;

                case TabAlignment.Right:
                    rect.Width = value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// ��������ʹ����ָ�����������׼���ζ���,������ƫ����,��Ӱ��ԭ���ľ���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="rectStand">��׼����</param>
        /// <param name="align">����</param>
        /// <param name="offset">ƫ����</param>
        /// <returns>������ľ���</returns>
        public static Rectangle Align(Rectangle rect, Rectangle rectStand, TabAlignment align, int offset)
        {
            int value;
            switch (align)
            {
                case TabAlignment.Top:
                    value = rect.Y - rectStand.Y + offset;
                    rect.Y -= value;
                    rect.Height += value;
                    break;

                case TabAlignment.Bottom:
                    value = rectStand.Bottom - rect.Bottom + offset;
                    rect.Height += value;
                    break;

                case TabAlignment.Left:
                    value = rect.X - rectStand.X + offset;
                    rect.X -= value;
                    rect.Width += value;
                    break;

                case TabAlignment.Right:
                    value = rectStand.Right - rect.Right + offset;
                    rect.Width += value;
                    break;

                default:
                    break;
            }

            return rect;
        }

        /// <summary>
        /// ���μ���Padding����¾���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="padding">��߾�</param>
        /// <returns>�¾���</returns>
        public static Rectangle Add(Rectangle rect, Padding padding)
        {
            return new Rectangle(rect.Left - padding.Left, rect.Top - padding.Top, rect.Width + padding.Horizontal, rect.Height + padding.Vertical);
        }

        /// <summary>
        /// ���μ�ȥPadding����¾���
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="padding">�ڱ߾�</param>
        /// <returns>�¾���</returns>
        public static Rectangle Subtract(Rectangle rect, Padding padding)
        {
            return new Rectangle(rect.Left + padding.Left, rect.Top + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
        }

        /// <summary>
        /// ���˾��ε�λ�õ���ָ�������������¾��Σ���Ӱ��ԭ��ֵ��
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="pos">��λ�õ�ƫ����</param>
        /// <returns>ƫ�ƺ���¾���</returns>
        public static Rectangle Offset(Rectangle rect, Point pos)
        {
            rect.Offset(pos);
            return rect;
        }

        /// <summary>
        /// �����ε�λ�õ���ָ�������������¾��Σ���Ӱ��ԭ��ֵ��
        /// </summary>
        /// <param name="rect">����</param>
        /// <param name="x">ˮƽƫ����</param>
        /// <param name="y">��ֱƫ����</param>
        /// <returns>ƫ�ƺ���¾���</returns>
        public static Rectangle Offset(Rectangle rect, int x, int y)
        {
            rect.Offset(x, y);
            return rect;
        }
    }
}
