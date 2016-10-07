namespace Microsoft.Win32
{
    //ROP����
    public static partial class NativeMethods
    {
        /// <summary>
        /// ��Դ��������ֱ�ӿ�����Ŀ���������
        /// </summary>
        public const int SRCCOPY = 0x00CC0020;      /* dest = source                   */
        /// <summary>
        /// ͨ��ʹ�ò����͵�OR���򣩲�������Դ��Ŀ������������ɫ�ϲ���
        /// </summary>
        public const int SRCPAINT = 0x00EE0086;     /* dest = source OR dest           */
        /// <summary>
        /// ͨ��ʹ��AND���룩����������Դ��Ŀ����������ڵ���ɫ�ϲ���
        /// </summary>
        public const int SRCAND = 0x008800C6;       /* dest = source AND dest          */
        /// <summary>
        /// ͨ��ʹ�ò����͵�XOR����򣩲�������Դ��Ŀ������������ɫ�ϲ���
        /// </summary>
        public const int SRCINVERT = 0x00660046;    /* dest = source XOR dest          */
        /// <summary>
        /// ͨ��ʹ��AND���룩��������Ŀ�����������ɫȡ������Դ�����������ɫֵ�ϲ���
        /// </summary>
        public const int SRCERASE = 0x00440328;     /* dest = source AND (NOT dest )   */
        /// <summary>
        /// ��Դ����������ɫȡ�����ڿ�����Ŀ���������
        /// </summary>
        public const int NOTSRCCOPY = 0x00330008;   /* dest = (NOT source)             */
        /// <summary>
        /// ʹ�ò������͵�OR���򣩲��������Դ��Ŀ������������ɫֵ��Ȼ�󽫺ϳɵ���ɫȡ����
        /// </summary>
        public const int NOTSRCERASE = 0x001100A6;  /* dest = (NOT src) AND (NOT dest) */
        /// <summary>
        /// ��ʾʹ�ò����͵�AND���룩��������Դ�����������ɫ���ض�ģʽ���һ��
        /// </summary>
        public const int MERGECOPY = 0x00C000CA;    /* dest = (source AND pattern)     */
        /// <summary>
        /// ͨ��ʹ�ò����͵�OR���򣩲������������Դ�����������ɫ��Ŀ������������ɫ�ϲ���
        /// </summary>
        public const int MERGEPAINT = 0x00BB0226;   /* dest = (NOT source) OR dest     */
        /// <summary>
        /// ���ض���ģʽ������Ŀ��λͼ�ϡ�
        /// </summary>
        public const int PATCOPY = 0x00F00021;      /* dest = pattern                  */
        /// <summary>
        /// ͨ��ʹ�ò���OR���򣩲�������Դ��������ȡ�������ɫֵ���ض�ģʽ����ɫ�ϲ���Ȼ��ʹ��OR���򣩲��������ò����Ľ����Ŀ����������ڵ���ɫ�ϲ���
        /// </summary>
        public const int PATPAINT = 0x00FB0A09;     /* dest = DPSnoo                   */
        /// <summary>
        /// ͨ��ʹ��XOR����򣩲�������Դ��Ŀ����������ڵ���ɫ�ϲ���
        /// </summary>
        public const int PATINVERT = 0x005A0049;    /* dest = pattern XOR dest         */
        /// <summary>
        /// ��ʾʹĿ�����������ɫȡ����
        /// </summary>
        public const int DSTINVERT = 0x00550009;    /* dest = (NOT dest)               */
        /// <summary>
        /// ��ʾʹ���������ɫ�������0��ص�ɫ�������Ŀ��������򣬣���ȱʡ�������ɫ����ԣ�����ɫΪ��ɫ����
        /// </summary>
        public const int BLACKNESS = 0x00000042;    /* dest = BLACK                    */
        /// <summary>
        /// ʹ���������ɫ��������1�йص���ɫ���Ŀ��������򡣣�����ȱʡ�����ɫ����˵�������ɫ���ǰ�ɫ����
        /// </summary>
        public const int WHITENESS = 0x00FF0062;    /* dest = WHITE                    */
    }
}
