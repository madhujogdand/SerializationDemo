using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
          
            try
            {
                Student stud = new Student();
                stud.Id=Convert.ToInt32(txtId.Text);
                stud.Name=txtName.Text;
                stud.Percentage=Convert.ToDouble(txtPercentage.Text);
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studBinary.dat",FileMode.Create,FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, stud);
                fs.Close();
                MessageBox.Show("Record Added");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studBinary.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                stud=(Student)bf.Deserialize(fs);
                fs.Close ();
                txtId.Text=stud.Id.ToString();
                txtName.Text=stud.Name;
                txtPercentage.Text=stud.Percentage.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.Id = Convert.ToInt32(txtId.Text);
                stud.Name = txtName.Text;
                stud.Percentage = Convert.ToDouble(txtPercentage.Text);
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studXML.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xs= new XmlSerializer(typeof(Student));
                xs.Serialize(fs, stud);
                fs.Close();
                MessageBox.Show("Record Added");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studXML.xml", FileMode.Open, FileAccess.Read);
               XmlSerializer xs=new XmlSerializer(typeof(Student));
                stud = (Student)xs.Deserialize(fs);
                fs.Close();
                txtId.Text = stud.Id.ToString();
                txtName.Text = stud.Name;
                txtPercentage.Text = stud.Percentage.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.Id = Convert.ToInt32(txtId.Text);
                stud.Name = txtName.Text;
                stud.Percentage = Convert.ToDouble(txtPercentage.Text);
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studSOAP.soap", FileMode.Create, FileAccess.Write);
              SoapFormatter sf=new SoapFormatter();
                sf.Serialize(fs, stud);
                fs.Close();
                MessageBox.Show("Record Added");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studSOAP.soap", FileMode.Open, FileAccess.Read);
               SoapFormatter sf=new SoapFormatter();
                stud = (Student)sf.Deserialize(fs);
                fs.Close();
                txtId.Text = stud.Id.ToString();
                txtName.Text = stud.Name;
                txtPercentage.Text = stud.Percentage.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.Id = Convert.ToInt32(txtId.Text);
                stud.Name = txtName.Text;
                stud.Percentage = Convert.ToDouble(txtPercentage.Text);
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studJSON.json", FileMode.Create, FileAccess.Write);
               JsonSerializer.Serialize<Student>(fs, stud);
                fs.Close();
                MessageBox.Show("Record Added");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                FileStream fs = new FileStream(@"D:\.NET\Serialization\studJSON.json", FileMode.Open, FileAccess.Read);
                stud=JsonSerializer.Deserialize<Student>(fs);
                fs.Close();
                txtId.Text = stud.Id.ToString();
                txtName.Text = stud.Name;
                txtPercentage.Text = stud.Percentage.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
