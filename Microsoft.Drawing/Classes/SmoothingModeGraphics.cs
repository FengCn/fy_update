using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ��ʱ�޸Ļ�ͼ�����ƽ��ģʽ,�ͷ�ʱ��Ϊԭ��ģʽ
    /// </summary>
    public sealed class SmoothingModeGraphics : DisposableMini
    {
        private SmoothingMode m_OldMode;    //ԭʼ��ƽ��ģʽ
        private Graphics m_Graphics;        //Ҫ�޸�ƽ��ģʽ�Ļ�ͼ����

        /// <summary>
        /// ���캯��,��ʱ�޸�Ϊ�����
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        public SmoothingModeGraphics(Graphics graphics)
            : this(graphics, SmoothingMode.AntiAlias)
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        /// <param name="newMode">��ƽ��ģʽ</param>
        public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
        {
            this.m_Graphics = graphics;
            this.m_OldMode = graphics.SmoothingMode;
            graphics.SmoothingMode = newMode;
        }

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="disposing">�ͷ��й���ԴΪtrue,����Ϊfalse</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.SmoothingMode = this.m_OldMode;
                this.m_Graphics = null;
            }
            this.m_OldMode = SmoothingMode.Default;
        }
    }
}
