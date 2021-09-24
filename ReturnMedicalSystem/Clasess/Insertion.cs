using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReturnMedicalSystem.Clasess
{
    class Insertion
    {
        //DB sp = new DB();
      
      

        public void insertproduct(string name,string batch,string qty,string pin,string pout, string dis, DateTime dt, string barcode, string location)
        {
            //string value convert to decimal
            decimal quantity = (string.IsNullOrEmpty(qty)) ? 0 : Convert.ToDecimal(qty);
            decimal pricein = (string.IsNullOrEmpty(pin)) ? 0 : Convert.ToDecimal(pin);
            decimal priceout = (string.IsNullOrEmpty(pout)) ? 0 : Convert.ToDecimal(pout);
            decimal discount = (string.IsNullOrEmpty(dis)) ? 0 : Convert.ToDecimal(dis);
            try
            {
                //product insert opration

                SqlCommand cmd = new SqlCommand("stp_Product", DB.con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@batch", batch);
                cmd.Parameters.AddWithValue("@quantity",quantity);
                cmd.Parameters.AddWithValue("@priceIn",pricein);
                cmd.Parameters.AddWithValue("@priceOut",priceout);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dt).ToShortDateString());
                cmd.Parameters.AddWithValue("@barcode",barcode);
                cmd.Parameters.AddWithValue("@location", location);
                DB.con.Open();
                cmd.ExecuteNonQuery();
                DB.con.Close();
                MessageBox.Show("Data Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception e)
			{
                MessageBox.Show(e.ToString());
            }
            finally
            {
                DB.con.Close();
            }
                
        }
    }
}

