using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewClientWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "http://localhost:58535" };
            using (var connection = factory.CreateConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    string cola = DropDownList1.SelectedItem.ToString();
                    chanel.QueueDeclare(cola, false, false, false, null);
                    string message = TextBox1.Text;
                    var body = Encoding.UTF8.GetBytes(message);
                    chanel.BasicPublish("",cola,null,body);
                }
            }
        }
    }
}