using System;

namespace MyResume
{
    public partial class Resume
    {
        [Obsolete("Les données se trouvent maintenant dans un fichier XML", false)]
        private void InitHobbies()
        {
            int i = 1;
            AddHobby(i++, "Natation");
            AddHobby(i++, "Running");
            AddHobby(i++, "Piano");
            AddHobby(i++, "Langues étrangères");
            AddHobby(i++, "Voyages (Nigéria (1 an), Bahreïn (1 an), Japon (6 fois), Etats-Unis...)");
        }

        [Obsolete("Les données se trouvent maintenant dans un fichier XML", false)]
        private void AddHobby(int p_index, string p_hobby)
        {
            Hobbies.Add(p_index, new SimpleResumeElement
            {
                Description = p_hobby
            });
        }

        private void InitHobbies(ResumeData p_resume)
        {
            ResumeDataHobbies v_home = (ResumeDataHobbies)p_resume.Items[2];

            for (int i = 0; i < v_home.Hobbie.Length; i++)
            {
                ResumeDataHobbiesHobbie v_adr = (ResumeDataHobbiesHobbie)v_home.Hobbie.GetValue(i);
                int v_index = Convert.ToInt16(v_adr.index);
                Hobbies.Add(v_index, new SimpleResumeElement
                {
                    Description = v_adr.Value.ToString().Replace("\\n", Environment.NewLine)
                });
            }

        }
    }
}
