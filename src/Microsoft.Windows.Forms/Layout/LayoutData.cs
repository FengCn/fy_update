using System.Drawing;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms.Layout
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class LayoutData : DisposableMini
    {
        /// <summary>
        /// �����û�ͼ����
        /// </summary>
        public Graphics Graphics;

        /// <summary>
        /// ����
        /// </summary>
        public Rectangle ClientRectangle;
        /// <summary>
        /// �߾�
        /// </summary>
        public Padding Padding;
        /// <summary>
        /// �ı�ͼƬ���λ��
        /// </summary>
        public TextImageRelation TextImageRelation;
        /// <summary>
        /// ���ҷ�ת��ʽ
        /// </summary>
        public RightToLeft RightToLeft;

        /// <summary>
        /// ͼƬ��С
        /// </summary>
        public Size ImageSize;
        /// <summary>
        /// ͼƬ���뷽ʽ
        /// </summary>
        public ContentAlignment ImageAlign;
        /// <summary>
        /// ͼƬƫ����
        /// </summary>
        public Point ImageOffset;

        /// <summary>
        /// �ı�
        /// </summary>
        public string Text;
        /// <summary>
        /// ����
        /// </summary>
        public Font Font;
        /// <summary>
        /// �ı����뷽ʽ
        /// </summary>
        public ContentAlignment TextAlign;
        /// <summary>
        /// �ı�ƫ����
        /// </summary>
        public Point TextOffset;

        /// <summary>
        /// ���-ͼƬ����(�����ȵ���Layout()����)
        /// </summary>
        public Rectangle OutImageBounds;//[OUT]
        /// <summary>
        /// ���-�ı�����(�����ȵ���Layout()����)
        /// </summary>
        public Rectangle OutTextBounds;//[OUT]


        //==================

        private bool m_IsLayouted;
        /// <summary>
        /// �Ƿ�ִ�й����ֲ���
        /// </summary>
        public bool IsLayouted
        {
            get
            {
                return this.m_IsLayouted;
            }
        }


        private Rectangle? m_CurrentClientRectangle;
        /// <summary>
        /// ��ǰ����,�Ѽ�ȥ�߾�
        /// </summary>
        public Rectangle CurrentClientRectangle
        {
            get
            {
                if (this.m_CurrentClientRectangle == null)
                    this.m_CurrentClientRectangle = RectangleEx.Subtract(this.ClientRectangle, this.Padding);
                return this.m_CurrentClientRectangle.Value;
            }
        }

        private TextImageRelation? m_CurrentTextImageRelation;
        /// <summary>
        /// ��ǰ�ı�ͼƬ���λ��,��ͨ�����ҷ�ת��ʽ����
        /// </summary>
        public TextImageRelation CurrentTextImageRelation
        {
            get
            {
                if (this.m_CurrentTextImageRelation == null)
                    this.m_CurrentTextImageRelation = LayoutOptions.RtlTranslateRelation(this.TextImageRelation, this.RightToLeft);
                return this.m_CurrentTextImageRelation.Value;
            }
        }

        private StringFormat m_CurrentStringFormat;
        /// <summary>
        /// ��ǰ�ı���ʽ,��Ⱦ�ı�ʱʹ��
        /// </summary>
        public StringFormat CurrentStringFormat
        {
            get
            {
                if (this.m_CurrentStringFormat == null)
                    this.m_CurrentStringFormat = LayoutOptions.GetStringFormat(this.TextAlign, this.RightToLeft);
                return this.m_CurrentStringFormat;
            }
        }

        private ContentAlignment? m_CurrentImageAlign;
        /// <summary>
        /// ��ǰͼƬ���뷽ʽ,��ͨ�����ҷ�ת��ʽ����
        /// </summary>
        public ContentAlignment CurrentImageAlign
        {
            get
            {
                if (this.m_CurrentImageAlign == null)
                    this.m_CurrentImageAlign = LayoutOptions.RtlTranslateAlignment(this.ImageAlign, this.RightToLeft);
                return this.m_CurrentImageAlign.Value;
            }
        }

        private ContentAlignment? m_CurrentTextAlign;
        /// <summary>
        /// ��ǰ�ı����뷽ʽ,��ͨ�����ҷ�ת��ʽ����
        /// </summary>
        public ContentAlignment CurrentTextAlign
        {
            get
            {
                if (this.m_CurrentTextAlign == null)
                    this.m_CurrentTextAlign = LayoutOptions.RtlTranslateAlignment(this.TextAlign, this.RightToLeft);
                return this.m_CurrentTextAlign.Value;
            }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        public LayoutData()
        {
        }

        /// <summary>
        /// �����ı���ͼƬ.�÷����ɱ����ö��,�������������ڲ��ֲ���ֻ�ᱻִ��һ��.
        /// </summary>
        public void DoLayout()
        {
            if (this.m_IsLayouted)
                return;
            this.m_IsLayouted = true;
            LayoutOptions.LayoutTextAndImage(this);
        }

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="disposing">�ͷ��й���ԴΪtrue,����Ϊfalse</param>
        protected override void Dispose(bool disposing)
        {
            if (this.m_CurrentStringFormat != null)
            {
                this.m_CurrentStringFormat.Dispose();
                this.m_CurrentStringFormat = null;
            }
        }
    }
}
