using System.ComponentModel;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// ͼԪ����
    /// </summary>
    [Browsable(false)]
    public partial class Sprite : Disposable
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Sprite()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="owner">������</param>
        public Sprite(IUIControl owner)
        {
            this.m_Owner = owner;
        }
    }
}
