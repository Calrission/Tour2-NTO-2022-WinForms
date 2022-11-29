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
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class ieEditTourOrder : Form
    {
        public Guid TourOrderId { get; set; }
        private TourOrder to = new();
        public ieEditTourOrder()
        {
            InitializeComponent();
        }

        private void ieEditTourOrder_Load(object sender, EventArgs e)
        {
            dgwTourOrderItems.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                comboClients.DataSource = db.Clients.ToList();
                comboPaymentType.DataSource = db.PaymentTypes.ToList();

                if (TourOrderId != Guid.Empty)
                {
                    to = db.TourOrders.Include(to => to.TourOrderItems).First(to => to.Id == TourOrderId);
                    comboClients.SelectedValue = to.ClientId;
                    comboPaymentType.SelectedValue = to.PaymentTypeId;
                }
                else
                {
                    to.TourOrderItems = new List<TourOrderItem>();
                    to.TotalCost = 0;
                }
                //dgwTourOrderItems.DataSource = to.TourOrderItems;
                lblTotalCost.Text = to.TotalCost.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (TourList tl = new())
            {
                tl.workingMode = WorkingMode.TourSelection;
                if (tl.ShowDialog() == DialogResult.OK) // Сработает, только если пользователь нажал кнопку "Выбрать" и число выбранных им строк > 0
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        List<Tour> tll = db.Tours.Include(t => t.Hotel).Where(t => tl.SelectedToursId.Contains(t.Id)).ToList();
                        // Добавляем выбранные элементы
                        foreach (Tour t in tll)
                        {
                            to.TourOrderItems.Add(new TourOrderItem() { Id=Guid.NewGuid(), TourId=t.Id, Price=t.Cost, Quantity=0, Cost=0, TourOrderId= this.TourOrderId, Tour=t, TourOrder=this.to });
                        }
                        // Перепривязываем список элементов
                        dgwTourOrderItems.DataSource = to.TourOrderItems;
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Никаких сохранений! Сохраняться будем только по кнопке OK!
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить тур «{0}»?", dgwTourOrderItems.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                    Models.TourOrderItem? toi = to.TourOrderItems.FirstOrDefault(to => to.Id == (Guid)dgwTourOrderItems.SelectedCells[0].Value); // Находим удаляемый объект
                    if (toi != null) // удаляем его
                    {
                        to.TourOrderItems.Remove(toi);
                        //dgwTourOrderItems.DataSource = to.TourOrderItems; // перепривязка
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // не забыть присвоить всем элементам тура правильный TourOrderId, а то там для нового тура пустой Guid стоять будет

        }

        private void dgwTourOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgwTourOrderItems.SelectedRows.Count > 0;
        }

    }
}
