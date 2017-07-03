using System;

namespace MyResume
{
    public class ProResumeElement : SimpleResumeElement
    {
        private DateTime m_startingDate;
        private DateTime m_endingDate;
        private TimeSpan m_jobLength;
        private string m_firmName;

        public DateTime StartingDate
        {
            get
            {
                return m_startingDate;
            }

            set
            {
                this.m_startingDate = value;
            }
        }

        public DateTime EndingDate
        {
            get
            {
                return m_endingDate;
            }

            set
            {
                this.m_endingDate = value;
            }
        }

        public TimeSpan JobLength
        {
            get
            {
                return EndingDate - StartingDate;
            }
        }

        public string JobLengthInFrench
        {
            get
            {
                double v_duration = Math.Floor(JobLength.TotalDays / 30);
                if (v_duration <= 12)
                    return string.Format("{1:MM/yyyy} -> {2:MM/yyyy}{3}{0} mois", v_duration, StartingDate, EndingDate, Environment.NewLine);
                else
                    return string.Format("{2:MM/yyyy} -> {3:MM/yyyy}{4}{0} ans et {1} mois", Math.Floor(v_duration /12), v_duration - Math.Floor(v_duration/12)*12,
                        StartingDate, EndingDate, Environment.NewLine);
            }
        }

        public string FirmName
        {
            get
            {
                return m_firmName;
            }

            set
            {
                this.m_firmName = value;
            }
        }
    }
}
