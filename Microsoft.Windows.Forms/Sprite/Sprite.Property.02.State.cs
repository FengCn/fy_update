using System;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        /// <summary>
        /// ״̬�ı��¼��������
        /// </summary>
        private static readonly object EVENT_STATE_CHANGED = new object();

        private State m_State = State.Normal;
        /// <summary>
        /// ��ť״̬
        /// </summary>
        public State State
        {
            get
            {
                return this.m_State;
            }
            set
            {
                if (value != this.m_State)
                {
                    this.m_State = value;
                    this.Feedback();
                    this.OnStateChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// ��ť״̬�ı����
        /// </summary>
        public event EventHandler StateChanged
        {
            add { this.Events.AddHandler(EVENT_STATE_CHANGED, value); }
            remove { this.Events.RemoveHandler(EVENT_STATE_CHANGED, value); }
        }

        /// <summary>
        /// ��ť״̬�ı��¼�����
        /// </summary>
        /// <param name="e">����</param>
        protected virtual void OnStateChanged(EventArgs e)
        {
            EventHandler handler = this.Events[EVENT_STATE_CHANGED] as EventHandler;
            if (handler != null)
                handler(this, e);
        }
    }
}
