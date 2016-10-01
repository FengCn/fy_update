namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private CornerStyle m_RoundCornerStyle = CornerStyle.None;
        /// <summary>
        /// Բ��������ʽ
        /// </summary>
        public CornerStyle RoundCornerStyle
        {
            get
            {
                return this.m_RoundCornerStyle;
            }
            set
            {
                if (value != this.m_RoundCornerStyle)
                {
                    this.m_RoundCornerStyle = value;
                    this.Feedback();
                }
            }
        }

        private RoundStyle m_RoundStyle = RoundStyle.None;
        /// <summary>
        /// Բ����ʽ
        /// </summary>
        public RoundStyle RoundStyle
        {
            get
            {
                return this.m_RoundStyle;
            }
            set
            {
                if (value != this.m_RoundStyle)
                {
                    this.m_RoundStyle = value;
                    this.Feedback();
                }
            }
        }

        private float m_RoundRadius = 0f;
        /// <summary>
        /// Բ�ǰ뾶
        /// </summary>
        public float RoundRadius
        {
            get
            {
                return this.m_RoundRadius;
            }
            set
            {
                if (value != this.m_RoundRadius)
                {
                    this.m_RoundRadius = value < 0f ? 0f : value;
                    this.Feedback();
                }
            }
        }
    }
}
