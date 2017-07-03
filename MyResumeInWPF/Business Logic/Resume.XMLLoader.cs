using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MyResume
{
    public partial class Resume
    {
        private ResumeData LoadFromXML(string p_filename)
        {
            ResumeData v_result = new ResumeData();
            if (!string.IsNullOrWhiteSpace(p_filename) && File.Exists(p_filename))
            {
                try
                {
                    var v_serializer = new XmlSerializer(typeof(ResumeData));

                    using (var v_stream = new StringReader(File.ReadAllText(p_filename)))
                    {
                        using (var v_reader = XmlReader.Create(v_stream))
                        {
                            v_result = (ResumeData)v_serializer.Deserialize(v_reader);
                        }
                    }
                }
                catch (Exception v_ex)
                {

                }
            }

            return v_result;
        }

    }
}
