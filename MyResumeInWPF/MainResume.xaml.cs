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
using Telerik.Windows.Controls;
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
            SpeakForMe.Instance.Speak("Bonjour, voici deux versions de mon CV. Une en WPF classique et l'autre en WPF avec les composants Telerik.", System.Speech.Synthesis.PromptRate.Fast);
            InitializeComponent();
            FillResume();
        }

        private void FillResume()
        {
            Resume v_myResume = new Resume();
            m_civilList.ItemsSource = v_myResume.Civil;
            FillTechnicalSkills(v_myResume.TechSkillsForTelerik);
            FillManagementSkills(v_myResume.ManagerSkillsForTelerik);
            FillLanguages(v_myResume.Languages);
            FillHobbies(v_myResume.Hobbies);

            //Pour utiliser un seul DataContext...
            //https://stackoverflow.com/questions/679933/wpf-binding-multiple-controls-to-different-datacontexts
            FillLearningAndJobs(v_myResume.Learning, v_myResume.Jobs);

            ManageGoogleMaps();
        }

        private void FillLearningAndJobs(SortedList<int, LearningResumeElement> p_learning, SortedList<int, ProResumeElement> p_jobs)
        {
            //on sélectionne l'intervalle max pour les années de formation...
            var v_endDateForJobs = p_jobs[p_jobs.Keys.Min<int>()].EndingDate;
            var v_startDateForJobs = p_jobs[p_jobs.Keys.Max<int>()].StartingDate;

            //on sélectionne l'intervalle max pour les années de formation...
            var v_endDate = new DateTime(p_learning[p_learning.Keys.Min<int>()].Year, 12, 31);
            var v_startDate = new DateTime(p_learning[p_learning.Keys.Max<int>()].Year, 1, 1);

            //hop, un petit type anonyme, histoire de ne pas rajouter une classe pour ca...
            this.DataContext = new {
                Jobs = new JobsList { JobsData = p_jobs.Values, JobsStartDate = v_startDateForJobs, JobsEndDate = v_endDateForJobs },
                Learning = new LearningList { TrainingData = p_learning.Values, TrainingStartDate = v_startDate, TrainingEndDate = v_endDate }
            };
        
        }       

        private void FillManagementSkills(ObservableCollection<SkillsResumeElement> p_managerSkills)
        {
            AddTechnicalSeries(p_managerSkills.Where(v_oneSkill => v_oneSkill.Group==SkillsResumeElement.Category.Aucun), Colors.SteelBlue, m_mgrkillsChart);
        }

        private void ManageGoogleMaps()
        {
            if (InternetConnectivity.IsConnectedToInternet())
            {
                //pour supprimer les erreurs Javascripts (dû au Browser WPF qui est en fait un ActiveX)
                (new MyResume.WebBrowserFix()).HideScriptErrors(m_googleMaps, true);

                string v_uri = AppLocationFinder.Current + "\\HomeForGoogleMaps.html";
                //string v_directUri = "https://www.google.com/maps/embed/v1/place?q=H1%20rue%20des%20marronniers%2077177%20Brou%20sur%20Chantereine&key=AIzaSyDjX1aA6DMHg_95iTBFLvXNdJ_X6vA6NGU";
                m_googleMaps.Loaded += delegate
                {
                    try
                    {
                        m_googleMaps.Navigate(new Uri(v_uri, UriKind.Absolute));
                    }
                    catch (Exception v_ex)
                    {
                        MessageBox.Show(v_ex.Message);
                        return;
                    }
                };
            }
            else
                m_googleMaps.Visibility = Visibility.Hidden;
        }

        private void FillHobbies(SortedList<int, SimpleResumeElement> p_hobbies)
        {
            m_hobbiesList.ItemsSource = from v_hobby in p_hobbies.Values select v_hobby;
            m_hobbiesList.SelectedItem = m_hobbiesList.Items[0];
        }

        private void FillLanguages(SortedList<int, SimpleResumeElement> p_languages)
        {
            m_allLanguagesCarousel.ItemsSource = from v_lng in p_languages.Values select v_lng;
            m_allLanguagesCarousel.SelectedItem = m_allLanguagesCarousel.Items[0];
        }

        private void FillTechnicalSkills(ObservableCollection<SkillsResumeElement> p_skills)
        {
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Langages), Colors.SteelBlue, m_mainSkillsChart);
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Méthodes), Colors.DarkSeaGreen, m_mainSkillsChart);
            AddTechnicalSeries(p_skills.Where(v_oneSkill => v_oneSkill.Group == SkillsResumeElement.Category.Outils), Colors.Crimson, m_mainSkillsChart);
        }

        private void AddTechnicalSeries(IEnumerable<SkillsResumeElement> p_skills, Color p_color, RadPolarChart p_chart)
        {
            RadarLineSeries v_technicalSkills = new RadarLineSeries();
            p_chart.Series.Add(v_technicalSkills);

            v_technicalSkills.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Description" };
            v_technicalSkills.ValueBinding = new GenericDataPointBinding<SkillsResumeElement, double>() { ValueSelector = v_allSkills => v_allSkills.Level };

            v_technicalSkills.ItemsSource = p_skills;
            v_technicalSkills.Stroke = new SolidColorBrush(p_color);
        }

        private void m_jobsContent_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            var v_selectedItem = (sender as RadTimeline).SelectedItem;

            if (v_selectedItem != null)
            {
                m_jobsDetails.Text = ((ProResumeElement)v_selectedItem).Description;
                m_jobFirmName.Text = ((ProResumeElement)v_selectedItem).FirmName;
                m_jobTitle.Text = ((ProResumeElement)v_selectedItem).Name;

                SpeakForMe.Instance.Speak(m_jobsDetails.Text);

                BitmapImage v_logo = new BitmapImage(new Uri("pack://application:,,,/"+ ((ProResumeElement)v_selectedItem).IconAsRsc));
                m_firmLogo.Source = v_logo;
            }
        }

        private void m_allLanguagesCarousel_Loaded(object sender, RoutedEventArgs e)
        {
            m_allLanguagesCarousel.BringDataItemIntoView(m_allLanguagesCarousel.Items[0]);
        }
    }
}
