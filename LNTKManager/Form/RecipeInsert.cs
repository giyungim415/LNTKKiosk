﻿using LNTKKiosk.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LNTKManager
{
    public partial class RecipeInsert : Form
    {
        public RecipeInsert()
        {
            InitializeComponent();
        }

        private Recipe _recipe = new Recipe();

        private void WriteToEntity()
        {
            _recipe.ProductId = (int)cbbProductId.SelectedValue;
            _recipe.GroceryId = (int)cbbGroceryId.SelectedValue;

            try
            {
                _recipe.Amount = int.Parse(txeAmount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txeAmount.Text == "")
            {
                MessageBox.Show("수량을 입력해주세요");
                return;
            }

            WriteToEntity();

            if (_recipe.Amount == 0)
                return;
            try
            {
                DataRepository.Recipe.Insert(_recipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("등록되었습니다.");
            Close();
        }

        private void RecipeInsert_Load(object sender, EventArgs e)
        {

            cbbProductId.DataSource = DataRepository.Product.GetAllPartial();
            cbbProductId.DisplayMember = "Name";
            cbbProductId.ValueMember = "ProductId";
            bdsGrocery.DataSource = DataRepository.Grocery.GetAll();
            
        }

        private void txeAmount_EditValueChanged(object sender, EventArgs e)
        {
            Helpers.InputConstraint.OnlyIntConstraint(txeAmount);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
