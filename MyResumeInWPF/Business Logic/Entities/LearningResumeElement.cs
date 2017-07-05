using System;

namespace MyResume
{
    public sealed class LearningResumeElement : SimpleResumeElement
    {
        private string m_firm;
        private ushort m_year;
        private ushort? m_dayLength = null;

        public string Firm
        {
            get
            {
                return m_firm;
            }

            set
            {
                this.m_firm = value;
            }
        }

        public ushort Year
        {
            get
            {
                return m_year;
            }

            set
            {
                this.m_year = value;
            }
        }

        public string DayLengthInFrench {
            get
            {
                if (DayLength.HasValue)
                    return string.Format("{0} jours.", DayLength.Value);
                else
                    return string.Empty;
            }

            private set { }

        }

        public ushort? DayLength {
            get
            {
                return m_dayLength;
            }

            set
            {
                this.m_dayLength = value;
            }
        }

        //Pour le TimeLine Telerik
        public TimeSpan Duration {
            get
            {
                if (DayLength.HasValue)
                    return new TimeSpan(DayLength.Value, 0, 0, 0);
                else
                    return new TimeSpan(1, 0, 0, 0);

            }
            private set { }
        }

        //Pour le TimeLine Telerik
        public DateTime Date
        {
            get
            {
                return new DateTime(Year, 1, 1);

            }
            private set { }
        }
    }
}
