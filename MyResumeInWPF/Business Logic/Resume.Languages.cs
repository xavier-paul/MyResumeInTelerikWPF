using System;

namespace MyResume
{
    public partial class Resume
    {
        [Obsolete("Les données se trouvent maintenant dans un fichier XML", false)]
        private void InitLanguages()
        {
            int v_index = 1;
            Languages.Add(v_index++, new SimpleResumeElement
            {
                Description = "Français : langue maternelle"
            });

            Languages.Add(v_index++, new SimpleResumeElement
            {
                Description = "Anglais : courant"
            });

            Languages.Add(v_index++, new SimpleResumeElement
            {
                Description = "Japonais : Débutant (JLPT N5 obtenu en 2014) : lu, écrit, parlé"
            });
        }

        private void InitLanguages(ResumeData p_resume)
        {
            ResumeDataLanguages v_home = (ResumeDataLanguages)p_resume.Items[3];

            for (int i = 0; i < v_home.Language.Length; i++)
            {
                ResumeDataLanguagesLanguage v_adr = (ResumeDataLanguagesLanguage)v_home.Language.GetValue(i);
                int v_index = Convert.ToInt16(v_adr.index);
                Languages.Add(v_index, new SimpleResumeElement
                {
                    Description = v_adr.Value.ToString().Replace("\\n", Environment.NewLine)
                });
            }

        }
    }
}
