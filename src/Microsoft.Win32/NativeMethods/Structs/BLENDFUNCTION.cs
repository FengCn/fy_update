using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// BLENDFUNCTION����
    /// </summary>
    public static partial class NativeMethods
    {
        /// <summary>
        /// <para>ʵ�ֹ���:The BLENDFUNCTION structure controls blending by specifying the blending functions for source and destination bitmaps.</para>
        /// <para>���÷���:Win32�ṹ��</para>
        /// <para>.</para>
        /// <para>������Ա:�����</para>
        /// <para>��������:2011-12-23</para>
        /// <para>������ע:</para>
        /// <para>.</para>
        /// <para>�޸���Ա:</para>
        /// <para>�޸�����:</para>
        /// <para>�޸ı�ע:</para>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            /// <summary>
            /// ��Ч��,�սṹ�����ֶ�ΪĬ��ֵ
            /// </summary>
            public static readonly BLENDFUNCTION Empty;
            /// <summary>
            /// һ�������ʹ�ø�ֵ
            /// </summary>
            public static readonly BLENDFUNCTION Default;
            /// <summary>
            /// ��̬����
            /// </summary>
            static BLENDFUNCTION()
            {
                Empty = new BLENDFUNCTION();
                Default = new BLENDFUNCTION(NativeMethods.AC_SRC_OVER, 0, 255, NativeMethods.AC_SRC_ALPHA);
            }

            /// <summary>
            /// ָ��Դ��ϲ�����Ŀǰ��Ψһ��Դ��Ŀ��Ļ�Ϸ�ʽ�Ѷ���ΪAC_SRC_OVER��
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// ������0��
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// ָ��һ��alpha͸����ֵ�����ֵ����������Դλͼ;��SourceConstantAlphaֵ��Դλͼ��ÿ�����ص�alphaֵ���;�������Ϊ0���ͻ�ٶ����ͼƬ��͸����;�����Ҫʹ��ÿ���ر����alphaֵ������SourceConstantAlphaֵ255����͸������
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// �����������Դ��Ŀ��Ľ�����ʽ��AlphaFormat����������ֵ��AC_SRC_ALPHA�� ���ֵ��Դ����Ŀ�걾����Alphaͨ��ʱ��Ҳ���ǲ�����ͼ�������͸��ͨ����Ϣʱ��������ϵͳAPI���ú���ǰ����Ԥ�ȳ���alphaֵ��Ҳ����˵λͼ��ĳ������λ�õ�red��green��blueͨ��ֵ��������alpha��ˡ����磬���alpha͸��ֵ��x����ôred��green��blue����ͨ����ֵ�������x�����ٳ���255����Ϊalpha��ֵ�ķ�Χ��0��255����֮����ܱ����á�
            /// </summary>
            public byte AlphaFormat;

            /// <summary>
            /// ���캯��
            /// </summary>
            /// <param name="op">BlendOp</param>
            /// <param name="flags">BlendFlags</param>
            /// <param name="alpha">SourceConstantAlpha</param>
            /// <param name="format">AlphaFormat</param>
            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                this.BlendOp = op;
                this.BlendFlags = flags;
                this.SourceConstantAlpha = alpha;
                this.AlphaFormat = format;
            }
        }
    }
}
