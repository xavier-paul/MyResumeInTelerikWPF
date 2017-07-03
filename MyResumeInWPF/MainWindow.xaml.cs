using System;
using System.Windows;
using System.Windows.Data;

namespace MyResume
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            FillResume();

            ManageGoogleMaps();
        }

        private void ManageGoogleMaps()
        {
            if (InternetConnectivity.IsConnectedToInternet())
            {
                //pour supprimer les erreurs Javascripts (dû au Browser WPF qui est en fait un ActiveX)
                (new MyResume.WebBrowserFix ()).HideScriptErrors(m_googleMaps, true);

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

        private void FillResume()
        {
            //http://www.wpf-tutorial.com/listview-control/listview-data-binding-item-template/

            Resume v_myResume = new Resume();
            try
            {
                m_civilList.ItemsSource = v_myResume.Civil;
                m_hobbiesList.ItemsSource = v_myResume.Hobbies;

                //Skills : Telerik radar ?
                m_skillsList.ItemsSource = v_myResume.Skills;

                //grouper par Catégorie : http://www.wpf-tutorial.com/listview-control/listview-grouping/
                //https://stackoverflow.com/questions/37657968/grouping-of-items-in-listview-wpf
                CollectionView v_view = (CollectionView)CollectionViewSource.GetDefaultView(m_skillsList.ItemsSource);
                PropertyGroupDescription v_groupDescription = new PropertyGroupDescription("Value.Group");
                v_view.GroupDescriptions.Add(v_groupDescription);
               
                m_languagesList.ItemsSource = v_myResume.Languages;

                m_trainingList.ItemsSource = v_myResume.Learning;
                m_jobsList.ItemsSource = v_myResume.Jobs;

                m_managerSkillsList.ItemsSource = v_myResume.ManagerSkills;
            }
            catch (Exception v_ex)
            {
                MessageBox.Show(v_ex.Message);
            }
        }

    }
}
