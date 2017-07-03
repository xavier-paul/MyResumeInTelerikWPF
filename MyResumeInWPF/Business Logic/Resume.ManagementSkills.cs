using System;

namespace MyResume
{
    public partial class Resume
    {
        [Obsolete("Les données se trouvent maintenant dans un fichier XML", false)]
        private void InitManagerSkills()
        {
            int v_index = 1;
            ManagerSkills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Pédagogie explicative",
                Level = 3
            });

            ManagerSkills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Résolution de problématique",
                Level = 4
            });
            ManagerSkills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Chiffrage (Poker Sizing / T-Shirt sizing)",
                Level = 3
            });
        }

        private void InitManagerSkills(ResumeData p_resume)
        {
            ResumeDataSkills v_home = (ResumeDataSkills)p_resume.Items[5];
            ResumeDataSkillsManagement v_adr = (ResumeDataSkillsManagement)v_home.Management.GetValue(0);

            for (int i = 0; i < v_adr.Skill.Length; i++)
            {
                Skill v_skill = (Skill)v_adr.Skill.GetValue(i);

                int v_index = Convert.ToInt16(v_skill.index);
                ManagerSkills.Add(v_index, new SkillsResumeElement
                {
                    Description = !string.IsNullOrEmpty(v_skill.Value) ? v_skill.Value.ToString().Replace("\\n", Environment.NewLine) : null,
                    Level = Convert.ToByte(v_skill.level)
                });
            }
        }
    }
}
