namespace Microsoft.Win32
{
    //SND����
    public static partial class NativeMethods
    {
        /// <summary>
        /// ͬ�������������ڲ������PlaySound�����ŷ��ء�
        /// </summary>
        public const int SND_SYNC = 0;
        /// <summary>
        /// ���첽��ʽ����������PlaySound�����ڿ�ʼ���ź��������ء�
        /// </summary>
        public const int SND_ASYNC = 1;
        /// <summary>
        /// ������ȱʡ���������޴˱�־����PlaySound��û�ҵ�����ʱ�Ქ��ȱʡ������
        /// </summary>
        public const int SND_NODEFAULT = 2;
        /// <summary>
        /// �������뵽�ڴ��е���������ʱpszSound��ָ���������ݵ�ָ�롣
        /// </summary>
        public const int SND_MEMORY = 4;
        /// <summary>
        /// �ظ�����������������SND_ASYNC��־һ��ʹ�á�
        /// </summary>
        public const int SND_LOOP = 8;
        /// <summary>
        /// PlaySound�����ԭ����������������������FALSE��
        /// </summary>
        public const int SND_NOSTOP = 0x10;
        /// <summary>
        /// ֹͣ��������������йص�������������pszSoundΪNULL����ֹͣ���е�����������ֹͣpszSoundָ����������
        /// </summary>
        public const int SND_PURGE = 0x40;
        /// <summary>
        /// pszSound����ָ����WAVE�ļ�����
        /// </summary>
        public const int SND_FILENAME = 0x20000;
    }
}
