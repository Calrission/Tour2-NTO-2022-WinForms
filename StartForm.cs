using Microsoft.VisualBasic.ApplicationServices;

namespace TravelCompanyCore
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegions_Click(object sender, EventArgs e)
        {
            using (RegionList rl = new()) 
                rl.ShowDialog();
        }
    }
}