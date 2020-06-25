using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labproject
{
    public partial class Add_UC : UserControl
    {
        public Add_UC()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Green;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Red;

            cmb_item.Items.Clear();
            cmb_item.Items.Add("Kokorec");
            cmb_item.Items.Add("Kumpir");
            cmb_item.Items.Add("Doner Kebab");
            cmb_item.Items.Add("Sis Kebab");
            cmb_item.Items.Add("Midye");
            cmb_item.Items.Add("Pide");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Green;
            radioButton3.ForeColor = System.Drawing.Color.Red;

            cmb_item.Items.Clear();
            cmb_item.Items.Add("Tea");
            cmb_item.Items.Add("Coffee");
            cmb_item.Items.Add("Raki");
            cmb_item.Items.Add("Ayran");
            cmb_item.Items.Add("Boza");
            cmb_item.Items.Add("Selgam Suyu");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Green;

            cmb_item.Items.Clear();
            cmb_item.Items.Add("Baklava");
            cmb_item.Items.Add("Kunefe");
            cmb_item.Items.Add("Lokma");
            cmb_item.Items.Add("Firinda");
            cmb_item.Items.Add("Asure");
            cmb_item.Items.Add("Kazabindi");
        }

        private void cmb_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_item.SelectedItem.ToString() == "Kokorec")
            {
                txt_price.Text = "750";
            }
            else if(cmb_item.SelectedItem.ToString() == "Kumpir")
            {
                txt_price.Text = "450";
            }
            else if(cmb_item.SelectedItem.ToString() == "Doner Kebab")
            {
                txt_price.Text = "350";
            }
            else if (cmb_item.SelectedItem.ToString() == "Sis Kebab")
            {
                txt_price.Text = "1000";
            }
            else if (cmb_item.SelectedItem.ToString() == "Midye")
            {
                txt_price.Text = "500";
            }
            else if (cmb_item.SelectedItem.ToString() == "Pide")
            {
                txt_price.Text = "800";
            }
            else if (cmb_item.SelectedItem.ToString() == "Tea")
            {
                txt_price.Text = "100";
            }
            else if (cmb_item.SelectedItem.ToString() == "Coffee")
            {
                txt_price.Text = "150";
            }
            else if (cmb_item.SelectedItem.ToString() == "Boza")
            {
                txt_price.Text = "200";
            }
            else if (cmb_item.SelectedItem.ToString() == "Raki")
            {
                txt_price.Text = "300";
            }
            else if (cmb_item.SelectedItem.ToString() == "Ayran")
            {
                txt_price.Text = "150";
            }
            else if (cmb_item.SelectedItem.ToString() == "Salgam Suyu")
            {
                txt_price.Text = "300";
            }
            else if (cmb_item.SelectedItem.ToString() == "Baklava")
            {
                txt_price.Text = "200";
            }
            else if (cmb_item.SelectedItem.ToString() == "Kunefe")
            {
                txt_price.Text = "300";
            }
            else if (cmb_item.SelectedItem.ToString() == "Lokma")
            {
                txt_price.Text = "170";
            }
            else if (cmb_item.SelectedItem.ToString() == "Firinda")
            {
                txt_price.Text = "200";
            }
            else if (cmb_item.SelectedItem.ToString() == "Asure")
            {
                txt_price.Text = "150";
            }
            else if (cmb_item.SelectedItem.ToString() == "Kazabindi")
            {
                txt_price.Text = "250";
            }
            else 
            {
                txt_price.Text = "0";
            }
            txt_total.Text = "";
            txt_quantity.Text = "";
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_quantity.Text.Length > 0)
            {
                txt_total.Text = (Convert.ToInt16(txt_price.Text) * Convert.ToInt16(txt_quantity.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] = cmb_item.SelectedItem.ToString();
            arr[1] = txt_price.Text;
            arr[2] = txt_quantity.Text;
            arr[3] = txt_total.Text;

            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);

            txt_sub.Text = (Convert.ToInt16(txt_sub.Text) + Convert.ToInt16(txt_total.Text)).ToString();





        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            if(txt_discount.Text.Length > 0)
            {
                txt_net.Text = (Convert.ToInt16(txt_sub.Text) - Convert.ToInt16(txt_discount.Text)).ToString();
            }
        }

        private void txt_paid_TextChanged(object sender, EventArgs e)
        {
            if (txt_paid.Text.Length > 0)
            {
                txt_balance.Text = (Convert.ToInt16(txt_net.Text) - Convert.ToInt16(txt_paid.Text)).ToString();
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                try
                {
                    string ConnectionString = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=cafe; Data Source=DESKTOP-AJVVOOM";
                    SqlConnection connection = new SqlConnection(ConnectionString);
                    SqlCommand command = connection.CreateCommand();

                    connection.Open();
                    command.CommandText = "Insert into Test_Invoice_Master (InvoiceDate, Sub_Total, Discount, Net_Amount, Paid_Amount) values " + 
                        " ( getdate() , " + txt_sub.Text + " ," + txt_discount.Text + " , " + txt_net.Text + ", " + txt_paid.Text + ") select scope_identity() ";
                    string InvoiceID = command.ExecuteScalar().ToString();

                    foreach (ListViewItem ListItem in listView1.Items)
                    {
                        command.CommandText = "Insert into Test_Invoice_Detail (MasterID, ItemName, ItemPrice, ItemQuantity, ItemTotal) values  " + 
                            " ('" + InvoiceID + "', '" + ListItem.SubItems[0].Text + "', '" + ListItem.SubItems[1].Text + "', '" + ListItem.SubItems[2].Text + "' , " + ListItem.SubItems[3].Text + ")";
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("Sale Created Succesfully, with Invoice # " + InvoiceID);
                }
                catch (Exception )
                {
                    MessageBox.Show("Sale Not created,Error");
                }




            }
            else
            {
                MessageBox.Show("Must Add an Item in the List");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
