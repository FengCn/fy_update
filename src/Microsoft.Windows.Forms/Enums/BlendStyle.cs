namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// �����ʽ
    /// </summary>
    public enum BlendStyle : int
    {
        /// <summary>
        /// ��ɫ
        /// </summary>
        Solid = 0,
        /// <summary>
        /// ����
        /// </summary>
        Gradient = 1,
        /// <summary>
        /// Alphaͨ����0����ָ��ֵ-����
        /// </summary>
        FadeIn = 2,
        /// <summary>
        /// Alphaͨ����ָ��ֵ����0-����
        /// </summary>
        FadeOut = 3,
        /// <summary>
        /// Alphaͨ����0����ָ��ֵ�ٽ��䵽0-���Խ���
        /// </summary>
        FadeInFadeOut = 4,
    }
}
