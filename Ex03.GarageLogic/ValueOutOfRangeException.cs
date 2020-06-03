using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_errorMessage;
        private Exception m_InnerException;
        //-----------------------------------------------------------------//
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_Message) : base(i_Message)
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
            this.m_errorMessage = i_Message;
        }
        //-----------------------------------------------------------------//
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_Message, Exception i_InnerException) :
            this(i_MaxValue, i_MinValue, i_Message)
        {
            this.m_InnerException = i_InnerException;
        }
        //-----------------------------------------------------------------//
        public static bool ValueOutOfRange(int i_Value, int i_MaxValue, int i_MinValue)
        {
            return (i_Value > i_MaxValue || i_Value < i_MinValue);
        }
    }
}
