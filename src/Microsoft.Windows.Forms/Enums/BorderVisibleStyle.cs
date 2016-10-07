using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// �߿���ʽ
    /// </summary>
    [Flags]
    public enum BorderVisibleStyle : int
    {
        /// <summary>
        /// ��
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// ��߿�
        /// </summary>
        Left = 0x0001,
        /// <summary>
        /// �ϱ߿�
        /// </summary>
        Top = 0x0002,
        /// <summary>
        /// �ұ߿�
        /// </summary>
        Right = 0x0004,
        /// <summary>
        /// �±߿�
        /// </summary>
        Bottom = 0x0008,
        /// <summary>
        /// ���б߿�
        /// </summary>
        All = 0x000F,
    }
}
