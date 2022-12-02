﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore
{
    public class NumericUpDownColumn : DataGridViewColumn
    {
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public int DecimalPlaces { get; set; }
        public decimal Increment { get; set; }

        public NumericUpDownColumn() : base(new NumericUpDownCell())
        {
            
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }

            set
            {
                // Ensure that the cell used for the template is a NumericUpDownCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                    throw new InvalidCastException("Must be a NumericUpDownCell");

                base.CellTemplate = value;
            }
        }

        public class NumericUpDownCell : DataGridViewTextBoxCell
        {
            public NumericUpDownCell() : base()
            {
                
            }

            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
                // Use the default row value when Value property is null.
                if (this.Value == null)
                {
                    ctl.Maximum = decimal.MaxValue;
                    ctl.Minimum = decimal.MinValue;
                    ctl.Value = (decimal)this.DefaultNewRowValue;
                }
                else
                {
                    NumericUpDownColumn nudc = (NumericUpDownColumn)this.OwningColumn;
                    ctl.Minimum = nudc.MinValue;
                    ctl.Maximum = nudc.MaxValue;
                    ctl.Increment= nudc.Increment;
                    ctl.DecimalPlaces= nudc.DecimalPlaces;
                    ctl.Value = decimal.Parse(this.Value.ToString());
                }
            }

            public override Type EditType
            {
                get { return typeof(NumericUpDownEditingControl); }
            }

            public override Type ValueType
            {
                get { return typeof(decimal); }
            }

            public override object DefaultNewRowValue
            {
                get { return 0; }
            }
        }

        class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public NumericUpDownEditingControl()
            {

            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
            public object EditingControlFormattedValue
            {
                get { return Math.Round(this.Value, 2).ToString(); }

                set
                {
                    if (value is String)
                    {
                        try
                        {
                            // This will throw an exception of the string is
                            // null, empty, or not in the format of a date.
                            this.Value = Math.Round(decimal.Parse((String)value), 2);
                        }
                        catch
                        {
                            // In the case of an exception, just use the
                            // default value so we're not left with a null
                            // value.
                            this.Value = 0;
                        }
                    }
                }
            }

            // Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {

            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
            public int EditingControlRowIndex
            {
                get { return rowIndex; }
                set { rowIndex = value; }
            }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
            public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                        //case Keys.Home:
                        //case Keys.End:
                        //case Keys.PageDown:
                        //case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }

            // Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get { return dataGridView; }
                set { dataGridView = value; }
            }

            // Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get { return valueChanged; }
                set { valueChanged = value; }
            }

            // Implements the IDataGridViewEditingControl.EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }


    }
}
