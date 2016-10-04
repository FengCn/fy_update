using System.Drawing;
using System.Drawing.Imaging;

namespace Microsoft.Windows.Forms
{
    public static partial class RenderEngine
    {
        /// <summary>
        /// ��ȡ�ڰ�ͼ��(�������µ�ͼ��,ʹ�������Ҫ�ֶ��ͷ�)
        /// </summary>
        /// <param name="originImage">ԭͼ</param>
        /// <returns>�ڰ�ͼ</returns>
        public static Bitmap GetGrayImage(Image originImage)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            //������ͼ��
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                //��ͼ�������
                if (m_DisabledImageAttr == null)
                {
                    //��ɫ�任����,��һ�е������зֱ��ʾRGBA����,��һ�е������зֱ��ʾRGBA����.
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] {0.2125f, 0.2125f, 0.2125f, 000f, 000f},//�µ�R=�ɵ�R*0.2125f+�ɵ�G*0.2125f+�ɵ�B*0.2125f
                        new float[] {0.2577f, 0.2577f, 0.2577f, 000f, 000f},
                        new float[] {0.0361f, 0.0361f, 0.0361f, 000f, 000f},
                        new float[] {000000f, 000000f, 000000f, 001f, 000f},
                        new float[] {0.3800f, 0.3800f, 0.3800f, 000f, 001f}
                    });

                    //������ͼ����
                    m_DisabledImageAttr = new ImageAttributes();
                    m_DisabledImageAttr.SetColorMatrix(colorMatrix);
                }

                //��ͼ
                g.DrawImage(originImage, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, m_DisabledImageAttr);
            }

            //����
            return newBitmap;
        }

        /// <summary>
        /// ��ȡ͸��ͼ��(�������µ�ͼ��,ʹ�������Ҫ�ֶ��ͷ�)
        /// </summary>
        /// <param name="originImage">ԭͼ</param>
        /// <param name="opacity">͸����[0-1]</param>
        /// <returns>͸��ͼ��</returns>
        public static Bitmap GetTransparentImage(Image originImage, float opacity)
        {
            int width = originImage.Width;
            int height = originImage.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            //������ͼ��
            using (Graphics graphics = Graphics.FromImage(newBitmap))
            {
                //��ͼ����
                using (ImageAttributes imgAttr = new ImageAttributes())
                {
                    ColorMatrix clrMatrix = new ColorMatrix();
                    clrMatrix.Matrix33 = opacity;
                    imgAttr.SetColorMatrix(clrMatrix);

                    //��ͼ
                    graphics.DrawImage(originImage, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imgAttr);
                }
            }

            //����
            return newBitmap;
        }

        /// <summary>
        /// ����ͼ��(�������µ�ͼ��,ʹ�������Ҫ�ֶ��ͷ�)
        /// </summary>
        /// <param name="originImage">Ҫ���ŵ�ͼ��</param>
        /// <param name="size">Ҫ����Ϊ�Ĵ�С</param>
        /// <returns>���ź��ͼ��</returns>
        public static Bitmap GetStretchImage(Image originImage, Size size)
        {
            if (originImage == null || size.Width <= 0 || size.Height <= 0)
                return null;

            Bitmap newBitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(originImage, new Rectangle(0, 0, size.Width, size.Height));
            }
            return newBitmap;
        }
    }
}
