using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// ����Բ��·������ʽ��
    /// </summary>
    [Flags]
    public enum RoundStyle : int
    {
        /// <summary>
        /// �ĸ��Ƕ�����Բ�ǡ�
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// ���Ͻ�ΪԲ�ǡ�
        /// </summary>
        TopLeft = 0x0001,
        /// <summary>
        /// ���Ͻ�ΪԲ�ǡ�
        /// </summary>
        TopRight = 0x0002,
        /// <summary>
        /// ���½�ΪԲ��
        /// </summary>
        BottomRight = 0x0004,
        /// <summary>
        /// ���½�ΪԲ�ǡ�
        /// </summary>
        BottomLeft = 0x0008,
        /// <summary>
        /// ���������ΪԲ�ǡ�
        /// </summary>
        Left = 0x0009,
        /// <summary>
        /// �ϱ�������ΪԲ�ǡ�
        /// </summary>
        Top = 0x0003,
        /// <summary>
        /// �ұ�������ΪԲ�ǡ�
        /// </summary>
        Right = 0x0006,
        /// <summary>
        /// �±�������ΪԲ�ǡ�
        /// </summary>
        Bottom = 0x000C,
        /// <summary>
        /// �ĸ��Ƕ�ΪԲ�ǡ�
        /// </summary>
        All = 0x000F,
    }
}
