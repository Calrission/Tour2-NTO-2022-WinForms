using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.RegularExpressions;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class EditHotel : Form
    {

        public Guid? EditableId { get; set; }

        public EditHotel()
        {
            InitializeComponent();
        }

        bool isModelValid()
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Trim().Length < 2 || txtName.Text.Length > 200)
                return false;
            if (String.IsNullOrEmpty(mtxtPhone.Text.Trim()) || !phone_validation().IsMatch(mtxtPhone.Text.Trim()))
                return false;
            if (rtxtHotelDescription.Text.Length > 500)
                return false;
            return true;
        }

        private static Regex phone_validation()
        {
            string pattern = @"^\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private void EditHotel_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                comboBoxRegion.DataSource = db.Regions.ToList();
                // Нас интересует только Контакты с ролью "Менеджер"
                Role ManagerRole = db.Roles.FirstOrDefault(r => r.Id == Role.ManagerId);
                comboBoxManager.DataSource = db.Contacts.Include(c => c.Roles).Where(t => t.Roles.Contains(ManagerRole)).ToList();
                
                if (EditableId != null && EditableId != Guid.Empty)
                {
                    // При редактировании дозаполняем контакт значениями из БД, поскольку из грида всего не перетащишь
                    Models.Hotel? EditableHotel = db.Hotels.Include(c => c.Region).Include(c => c.Manager).ToList().Find(c => c.Id == EditableId); // благодаря инклюду прилетят и регион и менеджер
                    CheckState toCheckOrNotToCheck = CheckState.Unchecked; // Ставить ли галочку при привязке

                    txtName.Text = EditableHotel.Name;
                    rtxtHotelDescription.Text = EditableHotel.Description;
                    mtxtPhone.Text = EditableHotel.PhoneNumber;
                    mtxtPhone.Text = EditableHotel.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
                    comboBoxRegion.SelectedItem = EditableHotel.Region;
                    comboBoxManager.SelectedItem = EditableHotel.Manager;
                }

            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
                errorProvider1.SetError(txtName, "Не указано Название отеля!");
            else if (txtName.Text.Trim().Length < 2)
                errorProvider1.SetError(txtName, "Название не должно быть короче двух значащих символов!");
            else if (txtName.Text.Length > 200)
                errorProvider1.SetError(txtName, "Название не должно быть длинее 200 символов!");
            else
                errorProvider1.Clear();
        }

        private void mtxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(mtxtPhone.Text.Trim()))
                errorProvider1.SetError(mtxtPhone, "Не указан Телефон!");
            else if (!phone_validation().IsMatch(mtxtPhone.Text.Trim()))
                errorProvider1.SetError(mtxtPhone, "Номер телефона не соответствует формату!");
            else
                errorProvider1.Clear();
        }

        private void rtxtHotelDescription_Validating(object sender, CancelEventArgs e)
        {
            if (rtxtHotelDescription.Text.Length > 500)
                errorProvider1.SetError(rtxtHotelDescription, "Описание не должно быть длинне 500 символов!");
            else
                errorProvider1.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = false; // флаг редактирования

            if (isModelValid())
            {
                // Работаем сразу в конексте
                using (ApplicationContext db = new ApplicationContext())
                {
                    Models.Hotel EditableHotel = new();
                    if (EditableId == Guid.Empty) // Создание Отеля
                    {
                        isNew = true;
                        EditableHotel.Id = Guid.NewGuid(); // Генерим новичку Id...
                    }
                    else // Редактирование Отеля
                    {
                        EditableHotel = db.Hotels.Find(EditableId);
                    }

                    EditableHotel.Name = txtName.Text.Trim();
                    EditableHotel.Description = rtxtHotelDescription.Text.Trim();
                    EditableHotel.PhoneNumber = "+7" + mtxtPhone.Text.Trim();
                    EditableHotel.RegionId = (Guid)comboBoxRegion.SelectedValue;
                    EditableHotel.ManagerId = (Guid)comboBoxManager.SelectedValue;

                    if (isNew) db.Hotels.Add(EditableHotel); // создаём
                    else db.Hotels.Update(EditableHotel); // редактируем
                    db.SaveChanges();
                }

                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
        }

        
    }
}
