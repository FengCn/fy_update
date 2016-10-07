using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Winmm.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú������صĴ����������mciGetErrorString�������з�����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// </summary>
        /// <param name="fdwError">����mciSendString���صĴ�����</param>
        /// <param name="lpszErrorText">��������������ַ����Ļ�����</param>
        /// <param name="cchErrorText">�������ĳ���</param>
        /// <returns>����������гɹ�������ֵΪTRUE�������������ʧ�ܣ�����ֵΪFALSE��</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern bool mciGetErrorString(int fdwError, ref string lpszErrorText, uint cchErrorText);
        /// <summary>
        /// <para>����:</para>
        /// <para>Ӧ�ó���ͨ����MCI��������������ý���豸��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// </summary>
        /// <param name="lpszCommand">MCI�����ַ���</param>
        /// <param name="lpszReturnString">��ŷ�����Ϣ�Ļ�����</param>
        /// <param name="cchReturn">�������ĳ���</param>
        /// <param name="hwndCallback">�ص����ڵľ����һ��ΪNULL</param>
        /// <returns>����������гɹ�������ֵΪ�㣻�����������ʧ�ܣ�����ֵΪ���㡣</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string lpszCommand, ref string lpszReturnString, uint cchReturn, IntPtr hwndCallback);


        /// <summary>
        /// The mmioAscend function ascends out of a chunk in a RIFF file descended into with the mmioDescend function or created with the mmioCreateChunk function.
        /// </summary>
        /// <param name="hMIO">File handle of an open RIFF file.</param>
        /// <param name="lpck">Pointer to an application-defined MMCKINFO structure previously filled by the mmioDescend or mmioCreateChunk function.</param>
        /// <param name="flags">Reserved; must be zero.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</returns>
        /// <summary>
        /// <para>Return code	Description</para>
        /// <para>MMIOERR_CANNOTSEEK</para>
        /// <para>There was an error while seeking to the end of the chunk.</para>
        /// <para>.</para>
        /// <para>MMIOERR_CANNOTWRITE</para>
        /// <para>The contents of the buffer could not be written to disk.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioAscend(IntPtr hMIO, NativeMethods.MMCKINFO lpck, int flags);
        /// <summary>
        /// The mmioClose function closes a file that was opened by using the mmioOpen function.
        /// </summary>
        /// <param name="hMIO">File handle of the file to close.</param>
        /// <param name="flags">Flags for the close operation. The following value is defined.</param>
        /// <summary>
        /// <para>Value	 Meaning</para>
        /// <para>MMIO_FHOPEN	If the file was opened by passing a file handle whose type is not HMMIO, using this flag tells the mmioClose function to close the multimedia file handle, but not the standard file handle.</para>
        /// </summary>
        /// <returns>Returns zero if successful or an error otherwise. The error value can originate from the mmioFlush function or from the I/O procedure. Possible error values include the following.</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioClose(IntPtr hMIO, int flags);
        /// <summary>
        /// The mmioDescend function descends into a chunk of a RIFF file that was opened by using the mmioOpen function. It can also search for a given chunk.
        /// </summary>
        /// <param name="hMIO">File handle of an open RIFF file.</param>
        /// <param name="lpck">Pointer to a buffer that receives an MMCKINFO structure.</param>
        /// <param name="lcpkParent">ointer to an optional application-defined MMCKINFO structure identifying the parent of the chunk being searched for. If this parameter is not NULL, mmioDescend assumes the MMCKINFO structure it refers to was filled when mmioDescend was called to descend into the parent chunk, and mmioDescend searches for a chunk within the parent chunk. Set this parameter to NULL if no parent chunk is being specified.</param>
        /// <param name="flags">Search flags. If no flags are specified, mmioDescend descends into the chunk beginning at the current file position. The following values are defined.</param>
        /// <summary>
        /// <para>Value	Meaning</para>
        /// <para>MMIO_FINDCHUNK	Searches for a chunk with the specified chunk identifier.</para>
        /// <para>MMIO_FINDLIST	Searches for a chunk with the chunk identifier &quot;LIST&quot; and with the specified form type.</para>
        /// <para>MMIO_FINDRIFF	Searches for a chunk with the chunk identifier &quot;RIFF&quot; and with the specified form type.</para>
        /// </summary>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</returns>
        /// <summary>
        /// <para>Value	Description</para>
        /// <para>MMIOERR_CHUNKNOTFOUND	The end of the file (or the end of the parent chunk, if given) was reached before the desired chunk was found.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioDescend(IntPtr hMIO, [MarshalAs(UnmanagedType.LPStruct)] NativeMethods.MMCKINFO lpck, [MarshalAs(UnmanagedType.LPStruct)] NativeMethods.MMCKINFO lcpkParent, int flags);
        /// <summary>
        /// The mmioOpen function opens a file for unbuffered or buffered I/O. The file can be a standard file, a memory file, or an element of a custom storage system. The handle returned by mmioOpen is not a standard file handle; do not use it with any file I/O functions other than multimedia file I/O functions.
        /// </summary>
        /// <param name="fileName">Pointer to a string containing the file name of the file to open. If no I/O procedure is specified to open the file, the file name determines how the file is opened, as follows:</param>
        /// <param name="not_used">Pointer to an MMIOINFO structure containing extra parameters used by mmioOpen. Unless you are opening a memory file, specifying the size of a buffer for buffered I/O, or specifying an uninstalled I/O procedure to open a file, this parameter should be NULL. If this parameter is not NULL, all unused members of the MMIOINFO structure it references must be set to zero, including the reserved members.</param>
        /// <param name="flags">Flags for the open operation. The MMIO_READ, MMIO_WRITE, and MMIO_READWRITE flags are mutually exclusive �� only one should be specified. The MMIO_COMPAT, MMIO_EXCLUSIVE, MMIO_DENYWRITE, MMIO_DENYREAD, and MMIO_DENYNONE flags are file-sharing flags. The following values are defined.</param>
        /// <summary>
        /// <para>Value	Meaning</para>
        /// <para>MMIO_ALLOCBUF	Opens a file for buffered I/O. To allocate a buffer larger or smaller than the default buffer size (8K, defined as MMIO_DEFAULTBUFFER), set the cchBuffer member of the MMIOINFO structure to the desired buffer size. If cchBuffer is zero, the default buffer size is used. If you are providing your own I/O buffer, this flag should not be used.</para>
        /// <para>MMIO_COMPAT	Opens the file with compatibility mode, allowing any process on a given machine to open the file any number of times. If the file has been opened with any of the other sharing modes, mmioOpen fails.</para>
        /// <para>MMIO_CREATE	Creates a new file. If the file already exists, it is truncated to zero length. For memory files, this flag indicates the end of the file is initially at the start of the buffer.</para>
        /// <para>MMIO_DELETE	Deletes a file. If this flag is specified, szFilename should not be NULL. The return value is TRUE (cast to HMMIO) if the file was deleted successfully or FALSE otherwise. Do not call the mmioClose function for a file that has been deleted. If this flag is specified, all other flags that open files are ignored.</para>
        /// <para>MMIO_DENYNONE	Opens the file without denying other processes read or write access to the file. If the file has been opened in compatibility mode by any other process, mmioOpen fails.</para>
        /// <para>MMIO_DENYREAD	Opens the file and denies other processes read access to the file. If the file has been opened in compatibility mode or for read access by any other process, mmioOpen fails.</para>
        /// <para>MMIO_DENYWRITE	Opens the file and denies other processes write access to the file. If the file has been opened in compatibility mode or for write access by any other process, mmioOpen fails.</para>
        /// <para>MMIO_EXCLUSIVE	Opens the file and denies other processes read and write access to the file. If the file has been opened in any other mode for read or write access, even by the current process, mmioOpen fails.</para>
        /// <para>MMIO_EXIST	Determines whether the specified file exists and creates a fully qualified file name from the path specified in szFilename. The file name is placed back into szFilename. The return value is TRUE (cast to HMMIO) if the qualification was successful and the file exists or FALSE otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file.</para>
        /// <para>MMIO_GETTEMP	Creates a temporary file name, optionally using the parameters passed in szFilename. For example, you can specify &quot;C:F&quot; to create a temporary file residing on drive C, starting with letter &quot;F&quot;. The resulting file name is placed in the buffer pointed to by szFilename. The return value is MMSYSERR_NOERROR (cast to HMMIO) if the temporary file name was created successfully or MMIOERR_FILENOTFOUND otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file. This flag overrides all other flags.</para>
        /// <para>MMIO_PARSE	Creates a fully qualified file name from the path specified in szFilename. The file name is placed back into szFilename. The return value is TRUE (cast to HMMIO) if the qualification was successful or FALSE otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file. If this flag is specified, all flags that open files are ignored.</para>
        /// <para>MMIO_READ	Opens the file for reading only. This is the default if MMIO_WRITE and MMIO_READWRITE are not specified.</para>
        /// <para>MMIO_READWRITE	Opens the file for reading and writing.</para>
        /// <para>MMIO_WRITE	Opens the file for writing only.</para>
        /// </summary>
        /// <returns>Returns a handle of the opened file. If the file cannot be opened, the return value is NULL. If lpmmioinfo is not NULL, the wErrorRet member of the MMIOINFO structure will contain one of the following error values.</returns>
        /// <summary>
        /// <para>Value	Description</para>
        /// <para>MMIOERR_ACCESSDENIED	The file is protected and cannot be opened.</para>
        /// <para>MMIOERR_INVALIDFILE	Another failure condition occurred. This is the default error for an open-file failure.</para>
        /// <para>MMIOERR_NETWORKERROR	The network is not responding to the request to open a remote file.</para>
        /// <para>MMIOERR_PATHNOTFOUND	The directory specification is incorrect.</para>
        /// <para>MMIOERR_SHARINGVIOLATION	The file is being used by another application and is unavailable.</para>
        /// <para>MMIOERR_TOOMANYOPENFILES	The number of files simultaneously open is at a maximum level. The system has run out of available file handles.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr mmioOpen(string fileName, IntPtr not_used, int flags);
        /// <summary>
        /// The mmioRead function reads a specified number of bytes from a file opened by using the mmioOpen function.
        /// </summary>
        /// <param name="hMIO">File handle of the file to be read.</param>
        /// <param name="wf">Pointer to a buffer to contain the data read from the file.</param>
        /// <param name="cch">Number of bytes to read from the file.</param>
        /// <returns>Returns the number of bytes actually read. If the end of the file has been reached and no more bytes can be read, the return value is 0. If there is an error reading from the file, the return value is - 1.</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioRead(IntPtr hMIO, [MarshalAs(UnmanagedType.LPArray)] byte[] wf, int cch);


        /// <summary>
        /// <para>����:</para>
        /// <para>������Ƶ(�ļ���,��Դ��,ϵͳ�¼�����)</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// <para>.</para>
        /// <para>���б�־�ɱ������ڲ���fdwSound��:</para>
        /// <para>SND_SYNC��ͬ�������������ڲ������PlaySound�����ŷ��ء�</para>
        /// <para>SND_ASYNC�����첽��ʽ����������PlaySound�����ڿ�ʼ���ź��������ء�</para>
        /// <para>SND_NODEFAULT��������ȱʡ���������޴˱�־����PlaySound��û�ҵ�����ʱ�Ქ��ȱʡ������</para>
        /// <para>SND_MEMORY���������뵽�ڴ��е���������ʱpszSound��ָ���������ݵ�ָ�롣</para>
        /// <para>SND_LOOP���ظ�����������������SND_ASYNC��־һ��ʹ�á�</para>
        /// <para>SND_NOSTOP��PlaySound�����ԭ����������������������FALSE��</para>
        /// <para>SND_PURGE��ֹͣ��������������йص�������������pszSoundΪNULL����ֹͣ���е�����������ֹͣpszSoundָ����������</para>
        /// <para>SND_NOWAIT���������������æ�����Ͳ������������������ء�</para>
        /// <para>SND_ALIAS��pszSound����ָ����ע����WIN.INI�е�ϵͳ�¼��ı�����</para>
        /// <para>SND_ALIAS_ID��pszSound����ָ����Ԥ�����������ʶ����</para>
        /// <para>SND_FILENAME��pszSound����ָ����WAVE�ļ�����</para>
        /// <para>SND_RESOURCE��pszSound������WAVE��Դ�ı�ʶ������ʱҪ�õ�hmod������</para>
        /// </summary>
        /// <param name="soundName">ָ����Ҫ�����������ַ������ò���������WAVE�ļ������֣�����WAV��Դ�����֣������ڴ����������ݵ�ָ�룬������ϵͳע���WIN.INI�ж����ϵͳ�¼�����������ò���ΪNULL��ֹͣ���ڲ��ŵ�������</param>
        /// <param name="hmod">Ӧ�ó����ʵ�����������pszSound��ָ��һ����Դ��ʶ������fdwSound������ΪSND_RESOURCE���������������ΪNULL��</param>
        /// <param name="soundFlags">��־����ϡ�</param>
        /// <returns>���ɹ���������TRUE�����򷵻�FALSE��</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern bool PlaySound([MarshalAs(UnmanagedType.LPWStr)] string soundName, IntPtr hmod, int soundFlags);
        /// <summary>
        /// <para>����:</para>
        /// <para>������Ƶ(�ļ���,��Դ��,ϵͳ�¼�����)</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// <para>.</para>
        /// <para>���б�־�ɱ������ڲ���fdwSound��:</para>
        /// <para>SND_SYNC��ͬ�������������ڲ������PlaySound�����ŷ��ء�</para>
        /// <para>SND_ASYNC�����첽��ʽ����������PlaySound�����ڿ�ʼ���ź��������ء�</para>
        /// <para>SND_NODEFAULT��������ȱʡ���������޴˱�־����PlaySound��û�ҵ�����ʱ�Ქ��ȱʡ������</para>
        /// <para>SND_MEMORY���������뵽�ڴ��е���������ʱpszSound��ָ���������ݵ�ָ�롣</para>
        /// <para>SND_LOOP���ظ�����������������SND_ASYNC��־һ��ʹ�á�</para>
        /// <para>SND_NOSTOP��PlaySound�����ԭ����������������������FALSE��</para>
        /// <para>SND_PURGE��ֹͣ��������������йص�������������pszSoundΪNULL����ֹͣ���е�����������ֹͣpszSoundָ����������</para>
        /// <para>SND_NOWAIT���������������æ�����Ͳ������������������ء�</para>
        /// <para>SND_ALIAS��pszSound����ָ����ע����WIN.INI�е�ϵͳ�¼��ı�����</para>
        /// <para>SND_ALIAS_ID��pszSound����ָ����Ԥ�����������ʶ����</para>
        /// <para>SND_FILENAME��pszSound����ָ����WAVE�ļ�����</para>
        /// <para>SND_RESOURCE��pszSound������WAVE��Դ�ı�ʶ������ʱҪ�õ�hmod������</para>
        /// </summary>
        /// <param name="soundName">ָ����Ҫ�����������ַ������ò���������WAVE�ļ������֣�����WAV��Դ�����֣������ڴ����������ݵ�ָ�룬������ϵͳע���WIN.INI�ж����ϵͳ�¼�����������ò���ΪNULL��ֹͣ���ڲ��ŵ�������</param>
        /// <param name="hmod">Ӧ�ó����ʵ�����������pszSound��ָ��һ����Դ��ʶ������fdwSound������ΪSND_RESOURCE���������������ΪNULL��</param>
        /// <param name="soundFlags">��־����ϡ�</param>
        /// <returns>���ɹ���������TRUE�����򷵻�FALSE��</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool PlaySound(byte[] soundName, IntPtr hmod, int soundFlags);
        /// <summary>
        /// <para>����:</para>
        /// <para>������Ƶ(�ڴ����������ݵ�ָ��)</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// <para>.</para>
        /// <para>���б�־�ɱ������ڲ���fdwSound��:</para>
        /// <para>SND_SYNC��ͬ�������������ڲ������PlaySound�����ŷ��ء�</para>
        /// <para>SND_ASYNC�����첽��ʽ����������PlaySound�����ڿ�ʼ���ź��������ء�</para>
        /// <para>SND_NODEFAULT��������ȱʡ���������޴˱�־����PlaySound��û�ҵ�����ʱ�Ქ��ȱʡ������</para>
        /// <para>SND_MEMORY���������뵽�ڴ��е���������ʱpszSound��ָ���������ݵ�ָ�롣</para>
        /// <para>SND_LOOP���ظ�����������������SND_ASYNC��־һ��ʹ�á�</para>
        /// <para>SND_NOSTOP��PlaySound�����ԭ����������������������FALSE��</para>
        /// <para>SND_PURGE��ֹͣ��������������йص�������������pszSoundΪNULL����ֹͣ���е�����������ֹͣpszSoundָ����������</para>
        /// <para>SND_NOWAIT���������������æ�����Ͳ������������������ء�</para>
        /// <para>SND_ALIAS��pszSound����ָ����ע����WIN.INI�е�ϵͳ�¼��ı�����</para>
        /// <para>SND_ALIAS_ID��pszSound����ָ����Ԥ�����������ʶ����</para>
        /// <para>SND_FILENAME��pszSound����ָ����WAVE�ļ�����</para>
        /// <para>SND_RESOURCE��pszSound������WAVE��Դ�ı�ʶ������ʱҪ�õ�hmod������</para>
        /// </summary>
        /// <param name="pszSound">ָ����Ҫ�����������ַ������ò���������WAVE�ļ������֣�����WAV��Դ�����֣������ڴ����������ݵ�ָ�룬������ϵͳע���WIN.INI�ж����ϵͳ�¼�����������ò���ΪNULL��ֹͣ���ڲ��ŵ�������</param>
        /// <param name="hMod">Ӧ�ó����ʵ�����������pszSound��ָ��һ����Դ��ʶ������fdwSound������ΪSND_RESOURCE���������������ΪNULL��</param>
        /// <param name="fdwSound">��־����ϡ�</param>
        /// <returns>���ɹ���������TRUE�����򷵻�FALSE��</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool PlaySound(IntPtr pszSound, IntPtr hMod, uint fdwSound);
    }
}
