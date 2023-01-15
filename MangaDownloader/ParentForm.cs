namespace MangaDownloader
{
    public partial class ParentForm : Form
    {
        SessionDataContext context = new SessionDataContext();
        SelectMangaForm welcomeForm;
        public ParentForm()
        {
            InitializeComponent();
            this.context.ChapterSelectForm = this.UpdatePanelToChapterSelect;
            welcomeForm = new SelectMangaForm(context);
            welcomeForm.TopLevel = false;
            welcomeForm.FormBorderStyle = FormBorderStyle.None;
            welcomeForm.Dock = DockStyle.Fill;

        }

        private void buttonSelectManaga_MouseClick(object sender, MouseEventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(welcomeForm);
            welcomeForm.Show();
        }

        private void ChapterSelect_Click(object sender, EventArgs e)
        {
            this.UpdatePanelToChapterSelect();
        }

        private void UpdatePanelToChapterSelect()
        {
            this.mainPanel.Controls.Clear();
        }
    }
}
