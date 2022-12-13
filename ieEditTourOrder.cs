using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class ieEditTourOrder : Form
    {
        public Guid TourOrderId { get; set; }
        private TourOrder to = new();
        bool isDraft = false; // Пу умолчанию это НЕ черновик
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
            this.dgwTourOrderItems.Columns.Insert(2, col);

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

                    isDraft = to.TourOrderStatusId == TourOrderStatus.DraftId;

                    dgwTourOrderItems.DataSource = to.TourOrderItems;
                    comboClients.SelectedValue = to.ClientId;
                    comboPaymentType.SelectedValue = to.PaymentTypeId;
                }
                else
                {
                    to.TourOrderItems = new List<TourOrderItem>();
                    to.TotalCost = 0;
                    isDraft = true; // При создании это черновик
                }

                // Не дадим редактировать Заказ со статусом, отличным от Черновика!
                comboClients.Enabled = isDraft;
                comboPaymentType.Enabled = isDraft;
                dgwTourOrderItems.Enabled = isDraft;
                btnAdd.Enabled = isDraft;
                //btnRemove.Enabled = isDraft;
                btnOK.Enabled = isDraft;

                lblTotalCost.Text = to.TotalCost.ToString();
            }

            setOKstatus();

        }

        private void setOKstatus()
        {
            btnOK.Enabled = isDraft && dgwTourOrderItems.Rows.Count > 0;
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
                            to.TourOrderItems.Add(new TourOrderItem() { Id = Guid.NewGuid(), TourId = t.Id, Price = t.Cost, Quantity = 0, Cost = 0, TourOrderId = this.TourOrderId, Tour = t, TourOrder = this.to });
                        }
                        // Перепривязываем список элементов
                        dgwTourOrderItems.DataSource = to.TourOrderItems;
                    }

                    setOKstatus();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Никаких сохранений! Сохраняться будем только по кнопке OK!
            if (dgwTourOrderItems.SelectedCells != null
                && MessageBox.Show( // Удостоверяемся, что пользователь в сознании
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

                setOKstatus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dgwTourOrderItems_Validating(sender, new CancelEventArgs());
            if (isModelValid())
            {
                // Работаем сразу в контексте
                using (ApplicationContext db = new())
                {
                    TourOrder EditableTourOrder = new(); // Для сохранения создаём новый объект

                    if (TourOrderId == Guid.Empty) // Создание Заказа
                    {
                        EditableTourOrder.Id = Guid.NewGuid(); // Генерим новичку Id...
                        EditableTourOrder.TourOrderItems = new List<TourOrderItem>(); // Создаём список элементов Заказа
                        EditableTourOrder.PaymentTypeId = (Guid)comboPaymentType.SelectedValue;
                        EditableTourOrder.ClientId = (Guid)comboClients.SelectedValue;
                        EditableTourOrder.TotalCost = Double.Parse(lblTotalCost.Text);
                        EditableTourOrder.TourOrderStatusId = TourOrderStatus.DraftId; // При создании статус всегда - Черновик
                        EditableTourOrder.TourOrderStatusReasonId = TourOrderStatusReason.NoReasonId; // Для Черновика причины нет
                        EditableTourOrder.TourOrderStatusShiftDate = DateTime.Now;

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
                                    TourOrderId = EditableTourOrder.Id
                                });
                        }
                        db.TourOrders.Add(EditableTourOrder);
                        db.SaveChanges();
                    }
                    else // Редактирование Заказа
                    {
                        // Читаем из БД Заказ БЕЗ элементов!
                        EditableTourOrder = db.TourOrders.Single(t => t.Id == TourOrderId);
                        // Обновляем основные поля
                        EditableTourOrder.PaymentTypeId = (Guid)comboPaymentType.SelectedValue;
                        EditableTourOrder.ClientId = (Guid)comboClients.SelectedValue;
                        EditableTourOrder.TotalCost = Double.Parse(lblTotalCost.Text);
                        // Обновляем Заказ
                        db.TourOrders.Update(EditableTourOrder);

                        // Теперь отдельно работаем с элементами напрямую в БД, минуя связи.
                        // Удаляем из таблицы TourOrderItems все элементы с текущим TourOrderId:
                        db.TourOrderItems.RemoveRange(db.TourOrderItems.Where(toi => toi.TourOrderId == EditableTourOrder.Id));

                        // Добавляем напрямую в таблицу TourOrderItems текущие элементы как новые объекты:
                        foreach (TourOrderItem toi in to.TourOrderItems)
                        {
                            db.TourOrderItems.Add(
                            new TourOrderItem
                            {
                                Id = Guid.NewGuid(),
                                Cost = toi.Cost,
                                Price = toi.Price,
                                Quantity = toi.Quantity,
                                TourId = toi.TourId,
                                TourOrderId = EditableTourOrder.Id
                            });
                        }
                        db.SaveChanges();
                    }
                    this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                    this.Close();
                }
            }
        }

        private bool isModelValid()
        {
            if (dgwTourOrderItems.Rows.Count == 0) // Нельзя сохранять Заказ без элементов
                return false;
            if (!to.TourOrderItems.All(toi => toi.Quantity > 0)) // Нельзя сохранять Заказ со строчками, в которых нет людей
                return false;
            return true;
        }

        private void dgwTourOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = isDraft && dgwTourOrderItems.SelectedRows.Count > 0;
            btnRemove.Enabled = isEnabled;
            btnOK.Enabled = isEnabled;
        }

        private void dgwTourOrderItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgwTourOrderItems.Rows.Count - 1) // Исключаем заголовок грида
            {
                Guid rowId = (Guid)dgwTourOrderItems.Rows[e.RowIndex].Cells[0].Value;
                TourOrderItem toi = to.TourOrderItems.Find(t => t.Id == rowId);
                toi.Cost = toi.Quantity * toi.Price;
                dgwTourOrderItems.DataSource = to.TourOrderItems; // перепривязка
                dgwTourOrderItems.Invalidate();
                lblTotalCost.Text = to.TourOrderItems.Sum(t => t.Cost).ToString();

                dgwTourOrderItems_Validating(sender, new CancelEventArgs());
            }
        }
        private void dgwTourOrderItems_Validating(object sender, CancelEventArgs e)
        {
            if (dgwTourOrderItems.Rows.Count == 0)
                errorProvider1.SetError(dgwTourOrderItems, "Нельзя сохранять Заказ без туров!");
            else if (!to.TourOrderItems.All(toi => toi.Quantity > 0))
                errorProvider1.SetError(dgwTourOrderItems, "Количество людей в туре должно быть больше нуля!");
            else
                errorProvider1.Clear();
        }

    }
}
