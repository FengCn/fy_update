using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// �ú������޶��Ŀ�ִ���ļ�����̬���ӿ⣨DLL��������ͼ���ļ�������ͼ�������顣
        /// </summary>
        /// <param name="lpszFile">����ɻ�ȡͼ��Ŀ�ִ���ļ���DLL,����ͼ���ļ������ֵĿս����ַ���ָ�롣</param>
        /// <param name="nIconIndex">ָ����ȡ��һ��ͼ�������ı�ַ�����磬�����ֵ���㣻�������޶����ļ��г�ȡ��һͼ�ꣻ���ֵ��C1��phlconLarge��phiconSmall������ΪNULL�����������޶��ļ���ͼ�������������ļ��ǿ�ִ���ļ���DLL������ֵ��RT_GROUP_ICON��Դ����Ŀ������ļ���һ��ICO�ļ�������ֵ��1����Windows95��WindowsNT4.0,�͸��߰汾�У����ֵΪ������phlconLarge��phiconSmall����ΪNULL�������ӻ�ȡͼ�꿪ʼ����ͼ�����Դ��ʶ������nlconlndex����ֵ�����磬ʹ��-3����ȡ��Դ��ʶ��Ϊ3��ͼ�ꡣ</param>
        /// <param name="phIconLarge">ָ��ͼ���������ָ�룬���ɽ��մ��ļ���ȡ�Ĵ�ͼ��ľ��������ò�����NULLû�д��ļ���ȡ��ͼ�ꡣ</param>
        /// <param name="phIconSmall">ָ��ͼ���������ָ�룬���ɽ��մ��ļ���ȡ��Сͼ��ľ��������ò�����NULL��û�д��ļ���ȡСͼ�ꡣ</param>
        /// <param name="nIcons">ָ��Ҫ���ļ��г�ȡͼ�����Ŀ��</param>
        /// <returns>���nlconlndex������-1��PhiconLarge��PhiconSmall������NULL������ֵ�ǰ�����ָ���ļ��е�ͼ����Ŀ�����򣬷���ֵ�ǳɹ��ش��ļ��л�ȡͼ�����Ŀ��</returns>
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phIconLarge, IntPtr[] phIconSmall, uint nIcons);
    }
}
