using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Msimg32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiAlphaBlend���ú���������ʾ����ָ��͸���ȵ�ͼ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Դ����������Ŀ����������С��һ������ô������Դλͼ��Ŀ���������ƥ�䡣</para>
        /// <para>���ʹ��SetStretchBltMode��������ôiStretchMode��ֵ��BLACKONWHITE��WHITEONBLACK���ڱ������У�iStretchMode��ֵ�Զ�ת����COLORONCOLOR��</para>
        /// <para>Ŀ������ʹ��ΪĿ���豸������ǰָ����ת����ʽ����ת����</para>
        /// <para>Դ������ʹ��ΪԴ�豸����ָ���ĵ�ǰת����ʽ����ת����</para>
        /// <para>���Դ�豸������ʶΪ��ǿ��ͼԪ�ļ��豸��������ô��������Ҹú�������FALSE����</para>
        /// <para>���Ŀ���Դλͼ��ɫ�ʸ�ʽ��ͬ����ôAlphaBlend��Դλͼת����ƥ��Ŀ��λͼ��</para>
        /// <para>AlphaBlend��֧�־������Դ��Ŀ������Ŀ�Ȼ�߶�Ϊ��������ô���ý�ʧ�ܡ�</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="xoriginDest">ָ��Ŀ������������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginDest">ָ��Ŀ������������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wDest">ָ��Ŀ���������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hDest">ָ��Ŀ���������ĸ߶ȣ����߼���λ��</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="xoriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wSrc">ָ��Դ��������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hSrc">ָ��Դ��������ĸ߶ȣ����߼���λ��</param>
        /// <param name="ftn">ָ������Դλͼ��Ŀ��λͼʹ�õ�alpha��Ϲ��ܣ���������Դλͼ��ȫ��alphaֵ�͸�ʽ��Ϣ��Դ��Ŀ���Ϲ��ܵ�ǰֻ��ΪAC_SRC_OVER�����һ������blendFunction��һ��BLENDFUNCTION�ṹ��BLENDFUNCTION�ṹ����Դ��Ŀ��λͼ�Ļ�Ϸ�ʽ������BlendOp�ֶ�ָ����Դ��ϲ�������ֻ֧��AC_SRC_OVER��������Դalphaֵ��Դͼ����ӵ�Ŀ��ͼ���ϡ�OpenGL��alpha��ϻ�֧�������ķ�ʽ���糣����ɫԴ����һ���ֶ�BlendFlags������0��Ҳ��Ϊ�Ժ��Ӧ�ñ����ġ����һ���ֶ�AlphaFormat������ѡ��0��ʾ����alphaֵ��AC_SRC_ALPHA��ʾÿ�������и��Ե�alphaͨ����</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ���ô����ֵΪFALSE��</returns>
        [DllImport("msimg32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AlphaBlend(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, NativeMethods.BLENDFUNCTION ftn);
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiGradientFill���ú��������κ������νṹ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����ھ��������м���һЩƽ������Ӱ�����ƣ������������ε������������GradientFill������CDI���������Բ�ֵ��������������</para>
        /// <para>�ڻ��ƾ���ʱ����ʹ��������Ӱģʽ��ˮƽģʽ�У����δ������ҿ�ʼ�䰵���ڴ�ֱģʽ�����Ǵ������½��С�</para>
        /// </summary>
        /// <param name="hdc">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="pVertex">ָ��TRIVERTEX�ṹ�����ָ�룬�������е�ÿ����������ζ��㡣</param>
        /// <param name="nVertex">������Ŀ��</param>
        /// <param name="pMesh">������ģʽ�µ�GRADIENT_TRIANGLE�ṹ���飬�����ģʽ�µ�GRADIENT_RECT�ṹ���顣</param>
        /// <param name="nMesh">����pMesh�еĳ�Ա��Ŀ����Щ��Ա�������λ���Σ���</param>
        /// <param name="ulMode">ָ����б���ģʽ���ò������԰�������ֵ����Щֵ�ĺ���Ϊ��</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ��򷵻�ֵΪFALSE��</returns>
        [DllImport("msimg32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GradientFill(IntPtr hdc, IntPtr pVertex, uint nVertex, IntPtr pMesh, uint nMesh, uint ulMode);
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiTransparentBlt���ú�����ָ����Դ�豸�����еľ����������ص���ɫ���ݽ���λ�飨bit_block��ת���������������Ŀ���豸������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����TransparentBlt֧��4λ/���غ�8λ/���ظ�ʽ��Դλͼ��ʹ��AlphaBlend����ָ������͸���ȵ�32λ/���ظ�ʽ��λͼ��</para>
        /// <para>���Դ��Ŀ����εĴ�С��һ�£���ô����Դλͼ������������Ŀ�����ƥ�䣬��ʹ��SetStretchBltMode����ʱ��BLACKONWHITE��WHITEONBLACK����iStretchModeģʽ����ת����TransparentBlt������COLORONCOLORģʽ��</para>
        /// <para>Ŀ���豸����ָ��������Ŀ������ı任���ͣ���Դ�豸����ָ����Դ����ʹ�õı任���͡�</para>
        /// <para>���Դλͼ��Ŀ��λͼ�Ŀ�Ȼ�߶��Ǹ�������ôTransparentBlt����Ҳ����λͼ���о���</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="xoriginDest">ָ��Ŀ������������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginDest">ָ��Ŀ������������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wDest">ָ��Ŀ���������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hDest">ָ��Ŀ���������ĸ߶ȣ����߼���λ��</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="xoriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wSrc">ָ��Դ��������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hSrc">ָ��Դ��������ĸ߶ȣ����߼���λ��</param>
        /// <param name="crTransparent">Դλͼ�е�RGBֵ����͸����ɫ��</param>
        /// <returns>����ֵ���������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ���ô����ֵΪFALSE��</returns>
        [DllImport("msimg32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TransparentBlt(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);
    }
}
