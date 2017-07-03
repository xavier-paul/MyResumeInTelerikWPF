using System.IO;

namespace MyResume
{
    public class SimpleResumeElement
    {
        private string m_description;
        private string m_iconForElement;
        private string m_name;

        public string Description
        {
            get
            {
                return m_description;
            }

            set
            {
                this.m_description = value;
            }
        }

        public string IconForElement
        {
            get
            {
                string v_normalPath = Path.Combine(Directory.GetCurrentDirectory(), @"Logos\" + m_iconForElement);

                if (!File.Exists(v_normalPath))
                    return @"G:\temp\Projets .Net\MyResumeInWPF\MyResumeInWPF\Logos\" + m_iconForElement;
                else
                    return v_normalPath;
            }

            set
            {
                this.m_iconForElement = value;
            }
        }

        public string Name {
            get
            {
                return m_name;
            }

            set
            {
                this.m_name = value;
            }
        }
    }
}
