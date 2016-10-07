namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// �ؼ���״̬��(Disabled)(Focused��Noraml,Hovered,Pressed���)
    /// </summary>
    public enum State : int
    {
        /// <summary>
        /// ����
        /// </summary>
        Normal = 0,
        /// <summary>
        /// ��������
        /// </summary>
        NormalFocused = 1,
        /// <summary>
        /// �������
        /// </summary>
        Hovered = 2,
        /// <summary>
        /// ������Ͻ���
        /// </summary>
        HoveredFocused = 3,
        /// <summary>
        /// ��갴��
        /// </summary>
        Pressed = 4,
        /// <summary>
        /// ��갴�½���
        /// </summary>
        PressedFocused = 5,
        /// <summary>
        /// ����
        /// </summary>
        Disabled = 6,
        /// <summary>
        /// ����
        /// </summary>
        Hidden = 7,
        /// <summary>
        /// ����ͻ��
        /// </summary>
        Highlight = 8,
    }
}
