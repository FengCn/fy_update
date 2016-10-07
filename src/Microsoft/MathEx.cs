using System;

namespace Microsoft
{
    /// <summary>
    /// Math����չ
    /// Copyright (c) JajaSoft
    /// </summary>
    public static class MathEx
    {
        #region �ֶ�

        /// <summary>
        /// E
        /// </summary>
        public const float E = 2.718282f;
        /// <summary>
        /// Log10E
        /// </summary>
        public const float Log10E = 0.4342945f;
        /// <summary>
        /// Log2E
        /// </summary>
        public const float Log2E = 1.442695f;
        /// <summary>
        /// Pi
        /// </summary>
        public const float Pi = 3.141593f;
        /// <summary>
        /// Pi/2
        /// </summary>
        public const float PiOver2 = 1.570796f;
        /// <summary>
        /// Pi/4
        /// </summary>
        public const float PiOver4 = 0.7853982f;
        /// <summary>
        /// Pi*2
        /// </summary>
        public const float TwoPi = 6.283185f;
        /// <summary>
        /// Double���͵� 180d / Math.PI
        /// </summary>
        public const double Double180OverPi = 180d / Math.PI;
        /// <summary>
        /// Double���͵� Math.PI / 180d
        /// </summary>
        public const double DoublePiOver180 = Math.PI / 180d;
        /// <summary>
        /// Single���͵� 180d / Math.PI
        /// </summary>
        public const float Single180OverPi = (float)Double180OverPi;
        /// <summary>
        /// Single���͵� Math.PI / 180d
        /// </summary>
        public const float SinglePiOver180 = (float)DoublePiOver180;

        #endregion

        #region ����

        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Byte Clamp(Byte value, Byte min, Byte max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Decimal Clamp(Decimal value, Decimal min, Decimal max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Double Clamp(Double value, Double min, Double max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Int16 Clamp(Int16 value, Int16 min, Int16 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Int32 Clamp(Int32 value, Int32 min, Int32 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Int64 Clamp(Int64 value, Int64 min, Int64 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static SByte Clamp(SByte value, SByte min, SByte max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static Single Clamp(Single value, Single min, Single max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static UInt16 Clamp(UInt16 value, UInt16 min, UInt16 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static UInt32 Clamp(UInt32 value, UInt32 min, UInt32 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }
        /// <summary>
        /// ����ָ����Χ�ڵ��޶�ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="min">��Сֵ</param>
        /// <param name="max">���ֵ</param>
        /// <returns>�޶�ֵ</returns>
        public static UInt64 Clamp(UInt64 value, UInt64 min, UInt64 max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        /// <summary>
        /// ����ת��Ϊ�Ƕ�
        /// </summary>
        /// <param name="radians">����</param>
        /// <returns>�Ƕ�</returns>
        public static Double ToDegrees(Double radians)
        {
            return (radians * Double180OverPi);
        }
        /// <summary>
        /// ����ת��Ϊ�Ƕ�
        /// </summary>
        /// <param name="radians">����</param>
        /// <returns>�Ƕ�</returns>
        public static Single ToDegrees(Single radians)
        {
            return (radians * Single180OverPi);
        }
        /// <summary>
        /// �Ƕ�ת��Ϊ����
        /// </summary>
        /// <param name="degrees">�Ƕ�</param>
        /// <returns>����</returns>
        public static Double ToRadians(Double degrees)
        {
            return (degrees * DoublePiOver180);
        }
        /// <summary>
        /// �Ƕ�ת��Ϊ����
        /// </summary>
        /// <param name="degrees">�Ƕ�</param>
        /// <returns>����</returns>
        public static Single ToRadians(Single degrees)
        {
            return (degrees * SinglePiOver180);
        }

        #endregion
    }
}
