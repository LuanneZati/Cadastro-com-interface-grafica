using ClassLibrary1;
using System.IO;

namespace DecimoPrimeiroProj
{
    public partial class Form1 : Form
    {
        List<PersonRecord> UserList = new List<PersonRecord>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            PersonRecord record = new PersonRecord(textBoxName.Text, Convert.ToInt32(textBoxAge.Text), textBoxId.Text, Convert.ToDateTime(textBoxBirth.Text));
            UserList.Add(record);
            GraphicInterface.StoreData(UserList);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (File.Exists(GraphicInterface.Path))
            {
                
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}