using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls.ChartView;

namespace MyResume
{
    /// <summary>
    /// Logique d'interaction pour MainResume.xaml
    /// </summary>
    public partial class MainResume : Window
    {
        public MainResume()
        {
            InitializeComponent();
            FillResume();

        }

        private void FillResume()
        {
            Resume v_myResume = new Resume();

            FillTechnicalSkills(v_myResume.TechSkills);
        }

        private void FillTechnicalSkills(ObservableCollection<SkillsResumeElement> p_skills)
        {
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Langages), Colors.SteelBlue);
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Méthodes), Colors.DarkSeaGreen);
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Outils), Colors.Crimson);
        }

        private void AddTechnicalSeries(IEnumerable<SkillsResumeElement> p_skills, Color p_color)
        {
            RadarLineSeries v_technicalSkills = new RadarLineSeries();
            m_mainSkillsChart.Series.Add(v_technicalSkills);

            v_technicalSkills.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Description" };
            v_technicalSkills.ValueBinding = new GenericDataPointBinding<SkillsResumeElement, double>() { ValueSelector = v_allSkills => v_allSkills.Level };

            v_technicalSkills.ItemsSource = p_skills;
            v_technicalSkills.Stroke = new SolidColorBrush(p_color);
        }


    }
}
