using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// ����ɫ��������ٻ��Ƶ����ݵ�����
    /// </summary>
    [Flags]
    public enum AeroStyle : int
    {
        /// <summary>
        /// ������
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// ���ư�͸��ģ��,һ��λ�ڿؼ����������
        /// </summary>
        Blur = 0x0001,
        /// <summary>
        /// ����Բ����Ч��,һ��λ�ڵײ����Ҳ�
        /// </summary>
        Glass = 0x0002,
        /// <summary>
        /// ������Ч��������
        /// </summary>
        All = 0x0003,
    }
}
