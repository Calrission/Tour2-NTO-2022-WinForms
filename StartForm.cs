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

        private void btnRoles_Click(object sender, EventArgs e)
        {
            using (RoleList rl = new())
                rl.ShowDialog();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            using (ContactList cl = new())
                cl.ShowDialog();
        }

        private void btnHotels_Click(object sender, EventArgs e)
        {
            using (HotelList hl = new())
                hl.ShowDialog();
        }

        private void btnTours_Click(object sender, EventArgs e)
        {
            using (TourList tl = new())
                tl.ShowDialog();
        }
    }
}