
namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private bool m_AutoFeedback = false;
        /// <summary>
        /// �Ƿ��Զ�������Owner
        /// </summary>
        public bool AutoFeedback
        {
            get
            {
                return this.m_AutoFeedback;
            }
            set
            {
                if (value != this.m_AutoFeedback)
                {
                    this.m_AutoFeedback = value;
                }
            }
        }

        private IUIControl m_Owner;
        /// <summary>
        /// ���ؼ�
        /// </summary>
        public IUIControl Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        /// <summary>
        /// ��������,��ǿ��
        /// </summary>
        public void Feedback()
        {
            this.Feedback(false);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="force">�Ƿ�ǿ�Ʒ���</param>
        public void Feedback(bool force)
        {
            if (this.m_Owner != null && (force || this.m_AutoFeedback))
                this.m_Owner.Invalidate();
        }
    }
}
