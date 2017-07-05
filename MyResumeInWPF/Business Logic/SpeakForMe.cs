
using System;
using System.Speech.Synthesis;

namespace MyResume
{
    public sealed class SpeakForMe
    {
        private PromptBuilder m_promptBuilder;
        private SpeechSynthesizer m_speechSynthesizer;
        private PromptStyle m_promptStyle;

        //pour un singleton avec double lock
        private static volatile SpeakForMe m_instance;
        private static object m_syncRoot = new Object();

        #region Singleton
        /// <summary>
        /// Obtient une classe permettant de faire parler le PC...
        /// </summary>
        public static SpeakForMe Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_syncRoot)
                    {
                        if (m_instance == null)
                            m_instance = new SpeakForMe();
                    }
                }
                return m_instance;
            }
            private set { m_instance = value; }
        }
        #endregion

        private SpeakForMe()
        {
            //https://openclassrooms.com/courses/faites-parler-vos-applications-en-net
            m_speechSynthesizer = new SpeechSynthesizer();
            m_promptBuilder = new PromptBuilder();

            string v_voice = "ScanSoft Virginie_Dri40_16kHz";
            if (CheckVoiceAvailability(m_speechSynthesizer, v_voice)) // Si la voix "Virginie" est installée,
                m_speechSynthesizer.SelectVoice(v_voice); // alors on l'utilise.
            else
                m_speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult); //sinon on prends la voix par défaut.

            m_promptStyle = new PromptStyle();
            m_promptStyle.Volume = PromptVolume.Loud;
            //m_promptStyle.Emphasis = PromptEmphasis.Strong;
        }

        public void Speak(string p_speech, PromptRate p_rate = PromptRate.Medium)
        {
            m_promptBuilder.ClearContent();
            m_promptBuilder.StartStyle(m_promptStyle);
            m_promptBuilder.AppendText(p_speech, p_rate);
            m_promptBuilder.EndStyle();
            m_speechSynthesizer.SpeakAsync(m_promptBuilder);
        }

        public bool CheckVoiceAvailability(SpeechSynthesizer p_speaker, string p_voice)
        {
            foreach (InstalledVoice v_allVoices in p_speaker.GetInstalledVoices()) // Je liste les voix installées
            {
                if (v_allVoices.VoiceInfo.Name == p_voice)
                    return true;
            }
            return false;
        }
    }
}
