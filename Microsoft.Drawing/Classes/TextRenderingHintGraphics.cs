using System.Drawing;
using System.Drawing.Text;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ��ʱ�޸Ļ�ͼ������ı�����ģʽ,�ͷ�ʱ��Ϊԭ��ģʽ
    /// </summary>
    public class TextRenderingHintGraphics : DisposableMini
    {
        private TextRenderingHint m_OldHint;    //ԭʼ���ı�����ģʽ
        private Graphics m_Graphics;            //Ҫ�޸��ı�����ģʽ�Ļ�ͼ����

        /// <summary>
        /// ���캯��,��ʱ�޸�Ϊ�����
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        public TextRenderingHintGraphics(Graphics graphics)
            : this(graphics, TextRenderingHint.AntiAlias)
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="graphics">��ͼ����</param>
        /// <param name="newHint">���ı�����ģʽ</param>
        public TextRenderingHintGraphics(Graphics graphics, TextRenderingHint newHint)
        {
            this.m_Graphics = graphics;
            this.m_OldHint = graphics.TextRenderingHint;
            graphics.TextRenderingHint = newHint;
        }

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="disposing">�ͷ��й���ԴΪtrue,����Ϊfalse</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_Graphics != null)
            {
                this.m_Graphics.TextRenderingHint = this.m_OldHint;
                this.m_Graphics = null;
            }
            this.m_OldHint = TextRenderingHint.SystemDefault;
        }
    }
}
