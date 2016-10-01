using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ��ʱ�޸Ļ�ͼ���������ƫ��ģʽ,�ͷ�ʱ��Ϊԭ��ģʽ
    /// </summary>
    public class PixelOffsetModeGraphics : DisposableMini
    {
        private PixelOffsetMode m_OldMode;  //ԭʼ������ƫ��ģʽ
        private Graphics m_Graphics;        //Ҫ�޸�����ƫ��ģʽ�Ļ�ͼ����

        /// <summary>
        /// ���캯��,��ʱ�޸�ΪĬ������ƫ��
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        public PixelOffsetModeGraphics(Graphics graphics)
            : this(graphics, PixelOffsetMode.Default)
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        /// <param name="newMode">������ƫ��ģʽ</param>
        public PixelOffsetModeGraphics(Graphics graphics, PixelOffsetMode newMode)
        {
            this.m_Graphics = graphics;
            this.m_OldMode = graphics.PixelOffsetMode;
            graphics.PixelOffsetMode = newMode;
        }

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="disposing">�ͷ��й���ԴΪtrue,����Ϊfalse</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.PixelOffsetMode = this.m_OldMode;
                this.m_Graphics = null;
            }
            this.m_OldMode = PixelOffsetMode.Default;
        }
    }
}
