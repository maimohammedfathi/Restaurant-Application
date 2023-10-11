using VersionOfProject.Entity;

namespace VersionOfProject
{
    public partial class Login : Form
    {
        WFContext con;
        AdminDashbordForm dashbordForm;
        CasherForm Casher;
        public Login()
        {
            InitializeComponent();
            con = new WFContext();
            dashbordForm = new AdminDashbordForm();
            Casher = new CasherForm();
            txt_Password.UseSystemPasswordChar = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string Email = txt_Email.Text.ToLower();
            string PassWord = txt_Password.Text;


            Check(Email, PassWord);


        }
        public bool Check(string Email, string Password)
        {
            try
            {

                if (Email == null || Email == string.Empty)
                {
                    MessageBox.Show($"email required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Password == null || Password == string.Empty)
                {
                    MessageBox.Show($"Password required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                if (con.Users.ToList().SingleOrDefault(u => u.Email.ToLower() == Email) == null)
                {
                    MessageBox.Show($" please enter correct email ".ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }


                var result = con.Users.
                SingleOrDefault(u => u.Email.ToLower() == Email && u.Password == Password);

                

                if (result.Id == 1)
                {

                    dashbordForm.ShowDialog();
                    txt_Email.Text = "";
                    txt_Password.Text = "";
                    return true;
                }
                else
                {
                    Casher.ShowDialog();
                    txt_Email.Text = "";
                    txt_Password.Text = "";
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }



            return false;
        }

        private void CheckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckShowPassword.Checked == false)
            {
                txt_Password.UseSystemPasswordChar = true;

            }
            else
            {
                txt_Password.UseSystemPasswordChar = false;

            }
        }
    }
}