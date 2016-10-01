using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Padding m_Padding = new Padding(3);
        /// <summary>
        /// �ı�ͼƬ�ڱ߾�
        /// </summary>
        public Padding Padding
        {
            get
            {
                return this.m_Padding;
            }
            set
            {
                if (value != this.m_Padding)
                {
                    this.m_Padding = value;
                    this.Feedback();
                }
            }
        }

        private TextImageRelation m_TextImageRelation = TextImageRelation.ImageBeforeText;
        /// <summary>
        /// �ı�ͼƬ��ϵ
        /// </summary>
        public TextImageRelation TextImageRelation
        {
            get
            {
                return this.m_TextImageRelation;
            }
            set
            {
                if (value != this.m_TextImageRelation)
                {
                    this.m_TextImageRelation = value;
                    this.Feedback();
                }
            }
        }

        private RightToLeft m_RightToLeft = RightToLeft.No;
        /// <summary>
        /// �ı�ͼƬ���һ���
        /// </summary>
        public RightToLeft RightToLeft
        {
            get
            {
                return this.m_RightToLeft;
            }
            set
            {
                if (value != this.m_RightToLeft)
                {
                    this.m_RightToLeft = value;
                    this.Feedback();
                }
            }
        }
    }
}
