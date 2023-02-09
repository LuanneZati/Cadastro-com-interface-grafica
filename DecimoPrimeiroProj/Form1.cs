using ClassLibrary1;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Threading;

namespace DecimoPrimeiroProj
{
    public partial class Form1 : Form
    {
        List<PersonRecord> UserList = new List<PersonRecord>();
        GraphicInterface graphicInterface = new GraphicInterface();
        static Thread t1;
        public Form1()
        {
            InitializeComponent();
            graphicInterface.LoadData(ref UserList);
            t1 = new Thread(new ThreadStart(success));
        }
        private void clearTextBox()
        {
            textBoxName.Text = "";
            textBoxAge.Text = "";
            textBoxId.Text = "";
            textBoxBirth.Text = "";
        }
        private void clearLabel()
        {
            labelName.Text = "-";
            labelAge.Text = "-";
            labelBirth.Text = "-";
            labelResult.ForeColor = Color.Red;
        }
        private void notFound()
        {
            labelResult.Text = "Record not found!";
        }
        private void success()
        {
            if(labelResult1.InvokeRequired)
            {
                labelResult1.Invoke((MethodInvoker)(()=> success()));
            }
            else
            {
                labelResult1.Text = "Success!";
                labelResult1.ForeColor = Color.Green;
                Thread.Sleep(5000);
                labelResult1.Text = "";
            }
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                PersonRecord record = new PersonRecord(textBoxName.Text, Convert.ToInt32(textBoxAge.Text), textBoxId.Text, Convert.ToDateTime(textBoxBirth.Text));
                UserList.Add(record);
                GraphicInterface.StoreData(UserList);
                labelResult1.Text = "Success!";
                labelResult1.ForeColor = Color.Green;
                clearTextBox();
            }
            catch (Exception)
            {
                labelResult1.Text = "Error!";
                labelResult1.ForeColor = Color.Red;
                clearTextBox();
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (File.Exists(GraphicInterface.Path))
            {
                string auxId = textBoxIdSearch.Text;
                for (int i = UserList.Count - 1; i >= 0; i--)
                {
                    if (UserList[i].Id.ToUpper() == auxId.ToUpper())
                    {
                        labelName.Text = UserList[i].Name;
                        labelAge.Text = Convert.ToString(UserList[i].Age);
                        labelBirth.Text = Convert.ToString(UserList[i].Birth);
                        labelResult.Text = "";
                        count++;
                    }
                }
                if (count == 0)
                {
                    notFound();
                    clearLabel();
                }
            }
            else
            {
                notFound();
                clearLabel();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (File.Exists(GraphicInterface.Path))
            {
                string auxId = textBoxIdSearch.Text;
                for (int i = UserList.Count - 1; i >= 0; i--)
                {
                    if (UserList[i].Id.ToUpper() == auxId.ToUpper())
                    {
                        UserList.RemoveAt(i);
                        count++;
                    }
                }
                if (count == 0)
                {
                    notFound();
                    clearLabel();
                }
                else
                {
                    File.Delete(GraphicInterface.Path);
                    GraphicInterface.UploadData(UserList);
                    labelResult.Text = "Deleted!";
                    clearLabel();
                    count = 0;
                }
            }
            else
            {
                notFound();
                clearLabel();
            }
        }
    }
    
}