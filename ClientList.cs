using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCompanyCore
{
    public partial class ClientList : Form
    {
        public ClientList()
        {
            InitializeComponent();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            dgwClients.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                var data = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList();
                dgwClients.DataSource = data;
            }
        }
    }
}
