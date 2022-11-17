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
    public partial class EditRegion : Form
    {
        internal Models.Region? EditableRegion { get; set; }

        public EditRegion()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = false; // флаг редактирования

            if (isModelValid())
            {
                if (EditableRegion != null)
                {
                    if (EditableRegion.Id == Guid.Empty) // Создание региона
                    {
                        isNew = true;
                        EditableRegion.Id = Guid.NewGuid();
                    }
                    EditableRegion.Name = txtRegionName.Text;
                    EditableRegion.Description = rtxtRegionDescription.Text;

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        if (isNew) db.Regions.Add(EditableRegion); // создаём
                        else db.Regions.Update(EditableRegion); // редактируем
                        db.SaveChanges();
                    }
                }
                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
        }

        bool isModelValid()
        {
            if (txtRegionName.Text.Trim().Length<2)
            {
                lblRegionNameValidation.Text = "Наименование региона не должно быть короче двух значащих символов";
                return false;
            }
            return true;
        }

        private void EditRegion_Load(object sender, EventArgs e)
        {
            if(EditableRegion!= null)
            {
                txtRegionName.Text= EditableRegion.Name;
                rtxtRegionDescription.Text= EditableRegion.Description;
                lblRegionNameValidation.Text = String.Empty;
            }
            else lblRegionNameValidation.Text = "Форма загружена не правильно, обратитесь к Грише";
        }
    }
}
