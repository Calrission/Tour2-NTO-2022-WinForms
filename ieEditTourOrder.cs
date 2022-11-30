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
using System.Xml.Linq;
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
            NumericUpDownColumn col = new NumericUpDownColumn();
            col.MaxValue = 99999999999999999;
            col.MinValue = 0;
            col.DecimalPlaces = 2;
            col.Increment = 100;
            col.DataPropertyName = "Price";
            col.HeaderText = "Цена";
            col.Name = "Price";
            col.Width = 80;
            this.dgwTourOrderItems.Columns.Insert(2,col);

            col = new NumericUpDownColumn();
            col.MaxValue = 1000;
            col.MinValue = 0;
            col.DecimalPlaces = 0;
            col.Increment = 1;
            col.DataPropertyName = "Quantity";
            col.HeaderText = "Количество человек";
            col.Name = "Quantity";
            col.Width = 90;
            this.dgwTourOrderItems.Columns.Insert(3, col);

            dgwTourOrderItems.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                comboClients.DataSource = db.Clients.ToList();
                comboPaymentType.DataSource = db.PaymentTypes.ToList();

                if (TourOrderId != Guid.Empty)
                {
                    // Заказ с элементами и соответствующими этим элементам связями:
                    to = db.TourOrders
                        .Include(to => to.TourOrderItems)
                        .ThenInclude(toi => toi.Tour)
                        .ThenInclude(t => t.Hotel)
                        .First(to => to.Id == TourOrderId);

                    dgwTourOrderItems.DataSource = to.TourOrderItems;
                    comboClients.SelectedValue = to.ClientId;
                    comboPaymentType.SelectedValue = to.PaymentTypeId;
                }
                else
                {
                    to.TourOrderItems = new List<TourOrderItem>();
                    to.TotalCost = 0;
                }
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
                        List<Tour> tll = db.Tours.Include(t => t.Hotel).Where(t => tl.SelectedTourIds.Contains(t.Id)).ToList();
                        // Добавляем выбранные элементы
                        dgwTourOrderItems.DataSource = new List<TourOrderItem>();
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
                    dgwTourOrderItems.DataSource = new List<TourOrderItem>(); // отвязка
                    to.TourOrderItems.Remove(toi); // удаление
                    dgwTourOrderItems.DataSource = to.TourOrderItems; // перепривязка
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = false; // флаг редактирования

            if (isModelValid())
            {
                // Работаем сразу в контексте
                using (ApplicationContext db = new())
                {
                    TourOrder EditableTourOrder = new(); // Для сохранения создаём новый объект

                    if (TourOrderId == Guid.Empty) // Создание Заказа
                    {
                        isNew = true;
                        EditableTourOrder.Id = Guid.NewGuid(); // Генерим новичку Id...
                        EditableTourOrder.TourOrderItems = new List<TourOrderItem>(); // Создаём список элементов Заказа
                        EditableTourOrder.PaymentTypeId = (Guid)comboPaymentType.SelectedValue;
                        EditableTourOrder.ClientId = (Guid)comboClients.SelectedValue;
                        EditableTourOrder.TotalCost = Double.Parse(lblTotalCost.Text);

                        foreach (TourOrderItem toi in to.TourOrderItems)
                        {
                            EditableTourOrder.TourOrderItems.Add(
                                new TourOrderItem
                                {
                                    Id = toi.Id,
                                    Cost = toi.Cost,
                                    Price = toi.Price,
                                    Quantity = toi.Quantity,
                                    TourId = toi.TourId,
                                    TourOrderId = EditableTourOrder.Id // У toi здесь был пустой Guid
                                });
                        }
                        to.TourOrderItems = new(); // Очищаем список, чтобы отвязаться от БД (на всякий случай?)
                        db.TourOrders.Add(EditableTourOrder);
                        db.SaveChanges();
                    }
                    else // Редактирование Заказа
                    {
                        // Читаем Заказ из БД вместе с элементами
                        EditableTourOrder = db.TourOrders.Include(t => t.TourOrderItems).Single(t => t.Id == TourOrderId);

                        EditableTourOrder.PaymentTypeId = (Guid)comboPaymentType.SelectedValue;
                        EditableTourOrder.ClientId = (Guid)comboClients.SelectedValue;
                        EditableTourOrder.TotalCost = Double.Parse(lblTotalCost.Text);

                        EditableTourOrder.TourOrderItems.RemoveAll(toi => { return true; }); // Удаляем ВСЁ
                        //to.TourOrderItems = new(); // Очищаем список, чтобы отвязаться от БД (на всякий случай?)
                        db.SaveChanges();
                    }

                    if (!isNew)
                    {
                        using (ApplicationContext db2 = new())
                        {
                            TourOrder EditableTourOrder2 = db2.TourOrders.Include(t => t.TourOrderItems).Single(t => t.Id == TourOrderId);
                            //TourOrderItem[] toi4iteration = new TourOrderItem[to.TourOrderItems.Count];
                            //to.TourOrderItems.CopyTo(toi4iteration); // Копируем(?) текущие объекты в другую коллекцию
                            //EditableTourOrder2.TourOrderItems.AddRange(toi4iteration);
                            //toi4iteration = Array.Empty<TourOrderItem>(); // Очищаем массив
                            foreach (TourOrderItem toi in to.TourOrderItems)
                            {
                                EditableTourOrder2.TourOrderItems.Add(
                                    new TourOrderItem
                                    {
                                        Id = toi.Id,
                                        Cost = toi.Cost,
                                        Price = toi.Price,
                                        Quantity = toi.Quantity,
                                        TourId = toi.TourId,
                                        TourOrderId = EditableTourOrder2.Id // У toi здесь был пустой Guid
                                    });
                            }
                            db2.TourOrders.Update(EditableTourOrder2); // редактируем
                            db2.SaveChanges();
                        }
                    }

                    this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                    this.Close();
                }

            }
        }

        private bool isModelValid()
        {
            if (dgwTourOrderItems.Rows.Count == 0)
                return false;
            return true;
        }

        private void dgwTourOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgwTourOrderItems.SelectedRows.Count > 0;
        }

        private void dgwTourOrderItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex<= dgwTourOrderItems.Rows.Count-1) // Исключаем заголовок грида
            {
                Guid rowId = (Guid)dgwTourOrderItems.Rows[e.RowIndex].Cells[0].Value;
                to.TourOrderItems.Find(t => t.Id == rowId).Cost = decimal.ToDouble(decimal.Parse(dgwTourOrderItems.Rows[e.RowIndex].Cells[2].Value.ToString()) * decimal.Parse(dgwTourOrderItems.Rows[e.RowIndex].Cells[3].Value.ToString()));
                dgwTourOrderItems.DataSource = to.TourOrderItems; // перепривязка
                dgwTourOrderItems.Invalidate();
                lblTotalCost.Text=to.TourOrderItems.Sum(t=>t.Cost).ToString();
            }
        }

    }
}
