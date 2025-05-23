using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCTemp.Classes
{
    public class clsEmployee
    {
        private int m_EmpID = 0;

        private string m_FN = string.Empty;
        private string m_LN = string.Empty;
        private string m_Phone = string.Empty;

        private string m_Email = string.Empty;
        private string m_Available = string.Empty;


        internal int Original_EmpID = 0;




        public int EmpID
        {
            get
            {
                return m_EmpID;
            }
            set
            {
                m_EmpID = value;
            }
        }


        public string FN
        {
            get
            {
                return m_FN;
            }
            set
            {
                m_FN = value;
            }
        }

        public string LN
        {
            get
            {
                return m_LN;
            }
            set
            {
                m_LN = value;
            }
        }

        public string Phone
        {
            get
            {
                return m_Phone;
            }
            set
            {
                m_Phone = value;
            }
        }

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }
        public string Available
        {
            get
            {
                return m_Available;
            }
            set
            {
                m_Available = value;
            }
        }

    }
}