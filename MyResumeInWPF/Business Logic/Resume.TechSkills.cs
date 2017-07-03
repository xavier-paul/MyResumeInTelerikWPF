using System;

namespace MyResume
{
    public partial class Resume
    {
        [Obsolete("Les données se trouvent maintenant dans un fichier XML", false)]
        private void InitTechSkills()
        {
            int v_index = 1;
            SkillsResumeElement.Category v_currentCat = SkillsResumeElement.Category.Langages;
            #region Languages
            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "C#",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "WPF",
                Level = 2,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Azure (Cloud)",
                Level = 1,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "T-SQL (SQL Server 2000 à 2016)",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "PL-SQL (Oracle 8 à 12c)",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Java",
                Level = 2,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "C / C++",
                Level = 2,
                Group = v_currentCat
            });
            #endregion

            #region Methods
            v_currentCat = SkillsResumeElement.Category.Méthodes;
            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Merise",
                Level = 4,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "UML",
                Level = 3,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Agile / SCRUM",
                Level = 2,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "TDD (Test-Driven Development)",
                Level = 2,
                Group = v_currentCat
            });
            #endregion

            #region Tools
            v_currentCat = SkillsResumeElement.Category.Outils;
            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Visual Studio 2017",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "TFS",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "VSS",
                Level = 5,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Power AMC 15",
                Level = 4,
                Group = v_currentCat
            });

            Skills.Add(v_index++, new SkillsResumeElement
            {
                Description = "Android Studio",
                Level = 2,
                Group = v_currentCat
            });
            #endregion
        }

        private void InitTechSkills(ResumeData p_resume)
        {
            ResumeDataSkills v_home = (ResumeDataSkills)p_resume.Items[5];
            ResumeDataSkillsTechnical v_adr = (ResumeDataSkillsTechnical)v_home.Technical.GetValue(0);

            for (int i = 0; i < v_adr.Skill.Length; i++)
            {
                Skill v_skill = (Skill)v_adr.Skill.GetValue(i);

                int v_index = Convert.ToInt16(v_skill.index);
                Skills.Add(v_index, new SkillsResumeElement
                {
                    Description = !string.IsNullOrEmpty(v_skill.Value) ? v_skill.Value.ToString().Replace("\\n", Environment.NewLine) : null,
                    Level = Convert.ToByte(v_skill.level),
                    Group = (SkillsResumeElement.Category)Enum.Parse(typeof(SkillsResumeElement.Category), v_adr.category, true)
                });
            }
        }
    }
}
