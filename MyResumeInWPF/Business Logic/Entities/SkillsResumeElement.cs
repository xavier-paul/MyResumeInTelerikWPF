using System;
using System.Collections.ObjectModel;
using System.IO;

namespace MyResume
{
    public class SkillsResumeElement : SimpleResumeElement
    {
        private byte m_level;
        public enum Category {Langages, Outils, Méthodes, Aucun};

        private Category m_group = Category.Aucun;

        private readonly string TICKS_LANGUAGE = Path.Combine(AppLocationFinder.Current, @"Logos\puces\AQUA.png");
        private readonly string TICKS_TOOLS = Path.Combine(AppLocationFinder.Current, @"Logos\puces\GREEN.png");
        private readonly string TICKS_METHODS = Path.Combine(AppLocationFinder.Current, @"Logos\puces\YELLOW.png");
        private readonly string TICKS_NONE = Path.Combine(AppLocationFinder.Current, @"Logos\puces\FIRE.png");

        public byte Level
        {
            get
            {
                return m_level;
            }

            set
            {
                this.m_level = value;
            }
        }

        private string TICKS
        {
            get
            {
                if (Group == Category.Langages)
                    return TICKS_LANGUAGE;
                else if (Group == Category.Méthodes)
                    return TICKS_METHODS;
                else if (Group == Category.Outils)
                    return TICKS_TOOLS;
                else
                    return TICKS_NONE;
            }
        }

        public ObservableCollection<String> AllImagesLevel
        {
            get
            {
                ObservableCollection<String> v_result = new ObservableCollection<String>();
                for (int i = 0; i < Level; i++)
                    v_result.Add(TICKS);

                return v_result;
            }
        }

        public Category Group
        {
            get
            {
                return m_group;
            }

            set
            {
                this.m_group = value;
            }
        }
    }
}
