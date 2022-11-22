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
    public partial class EditTour : Form
    {

        private Models.Tour? EditableTour { get; set; }

        public Guid EditableId { get; set; }

        public EditTour()
        {
            InitializeComponent();
        }

        private void EditTour_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext()){
                comboFoods.DataSource = db.Foods.ToList();
                comboHotels.DataSource = db.Hotels.ToList();

                if (EditableId != Guid.Empty)
                {
                    EditableTour = db.Tours.Find(EditableId);
                    comboFoods.SelectedValue = EditableTour.FoodId;
                    comboHotels.SelectedValue = EditableTour.HotelId;
                    rtxtTourDescription.Text = EditableTour.Description;
                    numericCost.Value = (decimal)EditableTour.Cost;
                    dateTimeStart.Value = EditableTour.StartDateTime;
                    dateTimeEnd.Value = EditableTour.EndDateTime;
                }
                else 
                {
                    EditableTour = new Models.Tour();
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = EditableTour.Id == Guid.Empty; // флаг редактирования

            if (isModelValid())
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (!isNew) EditableTour = db.Tours.Find(EditableId);
                    EditableTour.Cost = (Single)numericCost.Value;
                    EditableTour.Description = rtxtTourDescription.Text.Trim();
                    EditableTour.HotelId = (Guid)comboHotels.SelectedValue;
                    EditableTour.FoodId = (Guid)comboFoods.SelectedValue;
                    EditableTour.StartDateTime = dateTimeStart.Value;
                    EditableTour.EndDateTime = dateTimeEnd.Value;

                    if (isNew)
                    {
                        EditableTour.Id = Guid.NewGuid();
                        db.Tours.Add(EditableTour); // создаём
                    }
                    else db.Tours.Update(EditableTour); // редактируем
                    db.SaveChanges();
                }

                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool isModelValid()
        {
            if (rtxtTourDescription.Text.Length > 500)
                return false;
            if (dateTimeEnd.Value.Date < dateTimeStart.Value.Date)
                return false;
            return true;
        }

        private void rtxtTourDescription_Validating(object sender, CancelEventArgs e)
        {
            if (rtxtTourDescription.Text.Length > 500)
                errorProvider1.SetError(rtxtTourDescription, "Описание не должно быть длинне 500 символов!");
            else if (dateTimeEnd.Value.Date  < dateTimeStart.Value.Date)
                errorProvider1.SetError(dateTimeEnd, "Дата отъезда не должна быть раньше даты заезда");
            else
                errorProvider1.Clear();
        }
    }
}
